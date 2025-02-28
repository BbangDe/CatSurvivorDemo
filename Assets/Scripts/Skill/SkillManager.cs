using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // 전체 스킬 리스트
    [SerializeField]
    List<SkillControl> skillList;

    // 현재 보유 스킬 리스트
    List<int> mySkillList = new List<int>();
    
    // 스킬 오브젝트들을 꺼내올 오브젝트 풀
    Dictionary<int, List<SkillBase>> skillPool = new Dictionary<int, List<SkillBase>>();

    // 코루틴에서 사용할 시간데이터 캐싱
    WaitForSeconds delay_1f;
    WaitForSeconds delay_0_1f;

    private void Start()
    {
        // 스킬별 오브젝트풀 초기화
        for(int i=0; i<skillList.Count; i++)
        {
            skillPool.Add(i, new List<SkillBase>());
        }

        // 보유스킬 추가
        for (int i = 0; i < skillList.Count; i++)
        {
            AddSkill(i);
        }

        // 시간데이터 초기화
        delay_1f = new WaitForSeconds(1f);
        delay_0_1f = new WaitForSeconds(0.1f);
    }

    void AddSkill(int idx)
    {
        // 보유스킬에 스킬 추가
        mySkillList.Add(idx);
        // 쿨타임마다 스킬이 사용되도록 코루틴 실행
        StartCoroutine(SkillFire(idx));
    }

    // 풀에서 스킬 오브젝트 가져오는 함수
    SkillBase GetPool(int num)
    {
        // 적 오브젝트 번호의 풀에서 비활성화로 저장되어있는 오브젝트가 있으면
        for (int i = 0; i < skillPool[num].Count; i++)
        {
            // 해당 오브젝트를 리턴
            if (!skillPool[num][i].gameObject.activeSelf)
            {
                return skillPool[num][i];
            }
        }

        // 모든 오브젝트가 활성화 상태면 새로 생성해서 풀에 추가 후 리턴
        SkillBase newSkill = Instantiate(skillList[num].GetSkillBase());
        newSkill.gameObject.SetActive(false);
        skillPool[num].Add(newSkill);
        return newSkill;
    }

    IEnumerator SkillFire(int idx)
    {
        while(true)
        {
            // 스킬 쿨타임 대기
            for (int i = 0; i < skillList[idx].GetCoolDown(); i++)
            {
                yield return delay_1f;
            }

            for (int i=0; i < skillList[idx].GetCount(); i++)
            {
                SkillBase newSkill = GetPool(idx);
                newSkill.speed = skillList[idx].GetSpeed();
                newSkill.lifeTime = skillList[idx].GetLifeTime();
                newSkill.gameObject.SetActive(true);

                // 1사이클 내 스킬들 사이 텀만큼 대기
                for (int j = 0; j < skillList[idx].GetTerm() * 10; j++)
                {
                    yield return delay_0_1f;
                }
            }
        }
    }
}

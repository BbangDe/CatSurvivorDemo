using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // ��ü ��ų ����Ʈ
    [SerializeField]
    List<SkillControl> skillList;

    // ���� ���� ��ų ����Ʈ
    List<int> mySkillList = new List<int>();
    
    // ��ų ������Ʈ���� ������ ������Ʈ Ǯ
    Dictionary<int, List<SkillBase>> skillPool = new Dictionary<int, List<SkillBase>>();

    // �ڷ�ƾ���� ����� �ð������� ĳ��
    WaitForSeconds delay_1f;
    WaitForSeconds delay_0_1f;

    private void Start()
    {
        // ��ų�� ������ƮǮ �ʱ�ȭ
        for(int i=0; i<skillList.Count; i++)
        {
            skillPool.Add(i, new List<SkillBase>());
        }

        // ������ų �߰�
        for (int i = 0; i < skillList.Count; i++)
        {
            AddSkill(i);
        }

        // �ð������� �ʱ�ȭ
        delay_1f = new WaitForSeconds(1f);
        delay_0_1f = new WaitForSeconds(0.1f);
    }

    void AddSkill(int idx)
    {
        // ������ų�� ��ų �߰�
        mySkillList.Add(idx);
        // ��Ÿ�Ӹ��� ��ų�� ���ǵ��� �ڷ�ƾ ����
        StartCoroutine(SkillFire(idx));
    }

    // Ǯ���� ��ų ������Ʈ �������� �Լ�
    SkillBase GetPool(int num)
    {
        // �� ������Ʈ ��ȣ�� Ǯ���� ��Ȱ��ȭ�� ����Ǿ��ִ� ������Ʈ�� ������
        for (int i = 0; i < skillPool[num].Count; i++)
        {
            // �ش� ������Ʈ�� ����
            if (!skillPool[num][i].gameObject.activeSelf)
            {
                return skillPool[num][i];
            }
        }

        // ��� ������Ʈ�� Ȱ��ȭ ���¸� ���� �����ؼ� Ǯ�� �߰� �� ����
        SkillBase newSkill = Instantiate(skillList[num].GetSkillBase());
        newSkill.gameObject.SetActive(false);
        skillPool[num].Add(newSkill);
        return newSkill;
    }

    IEnumerator SkillFire(int idx)
    {
        while(true)
        {
            // ��ų ��Ÿ�� ���
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

                // 1����Ŭ �� ��ų�� ���� �Ҹ�ŭ ���
                for (int j = 0; j < skillList[idx].GetTerm() * 10; j++)
                {
                    yield return delay_0_1f;
                }
            }
        }
    }
}

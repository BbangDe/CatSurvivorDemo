using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class EnemyManager : MonoBehaviour
{
    // 적 몬스터 스폰 쿨타임
    [SerializeField]
    int spawnCoolDown;

    [SerializeField]
    int spawnDiff;

    // 본 게임은 서버에서 데이터를 받아서 사용
    // 데모에서는 코드상에 데이터를 넣어서 사용

    // 소환될 적 목록
    [SerializeField]
    List<EnemyControl> enemyControlList;

    // 소환될 적의 스피드 값 목록
    [SerializeField]
    List<float> enemySpeedList;

    // 소환될 적의 공격력 값 목록
    [SerializeField]
    List<float> enemyAttackList;

    // 소환될 적의 HP 값 목록
    [SerializeField]
    List<float> enemyHPList;

    // 오브젝트 풀에 사용할 적 오브젝트 풀
    Dictionary<int, List<EnemyControl>> enemyPool = new Dictionary<int, List<EnemyControl>>();

    private void Start()
    {
        // 오브젝트 풀 초기화
        for(int i=0; i<enemyControlList.Count; i++)
        {
            enemyPool.Add(i, new List<EnemyControl>());
        }

        // 몬스터 스폰 코루틴 실행
        StartCoroutine(Spawn());
    }


    // 풀에서 적 오브젝트 가져오는 함수
    EnemyControl GetPool(int num)
    {
        // 적 오브젝트 번호의 풀에서 비활성화로 저장되어있는 오브젝트가 있으면
        for(int i=0; i < enemyPool[num].Count; i++)
        {
            // 해당 오브젝트를 리턴
            if(!enemyPool[num][i].gameObject.activeSelf)
            {
                return enemyPool[num][i];
            }
        }

        // 모든 오브젝트가 활성화 상태면 새로 생성해서 풀에 추가 후 리턴
        EnemyControl newEnemy = Instantiate(enemyControlList[num], transform);
        newEnemy.gameObject.SetActive(false);
        enemyPool[num].Add(newEnemy);
        return newEnemy;
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            // 몬스터들을 시간마다 소환
            for(int i=0; i < enemyControlList.Count; i++)
            {
                for(int j=0; j<10; j++)
                {
                    // 풀에서 적 오브젝트 꺼내기
                    EnemyControl newEnemy = GetPool(i);
                    
                    // 플레이어와 일정거리 떨어진 곳에 랜덤하게 소환
                    int rand = Random.Range(0, 8);
                    switch(rand)
                    {
                        case 0:
                            newEnemy.transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.up * spawnDiff;
                            break;
                        case 1:
                            newEnemy.transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.down * spawnDiff;
                            break;
                        case 2:
                            newEnemy.transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.right * spawnDiff;
                            break;
                        case 3:
                            newEnemy.transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.left * spawnDiff;
                            break;
                        case 4:
                            newEnemy.transform.position = StageManager.instance.GetPlayerTransform().position + (Vector3.up * spawnDiff) + (Vector3.right * spawnDiff);
                            break;
                        case 5:
                            newEnemy.transform.position = StageManager.instance.GetPlayerTransform().position + (Vector3.up * spawnDiff) + (Vector3.left * spawnDiff);
                            break;
                        case 6:
                            newEnemy.transform.position = StageManager.instance.GetPlayerTransform().position + (Vector3.down * spawnDiff) + (Vector3.right * spawnDiff);
                            break;
                        case 7:
                            newEnemy.transform.position = StageManager.instance.GetPlayerTransform().position + (Vector3.down * spawnDiff) + (Vector3.left * spawnDiff);
                            break;
                        default:
                            newEnemy.transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.up * spawnDiff;
                            break;
                    }

                    // 적 스탯을 설정 후 활성화
                    newEnemy.SetStat(enemySpeedList[i], enemyAttackList[i], enemyHPList[i]);
                    newEnemy.gameObject.SetActive(true);
                }
            }
            
            yield return new WaitForSeconds(spawnCoolDown);
        }
    }
}

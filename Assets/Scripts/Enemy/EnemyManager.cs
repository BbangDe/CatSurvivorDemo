using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class EnemyManager : MonoBehaviour
{
    // �� ���� ���� ��Ÿ��
    [SerializeField]
    int spawnCoolDown;

    [SerializeField]
    int spawnDiff;

    // �� ������ �������� �����͸� �޾Ƽ� ���
    // ���𿡼��� �ڵ�� �����͸� �־ ���

    // ��ȯ�� �� ���
    [SerializeField]
    List<EnemyControl> enemyControlList;

    // ��ȯ�� ���� ���ǵ� �� ���
    [SerializeField]
    List<float> enemySpeedList;

    // ��ȯ�� ���� ���ݷ� �� ���
    [SerializeField]
    List<float> enemyAttackList;

    // ��ȯ�� ���� HP �� ���
    [SerializeField]
    List<float> enemyHPList;

    // ������Ʈ Ǯ�� ����� �� ������Ʈ Ǯ
    Dictionary<int, List<EnemyControl>> enemyPool = new Dictionary<int, List<EnemyControl>>();

    private void Start()
    {
        // ������Ʈ Ǯ �ʱ�ȭ
        for(int i=0; i<enemyControlList.Count; i++)
        {
            enemyPool.Add(i, new List<EnemyControl>());
        }

        // ���� ���� �ڷ�ƾ ����
        StartCoroutine(Spawn());
    }


    // Ǯ���� �� ������Ʈ �������� �Լ�
    EnemyControl GetPool(int num)
    {
        // �� ������Ʈ ��ȣ�� Ǯ���� ��Ȱ��ȭ�� ����Ǿ��ִ� ������Ʈ�� ������
        for(int i=0; i < enemyPool[num].Count; i++)
        {
            // �ش� ������Ʈ�� ����
            if(!enemyPool[num][i].gameObject.activeSelf)
            {
                return enemyPool[num][i];
            }
        }

        // ��� ������Ʈ�� Ȱ��ȭ ���¸� ���� �����ؼ� Ǯ�� �߰� �� ����
        EnemyControl newEnemy = Instantiate(enemyControlList[num], transform);
        newEnemy.gameObject.SetActive(false);
        enemyPool[num].Add(newEnemy);
        return newEnemy;
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            // ���͵��� �ð����� ��ȯ
            for(int i=0; i < enemyControlList.Count; i++)
            {
                for(int j=0; j<10; j++)
                {
                    // Ǯ���� �� ������Ʈ ������
                    EnemyControl newEnemy = GetPool(i);
                    
                    // �÷��̾�� �����Ÿ� ������ ���� �����ϰ� ��ȯ
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

                    // �� ������ ���� �� Ȱ��ȭ
                    newEnemy.SetStat(enemySpeedList[i], enemyAttackList[i], enemyHPList[i]);
                    newEnemy.gameObject.SetActive(true);
                }
            }
            
            yield return new WaitForSeconds(spawnCoolDown);
        }
    }
}

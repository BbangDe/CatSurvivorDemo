using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Spawn : SkillBase
{
    private void OnEnable()
    {
        // ���� �ð� �� ��ų�� ��������� ����
        StartCoroutine(Disappear());

        // �÷��̾� �ֺ� ������ ��ġ�� ��ȯ
        int rand = Random.Range(0, 8);
        int x_diff = Random.Range(1, 2);
        int y_diff = Random.Range(1, 2);

        switch (rand)
        {
            case 0:
                transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.up * y_diff;
                break;
            case 1:
                transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.down * y_diff;
                break;
            case 2:
                transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.right * x_diff;
                break;
            case 3:
                transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.left * x_diff;
                break;
            case 4:
                transform.position = StageManager.instance.GetPlayerTransform().position + (Vector3.up * y_diff) + (Vector3.right * x_diff);
                break;
            case 5:
                transform.position = StageManager.instance.GetPlayerTransform().position + (Vector3.up * y_diff) + (Vector3.left * x_diff);
                break;
            case 6:
                transform.position = StageManager.instance.GetPlayerTransform().position + (Vector3.down * y_diff) + (Vector3.right * x_diff);
                break;
            case 7:
                transform.position = StageManager.instance.GetPlayerTransform().position + (Vector3.down * y_diff) + (Vector3.left * x_diff);
                break;
            default:
                transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.up * y_diff;
                break;
        }

        transform.position += pivot;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Shield : SkillBase
{
    private void OnEnable()
    {
        // ���� �ð� �� ��ų�� ��������� ����
        StartCoroutine(Disappear());
    }

    private void Update()
    {
        // �ǵ�迭 ��ų�� ���������� �÷��̾ ����ٴϰ� ����
        transform.position = StageManager.instance.GetPlayerTransform().position + pivot;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Projectile : SkillBase
{
    [SerializeField]
    Rigidbody2D rb;

    Vector3 dir;

    private void OnEnable()
    {
        // ���� �ð� �� ��ų�� ��������� ����
        StartCoroutine(Disappear());

        // �߻�ü �ʱ���ġ ����
        transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.down * -1 + pivot;

        // �̵����� ������ ���� �߻�
        if(Input.GetKey(KeyCode.RightArrow))
        {
            dir.x = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir.x = -1;
        }
        else
        {
            dir.x = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir.y = -1;
        }
        else
        {
            dir.y = 0;
        }

        // ������ ���� ��� ���� �������� �߻�
        if(dir.x == 0 && dir.y == 0)
        {
            dir.y = 1;
        }
    }

    private void Update()
    {
        // ���������� �߻� �������� ����
        transform.position += dir * speed * Time.deltaTime;
    }
}

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
        // 일정 시간 후 스킬이 사라지도록 세팅
        StartCoroutine(Disappear());

        // 발사체 초기위치 세팅
        transform.position = StageManager.instance.GetPlayerTransform().position + Vector3.down * -1 + pivot;

        // 이동중인 방향을 향해 발사
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

        // 가만히 있을 경우 위쪽 방향으로 발사
        if(dir.x == 0 && dir.y == 0)
        {
            dir.y = 1;
        }
    }

    private void Update()
    {
        // 지속적으로 발사 방향으로 진행
        transform.position += dir * speed * Time.deltaTime;
    }
}

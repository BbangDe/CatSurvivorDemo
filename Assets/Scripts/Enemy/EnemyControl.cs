using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // 적 오브젝트의 리지드바디
    [SerializeField]
    Rigidbody2D rb;

    // 적 오브젝트의 스프라이트렌더러
    [SerializeField]
    SpriteRenderer spriteRenderer;

    // 적 오브젝트의 스탯 정보
    float speed;
    float attack;
    float nowHP;
    float maxHP;

    // 현재 살아 있는지 여부
    bool isDead;

    // 활성화 될 경우 살아있다는 표시로 isDead를 false로 설정
    private void OnEnable()
    {
        isDead = false;
    }

    private void Update()
    {
        // 살아 있는 상태일 경우
        if(!isDead)
        {
            // 플레이어와 적의 위치 차이를 통해 이동할 방향 벡터를 찾고 speed만큼 이동할 거리를 계산하여 물리이동
            Vector2 nextPos = (StageManager.instance.GetPlayerTransform().position + Vector3.down - rb.transform.position).normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.position + nextPos);

            // 스프라이트의 sortingOder를 y좌표 기준으로 1당 100으로 계산하여 2D상에서 z축 높이값을 표현
            spriteRenderer.sortingOrder = (int)(rb.transform.position.y * 100);
        }
    }

    // 적 몬스터의 스탯을 입력받아 설정
    public void SetStat(float speed, float attack, float HP)
    {
        this.speed = speed;
        this.attack = attack;
        nowHP = HP;
        maxHP = HP;
    }
}

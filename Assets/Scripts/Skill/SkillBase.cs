using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스킬들 베이스 코드
public class SkillBase : MonoBehaviour
{
    // 초기 위치를 조정해줄 위치값
    public Vector3 pivot;

    // 스킬 데이터
    public float speed;
    public float damage;
    public int lifeTime;

    // 일정 시간 후 스킬이 사라지도록 해주는 코루틴 정의
    public IEnumerator Disappear()
    {
        yield return new WaitForSeconds(lifeTime);

        gameObject.SetActive(false);
    }
}

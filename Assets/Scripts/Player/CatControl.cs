using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Weapon
{
    WarHammer, Chakram, WarAxe, Bow, Trident, MagicWand, Dagger
}

public class CatControl : MonoBehaviour
{
    // 고양이 캐릭터의 애니메이터
    [SerializeField]
    Animator animator;

    // 현재 장착중인 무기
    [SerializeField]
    Weapon weapon;

    // 무기 공격 가능한 상태
    bool canFire;

    // 걷는 중인 지
    bool isWalk;

    private void Start()
    {
        // 설정된 무기에 따른 무기 애니메이션 실행
        animator.SetTrigger(weapon.ToString());
        // 걷기 전이므로 걷기 상태는 false처리
        isWalk = false;
    }

    // 공격 가능한 상태 설정
    public void FireOk()
    {
        canFire = true;
    }

    // 걷이 모션 지정
    public void SetWalk()
    {
        // 걷는중이 아닐 경우에만 애니메이션 실행(중복실행 방지)
        if(!isWalk)
        {
            isWalk = true;
            animator.SetTrigger("Walk");
        }
    }

    // 걷기를 멈추게 하도록 지정
    public void SetStop()
    {
        // 걷는 중일 경우에만 애니메이션 실행(중복실행 방지)
        if(isWalk)
        {
            isWalk = false;
            animator.SetTrigger("Idle");
        }
    }
}

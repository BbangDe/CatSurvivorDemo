using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimationControl : MonoBehaviour
{
    // 고양이 제어 스크립트 연동
    [SerializeField]
    CatControl catControl;

    // 애니메이션 클립 함수로 사용
    public void SetPlayerFireOk()
    {
        catControl.FireOk();
    }
}

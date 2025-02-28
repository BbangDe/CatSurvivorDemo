using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region 시간제어
    [SerializeField]
    TextMeshProUGUI timeTxt;

    // 받아온 플레이 타임을 00:00 형태로 변형하여 세팅
    public void SetTimer(int time)
    {
        int minute = time / 60;
        int second = time % 60;

        timeTxt.text = string.Format("{0:D2}:{1:D2}", minute, second);
    }
    #endregion

    #region 경험치 제어
    // 경험치 제어 스크립트 연동
    [SerializeField]
    ExpControl expControl;

    // 경험치 세팅함수 호출
    public void SetExp(float nowExp, float maxExp)
    {
        expControl.SetExpGuage(nowExp, maxExp);
    }

    // 레벨 세팅함수 호출
    public void SetLevel(int lv)
    {
        expControl.SetLevel(lv);
    }
    #endregion

    #region 버튼액션
    // 일시정지 버튼 선택 시
    public void ClickPauseBtn()
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // 싱글톤 사용
    public static StageManager instance;

    #region 플레이어 매니저
    // 플레이어 관리 스크립트 연동
    [SerializeField]
    PlayerManager playerManager;

    // 플레이어의 Transform 리턴
    public Transform GetPlayerTransform()
    {
        return playerManager.transform;
    }
    #endregion

    #region UI 매니저
    // UI 관리 스크립트 연동
    [SerializeField]
    UIManager uiManager;

    // UI 데이터 설정(경험치 및 레벨 변경에 따른 UI변경)
    public void SetUI()
    {
        uiManager.SetExp(nowExp, maxExp);
        uiManager.SetLevel(lv);
    }

    // 시간 카운트 코루틴
    IEnumerator CountTime()
    {
        while (!isDead)
        {
            // 지정된 시간(1초) 단위로 시간 갱신
            yield return waitTime;
            playTime++;
            // 시간 세팅 함수로 UI반영
            uiManager.SetTimer(playTime);
        }
    }
    #endregion

    #region 스테이지 매니저
    // 게임 플레이 데이터
    int lv;
    float nowExp;
    float maxExp;
    int playTime;

    bool isDead;

    WaitForSeconds waitTime;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // 스테이지 초기화 및 초기 UI 세팅
        InitStage();
        SetUI();

        // 플레이 카운트 시작
        StartCoroutine(CountTime());
    }

    // 현재 플레이 타임 가져오는 함수
    public int GetPlayTime()
    {
        return playTime;
    }

    // 스테이지 값 초기화 단계
    public void InitStage()
    {
        nowExp = 0;
        maxExp = 10;
        lv = 1;

        isDead = false;

        playTime = 0;
        waitTime = new WaitForSeconds(1);
    }
    #endregion
}

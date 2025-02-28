using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // �̱��� ���
    public static StageManager instance;

    #region �÷��̾� �Ŵ���
    // �÷��̾� ���� ��ũ��Ʈ ����
    [SerializeField]
    PlayerManager playerManager;

    // �÷��̾��� Transform ����
    public Transform GetPlayerTransform()
    {
        return playerManager.transform;
    }
    #endregion

    #region UI �Ŵ���
    // UI ���� ��ũ��Ʈ ����
    [SerializeField]
    UIManager uiManager;

    // UI ������ ����(����ġ �� ���� ���濡 ���� UI����)
    public void SetUI()
    {
        uiManager.SetExp(nowExp, maxExp);
        uiManager.SetLevel(lv);
    }

    // �ð� ī��Ʈ �ڷ�ƾ
    IEnumerator CountTime()
    {
        while (!isDead)
        {
            // ������ �ð�(1��) ������ �ð� ����
            yield return waitTime;
            playTime++;
            // �ð� ���� �Լ��� UI�ݿ�
            uiManager.SetTimer(playTime);
        }
    }
    #endregion

    #region �������� �Ŵ���
    // ���� �÷��� ������
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
        // �������� �ʱ�ȭ �� �ʱ� UI ����
        InitStage();
        SetUI();

        // �÷��� ī��Ʈ ����
        StartCoroutine(CountTime());
    }

    // ���� �÷��� Ÿ�� �������� �Լ�
    public int GetPlayTime()
    {
        return playTime;
    }

    // �������� �� �ʱ�ȭ �ܰ�
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

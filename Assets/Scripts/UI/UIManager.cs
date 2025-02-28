using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region �ð�����
    [SerializeField]
    TextMeshProUGUI timeTxt;

    // �޾ƿ� �÷��� Ÿ���� 00:00 ���·� �����Ͽ� ����
    public void SetTimer(int time)
    {
        int minute = time / 60;
        int second = time % 60;

        timeTxt.text = string.Format("{0:D2}:{1:D2}", minute, second);
    }
    #endregion

    #region ����ġ ����
    // ����ġ ���� ��ũ��Ʈ ����
    [SerializeField]
    ExpControl expControl;

    // ����ġ �����Լ� ȣ��
    public void SetExp(float nowExp, float maxExp)
    {
        expControl.SetExpGuage(nowExp, maxExp);
    }

    // ���� �����Լ� ȣ��
    public void SetLevel(int lv)
    {
        expControl.SetLevel(lv);
    }
    #endregion

    #region ��ư�׼�
    // �Ͻ����� ��ư ���� ��
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

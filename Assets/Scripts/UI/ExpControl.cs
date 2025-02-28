using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpControl : MonoBehaviour
{
    // ����ġ ������ �̹���
    [SerializeField]
    Image fillImage;

    // ����ġ ������ �ִ� ����
    [SerializeField]
    float maxWidth;

    // ����ǥ�� �ؽ�Ʈ
    [SerializeField]
    TextMeshProUGUI levelTxt;

    private void Start()
    {
        // ����ġ ������ �ִ� ũ�⸦ �����صΰ� 0���� ����
        Vector2 size = fillImage.rectTransform.sizeDelta;
        maxWidth = size.x;
        size.x = 0f;
        fillImage.rectTransform.sizeDelta = size;

        // ������ 1�� �ʱ�ȭ
        levelTxt.text = "1";
    }

    // ����ġ ������ �����Լ�, ���� ����ġ�� �ִ� ����ġ�� �޾ƿ´�
    public void SetExpGuage(float nowExp, float maxExp)
    {
        // ����ġ ������ ����Ͽ�
        float fillAmount = nowExp / maxExp;

        // ����ġ ������ �ִ� ũ�⿡ ������ ���ؼ� ���� ���̸� ���Ͽ� ����
        Vector2 size = fillImage.rectTransform.sizeDelta;
        size.x = maxWidth * fillAmount;
        fillImage.rectTransform.sizeDelta = size;
    }

    // ���� ������ �޾ƿͼ� �ؽ�Ʈ�� ����
    public void SetLevel(int lv)
    {
        levelTxt.text = lv.ToString();
    }
}

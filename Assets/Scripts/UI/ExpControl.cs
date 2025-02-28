using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpControl : MonoBehaviour
{
    // 경험치 게이지 이미지
    [SerializeField]
    Image fillImage;

    // 경험치 게이지 최대 길이
    [SerializeField]
    float maxWidth;

    // 레벨표시 텍스트
    [SerializeField]
    TextMeshProUGUI levelTxt;

    private void Start()
    {
        // 경험치 게이지 최대 크기를 저장해두고 0으로 세팅
        Vector2 size = fillImage.rectTransform.sizeDelta;
        maxWidth = size.x;
        size.x = 0f;
        fillImage.rectTransform.sizeDelta = size;

        // 레벨은 1로 초기화
        levelTxt.text = "1";
    }

    // 경험치 게이지 세팅함수, 현재 경험치와 최대 경험치를 받아온다
    public void SetExpGuage(float nowExp, float maxExp)
    {
        // 경험치 비율을 계산하여
        float fillAmount = nowExp / maxExp;

        // 경험치 게이지 최대 크기에 비율을 곱해서 현재 길이를 구하여 지정
        Vector2 size = fillImage.rectTransform.sizeDelta;
        size.x = maxWidth * fillAmount;
        fillImage.rectTransform.sizeDelta = size;
    }

    // 현재 레벨을 받아와서 텍스트에 세팅
    public void SetLevel(int lv)
    {
        levelTxt.text = lv.ToString();
    }
}

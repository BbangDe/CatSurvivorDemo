using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimationControl : MonoBehaviour
{
    // ����� ���� ��ũ��Ʈ ����
    [SerializeField]
    CatControl catControl;

    // �ִϸ��̼� Ŭ�� �Լ��� ���
    public void SetPlayerFireOk()
    {
        catControl.FireOk();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Weapon
{
    WarHammer, Chakram, WarAxe, Bow, Trident, MagicWand, Dagger
}

public class CatControl : MonoBehaviour
{
    // ����� ĳ������ �ִϸ�����
    [SerializeField]
    Animator animator;

    // ���� �������� ����
    [SerializeField]
    Weapon weapon;

    // ���� ���� ������ ����
    bool canFire;

    // �ȴ� ���� ��
    bool isWalk;

    private void Start()
    {
        // ������ ���⿡ ���� ���� �ִϸ��̼� ����
        animator.SetTrigger(weapon.ToString());
        // �ȱ� ���̹Ƿ� �ȱ� ���´� falseó��
        isWalk = false;
    }

    // ���� ������ ���� ����
    public void FireOk()
    {
        canFire = true;
    }

    // ���� ��� ����
    public void SetWalk()
    {
        // �ȴ����� �ƴ� ��쿡�� �ִϸ��̼� ����(�ߺ����� ����)
        if(!isWalk)
        {
            isWalk = true;
            animator.SetTrigger("Walk");
        }
    }

    // �ȱ⸦ ���߰� �ϵ��� ����
    public void SetStop()
    {
        // �ȴ� ���� ��쿡�� �ִϸ��̼� ����(�ߺ����� ����)
        if(isWalk)
        {
            isWalk = false;
            animator.SetTrigger("Idle");
        }
    }
}

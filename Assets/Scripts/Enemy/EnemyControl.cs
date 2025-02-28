using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // �� ������Ʈ�� ������ٵ�
    [SerializeField]
    Rigidbody2D rb;

    // �� ������Ʈ�� ��������Ʈ������
    [SerializeField]
    SpriteRenderer spriteRenderer;

    // �� ������Ʈ�� ���� ����
    float speed;
    float attack;
    float nowHP;
    float maxHP;

    // ���� ��� �ִ��� ����
    bool isDead;

    // Ȱ��ȭ �� ��� ����ִٴ� ǥ�÷� isDead�� false�� ����
    private void OnEnable()
    {
        isDead = false;
    }

    private void Update()
    {
        // ��� �ִ� ������ ���
        if(!isDead)
        {
            // �÷��̾�� ���� ��ġ ���̸� ���� �̵��� ���� ���͸� ã�� speed��ŭ �̵��� �Ÿ��� ����Ͽ� �����̵�
            Vector2 nextPos = (StageManager.instance.GetPlayerTransform().position + Vector3.down - rb.transform.position).normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.position + nextPos);

            // ��������Ʈ�� sortingOder�� y��ǥ �������� 1�� 100���� ����Ͽ� 2D�󿡼� z�� ���̰��� ǥ��
            spriteRenderer.sortingOrder = (int)(rb.transform.position.y * 100);
        }
    }

    // �� ������ ������ �Է¹޾� ����
    public void SetStat(float speed, float attack, float HP)
    {
        this.speed = speed;
        this.attack = attack;
        nowHP = HP;
        maxHP = HP;
    }
}

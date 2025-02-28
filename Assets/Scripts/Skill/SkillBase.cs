using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ų�� ���̽� �ڵ�
public class SkillBase : MonoBehaviour
{
    // �ʱ� ��ġ�� �������� ��ġ��
    public Vector3 pivot;

    // ��ų ������
    public float speed;
    public float damage;
    public int lifeTime;

    // ���� �ð� �� ��ų�� ��������� ���ִ� �ڷ�ƾ ����
    public IEnumerator Disappear()
    {
        yield return new WaitForSeconds(lifeTime);

        gameObject.SetActive(false);
    }
}

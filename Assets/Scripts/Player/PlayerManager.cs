using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // �÷��̾ ����ٴ� ���� ī�޶�
    [SerializeField]
    Camera cam;

    // �÷��̾� �̵� �ӵ�
    [SerializeField]
    float speed;

    // �÷��̾� ������ ���� ȸ����
    [SerializeField]
    Vector3 rightRotate;
    // �÷��̾� ���� ���� ȸ����
    [SerializeField]
    Vector3 leftRotate;

    [SerializeField]
    CatControl catControl;

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        // ������ ����Ű ���� ��� ���������� �̵�, ������ �ٶ󺸰� ȸ��
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rightRotate);
            catControl.SetWalk();
        }

        // ���� ����Ű ���� ��� �������� �̵�, ���� �ٶ󺸰� ȸ��
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(leftRotate);
            catControl.SetWalk();
        }

        // ���� ����Ű ���� ��� �������� �̵�
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            catControl.SetWalk();
        }

        // �Ʒ��� ����Ű ���� ��� �Ʒ������� �̵�
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            catControl.SetWalk();
        }

        // ��� ����Ű�� ������ �ʰ� �ִ� ��� ���߱� �ִϸ��̼� ����
        if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) {
            catControl.SetStop();
        }

        // ī�޶� �÷��̾ ����ؼ� ����ٴϴٷ� ����
        Vector3 pos = cam.transform.position;
        pos.x = transform.position.x;
        pos.y = transform.position.y;
        cam.transform.position = pos;
    }
}

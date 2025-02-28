using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // 플레이어를 따라다닐 메인 카메라
    [SerializeField]
    Camera cam;

    // 플레이어 이동 속도
    [SerializeField]
    float speed;

    // 플레이어 오른쪽 방향 회전각
    [SerializeField]
    Vector3 rightRotate;
    // 플레이어 왼쪽 방향 회전각
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

        // 오른쪽 방향키 누를 경우 오른쪽으로 이동, 오른쪽 바라보게 회전
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rightRotate);
            catControl.SetWalk();
        }

        // 왼쪽 방향키 누를 경우 왼쪽으로 이동, 왼쪽 바라보게 회전
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(leftRotate);
            catControl.SetWalk();
        }

        // 위쪽 방향키 누를 경우 위쪽으로 이동
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            catControl.SetWalk();
        }

        // 아래쪽 방향키 누를 경우 아래쪽으로 이동
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            catControl.SetWalk();
        }

        // 모든 방향키를 누르지 않고 있는 경우 멈추기 애니메이션 실행
        if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) {
            catControl.SetStop();
        }

        // 카메라가 플레이어를 계속해서 따라다니다록 설정
        Vector3 pos = cam.transform.position;
        pos.x = transform.position.x;
        pos.y = transform.position.y;
        cam.transform.position = pos;
    }
}

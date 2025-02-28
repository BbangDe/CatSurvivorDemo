using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 맵 유형
 * InfinitySquare : 사방으로 무한히 펼쳐지는 맵인 경우
 * InfinityRow : 상하는 제한되어 있고 좌우로 무한히 펼쳐지는 맵인 경우
 * InfinityColumn : 좌우는 제한되어 있고 상하로 무한히 펼쳐지는 맵인 경우
 * LimitedSquare : 제한된 크기의 맵인 경우
 * 
 * 무한한 맵의 경우 오른쪽으로 이동시 제일 왼쪽의 타일들을 오른쪽 끝으로 이동시키면서 무한한 맵 구현
 * 위로 이동 시 제일 아래쪽의 타일들을 위쪽 끝으로 이동시키면서 무한한 맵 구현
 */
enum TileMode
{
    InfinitySquare, InfinityRow, InfinityColumn, LimitedSquare
}

/// <summary>
/// 타일맵 컨트롤 스크립트
/// </summary>
public class TileControl : MonoBehaviour
{
    // 현재 맵이 어떤 형태의 맵인지 체크
    [SerializeField]
    TileMode tileMode;

    /*
     * 전체 맵 블럭 리스트
     * InfinitySquare : 3*3 으로 9개의 블럭 존재
     * InfinityRow : 1*3 으로 3개의 블럭 존재
     * InfinityColumn : 3*1로 3개의 블럭 존재
     * LimitedSquare : 3*3으로 9개의 블럭 존재
    */
    [SerializeField]
    List<GameObject> tileBlocks1D = new List<GameObject>();

    // 맵 배치에 맞게 2차원 리스트에 맵 블럭을 저장할 리스트
    List<List<GameObject>> tileBlocks2D = new List<List<GameObject>>();

    //  타일의 크기
    [SerializeField]
    float sizeTile = 1.28f;
    //  파트당 한 변의 타일 개수
    [SerializeField]
    int countTile = 16;
    // 한 타일 셋 크기
    [SerializeField]
    float offset = 0f;

    // 가로, 세로 블럭 개수
    [SerializeField]
    int row_num = 0;
    [SerializeField]
    int col_num = 0;

    private void Start()
    {
        // 타일블럭 한 면의 크기 계산
        offset = sizeTile * countTile;

        for(int i=0; i<col_num; i++)
        {
            tileBlocks2D.Add(new List<GameObject>());
            for(int j=0; j<row_num; j++)
            {
                tileBlocks2D[i].Add(tileBlocks1D[0]);
                tileBlocks1D.RemoveAt(0);
            }
        }
    }

    private void Update()
    {
        MoveTileSet();
    }

    void MoveTileSet()
    {
        Transform playerTransform = StageManager.instance.GetPlayerTransform();
        Transform centerTransform = tileBlocks2D[col_num / 2][row_num / 2].transform;

        int dir_x = 0;
        int dir_y = 0;

        switch (tileMode)
        {
            case TileMode.InfinitySquare:
                // 현재 플레이어의 위치가 가운데 타일블럭 오른쪽 끝을 지난 상태이면 제일 왼쪽 타일들을 오른쪽 끝으로 이동
                if (playerTransform.position.x > (centerTransform.position.x + (offset / 2))) {
                    dir_x = -1;
                }
                // 현재 플레이어의 위치가 가운데 타일블럭 왼쪽 끝을 지난 상태이면 제일 오른쪽 타일들을 왼쪽 끝으로 이동
                else if (playerTransform.position.x < (centerTransform.position.x - (offset / 2)))
                {
                    dir_x = 1;
                }
                // 아직 가운데 타일 위에 있으면 좌우 방향 타일 이동은 0
                else
                {
                    dir_x = 0;
                }

                // 현재 플레이어의 위치가 가운데 타일블럭 위쪽 끝을 지난 상태이면 제일 아래쪽 타일들을 위쪽 끝으로 이동
                if (playerTransform.position.y > (centerTransform.position.y + (offset / 2)))
                {
                    dir_y = 1;
                }
                // 현재 플레이어의 위치가 가운데 타일블럭 아래쪽 끝을 지난 상태이면 제일 위쪽 타일들을 아래쪽 끝으로 이동
                else if (playerTransform.position.y < (centerTransform.position.y - (offset / 2)))
                {
                    dir_y = -1;
                }
                // 아직 가운데 타일 위에 있으면 상하 방향 타일 이동은 0
                else
                {
                    dir_y = 0;
                }
                break;
            case TileMode.InfinityRow:
                // 현재 플레이어의 위치가 가운데 타일블럭 오른쪽 끝을 지난 상태이면 제일 왼쪽 타일들을 오른쪽 끝으로 이동
                if (playerTransform.position.x > (centerTransform.position.x + (offset / 2)))
                {
                    dir_x = -1;
                }
                // 현재 플레이어의 위치가 가운데 타일블럭 왼쪽 끝을 지난 상태이면 제일 오른쪽 타일들을 왼쪽 끝으로 이동
                else if (playerTransform.position.x < (centerTransform.position.x - (offset / 2)))
                {
                    dir_x = 1;
                }
                // 아직 가운데 타일 위에 있으면 좌우 방향 타일 이동은 0
                else
                {
                    dir_x = 0;
                }

                dir_y = 0;
                break;
            case TileMode.InfinityColumn:
                // 현재 플레이어의 위치가 가운데 타일블럭 위쪽 끝을 지난 상태이면 제일 아래쪽 타일들을 위쪽 끝으로 이동
                if (playerTransform.position.y > (centerTransform.position.y + (offset / 2)))
                {
                    dir_y = 1;
                }
                // 현재 플레이어의 위치가 가운데 타일블럭 아래쪽 끝을 지난 상태이면 제일 위쪽 타일들을 아래쪽 끝으로 이동
                else if (playerTransform.position.y < (centerTransform.position.y - (offset / 2)))
                {
                    dir_y = -1;
                }
                // 아직 가운데 타일 위에 있으면 상하 방향 타일 이동은 0
                else
                {
                    dir_y = 0;
                }

                dir_x = 0;
                break;
            case TileMode.LimitedSquare:
                // 제한된 맵은 타일 이동 없이 고정
                dir_x = 0;
                dir_y = 0;
                break;
        }

        GameObject tmpTile;

        // dir_x가 0보다 크면 오른쪽 타일들을 왼쪽 끝으로 이동하고 나머지 타일은 배열내에서 오른쪽으로 1칸씩 이동
        if (dir_x > 0)
        {
            for(int i=0; i<col_num; i++)
            {
                tmpTile = tileBlocks2D[i][col_num - 1];
                for(int j=row_num-1; j>0; j--)
                {
                    tileBlocks2D[i][j] = tileBlocks2D[i][j - 1];
                }
                tileBlocks2D[i][0] = tmpTile;
                tileBlocks2D[i][0].transform.position += Vector3.left * (offset * 3);
            }
        }
        // dir_x가 0보다 작으면 왼쪽 타일들을 오른쪽 끝으로 이동하고 나머지 타일은 배열내에서 왼쪽으로 1칸씩 이동
        else if (dir_x < 0)
        {
            for (int i = 0; i < col_num; i++)
            {
                tmpTile = tileBlocks2D[i][0];
                for (int j = 0; j < row_num - 1; j++)
                {
                    tileBlocks2D[i][j] = tileBlocks2D[i][j + 1];
                }
                tileBlocks2D[i][row_num - 1] = tmpTile;
                tileBlocks2D[i][row_num - 1].transform.position += Vector3.right * (offset * 3);
            }
        }

        // dir_y가 0보다 크면 아래쪽 타일들을 위쪽 끝으로 이동하고 나머지 타일은 배열내에서 아래쪽으로 1칸씩 이동
        if (dir_y > 0)
        {
            for (int i = 0; i < row_num; i++)
            {
                tmpTile = tileBlocks2D[row_num - 1][i];
                for (int j = col_num - 1; j > 0; j--)
                {
                    tileBlocks2D[j][i] = tileBlocks2D[j - 1][i];
                }
                tileBlocks2D[0][i] = tmpTile;
                tileBlocks2D[0][i].transform.position += Vector3.up * (offset * 3);
            }
        }
        // dir_y가 0보다 작으면 위쪽 타일들을 아래쪽 끝으로 이동하고 나머지 타일은 배열내에서 위쪽으로 1칸씩 이동
        else if (dir_y < 0)
        {
            for (int i = 0; i < row_num; i++)
            {
                tmpTile = tileBlocks2D[0][i];
                for (int j = 0; j < col_num - 1; j++)
                {
                    tileBlocks2D[j][i] = tileBlocks2D[j + 1][i];
                }
                tileBlocks2D[row_num - 1][i] = tmpTile;
                tileBlocks2D[row_num - 1][i].transform.position += Vector3.down * (offset * 3);
            }
        }
    }
}
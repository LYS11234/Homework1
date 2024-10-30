using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Vector2Int GridSize;
    public Node[,] Grids;

    private void Start()
    {
        CreateGrid();
    }

    public void CreateGrid() //그리드 생성
    {
        Grids = new Node[GridSize.x, GridSize.y]; //그리드 크기 정의

        for(int x = 0; x < GridSize.x; x++)
        {
            for(int y = 0; y < GridSize.y; y++)
            {
                Vector2Int gridPos = new Vector2Int(x, y);
                int isObstruction = Random.Range(0, 10);
                bool isWalkable;
                if (isObstruction <= 0)
                {
                    isWalkable = false;
                }
                else
                {
                    isWalkable = true;
                }
                Grids[x, y] = new Node(gridPos, isWalkable);
            }
        }
    }

    public List<Node> NearbyNodes(Node node)
    {
        List<Node> nearNodes = new List<Node>();
        for (int x = -1; x <= 1; x++)
        {
            for(int y = -1; y <= 1; y++)
            {
                if(x == 0 && y == 0)
                {
                    continue;
                }

            }
        }


        return nearNodes;
    }
}

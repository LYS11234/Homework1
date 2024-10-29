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

    public void CreateGrid()
    {
        Grids = new Node[GridSize.x, GridSize.y];

        for(int x = 0; x < GridSize.x; x++)
        {
            for(int y = 0; y < GridSize.y; y++)
            {
                Vector2Int gridPos = new Vector2Int(x, y);
                bool isWalkable = true;
                Grids[x, y] = new Node(gridPos, isWalkable);
            }
        }
    }

    public List<Node> NearbyNodes(Node node)
    {
        List<Node> nearNodes = new List<Node>();

        return nearNodes;
    }
}

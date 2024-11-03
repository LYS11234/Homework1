using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Vector2Int GridSize;
    public GameObject[,] Grids;

    [SerializeField]
    private List<GameObject> emptyNodes = new List<GameObject>();
    [SerializeField]
    private List<GameObject> blockNodes = new List<GameObject>();
    [SerializeField]
    private List<GameObject> path = new List<GameObject>();
    [SerializeField]
    private List<GameObject> noWay = new List<GameObject>();

    [SerializeField]
    private Sprite sprite;

    private int movementCount;
    [SerializeField]
    private Camera cam;

    private void Start()
    {
        cam.transform.position = new Vector3(GridSize.x * 0.5f, GridSize.y * 0.5f - 0.5f, -10);
        cam.orthographicSize = GridSize.y * 0.5f;
        CreateGrid();
        path.Add(Grids[0, 0]);
        
    }

    private void Update()
    {
        CheckNearNodes();
    }

    public void CreateGrid() //그리드 생성
    {
        Grids = new GameObject[GridSize.x, GridSize.y]; //그리드 크기 정의

        for(int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y < GridSize.y; y++)
            {
                Vector2Int gridPos = new Vector2Int(x, y);
                int isObstruction = Random.Range(0, 20);
                Grids[x, y] = new GameObject();
                Grids[x, y].transform.position = new Vector2(x, y);
                Grids[x, y].AddComponent<SpriteRenderer>();
                Grids[x, y].GetComponent<SpriteRenderer>().sprite = sprite;
                if(x <= 0 && y <= 0)
                {
                    Grids[x, y].name = "StartPoint";
                    Grids[x, y].GetComponent<SpriteRenderer>().color = Color.blue;
                    continue;
                }

                if(x >= GridSize.x - 1 && y >= GridSize.y - 1)
                {
                    Grids[x, y].name = "EndPoint";
                    Grids[x, y].GetComponent<SpriteRenderer>().color = Color.yellow;
                    continue;
                }

                if (isObstruction > 2)
                {
                    continue;
                }
                Grids[x, y].AddComponent<BoxCollider2D>();
                Grids[x, y].GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
    public void CheckNearNodes()
    {
        if (path[movementCount].name == "EndPoint")
        {
            return;
        }

        if(path[movementCount].transform.position.x >= 1)
        {
            if(Grids[(int)path[movementCount].transform.position.x - 1, (int)path[movementCount].transform.position.y].TryGetComponent<BoxCollider2D>(out BoxCollider2D boxCollider))
            {
                blockNodes.Add(Grids[(int)path[movementCount].transform.position.x - 1, (int)path[movementCount].transform.position.y]);
            }
            else
            {
                emptyNodes.Add(Grids[(int)path[movementCount].transform.position.x - 1, (int)path[movementCount].transform.position.y]);
            }
        }
        if (path[movementCount].transform.position.x < GridSize.x - 1)
        {
            if (Grids[(int)path[movementCount].transform.position.x + 1, (int)path[movementCount].transform.position.y].TryGetComponent<BoxCollider2D>(out BoxCollider2D boxCollider))
            {
                blockNodes.Add(Grids[(int)path[movementCount].transform.position.x + 1, (int)path[movementCount].transform.position.y]);
            }
            else
            {
                emptyNodes.Add(Grids[(int)path[movementCount].transform.position.x + 1, (int)path[movementCount].transform.position.y]);
            }
        }
        if (path[movementCount].transform.position.y >= 1)
        {
            if (Grids[(int)path[movementCount].transform.position.x, (int)path[movementCount].transform.position.y - 1].TryGetComponent<BoxCollider2D>(out BoxCollider2D boxCollider))
            {
                blockNodes.Add(Grids[(int)path[movementCount].transform.position.x, (int)path[movementCount].transform.position.y - 1]);
            }
            else
            {
                emptyNodes.Add(Grids[(int)path[movementCount].transform.position.x, (int)path[movementCount].transform.position.y - 1]);
            }
        }
        if (path[movementCount].transform.position.y < GridSize.y - 1)
        {
            if (Grids[(int)path[movementCount].transform.position.x, (int)path[movementCount].transform.position.y + 1].TryGetComponent<BoxCollider2D>(out BoxCollider2D boxCollider))
            {
                blockNodes.Add(Grids[(int)path[movementCount].transform.position.x, (int)path[movementCount].transform.position.y + 1]);
            }
            else
            {
                emptyNodes.Add(Grids[(int)path[movementCount].transform.position.x, (int)path[movementCount].transform.position.y + 1]);
            }
        }
        AStarAlgorithm();
    }

    private void AStarAlgorithm()
    {
        float length = 99;
        int nextNode = 0;

        
        for(int i = 0; i < emptyNodes.Count; ++i)
        {
            if(noWay.Contains(emptyNodes[i]))
            {
                continue;
            }
            if(length > (emptyNodes[i].transform.position - Grids[GridSize.x - 1, GridSize.y - 1].transform.position).magnitude)
            {
                length = (emptyNodes[i].transform.position - Grids[GridSize.x - 1, GridSize.y - 1].transform.position).magnitude;
                nextNode = i;
            }
        }
        if (path.Contains(emptyNodes[nextNode]))
        {
            noWay.Add(emptyNodes[nextNode]);
            path.Remove(emptyNodes[nextNode]);
            emptyNodes[nextNode].GetComponent<SpriteRenderer>().color = Color.gray;
            movementCount--;
            
        }
        else
        {
            path.Add(emptyNodes[nextNode]);
            emptyNodes[nextNode].GetComponent<SpriteRenderer>().color = Color.black;
            movementCount++;
        }
        if (path[movementCount].name == "EndPoint")
        {
            path[movementCount].GetComponent<SpriteRenderer>().color = Color.yellow;
            for (int i = 1; i<path.Count - 1; i++)
            {
                path[i].name = i.ToString();
            }
            return;
        }
        
        
        emptyNodes.Clear();
        blockNodes.Clear();
    }


    public void QuadTree()
    {
        for (int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y < GridSize.y; y++)
            {

            }
        }
    }
}

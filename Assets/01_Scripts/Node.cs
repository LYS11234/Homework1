using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2Int NodePosition;
    public bool IsMovable;

    public Node ParentNode;

    public float GCost;
    public float HCost;
    public float FCost { get { return GCost + HCost; } }

    public Node(Vector2Int _nodePos,  bool _isMovable)
    {
        this.NodePosition = _nodePos;
        this.IsMovable = _isMovable;
    }
}

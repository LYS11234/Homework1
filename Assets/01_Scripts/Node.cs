using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour 
{
    public List<GameObject> EmptyNodes = new List<GameObject>();
    public List<GameObject> FilledNodes = new List<GameObject>();
    public List<GameObject> NearNodes = new List<GameObject>();
    private Grid grid;

    private void Start()
    {
        grid = GetComponentInParent<Grid>();
    }



    
}


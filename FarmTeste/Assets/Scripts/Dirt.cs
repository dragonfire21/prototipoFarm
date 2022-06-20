using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dirt : MonoBehaviour
{

    public bool takeSeed;
    [SerializeField] private TilemapCollider2D tile;
    // Start is called before the first frame update
    void Start()
    {
        tile = GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DesactiveAndActive();        
    }

    void DesactiveAndActive()
    {
        if (takeSeed)
        {
            tile.enabled = true;
        }
        else
        {
            tile.enabled = false;
        }
    }
}

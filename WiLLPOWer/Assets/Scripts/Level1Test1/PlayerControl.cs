using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
    private Vector3 currentPosition;
    [Header("Controls")]
    [SerializeField] private float inc;
    [SerializeField] private KeyCode keyup;
    [SerializeField] private KeyCode keydown;
    [SerializeField] private KeyCode keyright;
    [SerializeField] private KeyCode keyleft;

    [Header("PlayerPlacement")]
    private Grid gridLayout;
    [SerializeField] private string gridName;
    private Tilemap groundMap;
    [SerializeField] private string tilemapName;


    

    void Awake() 
    {
        currentPosition = transform.position;
        gridLayout = GameObject.Find(gridName).GetComponent<Grid>();
        groundMap = GameObject.Find(tilemapName).GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyup))
        {
            Debug.Log("going up");
            MoveUp();
        }
        if (Input.GetKeyDown(keydown))
        {
            Debug.Log("going down");
            MoveDown();
        }
        if (Input.GetKeyDown(keyleft))
        {
            Debug.Log("going left");
            MoveLeft();
        }
        if (Input.GetKeyDown(keyright))
        {
            Debug.Log("going right");
            MoveRight();
        }


    }



    private void MoveUp()
    {
        currentPosition = new Vector3(currentPosition.x + inc, currentPosition.y, currentPosition.z);
        // have to check the they are landing on a tile and that they land on the center
        CheckNCenter();
    }

    private void MoveDown()
    {
        currentPosition = new Vector3(currentPosition.x - inc, currentPosition.y, currentPosition.z);
        CheckNCenter();
    }

    private void MoveLeft()
    {
        currentPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + inc);
        CheckNCenter();
    }

    private void MoveRight()
    {
        currentPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - inc);
        CheckNCenter();
    }

    private void CheckNCenter()
    {
        Vector3 centerTile = transform.position;
        Vector3Int tileCellPos = gridLayout.WorldToCell(currentPosition);
        if (groundMap.HasTile(gridLayout.WorldToCell(currentPosition)))
        {
            centerTile = gridLayout.GetCellCenterWorld(tileCellPos);
            centerTile = new Vector3(centerTile.x, transform.position.y, centerTile.z);
        }
        currentPosition = centerTile;
        transform.position = currentPosition;

    }

    
}

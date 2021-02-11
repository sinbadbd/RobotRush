using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTiles : MonoBehaviour
{
    public GameObject[] tile;

    // start position of the tils
    public Vector3 tileStartPos;


    // tile spacing
    Vector2 tilesSpacing;

    // width of the grid;
    public int gridWidth;

    //height of the grid
    public int gridHeight;


    void Start()
    {
        // Get the exact size of our tiles
        tilesSpacing = tile[0].GetComponent<Renderer>().bounds.size;


        //loop the number of rows height
        for(int i =0; i < gridHeight; i++)
        {
            // loop the number of colums width
            for(int j=0; j < gridWidth; j++)
            {

                //
                int randomTile = Random.Range(0, tile.Length);

                GameObject go = Instantiate(tile[randomTile], new Vector3(tileStartPos.x + (j * tilesSpacing.x), tileStartPos.y + (i * tilesSpacing.y)), Quaternion.identity) as GameObject;


                go.transform.parent = GameObject.Find("BGTiles").transform;
                    
            }
        }
    }

}

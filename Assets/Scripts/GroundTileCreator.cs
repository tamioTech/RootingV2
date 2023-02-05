using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileCreator : MonoBehaviour
{
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject mineral;

    private int groundWidthMax = 10;
    private int groundDepthMax = 30;

    GameObject groundPiece;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < groundWidthMax; x++)
        {
            for (int y = 0; y < groundDepthMax; y++)
            {
                float xDir = x;
                float yDir = y;
                Vector3 dirtLocation = new Vector3(xDir, yDir, 0);
                Instantiate(SelectDirtType(), dirtLocation, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private GameObject SelectDirtType()
    {
        int dirtType = Mathf.Abs(Random.Range(0, 10));
        //print(dirtType);
        switch (dirtType)
        {
            case 0:
                groundPiece = ground;
                break;
            case 1:
                groundPiece = ground;
                break;
            case 2:
                groundPiece = ground;
                break;
            case 3:
                groundPiece = ground;
                break;
            case 4:
                groundPiece = ground;
                break;
            case 5:
                groundPiece = ground;
                break;
            case 6:
                groundPiece = ground;
                break;
            case 7:
                groundPiece = ground;
                break;
            case 8:
                groundPiece = mineral;
                break;
            case 9:
                groundPiece = rock;
                break;
        }
        return groundPiece;
    }

}

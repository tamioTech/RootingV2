using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDetection : MonoBehaviour
/* 
 * Detects collisions and sends data to RootMove script. 
 *  
 * Direction indexes:
 *  up      0
 *  down    1
 *  left    2
 *  right   3
 */
{
    public int direction = 0;

    private RootMove m_rootMove;
    private List<Collider> tiles;

    private void Awake()
    {
        m_rootMove = FindObjectOfType<RootMove>();
        tiles = new List<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Called for each object that enters the trigger
        if (direction == 0)  // Up
        {
            tiles.Add(other);                
            m_rootMove.tileUp = other;
        }
        else if (direction == 1)  // Down
        {
            tiles.Add(other);                
            m_rootMove.tileDown = other;
        }
        else if (direction == 2)  // Left
        {
            tiles.Add(other);                
            m_rootMove.tileLeft = other;
        }
        else if (direction == 3)  // Right
        {
            tiles.Add(other);                
            m_rootMove.tileRight = other;
        }
    }

    // Called each time an object exits the trigger
    private void OnTriggerExit(Collider other)
    {
        if (direction == 0)  // Up
        {
            tiles.Remove(other);
            if (tiles.Count < 1)
                m_rootMove.tileUp = null;
        }
        else if (direction == 1)  // Down
        {
            tiles.Remove(other);
            if (tiles.Count < 1)
                m_rootMove.tileDown = null;
        }
        else if (direction == 2)  // Left
        {
            tiles.Remove(other);
            if (tiles.Count < 1)
                m_rootMove.tileLeft = null;
        }
        else if (direction == 3)  // Right
        {
            tiles.Remove(other);
            if (tiles.Count < 1)
                m_rootMove.tileRight = null;
        }
    }
}

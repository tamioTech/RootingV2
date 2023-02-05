using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMove : MonoBehaviour
{
    public GameObject rootTip;
    public GameObject rootVertical;
    public GameObject rootHorizontal;
    public GameObject rootCornerRight;
    public GameObject rootCornerLeft;
    public GameObject rootCornerUpRight;
    public GameObject rootCornerUpLeft;
    public Transform rootCreatorTr;
    public Vector3 lastPos;

    public Collider tileUp;
    public Collider tileDown;
    public Collider tileLeft;
    public Collider tileRight;

    private string lastButtonPressed;
    private string currentButtonPressed;

    //private string last

    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        lastButtonPressed = "down";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {  // Up

            if (tileUp != null && tileUp.tag == "Rock")
                return;

            lastPos = transform.position;
            currentButtonPressed = "up";

            RotatePiece("up");
            transform.position += new Vector3(0, 1, 0);
            animator.SetTrigger("rootMove");

            GameObject rootPiece = Instantiate(PieceSelector(lastButtonPressed, currentButtonPressed), lastPos, Quaternion.identity);
            lastButtonPressed = "up";
        }
        else if (Input.GetKeyDown(KeyCode.S)) {  // Down            

            if (tileDown != null && tileDown.tag == "Rock")
                return;

            lastPos = transform.position;
            currentButtonPressed = "down";

            RotatePiece("down");
            transform.position += new Vector3(0, -1, 0);
            animator.SetTrigger("rootMove");


            GameObject rootPiece = Instantiate(PieceSelector(lastButtonPressed, currentButtonPressed), lastPos, Quaternion.identity);
            lastButtonPressed = "down";
        }
        else if (Input.GetKeyDown(KeyCode.A)) {  // Left 

            if (tileLeft != null && tileLeft.tag == "Rock")
                return;

            lastPos = transform.position;
            currentButtonPressed = "left";

            RotatePiece("left");
            transform.position += new Vector3(-1, 0, 0);
            animator.SetTrigger("rootMove");
            GameObject rootPiece = Instantiate(PieceSelector(lastButtonPressed, currentButtonPressed), lastPos, Quaternion.identity);
            lastButtonPressed = "left";
        }
        if (Input.GetKeyDown(KeyCode.D)) {  // Right
            
            if (tileRight != null && tileRight.tag == "Rock")
                return;

            lastPos = transform.position;
            currentButtonPressed = "right";

            RotatePiece("right");
            transform.position += new Vector3(1, 0, 0);
            animator.SetTrigger("rootMove");
            GameObject rootPiece = Instantiate(PieceSelector(lastButtonPressed, currentButtonPressed), lastPos, Quaternion.identity);
            lastButtonPressed = "right";
        }

    }

    private void RotatePiece(string tipDir)
    {
        switch (tipDir)
        {
            case "left":
                rootTip.transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case "right":
                rootTip.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case "up":
                rootTip.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case "down":
                rootTip.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }

    private GameObject PieceSelector(string lastButton, string currentButton)
    {
        print("cb: " + currentButton + " lb: " + lastButton);

        if (currentButton == "up" && lastButton == "up"){return rootVertical;}
        if (currentButton == "up" && lastButton == "left") { return rootCornerUpRight; }
        if (currentButton == "up" && lastButton == "right") { return rootCornerUpLeft; }
        if (currentButton == "down" && lastButton == "down") { return rootVertical; }
        if (currentButton == "down" && lastButton == "left") { return rootCornerRight; }
        if (currentButton == "down" && lastButton == "right") { return rootCornerLeft; }
        if (currentButton == "left" && lastButton == "up") { return rootCornerLeft; }
        if (currentButton == "left" && lastButton == "down") { return rootCornerUpLeft; }
        if (currentButton == "left" && lastButton == "left") { return rootHorizontal; }
        if (currentButton == "right" && lastButton == "up") { return rootCornerRight; }
        if (currentButton == "right" && lastButton == "down") { return rootCornerUpRight; }
        if (currentButton == "right" && lastButton == "right") { return rootHorizontal; }

        else return rootVertical;

    }

}

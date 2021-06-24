using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    GameManager gameManager;
    private int posX;
    private int posY;
    private int ringType;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        int.TryParse(gameObject.name.Substring(2, 1), out posX);
        int.TryParse(gameObject.name.Substring(3, 1), out posY);
        string ringChar = gameObject.name.Substring(1, 1);
        switch (ringChar)
        {
            case "M":
                ringType = 1;
                break;
            case "T":
                ringType = 2;
                break;
            default:
                ringType = 0;
                break;
        }
    }

    private void OnMouseDown()
    {
        gameManager.peiceMoveToPosX = posX;
        gameManager.peiceMoveToPosY = posY;
        gameManager.actionToCarry = ringType;
        gameManager.actionCompleted = true;
    }
}

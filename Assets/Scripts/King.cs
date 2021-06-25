using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Peice
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        isWhite = (gameObject.name.Substring(4, 1) == "W");
        if (isWhite)
        {
            posY = 0;
        }
        else
        {
            posY = 7;
        }
        int.TryParse(gameObject.name.Substring(9), out posX);
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameManager.actionCompleted)
                                   && (gameManager.peiceSelectedName == gameObject.name)
                                   && (gameManager.peiceSelectedType == "King"))
        {
            ActionCarryOut(gameManager, gameObject, posX, posY);
            posX = gameManager.peiceMoveToPosX;
            posY = gameManager.peiceMoveToPosY;
        }
    }

    private void PossibleMovesandTakes(bool boolValue)
    {
        int x = posX;
        int y = posY;
        PossibleTake(x, y - 1, boolValue);
        PossibleTake(x, y + 1, boolValue);
        PossibleTake(x - 1, y, boolValue);
        PossibleTake(x + 1, y, boolValue);
        PossibleTake(x + 1, y - 1, boolValue);
        PossibleTake(x + 1, y + 1, boolValue);
        PossibleTake(x - 1, y - 1, boolValue);
        PossibleTake(x - 1, y + 1, boolValue);
    }

    private void PossibleTake(int x, int y, bool boolValue)
    {
        Debug.Log("Before While Possible Take" + x + " " + y);
        if ((x < 8) && (x > -1) && (y < 8) && (y > -1))
            if (gameManager.gameBoardSet[x, y] != null)
            {
                if ((isWhite != GameObject.Find(gameManager.gameBoardSet[x, y].name).GetComponent<Peice>().isWhite))
                {
                    gameManager.gameBoardTake[x, y].SetActive(boolValue);
                }
            }
            else
            {
                gameManager.gameBoardMove[x, y].SetActive(boolValue);
            }
    }

    private void OnMouseEnter()
    {
        if (!gameManager.peiceSelected)
        {
            if (gameManager.playerIsWhite == isWhite)
            {
                PossibleMovesandTakes(true);
            }
        }
    }

    private void OnMouseExit()
    {
        if (!gameManager.peiceSelected)
        {
            if (gameManager.playerIsWhite == isWhite)
            {
                PossibleMovesandTakes(false);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!gameManager.peiceSelected)
        {
            if (!gameManager.peiceSelected)
            {
                gameManager.gameBoardSelect[posX, posY].SetActive(true);
                PossibleMovesandTakes(true);
                gameManager.peiceSelected = true;
                gameManager.peiceToMovePosX = posX;
                gameManager.peiceToMovePosY = posY;
                gameManager.peiceSelectedType = "King";
                gameManager.peiceSelectedName = gameObject.name;
            }
        }
    }
}

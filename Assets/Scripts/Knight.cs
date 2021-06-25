using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Peice
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
                   && (gameManager.peiceSelectedType == "knight"))
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
        PossibleMoveorTake(boolValue, x + 1, y + 2);
        PossibleMoveorTake(boolValue, x - 1, y + 2);
        PossibleMoveorTake(boolValue, x + 1, y - 2);
        PossibleMoveorTake(boolValue, x - 1, y - 2);
        PossibleMoveorTake(boolValue, x + 2, y + 1);
        PossibleMoveorTake(boolValue, x + 2, y - 1);
        PossibleMoveorTake(boolValue, x - 2, y + 1);
        PossibleMoveorTake(boolValue, x - 2, y - 1);
    }

    private void PossibleMoveorTake(bool boolValue, int x, int y)
    {
        if ((x <= 7) && (x >= 0) && (y <= 7) && (y >= 0))
            if (gameManager.gameBoardSet[x, y] == null)
            {
                gameManager.gameBoardMove[x, y].SetActive(boolValue);
            }
            else
            {
                if ((isWhite != GameObject.Find(gameManager.gameBoardSet[x, y].name).GetComponent<Peice>().isWhite))
                {
                    gameManager.gameBoardTake[x, y].SetActive(boolValue);
                }
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
                gameManager.peiceSelectedType = "knight";
                gameManager.peiceSelectedName = gameObject.name;
            }
        }
    }
}

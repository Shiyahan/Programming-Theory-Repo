using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pawn : Peice
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        int.TryParse(gameObject.name.Substring(9), out posX);
        isWhite = (gameObject.name.Substring(4, 1) == "W");
        if (isWhite)
        {
            posY = 1;
        }
        else
        {
            posY = 6;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameManager.actionCompleted)
                    && (gameManager.peiceSelectedName == gameObject.name)
                    && (gameManager.peiceSelectedType == "Pawn"))
        {
            switch (gameManager.actionToCarry)
            {
                case 1:
                    gameManager.gameBoardSet[posX, posY] = null;
                    posX = gameManager.peiceMoveToPosX;
                    posY = gameManager.peiceMoveToPosY;
                    gameManager.gameBoardSet[posX, posY] = gameObject;
                    MoveTo(gameObject, posX, posY);
                    gameManager.playerSwitch = true;
                    gameManager.actionCompleted = false;
                    gameManager.resetAction = true;
                    break;
                case 2:
                    Debug.Log(gameManager.gameBoardSet[gameManager.peiceMoveToPosX, gameManager.peiceMoveToPosY].name);
                    Destroy(gameManager.gameBoardSet[gameManager.peiceMoveToPosX, gameManager.peiceMoveToPosY]);
                    gameManager.gameBoardSet[posX, posY] = null;
                    Debug.Log("----" + posX + " " + posY);
                    posX = gameManager.peiceMoveToPosX;
                    posY = gameManager.peiceMoveToPosY;
                    gameManager.gameBoardSet[posX, posY] = gameObject;
                    MoveTo(gameObject, posX, posY);
                    gameManager.playerSwitch = true;
                    gameManager.actionCompleted = false;
                    gameManager.resetAction = true;
                    break;
                default:
                    Debug.Log(" Error action not programmed yet ----------");
                    break;
            }

        }
    }

    private void PossibleMoves(bool boolValue)
    {
        //Check if initial position: Pawn can move one or two slots
        if (isWhite)
        {
            if (gameManager.gameBoardSet[posX, posY + 1] == null)
            {
                gameManager.gameBoardMove[posX, posY + 1].SetActive(boolValue);
                if (posY == 1)
                {
                    if (gameManager.gameBoardSet[posX, posY + 2] == null)
                    {
                        gameManager.gameBoardMove[posX, posY + 2].SetActive(boolValue);
                    }
                }
            }
        }
        else
        {
            if (gameManager.gameBoardSet[posX, posY - 1] == null)
            {
                gameManager.gameBoardMove[posX, posY - 1].SetActive(boolValue);
                if (posY == 6)
                {
                    if (gameManager.gameBoardSet[posX, posY - 2] == null)
                    {
                        gameManager.gameBoardMove[posX, posY - 2].SetActive(boolValue);
                    }
                }
            }
        }
    }

    private void PossibleTakes(bool boolValue)
    {
        if (isWhite)
        {
            if (posX < 7)
            {
                if ((gameManager.gameBoardSet[posX + 1, posY + 1] != null)
                    && (isWhite != GameObject.Find(gameManager.gameBoardSet[posX + 1, posY + 1].name).GetComponent<Peice>().isWhite))
                {
                    gameManager.gameBoardTake[posX + 1, posY + 1].SetActive(boolValue);
                }
            }
            if (posX > 0)
            {
                if ((gameManager.gameBoardSet[posX - 1, posY + 1] != null)
                    && (isWhite != GameObject.Find(gameManager.gameBoardSet[posX - 1, posY + 1].name).GetComponent<Peice>().isWhite))
                {
                    gameManager.gameBoardTake[posX - 1, posY + 1].SetActive(boolValue);
                }
            }
        }
        else
        {
            if (posX < 7)
            {
                if ((gameManager.gameBoardSet[posX + 1, posY - 1] != null)
                    && (isWhite != GameObject.Find(gameManager.gameBoardSet[posX + 1, posY - 1].name).GetComponent<Peice>().isWhite))
                {
                    gameManager.gameBoardTake[posX + 1, posY - 1].SetActive(boolValue);
                }
            }
            if (posX > 0)
            {
                if ((gameManager.gameBoardSet[posX - 1, posY - 1] != null)
                    && (isWhite != GameObject.Find(gameManager.gameBoardSet[posX - 1, posY - 1].name).GetComponent<Peice>().isWhite))
                {
                    gameManager.gameBoardTake[posX - 1, posY - 1].SetActive(boolValue);
                }
            }
        }
    }

    private void OnMouseEnter()
    {
        if (!gameManager.peiceSelected)
        {
            if (gameManager.playerIsWhite == isWhite)
            {
                PossibleMoves(true);
                PossibleTakes(true);
            }
        }
    }

    private void OnMouseExit()
    {
        if (!gameManager.peiceSelected)
        {
            if (gameManager.playerIsWhite == isWhite)
            {
                PossibleMoves(false);
                PossibleTakes(false);
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
                PossibleMoves(true);
                PossibleTakes(true);
                gameManager.peiceSelected = true;
                gameManager.peiceToMovePosX = posX;
                gameManager.peiceToMovePosY = posY;
                gameManager.peiceSelectedType = "Pawn";
                gameManager.peiceSelectedName = gameObject.name;
            }
        }
    }
}

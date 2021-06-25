using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
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
                   && (gameManager.pieceSelectedName == gameObject.name)
                   && (gameManager.pieceSelectedType == "knight"))
        {
            ActionCarryOut(gameManager, gameObject, posX, posY);
            posX = gameManager.pieceMoveToPosX;
            posY = gameManager.pieceMoveToPosY;
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
                if ((isWhite != GameObject.Find(gameManager.gameBoardSet[x, y].name).GetComponent<Piece>().isWhite))
                {
                    gameManager.gameBoardTake[x, y].SetActive(boolValue);
                }
            }
    }

    private void OnMouseEnter()
    {
        if (!gameManager.pieceSelected)
        {
            if (gameManager.playerIsWhite == isWhite)
            {
                PossibleMovesandTakes(true);
            }
        }
    }

    private void OnMouseExit()
    {
        if (!gameManager.pieceSelected)
        {
            if (gameManager.playerIsWhite == isWhite)
            {
                PossibleMovesandTakes(false);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!gameManager.pieceSelected)
        {
            if (!gameManager.pieceSelected)
            {
                gameManager.gameBoardSelect[posX, posY].SetActive(true);
                PossibleMovesandTakes(true);
                gameManager.pieceSelected = true;
                gameManager.pieceToMovePosX = posX;
                gameManager.pieceToMovePosY = posY;
                gameManager.pieceSelectedType = "knight";
                gameManager.pieceSelectedName = gameObject.name;
            }
        }
    }
}

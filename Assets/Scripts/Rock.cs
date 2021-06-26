using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Piece
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
                           && (gameManager.pieceSelectedType == "Rock"))
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
        x++;
        while ((x < 8) && (gameManager.gameBoardSet[x, y] == null))
        {
            if (gameManager.gameBoardSet[x, y] == null)
            {
                gameManager.gameBoardMove[x, y].SetActive(boolValue);
                x++;
            }
        }
        PossibleTake(x, y, boolValue);

        x = posX;
        y = posY;
        x--;
        while ((x > -1) && (gameManager.gameBoardSet[x, y] == null))
        {
            if (gameManager.gameBoardSet[x, y] == null)
            {
                gameManager.gameBoardMove[x, y].SetActive(boolValue);
                x--;
            }
        }
        PossibleTake(x, y, boolValue);

        x = posX;
        y = posY;
        y++;
        while ((y < 8) && (gameManager.gameBoardSet[x, y] == null))
        {
            if (gameManager.gameBoardSet[x, y] == null)
            {
                gameManager.gameBoardMove[x, y].SetActive(boolValue);
                y++;
            }
        }
        PossibleTake(x, y, boolValue);

        x = posX;
        y = posY;
        y--;
        while ((y > -1) && (gameManager.gameBoardSet[x, y] == null))
        {
            if (gameManager.gameBoardSet[x, y] == null)
            {
                gameManager.gameBoardMove[x, y].SetActive(boolValue);
                y--;
            }
        }
        PossibleTake(x, y, boolValue);
    }

    private void PossibleTake(int x, int y, bool boolValue)
    {
        if (PositionOnBoard2(x, y))
            if (gameManager.gameBoardSet[x, y] != null)
                if ((isWhite != GameObject.Find(gameManager.gameBoardSet[x, y].name).GetComponent<Piece>().isWhite))
                {
                    gameManager.gameBoardTake[x, y].SetActive(boolValue);
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
                gameManager.pieceSelectedType = "Rock";
                gameManager.pieceSelectedName = gameObject.name;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
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
                           && (gameManager.pieceSelectedType == "Bshp"))
        {
            ActionCarryOut(gameManager, gameObject, ref posX, ref posY);
            hasMoved = true;
        }
    }

    private void PossibleMovesandTakes(bool boolValue)
    {
        PossibleMovesDirection(gameManager, gameObject, posX, posY, 1, 1, boolValue);
        PossibleMovesDirection(gameManager, gameObject, posX, posY, -1, 1, boolValue);
        PossibleMovesDirection(gameManager, gameObject, posX, posY, 1, -1, boolValue);
        PossibleMovesDirection(gameManager, gameObject, posX, posY, -1, -1, boolValue);
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
                gameManager.pieceSelectedType = "Bshp";
                gameManager.pieceSelectedName = gameObject.name;
            }
        }
    }
}

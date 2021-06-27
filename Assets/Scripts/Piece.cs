using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    protected int posX;
    protected int posY;
    public bool isWhite;
    protected string pieceName;
    public bool hasMoved;
    private static float boardPositionSize = 0.25f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private float BoardPosition(int position)
    {
        return ((position + 1) * boardPositionSize - boardPositionSize * 4.5f);
    }

    private void MoveTo(GameObject gameObject, int x, int y)
    {
        gameObject.transform.position = new Vector3(BoardPosition(x), 0, BoardPosition(y));
    }

    public virtual void ActionCarryOut(GameManager gameManager, ref int posX, ref int posY)
    {
        switch (gameManager.actionToCarry)
        {
            case 1:
                gameManager.gameBoardSet[posX, posY] = null;
                posX = gameManager.pieceMoveToPosX;
                posY = gameManager.pieceMoveToPosY;
                gameManager.gameBoardSet[posX, posY] = gameObject;
                MoveTo(gameObject, posX, posY);
                gameManager.playerSwitch = true;
                gameManager.actionCompleted = false;
                gameManager.resetAction = true;
                break;
            case 2:
                Destroy(gameManager.gameBoardSet[gameManager.pieceMoveToPosX, gameManager.pieceMoveToPosY]);
                gameManager.gameBoardSet[posX, posY] = null;
                posX = gameManager.pieceMoveToPosX;
                posY = gameManager.pieceMoveToPosY;
                gameManager.gameBoardSet[posX, posY] = gameObject;
                MoveTo(gameObject, posX, posY);
                gameManager.playerSwitch = true;
                gameManager.actionCompleted = false;
                gameManager.resetAction = true;
                break;
            case 3:
                gameManager.gameBoardSet[posX, posY] = null;
                posX = gameManager.pieceMoveToPosX;
                posY = gameManager.pieceMoveToPosY;
                gameManager.gameBoardSet[posX, posY] = gameObject;
                MoveTo(gameObject, posX, posY);

                gameManager.actionToCarry = 1;
                gameManager.pieceSelectedType = "Rock";

                int _x = 0;
                gameManager.pieceMoveToPosX = 2;
                if (posX == 6)
                {
                    _x = 7;
                    gameManager.pieceMoveToPosX = 5;
                }
                gameManager.pieceSelectedName = gameManager.gameBoardSet[_x, posY].name;
                break;
            default:
                Debug.Log(" Error action not programmed yet ----------");
                break;
        }
    }

    private bool PositionOnBoard2(int x, int y)
    {
        return (PositionOnBoard1(x) && PositionOnBoard1(y));
    }

    private bool PositionOnBoard1(int x)
    {
        return ((x >= 0) && (x <= 7));
    }

    private void PossibleMovesDirectionTake(GameManager gameManager, GameObject gameObject,
                                                int x, int y, bool boolValue)
    {
        if (PositionOnBoard2(x, y))
            if (gameManager.gameBoardSet[x, y] != null)
                if ((gameObject.GetComponent<Piece>().isWhite != GameObject.Find(gameManager.gameBoardSet[x, y].name).GetComponent<Piece>().isWhite))
                {
                    gameManager.gameBoardTake[x, y].SetActive(boolValue);
                }
    }

    public virtual void PossibleMovesDirection(GameManager gameManager,
                                                int x, int y, int _x, int _y, bool boolValue)
    {
        x += _x;
        y += _y;
        while ((PositionOnBoard2(x, y)) && (gameManager.gameBoardSet[x, y] == null))
        {
            if (gameManager.gameBoardSet[x, y] == null)
            {
                gameManager.gameBoardMove[x, y].SetActive(boolValue);
                x += _x;
                y += _y;
            }
        }
        PossibleMovesDirectionTake(gameManager, gameObject, x, y, boolValue);
    }
}

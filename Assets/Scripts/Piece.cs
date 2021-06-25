using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    protected int posX;
    protected int posY;
    public bool isWhite;
    protected string pieceName;
    private static float boardPositionSize = 0.25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static float BoardPosition(int position)
    {
        return ((position + 1) * boardPositionSize - boardPositionSize * 4.5f);
    }

    public static void MoveTo(GameObject gameObject, int x, int y)
    {
        gameObject.transform.position = new Vector3(Piece.BoardPosition(x), 0, Piece.BoardPosition(y));
    }

    public static void ActionCarryOut(GameManager gameManager, GameObject gameObject, int posX, int posY)
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
                Debug.Log(gameManager.gameBoardSet[gameManager.pieceMoveToPosX, gameManager.pieceMoveToPosY].name);
                Destroy(gameManager.gameBoardSet[gameManager.pieceMoveToPosX, gameManager.pieceMoveToPosY]);
                gameManager.gameBoardSet[posX, posY] = null;
                Debug.Log("----" + posX + " " + posY);
                posX = gameManager.pieceMoveToPosX;
                posY = gameManager.pieceMoveToPosY;
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
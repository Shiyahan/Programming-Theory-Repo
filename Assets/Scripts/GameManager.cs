using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game arrays 
    public GameObject[,] gameBoardSet = new GameObject[8, 8];
    public GameObject[,] gameBoardSelect = new GameObject[8, 8];
    public GameObject[,] gameBoardMove = new GameObject[8, 8];
    public GameObject[,] gameBoardTake = new GameObject[8, 8];

    // Player Controls
    public bool playerIsWhite = true;
    public bool playerSwitch = false;

    // variables for actions
    public bool peiceSelected = false;
    public string peiceSelectedName;
    public string peiceSelectedType;
    public int peiceToMovePosX;
    public int peiceToMovePosY;
    public int actionToCarry;
    public int peiceMoveToPosX;
    public int peiceMoveToPosY;
    public bool actionCompleted;
    public bool resetAction = false;

    // Prefabs variables
    public GameObject ringSelectPrefab;
    public GameObject ringMovePrefab;
    public GameObject ringTakePrefab;
    public GameObject pawnWhitePrefab;
    public GameObject pawnBlackPrefab;
    public GameObject rockWhitePrefab;
    public GameObject rockBlackPrefab;
    private static float boardPositionSize = 0.25f;

    // variables to DEBUG
    public bool debugFlag = false;
    public int debugX, debugY;

    // Start is called before the first frame update
    void Start()
    {
        initGameBoard();
    }

    // Update is called once per frame
    void Update()
    {
        if (resetAction)
        {
            ActionReset();
            resetAction = false;
        }

        if (debugFlag)
        {
            Debug.Log(gameBoardSet[debugX, debugY].name);
            debugFlag = false;
        }
    }

    private float BoardPosition(int position)
    {
        return ((position + 1) * boardPositionSize - boardPositionSize * 4.5f);
    }

    private void RingSetInactive(int i, int j)
    {
        gameBoardSelect[i, j].SetActive(false);
        gameBoardMove[i, j].SetActive(false);
        gameBoardTake[i, j].SetActive(false);
    }

    private void initGameBoard()
    {
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                gameBoardSelect[i, j] = Instantiate(ringSelectPrefab, new Vector3(BoardPosition(i), 0.02f, BoardPosition(j)), Quaternion.identity);
                gameBoardSelect[i, j].name = "RS" + i.ToString() + j.ToString();
                gameBoardMove[i, j] = Instantiate(ringMovePrefab, new Vector3(BoardPosition(i), 0.02f, BoardPosition(j)), Quaternion.identity);
                gameBoardMove[i, j].name = "RM" + i.ToString() + j.ToString();
                gameBoardTake[i, j] = Instantiate(ringTakePrefab, new Vector3(BoardPosition(i), 0.02f, BoardPosition(j)), Quaternion.identity);
                gameBoardTake[i, j].name = "RT" + i.ToString() + j.ToString();
                RingSetInactive(i, j);
            }
        }

        // Instantiate Pawns
        for (int i = 0; i < 8; i++)
        {
            gameBoardSet[i, 1] = Instantiate(pawnWhitePrefab, new Vector3(BoardPosition(i), 0, BoardPosition(1)), Quaternion.Euler(new Vector3(-90, 0, 0)));
            gameBoardSet[i, 1].name = "PawnWhite" + i.ToString();
        }

        for (int i = 0; i < 8; i++)
        {
            gameBoardSet[i, 6] = Instantiate(pawnBlackPrefab, new Vector3(BoardPosition(i), 0, BoardPosition(6)), Quaternion.Euler(new Vector3(-90, 0, 0)));
            gameBoardSet[i, 6].name = "PawnBlack" + i.ToString();
        }

        // Instantiate Rocks
        gameBoardSet[0, 0] = Instantiate(rockWhitePrefab, new Vector3(BoardPosition(0), 0, BoardPosition(0)), Quaternion.Euler(new Vector3(-90, 0, 0)));
        gameBoardSet[0, 0].name = "RockWhite0";
        gameBoardSet[7, 0] = Instantiate(rockWhitePrefab, new Vector3(BoardPosition(7), 0, BoardPosition(0)), Quaternion.Euler(new Vector3(-90, 0, 0)));
        gameBoardSet[7, 0].name = "RockWhite7";
        gameBoardSet[0, 7] = Instantiate(rockBlackPrefab, new Vector3(BoardPosition(0), 0, BoardPosition(7)), Quaternion.Euler(new Vector3(-90, 0, 0)));
        gameBoardSet[0, 7].name = "RockBlack0";
        gameBoardSet[7, 7] = Instantiate(rockBlackPrefab, new Vector3(BoardPosition(7), 0, BoardPosition(7)), Quaternion.Euler(new Vector3(-90, 0, 0)));
        gameBoardSet[7, 7].name = "RockBlack7";
    }

    private void ActionReset()
    {
        peiceSelected = false;
        peiceSelectedName = " ";
        peiceSelectedType = " ";
        actionToCarry = 9;
        actionCompleted = false;
        resetRings();
    }

    private void resetRings()
    {
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                RingSetInactive(i, j);
            }
        }
    }
}

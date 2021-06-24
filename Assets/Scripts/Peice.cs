using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peice : MonoBehaviour
{
    protected int posX;
    protected int posY;
    public bool isWhite;
    protected string peiceName;
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
        gameObject.transform.position = new Vector3(Peice.BoardPosition(x), 0, Peice.BoardPosition(y));
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchView : MonoBehaviour
{
    GameManager gameManager;
    private Vector3 cameraPositionWhite = new Vector3(0, 2, -2);
    private Vector3 cameraPositionblack = new Vector3(0, 2, 2);

    private Vector3 cameraRotationWhite = new Vector3(45, 0, 0);
    private Vector3 cameraRotationBlack = new Vector3(45, 180, 0);

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSwitch();
    }

    private void PlayerSwitch()
    {
        if (gameManager.playerSwitch)
        {
            gameManager.playerSwitch = false;
            gameManager.playerIsWhite = !gameManager.playerIsWhite;
            if (gameManager.playerIsWhite)
            {
                transform.position = cameraPositionWhite;
                transform.rotation = Quaternion.Euler(cameraRotationWhite);
            }
            else
            {
                transform.position = cameraPositionblack;
                transform.rotation = Quaternion.Euler(cameraRotationBlack);
            }
        }
    }
}

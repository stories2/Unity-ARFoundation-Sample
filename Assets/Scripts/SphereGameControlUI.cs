using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereGameControlUI : MonoBehaviour
{
    public GameObject player;
    PlayerMovementScript playerMovement;
    Vector3 movement;
    bool[] isBtnsClicked;

    const int MOVE_UP = 0, MOVE_DOWN = 1, MOVE_RIGHT = 2, MOVE_LEFT = 3;
    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector3();
        isBtnsClicked = new bool[4];
        playerMovement = player.GetComponent<PlayerMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(isBtnsClicked[MOVE_RIGHT] ? 0.1f : (isBtnsClicked[MOVE_LEFT] ? -0.1f : 0), 0, 
                                isBtnsClicked[MOVE_UP] ? 0.1f : (isBtnsClicked[MOVE_DOWN] ? -0.1f : 0)).normalized;
        // Debug.Log("movement: " + movement);
        playerMovement.SetMoveDirection(movement);
    }

    public void BtnClicked(int btnType) {
        isBtnsClicked[btnType] = true;
    }

    public void BtnReleased(int btnType) {
        isBtnsClicked[btnType] = false;
    }
}

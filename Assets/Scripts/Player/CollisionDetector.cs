using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerControls playerControls;
    Vector3 checkPointPos;
    [SerializeField] GameObject winCanvas;
    void Start()
    {

        playerMovement = GetComponent<PlayerMovement>();
        playerControls = transform.GetChild(0).GetComponent<PlayerControls>();
        checkPointPos = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 otherObjectPosition = other.transform.position;
        if (other.CompareTag("DirectionChanger"))
        {
            transform.position = new Vector3(otherObjectPosition.x, transform.position.y, otherObjectPosition.z);
            other.gameObject.SetActive(false);
            playerMovement.StartCoroutine(playerMovement.Rotate90());
        }
        else if (other.CompareTag("Checkpoint"))
        {
            checkPointPos = new Vector3(otherObjectPosition.x, transform.position.y, otherObjectPosition.z);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Enemy"))
        {
            playerMovement.dynamicMoveSpeed = 0;
            playerControls.inputReset = true;
            transform.position = checkPointPos;
        }
        else if (other.CompareTag("Finish"))
        {
            Time.timeScale = 0;
            winCanvas.SetActive(true);
        }
    }
}


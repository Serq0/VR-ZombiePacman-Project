using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public string buttonWalk;
    //public string buttonWalkBack;


    float SPEED = 3.0f / 2;
    bool move;
    public Text TutorialMove;
    public bool moveBackward = false;

    void Start()
    {
        move = false;
    }


    void Update()
    {
        /* strzelanie
        if (Input.GetButtonDown("YButton"))
        {
            GameObject shootIt = Instantiate(bullet);
            shootIt.transform.position = transform.position;
            Rigidbody rb = shootIt.GetComponent<Rigidbody>();
            Camera cam = GetComponentInChildren<Camera>();
            rb.velocity = cam.transform.rotation * Vector3.forward * shootingSpeed;

        }
        */
        if (move)
        {
            transform.position = transform.position + Camera.main.transform.forward * SPEED * Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (Input.GetButtonDown("CButton"))
        {
            move = true;
            TutorialMove.gameObject.SetActive(false);
        }
        if (Input.GetButtonUp("CButton"))
        {
            move = false;
        }
    }


}


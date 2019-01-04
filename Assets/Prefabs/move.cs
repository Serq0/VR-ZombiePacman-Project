using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour {
    public Material materialGround;
    public GameObject ground;
    GameObject gobj;
    public int SPEED = 3;
    public bool moving = false;
    public Text ctext;
    public int count;
	// Use this for initialization
	void Start () {
        //ground.GetComponent<MeshRenderer>().material = materialGround;
        count = 8;
	}
	
	// Update is called once per frame
	void Update () {
        //ground.GetComponent<MeshRenderer>().material = materialGround; //cos sie zepsulo - to fix

        if (Input.GetButtonDown("Fire1"))
        {
            moving = !moving;
        }

        if (moving)
        {
            transform.position = transform.position + Camera.main.transform.forward * SPEED * Time.deltaTime;
        }

        if (transform.position.y < 0.74f)
        {
            SceneManager.LoadScene("Pacman");
        }
        
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cylinder"))
        {
            Destroy(other.gameObject);
            count -= 1;
            Counter();

            if(count == 0)
            {
                //ctext.gameObject.SetActive(false);
                ctext.text = "thanks for playing :)";
            }
        }
    }

    public void Counter()
    {
        ctext.text = "antibiotics to collect " + count.ToString();
    }

}

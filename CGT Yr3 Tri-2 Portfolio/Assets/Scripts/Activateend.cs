using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Activateend : MonoBehaviour
{
    //public varibles
    public GameObject EndCam;

    public TextMeshProUGUI Pickup;
    public GameObject HUD;



    bool active = true;
    bool action = false;


    // sets UI at start to not active
    void Start()
    {
        Pickup.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        //when player enters collider sets UI elements to active
        if (active == true)
        {
            Pickup.gameObject.SetActive(true);
        }

        if (collision.transform.tag == "Player")
        {
            action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        //when player exits the UI text diactivates
        if (active == true)
        {
            Pickup.gameObject.SetActive(false);
            action = false;
        }
    }

    void Update()
    {
        //press f to interact with staff at end / activate HUD elements
        if (Input.GetKeyDown(KeyCode.F) && active == true && action == true)
        {
            Pickup.gameObject.SetActive(false);
            EndCam.SetActive(true);
            HUD.SetActive(false);
            StartCoroutine(Beam());
            StartCoroutine(Ending());

        }


    }

    // activates particle effect after 4secs
    IEnumerator Beam()
    {
        yield return new WaitForSeconds(4.5f);
        FindObjectOfType<AudioManager>().Play("Beam");
    }


    //swaps scenes after 15sec
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Activateend : MonoBehaviour
{

    public GameObject EndCam;

    public TextMeshProUGUI Pickup;
    public GameObject HUD;



    bool active = true;
    bool action = false;


    // Start is called before the first frame update
    void Start()
    {
        Pickup.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        //when player enters collider sets UI elents to active
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
        //Pickup of key and letter activate gate and remove key and letter
        if (Input.GetKeyDown(KeyCode.F) && active == true && action == true)
        {
            Pickup.gameObject.SetActive(false);
            EndCam.SetActive(true);
            HUD.SetActive(false);
            StartCoroutine(Beam());
            StartCoroutine(Ending());

        }


    }

    IEnumerator Beam()
    {
        yield return new WaitForSeconds(4.5f);
        FindObjectOfType<AudioManager>().Play("Beam");
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
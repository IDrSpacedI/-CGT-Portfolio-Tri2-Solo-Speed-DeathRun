using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableSlowDownTime : MonoBehaviour
{
    public GameObject Sign;
    public GameObject VoidEnergy;
    public GameObject TimeManager;

    public TextMeshProUGUI Pickup;

    public Material GlowMaterial;

    bool active = true;
    bool action = false;


    // Start is called before the first frame update
    void Start()
    {
        Sign.SetActive(false);
        TimeManager.SetActive(false);
        Pickup.gameObject.SetActive(false);
        GlowMaterial.DisableKeyword("_EMISSION");
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
            Sign.SetActive(true);
            TimeManager.SetActive(true);
            GlowMaterial.EnableKeyword("_EMISSION");
            VoidEnergy.SetActive(false);
        }


    }



}

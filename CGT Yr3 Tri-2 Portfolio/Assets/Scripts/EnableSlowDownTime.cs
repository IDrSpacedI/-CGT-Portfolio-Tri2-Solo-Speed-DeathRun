using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableSlowDownTime : MonoBehaviour
{
    //varibles
    public GameObject Sign;
    public GameObject VoidEnergy;
    public GameObject TimeManager;

    public TextMeshProUGUI Pickup;

    public Material GlowMaterial;

    bool active = true;
    bool action = false;


    //sets gameobjects to false at start
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
        //activates glow material when player picks up void energy
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

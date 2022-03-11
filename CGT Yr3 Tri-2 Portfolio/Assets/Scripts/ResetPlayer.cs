using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Transform TeleportTarget;
    public GameObject thePlayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            thePlayer.transform.position = TeleportTarget.transform.position;
        }


    }


    void OnTriggerEnter(Collider other)
    {
        print("RESET");
        print(TeleportTarget.transform.position);

        thePlayer.transform.position = TeleportTarget.transform.position;

        if (thePlayer.transform.position == TeleportTarget.transform.position)
        {
            //no reset
        }
        else
        {
            thePlayer.transform.position = TeleportTarget.transform.position;
            //reset again
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (thePlayer.transform.position == TeleportTarget.transform.position)
        {
            //no reset
        }
        else
        {
            thePlayer.transform.position = TeleportTarget.transform.position;
            //reset again
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Transform TeleportTarget;
    public GameObject thePlayer;
    public GameObject Portal;
    public CharacterController cc;

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

        cc.enabled = false;
        thePlayer.transform.position = TeleportTarget.transform.position;
        StartCoroutine(portal());
        cc.enabled = true;
        

    }

    IEnumerator portal()
    {
        Portal.SetActive(true);
        yield return new WaitForSeconds(3f);
        Portal.SetActive(false);
    }
        
}
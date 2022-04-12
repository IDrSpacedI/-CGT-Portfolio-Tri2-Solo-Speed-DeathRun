using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDowwnTimer : MonoBehaviour
{
    //varibles
    float currentTime = 0f;
    public float startingTime = 100f;
    public GameObject DeathHUD;
    public GameObject EndCam;

    [SerializeField] TextMeshProUGUI countdownText;

    //sets current time to strating time and deactivates death screen
    void Start()
    {
        currentTime = startingTime;
        DeathHUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0.0" + "Sec");

        //when timer hits 0 activate death screen
        if(currentTime <= 0)
        {
            currentTime = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            DeathHUD.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDowwnTimer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 100f;
    public GameObject DeathDHUD;

    [SerializeField] TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        DeathDHUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0.0" + "Sec");

        if(currentTime <= 0)
        {
            currentTime = 0;
            DeathDHUD.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void Tryagain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = false;
    }

    public void MainMenuback()
    {
        SceneManager.LoadScene("MainMenu");
    }



    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}

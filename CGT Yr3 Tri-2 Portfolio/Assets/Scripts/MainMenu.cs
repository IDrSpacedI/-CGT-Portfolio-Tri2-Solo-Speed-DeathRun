using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //play game from begining 
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //quit game
    public void Quit()
    {
        Application.Quit();
    }

    //load level 1
    public void Level1()
    {
        SceneManager.LoadScene("Level1");

    }

    //load level 2
    public void Level2()
    {
        SceneManager.LoadScene("Level 2");

    }

    //load level 3
    public void Level3()
    {
        SceneManager.LoadScene("Level 3");

    }

    //load level 4
    public void Level4()
    {
        SceneManager.LoadScene("Level 4");

    }

    //load current level playing
    public void Tryagain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //load main menu
    public void MainMenuback()
    {
        SceneManager.LoadScene("MainMenu");

    }


    //go back to main menu if you press ESC Key
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }
    }

}

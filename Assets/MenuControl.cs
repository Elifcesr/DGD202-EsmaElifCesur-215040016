using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update 
    public GameObject inGameScreen, pauseScreen;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    public void pauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void playButton() 
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }

    public void replayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void homeButton()
    {
        Time.timeScale = 1;
        DataManager.Instance.saveData();
        SceneManager.LoadScene(0);
    }
}

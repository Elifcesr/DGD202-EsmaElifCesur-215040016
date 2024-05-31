using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menumanager : MonoBehaviour
{
   
    

    // Start is called before the first frame update
    public Image levelImage;
    public void levelgo()
    {
        levelImage.gameObject.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButton1() 
    {
        SceneManager.LoadScene(1);
    }
     public void playButton2() 
    {
        SceneManager.LoadScene(2);
    }
     public void playButton3() 
    {
        SceneManager.LoadScene(3);
    }
      public void playButton4() 
    {
        SceneManager.LoadScene(4);
    }


    public void quit ()
    {
       
        Application.Quit();
       
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private int shotSaw;
    public int totalShotSaw;
    private int enemyKilled;
    public int totalEnemyKilled;

    

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        
        } else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
       
    }

    // Update is called once per frame
     public int levelint;
 void Update()
    {
        if(PlayerManager.dead)
        {
            StartCoroutine(restart());
            PlayerManager.dead=false;
        }
    }
   
     public IEnumerator restart()
    {
      
        yield return new WaitForSeconds(3);
          SceneManager.LoadScene(levelint);
    }

    public int ShotSaw
    {
        get
        {
            return shotSaw;
        }
        set
        {
            shotSaw = value;
            GameObject.Find("shotSawText").GetComponent<Text>().text ="Atılan Testere : " + shotSaw.ToString();
        }
    }

    public int EnemyKilled
    {
        get 
        {
            return enemyKilled;
        }
        set 
        {
            enemyKilled = value;
         
        }
    }

    private void startProcess()
    {
     
        loadData();
    }

    public void saveData ()
    {
        totalShotSaw += shotSaw;
        totalEnemyKilled += enemyKilled;

     
    }

    public void loadData ()
    {
       
    }

    public void winProcess()
    {
        if (enemyKilled >= 5)
        {
            print("Kazandınız!");
        }

    }

    public void loseProcess()
    {
            print("Kaybettiniz!");
    }
}



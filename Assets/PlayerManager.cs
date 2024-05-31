using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
   public float Healt;
    public float sawSpeed;
    public DataManager ShotSaw;

    Transform Muzzle;

    public Slider slider;
    public GameObject saw, bloodParticle;

    public static bool dead = false;
    bool mouseIsNotOverUI;
    // Start is called before the first frame update
    void Start()
    {
        dead =false;
        Muzzle= transform.GetChild(1);
        slider.maxValue = Healt;
        slider.value = Healt;
    }

    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;
        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI) {
            shootSaw();
        } 
    }

    public void getDamage (float damage)
    {
      
        if (Healt-damage >=0)
        {
            Healt -= damage;
        }
        else
        {
            Healt = 0;
        }
        slider.value = Healt;
        AmIDead();
    }

    void AmIDead()
    {
        if (Healt<=0)
        {
            Destroy(Instantiate(bloodParticle,transform.position, Quaternion.identity),3f);
           DataManager.Instance.loseProcess();
            dead = true;
           
            Destroy(gameObject);
        }
    }
    
   

    void shootSaw()
    {
      if(DataManager.Instance.ShotSaw < DataManager.Instance.totalShotSaw)
      {
         GameObject tempSaw = Instantiate(saw, Muzzle.position,Quaternion.identity);
       if(PlayerController.facingRight ) tempSaw.GetComponent<Rigidbody2D>().AddForce(Muzzle.right * sawSpeed,ForceMode2D.Impulse);
         else 
         {
             tempSaw.GetComponent<Rigidbody2D>().AddForce(-Muzzle.right * sawSpeed,ForceMode2D.Impulse);
         }
        DataManager.Instance.ShotSaw++;
      }
      
       
    }
}

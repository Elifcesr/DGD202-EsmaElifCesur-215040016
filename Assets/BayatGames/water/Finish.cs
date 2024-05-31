using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int num;
   public void finish()
   {
    SceneManager.LoadScene(num);
   }
   void OnTriggerEnter2D(Collider2D coll) 
   {
    if(coll.gameObject.CompareTag("Player"))
    {
     GetComponent<Animator>().enabled=true;        
    }

   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mus : MonoBehaviour
{
    // Start is called before the first frame update
   public static bool a=true;
    void Start()
    {
        if (a)
        {
             DontDestroyOnLoad(gameObject); 
             a=false;
        
        } 
        else
        {
            Destroy(gameObject);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetikle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spike;
    
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            spike.GetComponent<Animator>().enabled=true;
            Destroy(this.gameObject,0.2f);
        }
    }
}

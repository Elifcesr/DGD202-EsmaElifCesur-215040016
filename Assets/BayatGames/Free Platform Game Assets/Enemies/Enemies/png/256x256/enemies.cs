using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class enemies : MonoBehaviour
{
    public float enemyHP;
    public float enemyDamage;
    public DataManager EnemyKilled;
    public GameObject life;
    public Transform[] points;

    bool dead = false;
    bool colliderBusy = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeGoWhere());
        life.GetComponent<SpriteRenderer>().drawMode=SpriteDrawMode.Tiled;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    IEnumerator TimeGoWhere()
    {
        int a=0;
        for(int i=0;i<points.Length;i++)
        { 
             
            while(a<70)
            {
                a++;
                this.gameObject.transform.position = Vector2.MoveTowards(this.transform.position, points[i].position, 0.05f);
               
                yield return new WaitForSeconds(0.015f);
            }
            
            a=0;
        }
        
        StartCoroutine(TimeGoWhere());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            print("collider alanına girdi = " + collision.name);
            collision.GetComponent<PlayerManager>().getDamage(enemyDamage);
        } 
        else if(collision.tag == "saw")
        {
            print("hasar " + collision.name);
           
          
            getDamage(collision.GetComponent<SawManager>().sawDamage);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("collider alanıdan çıktı = " + collision.name);
            colliderBusy =false;
        }
    }

    public void getDamage(float damage)
    {
        if (enemyHP - damage >= 0)
        {
            enemyHP -= damage;

            life.GetComponent<SpriteRenderer>().size = new Vector2(enemyHP, 1.2f);
        }
        else
        {
            enemyHP = 0;
            
        }
      
        AmIDead();
    }

    void AmIDead()
    {
        if (enemyHP <= 0)
        {
          DataManager.Instance.EnemyKilled++;

            Destroy(this.gameObject);
        }
    }
}

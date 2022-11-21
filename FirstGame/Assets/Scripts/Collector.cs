using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{





    // int test = count.GetComponent<MonsterSpawner>(test);




    private void Start()
    {

        
        
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Test");
        if (collision.CompareTag("Enemy") && MonsterSpawner.totalMon > 10)
        {
            Destroy(collision.gameObject);
            MonsterSpawner.totalMon--;
            
        }
        if (MonsterSpawner.totalMon == 10)
        {
            MonsterSpawner.chucky = true;

        }

    }



    


}

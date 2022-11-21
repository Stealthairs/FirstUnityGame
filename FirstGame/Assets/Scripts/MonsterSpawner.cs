using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    static public int totalMon;
    static public bool chucky = true;



    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftpos, rightpos;

    private int randomIndex;
    private int randomSide;


    void Start()
    {
        StartCoroutine(SpawnMonsters());
        
    }

    void Update()
    {
        if(chucky == true)
        {
            StartCoroutine(SpawnMonsters());
            chucky = false;
        }

    }

    IEnumerator SpawnMonsters()
    {

        
        int i = 0;
     
        while (totalMon < 15) {
           
            if(totalMon > 15)
            {
                break;
            }
            i++;
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            totalMon++;

            if (randomSide == 0)
                {
                    spawnedMonster.transform.position = leftpos.position;
                    spawnedMonster.GetComponent<Monstor>().speed = Random.Range(4, 6);
                    
                   
                    
                }
                else
                {
                    spawnedMonster.transform.position = rightpos.position;
                    spawnedMonster.GetComponent<Monstor>().speed = Random.Range(2,4);

                    
            }
        }
        
    }

    public void MonstorManager()
    {

  
    }

    

    // Start is called before the first frame update


    // Update is called once per frame


    
}

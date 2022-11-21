using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour

{


    private Transform Player;

    private Vector3 tmpPos;

    [SerializeField]
    private float minX, maxX;

 


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {


        if (!Player)
        {
            return;
        }

        tmpPos = transform.position;
        tmpPos.x = Player.position.x;

        if(tmpPos.x < minX)
        {
            tmpPos.x = minX;
        }
        if (tmpPos.x > maxX){ 
            tmpPos.x = maxX;
        }

        transform.position = tmpPos;
        
    }

    void CamEnd(){
        
    }


}

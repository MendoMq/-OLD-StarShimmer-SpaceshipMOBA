using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : MonoBehaviour
{
    
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) <= 0.1f){
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}

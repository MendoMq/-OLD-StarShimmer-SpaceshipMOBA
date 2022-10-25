using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject bigProjectilePrefab;
    public GameObject areaPrefab;
    // Start is called before the first frame update

    Camera camera;
    RaycastHit hit;

    public LayerMask layermask;

    void Start()
    {
        camera=GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            ShootSingle();
        }
        if(Input.GetMouseButtonDown(1)){
            ShootArea();
        }
    }

    
    void ShootSingle(){
        GameObject clone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        //clone.GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity, ForceMode.Impulse);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
    }

    void ShootArea(){
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, layermask)) {
            GameObject areaClone = Instantiate(areaPrefab, hit.point, Quaternion.identity);
            GameObject clone = Instantiate(bigProjectilePrefab, transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(hit.point - clone.transform.position) * 10, ForceMode.Impulse);
            clone.GetComponent<ExplosiveProjectile>().target = areaClone.transform;
        }
    }
}

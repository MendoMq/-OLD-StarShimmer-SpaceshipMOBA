using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Camera camera;
    public LayerMask layermask;
    Rigidbody rb;
    float vR=0;

    public float thrust=2;
    public float rotationalThrust=50f;
    public float autoRotateSpeed=1;

    public float lateralThrustMulti=0.5f;

    Quaternion deltaRotation;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        camera=GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Input.GetMouseButton(1)){
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask)) {
                Vector3 targetDirection = hit.point - transform.position;
                Quaternion rot = Quaternion.LookRotation(targetDirection,Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, Time.deltaTime * autoRotateSpeed);
            }
            vR-=vR*Time.deltaTime*4;
            if(Input.GetKey(KeyCode.A)){
                rb.AddForce(-transform.right * (thrust*lateralThrustMulti));
            }
            if(Input.GetKey(KeyCode.D)){
                rb.AddForce(transform.right * (thrust*lateralThrustMulti));
            }
        }else{
            if(Input.GetKey(KeyCode.A)){
                vR+=-rotationalThrust*Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.D)){
                vR+=rotationalThrust*Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.Space)){
            if((Mathf.Abs(rb.velocity.x)+Mathf.Abs(rb.velocity.z)) > 0.01f){
                rb.velocity=new Vector3(rb.velocity.x - rb.velocity.x*(Time.deltaTime)*2, rb.velocity.y, rb.velocity.z - rb.velocity.z*(Time.deltaTime)*2);
            }else{
                rb.velocity=Vector3.zero;
            }
            
            vR-=vR*Time.deltaTime*2;
        }else{
            if(Input.GetKey(KeyCode.W)){
                rb.AddForce(transform.forward * thrust);
            }
            if(Input.GetKey(KeyCode.S)){
                rb.AddForce(-transform.forward * (thrust*lateralThrustMulti));
            }
            
            if(Input.GetKey(KeyCode.Q)){
                rb.AddForce(-transform.right * (thrust*lateralThrustMulti));
            }
            if(Input.GetKey(KeyCode.E)){
                rb.AddForce(transform.right * (thrust*lateralThrustMulti));
            }
            
            
        }

        

        deltaRotation = Quaternion.Euler(new Vector3(0, vR, 0) * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}

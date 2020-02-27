using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour {

    public float tapForce = 10;
    public float tiltSmooth = 5;
    public Vector3 startPos;

    Rigidbody2D rigidBody;
    Quaternion downRotation;
    Quaternion forwardRotation;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0,0,-90);
        forwardRotation = Quaternion.Euler(0,0,35);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//tap notification
        {
            transform.rotation = forwardRotation;
            rigidBody.velocity = Vector3.zero;
            rigidBody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "ScoreZone") { 
            //regester score event
            //play a sound
        }
        if (col.gameObject.tag == "DeadZone")
        {
            //freeze bird where hits
            rigidBody.simulated = false;

            //register a dead event
            //play a sound
        }
    }
}

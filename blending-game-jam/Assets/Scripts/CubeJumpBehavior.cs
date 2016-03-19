using UnityEngine;
using System.Collections;

public class CubeJumpBehavior : MonoBehaviour {

    public float delay = 1f;
    private float _delay;
    public float jumpForce = 10f;
    // Use this for initialization
    void Start () {
    _delay = delay;
    }
    
    // Update is called once per frame
    void Update () {
        if(_delay > 0f){
            _delay -= Time.deltaTime;
        }
        else{
            Rigidbody rb;
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.up * jumpForce);
            _delay = delay;
        }
    
    }
}

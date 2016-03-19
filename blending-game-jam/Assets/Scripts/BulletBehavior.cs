using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class BulletBehavior : MonoBehaviour {

    public float bulletSpeed = 100f;
    public Cube.Type type_killed;
    public float lifeTime = 3f;

    // Use this for initialization
    void Start () {
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * bulletSpeed);
    }
    
    // Update is called once per frame
    void Update () {
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0) {
            Dies();
        }
    }

    public void Dies(){
        Destroy(gameObject);
    }
}
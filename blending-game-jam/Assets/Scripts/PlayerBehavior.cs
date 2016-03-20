using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {
    public GameObject player;
    public float repulsionPower = 100f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    public void OnTriggerEnter(Collider other){
        GameObject monster = other.gameObject;
            print(monster.tag);
        if(monster.tag == "Monster"){
            monster.transform.GetComponent<MonsterMove>().delay = 2f;
            Vector3 direction = transform.forward*-1;
            Rigidbody rb;
            rb = GetComponent<Rigidbody>();
            print(direction* repulsionPower);
            rb.AddForce(direction * repulsionPower);
            }
    }
}

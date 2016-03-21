using UnityEngine;
using System.Collections;

public class StreetBehavior : MonoBehaviour {
    public Transform collider;
    public int id;
    public GenerateStreet generator;
    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    public void OnTriggerEnter(Collider other){
            if(other.gameObject.tag=="Player"){
                generator.StreetFinish(id);
            }
        }
}

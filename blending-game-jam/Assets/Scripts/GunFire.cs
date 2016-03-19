using UnityEngine;
using System.Collections;


public class GunFire : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }
    
    public void Fire() {
    GameObject instance = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
    instance.transform.position = transform.position;
    /*instance.transform.parent = transform;*/
    instance.transform.rotation = transform.rotation;
}
}

using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {
    public float fire_delay = 0f;

    public GunFire gun_fire;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        if (fire_delay > 0){
        fire_delay -= Time.deltaTime;
        }
        if(Input.GetMouseButtonDown(0)){
            Fire();
        }
    
    }

    private void Fire(){
        if (fire_delay > 0f) {
            fire_delay -= Time.deltaTime;
            return;
        }
        fire_delay = 0f;
        gun_fire.Fire();
        fire_delay = 0.5f;
        }
}

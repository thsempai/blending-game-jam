using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    public enum Type{Vampire, Zombie, Werewolf};
    public Type type;
    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    public void OnCollisionEnter(Collision collision){
        BulletBehavior bulletBehavior = collision.gameObject.GetComponent<BulletBehavior>();
        if(bulletBehavior != null){
            if(bulletBehavior.type_killed == type){
                DiesByBullet();
            }
        }
    }

    private void DiesByBullet(){
        Dies();
    }

    private void Dies(){
        Destroy(gameObject);
    }
}

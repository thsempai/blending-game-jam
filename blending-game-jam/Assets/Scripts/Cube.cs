using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    public enum Type{vampire, zombie, werewolf};
    public enum Part{head, body, legs}
    public Part part;
    public Type type;
    // Use this for initialization
    void Start () {
    string part_name = type.ToString() + '-' + part.ToString();
    for(int index=0; index < transform.childCount; index++) {
        Transform child = transform.GetChild(index);
        Texture texture =  Resources.Load(part_name) as Texture;
        if(child.transform.name == "default"){
            child.gameObject.GetComponent<Renderer>().material.mainTexture = texture;}}
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    public void OnCollisionEnter(Collision collision){
        BulletBehavior bulletBehavior = collision.gameObject.GetComponent<BulletBehavior>();
        if(bulletBehavior != null){
            print("Boom");
            if(bulletBehavior.type_killed == type){
                bulletBehavior.Dies();
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

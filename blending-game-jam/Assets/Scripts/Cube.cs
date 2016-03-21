using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    public enum Type{vampire, zombie, werewolf};
    public enum Part{head, body, legs}
    public Part part;
    public Type type;

    public AudioSource fail;
    public AudioSource die;
    float die_delay = 0f;
    bool died = false;

    // Use this for initialization
    void Start () {

    }

    public void Generate(){
        string part_name = type.ToString() + '-' + part.ToString();
        for(int index=0; index < transform.childCount; index++) {
            Transform child = transform.GetChild(index);
            Texture texture =  Resources.Load(part_name) as Texture;
            if(child.transform.name == "default"){
                child.gameObject.GetComponent<Renderer>().material.mainTexture = texture;}}
    
    }
    
    // Update is called once per frame
    void Update () {
        if(die_delay >0){
            die_delay -= Time.deltaTime;
        }
        else if(died){
            Dies();
        }
    }

    public void OnCollisionEnter(Collision collision){
        BulletBehavior bulletBehavior = collision.gameObject.GetComponent<BulletBehavior>();
        if(bulletBehavior != null){
            if(bulletBehavior.type_killed == type){
                if(!bulletBehavior.alreayKill){
                    bulletBehavior.alreayKill = true;
                    bulletBehavior.Dies();
                    DiesByBullet(bulletBehavior.transform.forward);
                }
            }
            else{
                fail.Play();
            }
        }
    }

    private void HitFail(){
        fail.Play();
    }
    private void DiesByBullet(Vector3 direction){
        if(died)
            return;
        die.Play();
        transform.parent.parent.GetComponent<MonsterMove>().RemovePart();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        transform.parent = null;
        rb.AddForce(direction * 200);
        die_delay = 1f;
        died = true;
        /*Dies();*/
    }

    private void Dies(){
        Destroy(gameObject);
    }
}

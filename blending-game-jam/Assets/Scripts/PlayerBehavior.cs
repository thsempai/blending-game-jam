using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerBehavior : MonoBehaviour {
    public GameObject player;
    public float repulsionPower = 100f;
    public int healthPoint = 3;
    public float invincible = 0f;
    public AudioSource hit;
    public AudioSource dying;
    public bool died = false;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update () {
        if(invincible > 0){
            invincible -= Time.deltaTime;
        }
        else if(died){
            SceneManager.LoadScene("test");
        }
    
    }


    private void FreezeControl(){
        //isControllable = false; // disable player controls.
        GetComponent<FirstPersonController>().enabled = false;
    }

    public void OnTriggerStay(Collider other){
        GameObject monster = other.gameObject;
        if(monster.tag == "Monster"){
            if(invincible<=0f && !died){
                invincible = 2f;
                healthPoint-=1;
                if(healthPoint <= 0){
                    dying.Play();
                    died = true;
                    FreezeControl();
                }
                else{
                    hit.Play();
                }
                monster.transform.parent.parent.GetComponent<MonsterMove>().delay = 2f;
                /*Vector3 direction = transform.forward*-1;
                Rigidbody rb;
                rb = GetComponent<Rigidbody>();
                rb.AddRelativeForce(direction * repulsionPower);*/

                }
            }
    }
}

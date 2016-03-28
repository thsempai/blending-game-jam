﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Events;

public class PlayerBehavior : MonoBehaviour {
    public GameObject player;
    public float repulsionPower = 100f;
    public int healthPoint = 3;
    public float invincible = 0f;
    public AudioSource hit;
    public AudioSource dying;
    public bool died = false;
    public bool godMode = false;
    private float xStartPosition;
    public int scoreWalk;
    public int scoreHit;
    public int score;

    public UnityEvent healtPointUI;
    public UnityEvent godModeUI;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        xStartPosition = transform.position.x;
    }
    
    // Update is called once per frame
    void Update () {
        if(godMode){
            godModeUI.Invoke();
        }
        if(invincible > 0){
            invincible -= Time.deltaTime;
        }
        else if(died){
            SceneManager.LoadScene("test");
        }

        int newScore = (int)((transform.position.x - xStartPosition)/10);
        print(newScore);
        if(newScore> scoreWalk){
            scoreWalk = newScore;
        }
        score = scoreHit + scoreWalk;
    }


    private void FreezeControl(){
        //isControllable = false; // disable player controls.
        GetComponent<FirstPersonController>().enabled = false;
    }

    public void OnTriggerStay(Collider other){
        GameObject monster = other.gameObject;
        if(monster.tag == "Monster"){
            if(invincible<=0f && !died && !godMode){
                invincible = 2f;
                healthPoint-=1;
                healtPointUI.Invoke();
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

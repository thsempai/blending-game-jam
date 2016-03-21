﻿using UnityEngine;
using System.Collections;

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
            Application.LoadLevel("test");
        }
    
    }

    public void OnTriggerEnter(Collider other){
        GameObject monster = other.gameObject;
            print(monster.tag);
        if(monster.tag == "Monster"){
                print("test");
            if(invincible<=0f){
                invincible = 2f;
                healthPoint-=1;
                if(healthPoint<=0){
                    GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                    died = true;
                    dying.Play();
                }
                else{
                hit.Play();
                }
                monster.transform.GetComponent<MonsterMove>().delay = 4f;
                Vector3 direction = transform.forward*-1;
                Rigidbody rb;
                rb = GetComponent<Rigidbody>();
                rb.AddForce(direction * repulsionPower);
                }
            }
    }
}

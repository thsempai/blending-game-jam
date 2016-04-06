using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class MonsterMove : MonoBehaviour {

    public float delay=0f;
    public int partDied=0;
    public float distanceReact;
    public bool monsterFreeze = false;
    public bool playerNearest = false;
    GameObject player;
    NavMeshAgent navMeshAgent;
    public float speed= 3f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
        navMeshAgent.Stop();
    }
    
    // Update is called once per frame
    void Update () {
    float distancePlayer = Vector3.Distance(player.transform.position, transform.position);
    if(distanceReact > distancePlayer){
        if(!monsterFreeze){
            playerNearest = true;
            }
        }

    if(partDied>= 3){
        Dies();
        return;
    }

    if(delay>0f){
        delay -= Time.deltaTime;
        navMeshAgent.Stop();
        }
    else if(!monsterFreeze && playerNearest){
        navMeshAgent.Resume();
        navMeshAgent.destination = player.transform.position;
    }
    }
    public void RemovePart(){
        partDied += 1;
        navMeshAgent.speed -= 0.7f;
        delay = 0.5f;
    }
    private void Dies(){
        Destroy(gameObject);
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class MonsterMove : MonoBehaviour {

    public float delay=0f;
    public int partDied=0;
    GameObject player;
    NavMeshAgent navMeshAgent;
    float speed= 3f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
    }
    
    // Update is called once per frame
    void Update () {
    if(partDied>= 3){
        Dies();
        return;
    }

    if(delay>0f){
        delay -= Time.deltaTime;
        navMeshAgent.Stop();
        }
    else{
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

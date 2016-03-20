using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class MonsterMove : MonoBehaviour {

    public float delay=0f;
    public int partDied=0;
    GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update () {
    if(partDied>= 3){
        Dies();
        return;
    }
    NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
    if(delay>0f){
        delay -= Time.deltaTime;
        navMeshAgent.Stop();
        }
    else{
        navMeshAgent.Resume();
        navMeshAgent.destination = player.transform.position;
    }
    }

    private void Dies(){
        Destroy(gameObject);
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class MonsterMove : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
    navMeshAgent.destination = Vector3.zero;
    }
}

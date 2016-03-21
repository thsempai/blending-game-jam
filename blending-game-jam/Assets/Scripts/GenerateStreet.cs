using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateStreet : MonoBehaviour {
    public List<GameObject> streets = new List<GameObject>();
    public GameObject startStreet;
    // Use this for initialization
    void Start () {
        streets.Add(startStreet);
        for(int index=1; index<10;index++){
            AddStreet();
        }
    
    }
    
    void AddStreet(){
        GameObject instance = Instantiate(Resources.Load("street", typeof(GameObject))) as GameObject;
        int index = streets.Count;
        Vector3 position = streets[index-1].transform.position;
        instance.GetComponent<StreetBehavior>().id = index;
        instance.GetComponent<StreetBehavior>().generator = this;
        streets.Add(instance);
        position.x += 30f;
        instance.transform.position = position;
    }
    // Update is called once per frame
    void Update () {
    
    }

    public void StreetFinish(int id){
        AddStreet();
    }
}

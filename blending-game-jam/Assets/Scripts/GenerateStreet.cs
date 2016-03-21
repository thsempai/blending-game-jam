using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateStreet : MonoBehaviour {
    public List<GameObject> streets = new List<GameObject>();
    public GameObject startStreet;
    public int startStreetsForward = 10;
    public int startStreetsBackward = 5;
    public float offset = 30f;


    void Start(){
        // add start street
        for(int index=0; index < startStreetsBackward; index++){
            AddStreet();
        }

        streets.Add(startStreet);

        for(int index=0; index < startStreetsForward; index++){
            AddStreet();
        }
    }

    private void AddStreet(){
        int actualIndex = streets.Count - 1;

        Vector3 position;

        if(actualIndex== -1){
            position = startStreet.transform.position;
            position.x -= startStreetsBackward * offset;
        }
        else{
            position = streets[actualIndex].transform.position;
            position.x += offset;
        }

        Quaternion rotation = startStreet.transform.rotation;

        GameObject instance = Instantiate(Resources.Load("street", typeof(GameObject)), position, rotation) as GameObject;
        streets.Add(instance);
    }

}

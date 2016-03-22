using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateStreet : MonoBehaviour {
    public List<GameObject> streets = new List<GameObject>();
    public List<int> streetsIdAlreayPassed = new List<int>();
    public GameObject startStreet;
    public int startStreetsForward = 10;
    public int startStreetsBackward = 5;
    public float offset = 30f;
    public int numberMaxOfStreet = 16;
    private int streetCount = 1;


    void Start(){
        // add start street
        if (numberMaxOfStreet < startStreetsForward + startStreetsBackward + 1){
            numberMaxOfStreet = startStreetsForward + startStreetsBackward + 1;
        }

        for(int index=0; index < startStreetsBackward; index++){
            AddStreet();
        }

        startStreet.GetComponent<StreetBehavior>().generator = this;
        startStreet.GetComponent<StreetBehavior>().id = streets.Count;
        streets.Add(startStreet);
        startStreet.transform.Find("wall").gameObject.SetActive(true);
        startStreet.GetComponent<StreetBehavior>().Initialize();

        for(int index=0; index < startStreetsForward; index++){
            AddStreet();
        }
    }

    private void AddStreet(){
        int actualIndex = streets.Count - 1;

        Vector3 position;
        Quaternion rotation;

        if(actualIndex== -1){
            position = startStreet.transform.position;
            position.x -= startStreetsBackward * offset;
            rotation = startStreet.transform.rotation;
        }
        else{
            position = streets[actualIndex].transform.position;
            position.x += offset;
            rotation = streets[actualIndex].transform.rotation;
        }


        GameObject instance = Instantiate(Resources.Load("street", typeof(GameObject)), position, rotation) as GameObject;
        streets.Add(instance);
        StreetBehavior streetBehavior = instance.transform.GetComponent<StreetBehavior>();
        streetBehavior.generator = this;
        streetBehavior.id = actualIndex + 1;
        streetBehavior.Initialize();
        streetCount +=1;
    }

    private void RemoveStreet(){
        int id = streets.Count - 1 - numberMaxOfStreet;
        Destroy(streets[id]);
        streetCount -= 1;
    }

    public void FinishStreet(int id)
    {
        if(streetsIdAlreayPassed.Contains(id)){
            return;
        }

        GameObject street = streets[id];
        AddStreet();
        streetsIdAlreayPassed.Add(id);

        street.transform.Find("wall").gameObject.SetActive(true);

        if (streetCount > numberMaxOfStreet) {
            RemoveStreet();
        }
    }

}

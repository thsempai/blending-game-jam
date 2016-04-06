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
    public bool resetScore = false;
    private int streetCount = 1;
    private int level = 1;

    void Start(){
        if(resetScore) PlayerPrefs.SetInt("hightest score", 0);
        // add start street
        if (numberMaxOfStreet < startStreetsForward + startStreetsBackward + 1){
            numberMaxOfStreet = startStreetsForward + startStreetsBackward + 1;
        }

        for(int index=0; index < startStreetsBackward; index++){
            AddStreet(0);
        }

        startStreet.GetComponent<StreetBehavior>().generator = this;
        startStreet.GetComponent<StreetBehavior>().id = streets.Count;
        streets.Add(startStreet);
        startStreet.transform.Find("wall").gameObject.SetActive(true);
        StreetBehavior startStreetBehavior = startStreet.GetComponent<StreetBehavior>();
        startStreetBehavior.difficulty = 0;
        startStreetBehavior.monstersNumber = 0;
        startStreetBehavior.Initialize();

        for(int index=0; index < startStreetsForward; index++){
            AddStreet(level);
            level++;
        }
    }

    private void AddStreet(int level){
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

        if(level==0){
            streetBehavior.monstersNumber = 0;
            streetBehavior.side = 1;
            streetBehavior.difficulty = 0;
        }
        else{
            streetBehavior.difficulty = level;
        }
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
        AddStreet(1);
        streetsIdAlreayPassed.Add(id);

        street.transform.Find("wall").gameObject.SetActive(true);

        if (streetCount > numberMaxOfStreet) {
            RemoveStreet();
        }
    }

}

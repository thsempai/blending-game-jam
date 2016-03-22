using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StreetBehavior : MonoBehaviour {
    public int id;
    public GenerateStreet generator;

    public int monstersNumber = 2;
    public int cutting = 16;
    public float yMonsterPosition = 5f;
    // Use this for initialization
    
    public void Initialize () {
        // find nearest the power of 2
        cutting  = (int)Mathf.Pow(Mathf.Floor(Mathf.Sqrt(cutting)),2);
        if(monstersNumber > cutting){
            monstersNumber = cutting;
        }
        AddMonsters();
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    private void AddMonsters(){
        List<Vector3> monstersPosition = new List<Vector3>();
        int axePart = (int)Mathf.Sqrt(cutting);
        float partWidth = generator.offset/axePart;

        Quaternion rotation = transform.rotation;
        for(int index=0; index < monstersNumber; index++){
            Vector3 position;

            {
                float x = Random.Range(0,axePart) * partWidth + partWidth /2;
                float z = Random.Range(0, axePart) * partWidth + partWidth /2;
                position = new Vector3(x , yMonsterPosition, z);
                //position = new Vector3()
            }
            while(monstersPosition.Contains(position));
            monstersPosition.Add(position);
            GameObject instance = Instantiate(Resources.Load("monster", typeof(GameObject)), position, rotation) as GameObject;
        }

    }

    public void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
        generator.FinishStreet(id);
        }
    }

}

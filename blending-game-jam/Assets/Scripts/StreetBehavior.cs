using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StreetBehavior : MonoBehaviour {
    public enum Formation{triangle, reversedTriangle, diamond, line}
    public int id;
    public GenerateStreet generator;

    public int monstersNumber = 2;
    public int side = 4;
    private int cutting;
    public Formation formation;
    public float yMonsterPosition = 5f;
    // Use this for initialization
    
    public void Initialize () {
        // find nearest the power of 2
        if(side % 2 == 0){
            side--;
        }
        cutting  = (int)Mathf.Pow(side,2);
        int maxMonster = 0;

        switch(formation){
            case Formation.triangle: case Formation.reversedTriangle:
                maxMonster = (int)Mathf.Pow((side+1)/2, 2);break;
            case Formation.diamond:
                maxMonster = (int)(Mathf.Pow((side+1)/2, 2) + Mathf.Pow((side)/2, 2));break;
            case Formation.line:
                maxMonster = side; break;
        }

        if(monstersNumber > maxMonster){
            monstersNumber = maxMonster;
        }
        AddMonsters();
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    private void AddMonsters(){

        switch(formation){
            case Formation.triangle: AddMonsterOnTriangle(); break;
            case Formation.reversedTriangle: AddMonsterOnReversedTriangle(); break;
            case Formation.diamond: AddMonsterOnDiamond(); break;
            case Formation.line: AddMonsterOnline(); break;
        }
    }

    private void AddMonsterOnTriangle(){
        float partWidth = generator.offset/side;
        Quaternion rotation = transform.rotation;
        int middle = (int)(side/2);
        int x = middle;
        int z = middle;

        for(int index=0; index < monstersNumber; index++){
            Vector3 position = transform.position;
            position.x += x * partWidth - (generator.offset - partWidth) / 2;
            position.z += z * partWidth - (generator.offset - partWidth) / 2;

            GameObject instance = Instantiate(Resources.Load("monster", typeof(GameObject)), position, rotation) as GameObject;
            instance.transform.parent = transform;

            //recompute position
            if(z == middle){
                z += 1;
            }
            else{
                int step = Mathf.Abs(middle - z);

                if(z < middle){
                    if(step >= 2 * middle - x){
                        z = middle;
                        x += 1;
                    }
                    else{
                        z = middle + step + 1;
                    }
                }
                else{
                        z = middle - step;
                }
            }   
        }
    }

    private void AddMonsterOnReversedTriangle(){
        float partWidth = generator.offset/side;
        Quaternion rotation = transform.rotation;
        int middle = (int)(side/2);
        int x = middle * 2;
        int z = middle;

        for(int index=0; index < monstersNumber; index++){
            Vector3 position = transform.position;
            position.x += x * partWidth - (generator.offset - partWidth) / 2;
            position.z += z * partWidth - (generator.offset - partWidth) / 2;

            GameObject instance = Instantiate(Resources.Load("monster", typeof(GameObject)), position, rotation) as GameObject;
            instance.transform.parent = transform;

            //recompute position
            if(z == middle){
                z += 1;
            }
            else{
                int step = Mathf.Abs(middle - z);
  
                if(z < middle){
                    if(step >= x - middle){
                        z = middle;
                        x -= 1;
                    }
                    else{
                        z = middle + step + 1;
                    }
                }
                else{
                        z = middle - step;
                }
            }   
        }
    }


    private void AddMonsterOnDiamond(){
        float partWidth = generator.offset/side;
        Quaternion rotation = transform.rotation;
        int middle = (int)(side/2);
        int x = middle;
        int z = middle;
        int firstPart = monstersNumber - (int)Mathf.Pow(side/2, 2);
        int secondPart = monstersNumber - firstPart;

        for(int index=0; index < firstPart; index++){
            Vector3 position = transform.position;
            position.x += x * partWidth - (generator.offset - partWidth) / 2;
            position.z += z * partWidth - (generator.offset - partWidth) / 2;

            GameObject instance = Instantiate(Resources.Load("monster", typeof(GameObject)), position, rotation) as GameObject;
            instance.transform.parent = transform;

            //recompute position
            if(z == middle){
                z += 1;
            }
            else{
                int step = Mathf.Abs(middle - z);

                if(z < middle){
                    if(step >= x){
                        z = middle;
                        x -= 1;
                    }
                    else{
                        z = middle + step + 1;
                    }
                }
                else{
                        z = middle - step;
                }
            }   
        }
        x = middle + 1;
        z = middle;

        for(int index=0; index < secondPart; index++){
            Vector3 position = transform.position;
            position.x += x * partWidth - (generator.offset - partWidth) / 2;
            position.z += z * partWidth - (generator.offset - partWidth) / 2;

            GameObject instance = Instantiate(Resources.Load("monster", typeof(GameObject)), position, rotation) as GameObject;
            instance.transform.parent = transform;

            //recompute position
            if(z == middle){
                z += 1;
            }
            else{
                int step = Mathf.Abs(middle - z);
                if(z < middle){
                    if(step >= middle - (x - middle)) {
                        z = middle;
                        x += 1;
                    }
                    else{
                        z = middle + step + 1;
                    }
                }
                else{
                        z = middle - step;
                }
            }   
        }
    }

    private void AddMonsterOnline(){
        float partWidth = generator.offset/side;
        Quaternion rotation = transform.rotation;
        int middle = (int)(side/2);
        int x = middle;
        int z = middle;

        for(int index=0; index < monstersNumber; index++){
            Vector3 position = transform.position;
            position.x += x * partWidth - (generator.offset - partWidth) / 2;
            position.z += z * partWidth - (generator.offset - partWidth) / 2;

            GameObject instance = Instantiate(Resources.Load("monster", typeof(GameObject)), position, rotation) as GameObject;
            instance.transform.parent = transform;

            //recompute position
            if(z == middle){
                z += 1;
            }
            else{
                int step = Mathf.Abs(middle - z);

                if(z < middle){
                    z = middle + step + 1;
                }
                else{
                        z = middle - step;
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
        generator.FinishStreet(id);
        }
    }

}

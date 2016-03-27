using UnityEngine;
using System.Collections;

public class CreateMonster : MonoBehaviour {

    // Use this for initialization
    public bool monsterStatic = false;
    public int monsterPart = 1;

    public void Initialize () {
    if(!monsterStatic){
        int rnd = 1;
        for(int index=0; index<transform.childCount;index++){
            Transform child = transform.GetChild(index);
            Cube cube = child.GetComponent<Cube>();
            if(cube != null){
                if(monsterPart > 0){
                rnd = Random.Range(1,4);
                }
                monsterPart--;
                switch(rnd){
                    case 1: cube.type = Cube.Type.zombie;break;
                    case 2: cube.type = Cube.Type.vampire;break;
                    case 3: cube.type = Cube.Type.werewolf;break;
                }
                cube.Generate();
            }
        }
    }
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}

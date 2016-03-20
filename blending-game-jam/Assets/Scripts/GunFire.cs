using UnityEngine;
using System.Collections;


public class GunFire : MonoBehaviour {

    // Use this for initialization
    Cube.Type type;
    float delay = 0f;
    public GameObject holy;
    public GameObject garlic;
    public GameObject silver;
    int index=0;
    void Start () {
    
    }

    public void Update(){
        if(delay > 0){
            delay -= Time.deltaTime;
            return;
        } 
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if (wheel < 0){
            index -= 1;
            delay += 0.3f;
        }
        else if(wheel > 0){
            index += 1;
            delay += 0.3f;
        }
        
        if(index > 2){
            index = 0;
        }
        else if(index < 0){
            index = 2;
        }

        holy.SetActive(false);
        garlic.SetActive(false);
        silver.SetActive(false);

        switch(index){
            case 0:
            holy.SetActive(true);
            type = Cube.Type.zombie;
            break;
            case 1:
            garlic.SetActive(true);
            type = Cube.Type.vampire;
            break;
            case 2:
            silver.SetActive(true);
            type = Cube.Type.werewolf;
            break;
        }
    }
    
    public void Fire() {
    GameObject instance = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
    instance.transform.GetComponent<BulletBehavior>().type_killed = type;
    instance.transform.position = transform.position;
    /*instance.transform.parent = transform;*/
    instance.transform.rotation = transform.rotation;
}
}

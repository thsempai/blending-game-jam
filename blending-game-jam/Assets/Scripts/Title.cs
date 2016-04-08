using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

public void Quit(){
    Quit();
}

public void Menu(){
    SceneManager.LoadScene("title");
}

public void play(){
    SceneManager.LoadScene("test");
}


public void credit(){
    SceneManager.LoadScene("credits");
}
}
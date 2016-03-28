using UnityEngine;
using System.Collections;

public class PlayerHeadAnime : MonoBehaviour {
    public Animator animator;
    // Use this for initialization
    void Start () {
    animator = GetComponent<Animator>();
    }

    public void SetGodMode(bool actived){
        animator.SetBool("godMode", actived);
    }

    public void Beat(){
        int wounds = animator.GetInteger("wounds");
        wounds++;
        animator.SetInteger("wounds", wounds);
    }
}

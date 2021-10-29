using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoorMotion : MonoBehaviour
{
    private Animator animator;
    private AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        animator.SetBool("open", true);
        doorSound.PlayDelayed(0.5f);   
    }

    private void OnTriggerExit(Collider other){
        animator.SetBool("open", false); 
        doorSound.PlayDelayed(0.5f);   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

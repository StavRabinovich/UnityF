using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator animator;
    private AudioSource doorSqueak;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorSqueak = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        animator.SetBool("DoorIsOpening", true);
        doorSqueak.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorIsOpening", false);
        doorSqueak.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitScript : MonoBehaviour
{
    
    private Animator animator;
    private string myTeam;
    private int hitCount;
    private bool canGetHit = true;
    public bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        this.myTeam = this.gameObject.tag;
        this.hitCount = 2;
        isAlive = true;
    }
    public IEnumerator shootBullet(GameObject bulletClone)
    {
        yield return new WaitForSeconds(2f);
        bulletClone.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if(other.gameObject.tag.Equals("Bullet")&& canGetHit)
        {
            canGetHit = false;
            animator.SetInteger("state", 2);
            print("hit");
            StartCoroutine(getHit());
            hitCount--;
            canGetHit = true;
        }
    }

    IEnumerator getHit()
    {
        if(hitCount > 0)
        {
            yield return new WaitForSeconds(0.5f);
            animator.SetInteger("state", 0);
        }
        else
        {
            animator.SetInteger("state", 3);
        }
        print("Hitcount = " + hitCount + "");
    }
}

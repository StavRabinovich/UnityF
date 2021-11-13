using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class N1 : MonoBehaviour
{
    public Animator animator;
    private string myTeam;
    private int hitCount;
    private bool canGetHit = true;
    public bool isAlive;
    public GameObject endScreen;
    public QuitGame endScript;
    public GameObject finishPnl;
    public TextMeshProUGUI txtVictory;

    // Start is called before the first frame update
    void Start()
    {
        endScreen = GameObject.Find("EndGame");
        animator = GetComponent<Animator>();
        this.myTeam = this.gameObject.tag;
        this.hitCount = 2;
        isAlive = true;

    }
    public IEnumerator shootBullet(GameObject bulletClone)
    {
        yield return new WaitForSeconds(2f);
        bulletClone.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (other.gameObject.tag.Equals("Bullet") && canGetHit)
        {
            canGetHit = false;
            animator.SetInteger("state", 2);
            print("hit");
            StartCoroutine(getHit());
            hitCount = hitCount - 1;
            canGetHit = true;
        }
    }

    IEnumerator getHit()
    {
        if (hitCount > 0)
        {
            yield return new WaitForSeconds(0.5f);
            animator.SetInteger("state", 0);
        }
        else
        {  
            yield return new WaitForSeconds(0.5f);
            animator.SetInteger("state", 3);
            isAlive = false;
            print("dead");
            txtVictory.text = "Blue Victory!";
            finishPnl.GetComponent<QuitGame>().enemyAlive = false;
            //GameObject.Find("pnlBlue").GetComponent<blueBoard>().De
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

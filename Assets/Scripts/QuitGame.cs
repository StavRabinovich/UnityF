using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public AllyMotion enemy;
    bool enemyAlive;
    //Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<AllyMotion>();
        enemyAlive = enemy.isAlive;
        //enemy.isAlive = false;
    }

    // Update is called once per frame
    void Update()
    {

        getUpdate();
        if (enemyAlive)
            print("Enemy dead");
        else
            print("Enemy Alive");
        /*enemyElive = e
            print(enemy.isAlive);
            if (enemy.isAlive == false)
                print("End");*/
        //this.gameObject.SetActive(true);

    }
    public IEnumerator getUpdate()
    {
        enemyAlive = enemy.isAlive;
        yield return new WaitForSeconds(1f);
    }
    public void OnQuitPressed()
    {
        Application.Quit();
    }
}

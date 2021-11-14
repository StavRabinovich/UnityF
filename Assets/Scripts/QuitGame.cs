using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public bool enemyAlive;
    public GameObject endScreen;

    //Start is called before the first frame update
    void Start()
    {
        enemyAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        ///print("Enemy : " + enemyAlive);
        if (enemyAlive == false)
        {
            endScreen.SetActive(true);
        }
    }
    public void OnQuitPressed()
    {
        Application.Quit();
    }
}

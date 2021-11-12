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
        //this.endScreen = GameObject.Find("EndGame");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAlive == false)
        {
            endScreen.SetActive(true);
            print("blabla");
        }
    }
    public void OnQuitPressed()
    {
        Application.Quit();
    }
}

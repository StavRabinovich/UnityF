using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class redBoard : MonoBehaviour
{
    public TextMeshProUGUI shootText;
    public TextMeshProUGUI alertsText;
    public TextMeshProUGUI aliveText;
    public TextMeshProUGUI gunsText;
    public TextMeshProUGUI granadesText;

    public static int countAlive;
    public static int countGuns;
    public static int countGranades;





    // Start is called before the first frame update
    void Start()
    {
        countAlive = 2;
        countGuns = 0;
        countGranades = 0;
        aliveText.text = "Alive: \t\t\t" + countAlive;
        gunsText.text = "Guns: \t\t\t" + countGuns;
        granadesText.text = "Granades: \t\t" + countGranades;
    }


    private void DeadMember()
    {
        --countAlive;
        aliveText.text = "Alive: \t\t\t" + countAlive;
        if (countAlive == 0)
        {
            // EndGame - Blue Wins
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

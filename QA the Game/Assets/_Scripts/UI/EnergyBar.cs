using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{

    public PlayerMovement player;
    public Image content;
    float curContent;

    void Start()
    {
        curContent = player.curEnergy / player.maxEnergy;
        content.fillAmount = curContent;
    }

    public void updateEnergy()
    {
        Debug.Log("Reached updateEnergy");
        curContent = player.curEnergy / player.maxEnergy;
        content.fillAmount = curContent;
        Debug.Log("energy curContent= " + curContent);
    }
}

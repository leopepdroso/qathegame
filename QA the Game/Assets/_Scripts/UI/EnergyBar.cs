using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{

	public AttributeController playerAttributes;
    public Image content;
    float curContent;

    void Start()
    {
		curContent = playerAttributes.curEnergy / playerAttributes.maxEnergy;
        content.fillAmount = curContent;
    }

    public void updateEnergy()
    {
        Debug.Log("Reached updateEnergy");
		curContent = playerAttributes.curEnergy / playerAttributes.maxEnergy;
        content.fillAmount = curContent;
        Debug.Log("energy curContent= " + curContent);
    }
}

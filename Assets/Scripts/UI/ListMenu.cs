using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListMenu : MonoBehaviour
{
    public Image [] components;
    public void colorChange()
    {
        int step = GameManager.Instance.currentStep;
        components[step].color = new Color(135,221,138);
        components[step+1].color = new Color(105,216,221);
    }
}

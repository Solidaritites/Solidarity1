using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel;

    public void OpenThePanel()
    {
        if (panel.activeSelf == false)
        {
            panel.SetActive(true);
        }
    }

    public void HideThePanel()
    {
        if (panel.activeSelf == true)
        {
            panel.SetActive(false);
        }
    }
}

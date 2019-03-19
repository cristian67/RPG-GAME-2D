using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAttribute : MonoBehaviour
{
    public void SwitchButton(int pointAttribute)
    {
        if (pointAttribute > 0)
        {
            gameObject.SetActive(true);
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}

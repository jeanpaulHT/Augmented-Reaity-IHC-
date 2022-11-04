using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToScreenScript : MonoBehaviour
{
    public Canvas oldScreen;

    public Canvas newScreen;

    public void ChangeScreen()
    {
        oldScreen.enabled = false;
        newScreen.enabled = true; 
    }
}

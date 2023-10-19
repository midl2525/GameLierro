using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cell : MonoBehaviour
{
    public bool Active;

    public void UpdateInfo()
    {
        if(Active)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}

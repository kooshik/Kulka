using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpisodeTile : MonoBehaviour
{
    public Image imgSelected;
    public Image imgUnselected;

    public bool isSelected;

    public void Select(bool select)
    {
        isSelected = select;

        imgSelected.enabled = isSelected;
        imgUnselected.enabled = !isSelected;
    }
}

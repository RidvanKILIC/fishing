using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]
public class markContainer : MonoBehaviour
{
    public mark _mark;
    public TMP_Text distanceText;
    public mark getMark()
    {
        return _mark;
    }
    public void setMark(mark _mrk)
    {
        _mark = _mrk;
    }
    public void setDistance(float distance = 0f)
    {
        if (this.gameObject != null)
        {
            if (distance <= 0f)
            {
                transform.GetChild(1).GetComponent<TMP_Text>().text = string.Empty;
                if (!this._mark.getDiscoved())
                {
                    this._mark.setDiscovered(true);
                    UIManager.Uinstance.setAreaText(this._mark.getAreaName());
                }
                else if (this._mark.getAreaName().Contains("Fishing"))
                {
                    UIManager.Uinstance.activateFishing();
                }
            }
            else
            {
                transform.GetChild(1).GetComponent<TMP_Text>().text = distance.ToString();
                if (this._mark.getAreaName().Contains("Fishing"))
                {
                    UIManager.Uinstance.finishFishing();
                }
            }
            

        }
    }
}

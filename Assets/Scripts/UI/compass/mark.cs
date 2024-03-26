using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class mark : MonoBehaviour
{
    [SerializeField] public Sprite icn;
    [SerializeField] string areaName;
    bool discoved=false;
    // Start is called before the first frame update
    public Vector2 getPos()
    {
        return new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.z);
    }
    public Sprite getIcn()
    {
        return icn;
    }
    public string getAreaName()
    {
        return areaName;
    }
    public void setDiscovered(bool _state)
    {
        discoved = _state;
    }
    public bool getDiscoved()
    {
        return discoved;
    }
}
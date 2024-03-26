using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Anim : MonoBehaviour
{
    [SerializeField] Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setFishing(bool _state)
    {
        //_anim.SetBool("start/stop_Fishing", _state);
    }
    public void throwRod()
    {
        //_anim.SetTrigger("throwRod");
    }

    public void pullRod()
    {

    }
}

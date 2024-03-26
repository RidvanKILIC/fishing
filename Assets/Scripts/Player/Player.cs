using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool closeToArea=false;
    bool fishing=false;
    bool isStateChanged = false;
    [SerializeField] whaleMovement _whaleMovement;
    [SerializeField] player_Anim _anim;
    [SerializeField] FishingRod _fishingRod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setCloseToArea(bool _state)
    {
       
        if(_state != closeToArea)
        {
            closeToArea = _state;
            isStateChanged = true;
        }
        else
        {
            isStateChanged = false;
        }
        if(isStateChanged && !fishing)
        {
            if (_state)
                CameraController.CInstance.switchCamera(CameraController.CInstance.Wider);
            else
                CameraController.CInstance.switchCamera(CameraController.CInstance.Zoom);
        }
    }
    public void setFishing(bool _state)
    {
        _whaleMovement.setCanMove(!_state);
        fishing = _state;
        if (fishing)
        {
            CameraController.CInstance.switchCamera(CameraController.CInstance.Fishing,2f);
            Debug.Log("Fishing ");
        }
        else
        {
            CameraController.CInstance.switchCamera(CameraController.CInstance.Wider,2f);
        }
        _anim.setFishing(_state);
    }
    public bool isFishing()
    {
        return fishing;
    }
    public void throwRod()
    {
        _anim.throwRod();
        _fishingRod.throwRod();
    }
    public void pullRod()
    {
        _anim.pullRod();
    }

}

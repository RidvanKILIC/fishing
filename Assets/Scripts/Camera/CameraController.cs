using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor;
using Cinemachine;
[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
	[SerializeField]public CinemachineVirtualCamera Wider;
	[SerializeField]public CinemachineVirtualCamera Zoom;
	[SerializeField]public CinemachineVirtualCamera Fishing;
    [SerializeField] CinemachineBrain _CamBrain; 
	[SerializeField] List<CinemachineVirtualCamera> CamPool = new List<CinemachineVirtualCamera>();
	[SerializeField]CinemachineVirtualCamera activeCam;

	public static CameraController CInstance { get; set; }
    private void Awake()
    {
        if (CInstance == null)
        {
            CInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
		CamPool = new List<CinemachineVirtualCamera>() { Wider, Zoom, Fishing };
		setActivecam();
    }
	void setActivecam()
    {
		foreach(var item in CamPool)
        {
            if (activeCam == null)
            {
                activeCam = item;
            }
            else if(activeCam!=null)
            {
                if (activeCam.Priority < item.Priority)
                    activeCam = item;
            }
        }
    }
    public void switchCamera(CinemachineVirtualCamera _cam, float blendTime=4f)
	{
        _CamBrain.m_DefaultBlend.m_Time = blendTime;
        foreach(var item in CamPool)
        {
            if (item == _cam)
            {
                item.Priority =11;
            }
            else
            {
                item.Priority = 0;
            }
                
        }
        setActivecam();
	}

}
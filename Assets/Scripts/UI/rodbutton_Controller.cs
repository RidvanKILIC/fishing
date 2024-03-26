using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class rodbutton_Controller : MonoBehaviour
{
    [SerializeField] Button rodBtn;
    [SerializeField] TMP_Text rodText;
    [SerializeField] Player _playerScript;
    private void Start()
    {
        setBtn(0);
    }
    private void Update()
    {

    }
    /// <summary>
    /// 0 for Throw 1 for Pull
    /// </summary>
    /// <param name="_type"></param>
    public void setBtn(int _type =0)
    {
        if (_type == 0)
        {
            rodText.text = "Throw";
            rodBtn.onClick.AddListener(() => throwRod());
        }   
        else if (_type == 1)
        {
            rodText.text = "Pull";
            rodBtn.onClick.AddListener(() => pullRod());
        }
           
    }
    public void throwRod()
    {
        _playerScript.throwRod();
        setBtn(1);
    }
    public void pullRod()
    {
        _playerScript.pullRod();
        setBtn(0);
    }
}

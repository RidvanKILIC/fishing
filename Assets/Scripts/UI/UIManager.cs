using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject AreaPanel;
    [SerializeField] GameObject fishingControllerPanel;
    [SerializeField] GameObject WhaleControllerPanel;
    [SerializeField] GameObject StartFishingBtn;
    [SerializeField] GameObject FinishFishingBtn;
    [SerializeField] GameObject rodBtn;
    [SerializeField] TMP_Text areaText;
    [SerializeField] Player _playertController;

    [SerializeField] Windbutton_Controller whaleMovementBtnCont;
    public static UIManager Uinstance { get;set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (Uinstance == null)
            Uinstance = this;
        else
            Destroy(this);
    }
    private void Start()
    {
        if (!WhaleControllerPanel.activeInHierarchy)
            WhaleControllerPanel.SetActive(true);
        if (fishingControllerPanel.activeInHierarchy)
            fishingControllerPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void setAreaText(string _text = "")
    {
     
        if(!_text.Contains("Fishing"))
        {
            StartFishingBtn.SetActive(false);
        }
        areaText.text = _text;
        activeAreaPanel();
    }
    public void activeAreaPanel()
    {
        AreaPanel.SetActive(true);
        Invoke("deactiveAreaPanel", 3f);
    }
    public void activateFishing()
    {
        rodBtn.SetActive(false);
        fishingControllerPanel.SetActive(true);
        FinishFishingBtn.SetActive(false);
        StartFishingBtn.SetActive(true);
    }
    public void deactiveAreaPanel()
    {
        AreaPanel.SetActive(false);
    }
    public void startFishing()
    {
        whaleMovementBtnCont.setPower(0f);
        WhaleControllerPanel.SetActive(false);
        _playertController.setFishing(true);
        StartFishingBtn.SetActive(false);
        FinishFishingBtn.SetActive(true);
        rodBtn.SetActive(true);

    }
    public void finishFishing()
    {   
        _playertController.setFishing(false);
        if(FinishFishingBtn.activeInHierarchy)
            FinishFishingBtn.SetActive(false);
        if (StartFishingBtn.activeInHierarchy)
            StartFishingBtn.SetActive(false);
        fishingControllerPanel.SetActive(false);
        WhaleControllerPanel.SetActive(true);
        rodBtn.GetComponent<rodbutton_Controller>().setBtn(0);
    }
}

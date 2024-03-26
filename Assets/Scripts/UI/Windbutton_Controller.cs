using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Windbutton_Controller : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField]float power=0f;
    [SerializeField] float smoothTime = 0f;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setPower(1f);
            //StopCoroutine(powerDown());
            //StartCoroutine(powerUo());
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            setPower(0f);
            //StopCoroutine(powerUo());
            //StartCoroutine(powerDown());
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        setPower(1f);
        //StopCoroutine(powerDown());
        //StartCoroutine(powerUo());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        setPower(0f);
        //StopCoroutine(powerUo());
        //StartCoroutine(powerDown());
    }
    public void setPower(float _value)
    {
        power = _value;
    }
    public float getValue()
    {
        return power;
    }
    private IEnumerator powerUo()
    {
        float duration = 1f;
        while (power <= 1f)
        {
            power += Time.deltaTime / duration;
            yield return null;
        }
    }
    private IEnumerator powerDown()
    {
        float duration = 1f; 
        while (power > 0f)
        {
            power -= Time.deltaTime / duration;
            yield return null;
        }
    }
}

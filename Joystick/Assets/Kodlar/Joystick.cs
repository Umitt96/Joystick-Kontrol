using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    // event trigger ekleyip aşağıdaki fonksion isimlerini component olarak aktar
    public GameObject joystick, joyBG; // GUI nesneleri
    public static Vector2 JoyVector;
    private Vector2 touchpos, originalpos;
    private float joyRadius; //oynatma çapı
    public bool portatifmi;
    void Start()
    {
        originalpos = joyBG.transform.position;
        joyRadius = joyBG.GetComponent<RectTransform>().sizeDelta.y;
    }


    public void PointDown()
    {
       if(portatifmi){
        joystick.transform.position = Input.mousePosition;
        joyBG.transform.position = Input.mousePosition;
        }
        touchpos = Input.mousePosition;
    }

    public void Dragger(BaseEventData bevent)
    {
        // dokunduğun anda, x ve y koordinatlarını o değişken yapar.
        PointerEventData pointerdata = bevent as PointerEventData;
        Vector2 dragPos = pointerdata.position;
        JoyVector = (dragPos - touchpos).normalized;

        float joydist = Vector2.Distance(dragPos, touchpos);

        if (joydist < joyRadius)
            joystick.transform.position = touchpos + JoyVector * joydist;
        else
            joystick.transform.position = touchpos + JoyVector * joyRadius;
    }

    public void PointUp()
    {
        //dokunma bitince (eğer portatifse) mevcut konumuna geçer
        JoyVector = Vector2.zero;
        joystick.transform.position = originalpos;
        joyBG.transform.position = originalpos;
    }    
}

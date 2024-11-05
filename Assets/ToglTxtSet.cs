using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TexDrawLib;
public class ToglTxtSet : MonoBehaviour
{
    string ss;
    
    public void SetTxt(string s)
    {
        ss= s;
        Transform off = transform.Find("Label Off");
        Transform on = transform.Find("Label On");
        on.gameObject.SetActive(false);
        off.GetComponent<TEXDraw>().text = ss;
        off.GetComponent<TEXDraw>().size = 20;

    }

    public string RoadTxt()
    {
        Debug.Log(ss+"라고 입력 했어요 제발");
        return ss;
    }
}

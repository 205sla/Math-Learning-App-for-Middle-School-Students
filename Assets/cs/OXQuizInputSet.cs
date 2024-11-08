using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TexDrawLib;

public class OXQuizInputSet : MonoBehaviour
{
    public TMP_Text problemNumText;
    public GameObject problemStrText;

    public void SetProblemTxt(string problemNum="??", string problemStr = "??")
    {
        problemNumText.text = problemNum;
        problemStrText.GetComponent<TEXDraw>().text = problemStr;
    }
}


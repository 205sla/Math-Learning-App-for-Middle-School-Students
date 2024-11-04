using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OXQuizInputSet : MonoBehaviour
{
    public TMP_Text problemNumText;
    public TMP_Text problemStrText;

    public void SetProblemTxt(string problemNum="??", string problemStr = "??")
    {
        problemNumText.text = problemNum;
        problemStrText.text = problemStr;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TexDrawLib;
public class short_answerInputSet : MonoBehaviour
{
    public TMP_Text problemNumText;
    public GameObject problemStrText;
    public TMP_Text ansTxt;
    public TMP_Text HintText;

    public GameObject MainCode;

    public void SetProblemTxt(string problemNum = "??", string problemStr = "??", string Hint="정답을 입력하세요.")
    {
        problemNumText.text = problemNum;
        problemStrText.GetComponent<TEXDraw>().text = problemStr;
        ansTxt.text = "";
        HintText.text = Hint;
    }

    public void AnswerDonBtn()
    {
        MainCode.GetComponent<MoveManager>().InputAns(ansTxt.text);
    }
}

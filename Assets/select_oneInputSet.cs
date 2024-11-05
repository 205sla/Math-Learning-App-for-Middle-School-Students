using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TexDrawLib;
using Michsky.MUIP;

public class select_oneInputSet : MonoBehaviour
{
    public TMP_Text problemNumText;
    public GameObject problemStrText;
    public GameObject[] Toggles;


    public GameObject MainCode;




    public void SetProblemTxt(string problemNum = "??", string problemStr = "??", string Correctanswer = "??",
        string WrongAnswer1 = "??", string WrongAnswer2 = "??", string WrongAnswer3 = "??", string WrongAnswer4 = "??")
    {
        Debug.Log("ㅇㅇ");
        problemNumText.text = problemNum;
        problemStrText.GetComponent<TEXDraw>().text = problemStr;
        Toggles[0].GetComponent<CustomToggle>().UpdateState(false);
        Toggles[1].GetComponent<CustomToggle>().UpdateState(false);
        Toggles[2].GetComponent<CustomToggle>().UpdateState(false);
        Toggles[3].GetComponent<CustomToggle>().UpdateState(false);
        Toggles[4].GetComponent<CustomToggle>().UpdateState(false);
        SetToggleText(0, Correctanswer);
        SetToggleText(1, WrongAnswer1);
        SetToggleText(2, WrongAnswer2);
        SetToggleText(3, WrongAnswer3);
        SetToggleText(4, WrongAnswer4);
    }
    public void AnswerDonBtn()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Toggles[i].GetComponent<Toggle>().isOn)
            {
                Debug.Log(Toggles[i].GetComponent<ToglTxtSet>().RoadTxt());
                MainCode.GetComponent<MoveManager>().InputAns(Toggles[i].GetComponent<ToglTxtSet>().RoadTxt());
            }
        }
        
    }
    void SetToggleText(int toggleIndex, string value)
    {
        // 토글이 0이 아닌 값일 경우 텍스트를 설정, 0이면 비활성화
        if (value != null)
        {
            // 텍스트 설정
            Toggles[toggleIndex].gameObject.SetActive(true);  // 텍스트를 활성화
            Toggles[toggleIndex].GetComponent<ToglTxtSet>().SetTxt(value.ToString());
        }
        else
        {
            // 텍스트 비활성화
            Toggles[toggleIndex].gameObject.SetActive(false);
        }
    }
}

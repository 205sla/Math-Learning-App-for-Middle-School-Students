using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TexDrawLib;
using Michsky.MUIP;


public class select_multipleInputSet : MonoBehaviour
{
    public TMP_Text problemNumText;
    public GameObject problemStrText;
    public GameObject[] Toggles;


    public GameObject MainCode;
    // Start is called before the first frame update
    public void SetProblemTxt(string problemNum = "??", string problemStr = "??", string answer1 = "??",
       string answer2 = "??", string answer3 = "??", string answer4 = "??", string answer5 = "??")
    {
        Debug.Log("ㅇㅇ");
        problemNumText.text = problemNum;
        problemStrText.GetComponent<TEXDraw>().text = problemStr;
        Toggles[0].GetComponent<CustomToggle>().UpdateState(false);
        Toggles[1].GetComponent<CustomToggle>().UpdateState(false);
        Toggles[2].GetComponent<CustomToggle>().UpdateState(false);
        Toggles[3].GetComponent<CustomToggle>().UpdateState(false);
        Toggles[4].GetComponent<CustomToggle>().UpdateState(false); 
        SetToggleText(0, answer1);
        SetToggleText(1, answer2);
        SetToggleText(2, answer3);
        SetToggleText(3, answer4);
        SetToggleText(4, answer5);

    }

    // Update is called once per frame
    public void AnswerDonBtn()
    {
        string ans = "";
        for (int i = 0; i < 5; i++)
        {
            if (Toggles[i].GetComponent<Toggle>().isOn)
            {
                ans += (i+1).ToString();
                ans += ",";
            }
        }
        Debug.Log("제출한 답은" + RemoveLastChar(ans));
        MainCode.GetComponent<MoveManager>().InputAns(RemoveLastChar(ans));

    }

    string RemoveLastChar(string str)
    {
        if (str.Length > 0)
        {
            return str.Substring(0, str.Length - 1);
        }
        return str;  // 문자열이 빈 경우 그대로 반환
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

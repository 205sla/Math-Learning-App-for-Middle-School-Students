using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class EndPageSet : MonoBehaviour
{
    public GameObject[] Pip;
    public Toggle togle;

    public GameObject Bug;
    public GameObject Tog;

    string WrongProblemS = "";

    private static readonly Color32[] colors = new Color32[]
    {
        new Color32(255, 99, 71, 255),  // Tomato Red
        new Color32(255, 165, 0, 255),  // Orange
        new Color32(255, 223, 186, 255), // Peach
        new Color32(255, 105, 180, 255), // HotPink
        new Color32(255, 192, 203, 255), // Pink
        new Color32(255, 140, 0, 255),  // Dark Orange
        new Color32(144, 238, 144, 255), // Light Green
        new Color32(173, 216, 230, 255), // Light Blue
        new Color32(135, 206, 235, 255), // Sky Blue
        new Color32(240, 230, 140, 255), // Khaki
        new Color32(255, 250, 250, 255), // Snow
        new Color32(255, 239, 213, 255), // Papaya Whip
        new Color32(238, 130, 238, 255), // Violet
        new Color32(0, 255, 255, 255),   // Cyan
        new Color32(0, 255, 127, 255),   // Spring Green
        new Color32(50, 205, 50, 255),   // Lime Green
        new Color32(255, 69, 0, 255),    // Red Orange
        new Color32(255, 20, 147, 255),  // Deep Pink
        new Color32(221, 160, 221, 255), // Plum
        new Color32(100, 149, 237, 255), // Cornflower Blue
    };

    static Color32 GetRandomColor()
    {
        int randomIndex = Random.Range(0, colors.Length);  // 0부터 colors.Length - 1 사이의 랜덤 인덱스 생성
        return colors[randomIndex];  // 해당 인덱스의 색상을 반환
    }
    public void SetEndPage(List<string[]> L)
    {
        Bug.SetActive(true);
        Debug.Log("세팅해봐");
        Pip[0].GetComponent<PieChart>().ChangeValue(0, 20 - L.Count);
        Pip[0].GetComponent<PieChart>().ChangeValue(1, L.Count);
        Pip[0].GetComponent<PieChart>().UpdateIndicators();

        if (L.Count > 0) {
            Tog.SetActive(true);
            Dictionary<string, int> sectionProblemCount = new Dictionary<string, int>();

            // 리스트를 순회하며 문제 수를 셈
            foreach (var item in L)
            {
                string sectionName = item[0]; // 단원 이름
                WrongProblemS += item[1];
                WrongProblemS += "번, ";
                if (sectionProblemCount.ContainsKey(sectionName))
                {
                    sectionProblemCount[sectionName]++;
                }
                else
                {
                    sectionProblemCount[sectionName] = 1;
                }
            }

            int i = 0;
            // 결과 출력
            foreach (var entry in sectionProblemCount)
            {
                Pip[1].GetComponent<PieChart>().AddNewItem();
                Pip[1].GetComponent<PieChart>().ChangeValue(i, entry.Value);
                Pip[1].GetComponent<PieChart>().ChangeName(i, entry.Key);
                Pip[1].GetComponent<PieChart>().ChangeColor(i, GetRandomColor());
                i++;
            }

            

            Pip[1].GetComponent<PieChart>().UpdateIndicators();
            togleChang();


            //Bug.SetActive(false);
        }
        else
        {

            Tog.SetActive(false);
        }

        

    }

    public void SeePip0()
    {
        Pip[0].gameObject.SetActive(true);
        Pip[1].gameObject.SetActive(false);
    }
    public void SeePip1()
    {
        Pip[0].gameObject.SetActive(false);
        Pip[1].gameObject.SetActive(true);
    }

    public void togleChang() {
        ///*
        if(togle != null)
        {
            if (togle.isOn)
            {
                SeePip0();
            }
            else
            {
                SeePip1();
            }
        }
        else
        {
            Debug.Log("넌 뭐냐");
        }
        
   //*/
    }

}

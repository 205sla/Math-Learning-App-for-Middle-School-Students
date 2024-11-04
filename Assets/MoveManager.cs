using DG.Tweening;
using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Profiling;
using static mainCodeCs;

public class MoveManager : MonoBehaviour
{
    public string Progress = "";


    public Transform startBut;
    public GameObject[] Buttons;
    public GameObject page;
    public GameObject[] HomePageList;
    public GameObject[] InputFildList;
    bool 개념별학습, 오답학습;

    List<List<string>> problemList;
    int problemNum;

    public int StudyCos;
    void Start()
    {
        저장과불러오기();






    }

    private void Update()
    {
        if(Progress == "문제출제시작")
        {
            Progress = "문제출제중";
            SetProblem();
        }
    }
    void SeeProblem()
    {
        List<string> p = problemList[problemNum];
        if (p[4]== "oxQuiz")
        {
            InputFildList[0].gameObject.SetActive(true);
            InputFildList[0].GetComponent<OXQuizInputSet>().SetProblemTxt(problemNum+"번 문제", p[3]);

        }
        else
        {
            Debug.Log("일단은 보류여");
            //임시 코드여
            problemNum++;
            SeeProblem();
        }
    }

    void SetProblem()
    {
        problemList = GameObject.Find("MainCode").GetComponent<mainCodeCs>().RandRandomQuiz();
        problemNum = 0;
        Progress = "문제 출력";
        SeeProblem();
    }

    public void InputAns(string ans)
    {
        if(Progress== "문제풀기")
        {
            Progress = "채점";
            Debug.Log(ans);
        }
        
    }

    public void studyStartBtnDwn(int cos)
    {
        StudyCos = cos;
        page.transform.DOLocalMove(new Vector3(-1080*2, 0, 0), 1.0f).SetEase(Ease.OutBounce);
        Progress = "문제출제시작";
    }

    public void btndwn1()//학기별 버튼 누름
    {
        //page.DoLa
        page.transform.DOLocalMove(new Vector3(-1080, 0, 0), 1.0f).SetEase(Ease.OutBounce);
        Debug.Log("학기별 누름");
    }


    
    public void StartButDwn()//타이틀에서 시작버튼 누름
    {
        startBut.transform.DOScale(0, 0.3f).OnComplete(() =>
        {
            Buttons[0].gameObject.SetActive(true);
            if (개념별학습)
            {
                Buttons[1].gameObject.SetActive(true);

            }
            if (오답학습)
            {
                Buttons[2].gameObject.SetActive(true);
            }
        });
        
        

    }

    void 저장과불러오기()
    {
        if (ES3.KeyExists("개념별학습"))
        {
            개념별학습 = ES3.Load<bool>("개념별학습");
        }
        else
        {
            개념별학습 = false;
            ES3.Save("개념별학습", 개념별학습);
        }

        if (ES3.KeyExists("오답학습"))
        {
            오답학습 = ES3.Load<bool>("오답학습");
        }
        else
        {
            오답학습 = false;
            ES3.Save("오답학습", 오답학습);
        }
    }
}

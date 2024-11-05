using DG.Tweening;
using Michsky.MUIP;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveManager : MonoBehaviour
{

    public string Progress = "";

    public GameObject ShowResults;
    public Transform startBut;
    public GameObject[] Buttons;
    public GameObject page;
    public GameObject[] HomePageList;
    public GameObject[] InputFildList;
    bool 개념별학습, 오답학습;

    List<List<string>> problemList;
    List<string[]> wrongP;
    int problemNum;

    public GameObject EndPageSet;

    public int StudyCos;
    void Start()
    {
        저장과불러오기();






    }

    private void Update()
    {
        if (Progress == "문제출제시작")
        {
            Progress = "문제출제중";
            SetProblem();
        }
        if (Progress == "문제 끝")
        {
            problemEnd();
        }
    }
    void SeeProblem()
    {

        if (problemNum >= 4)//20으로 바꿔야 함
        {
            Progress = "문제 끝";
            return;
        }
        else
        {

            Progress = "문제출력";
        }
        List<string> p = problemList[problemNum];
        if (p[4] == "oxQuiz")
        {
            InputFildList[0].gameObject.SetActive(true);
            InputFildList[0].GetComponent<OXQuizInputSet>().SetProblemTxt((problemNum + 1) + "번 문제", p[3]);

        }
        else if (p[4] == "shortAns")
        {
            InputFildList[1].gameObject.SetActive(true);
            InputFildList[1].GetComponent<short_answerInputSet>().SetProblemTxt((problemNum + 1) + "번 문제", p[3]);

        }
        else if (p[4] == "select1")
        {
            InputFildList[2].gameObject.SetActive(true);
            InputFildList[2].GetComponent<select_oneInputSet>().SetProblemTxt((problemNum + 1) + "번 문제", p[3], p[5], p[6], p[7], p[8], p[9]);
        }
        else if (p[4] == "selectM")
        {
            InputFildList[3].gameObject.SetActive(true);
            InputFildList[3].GetComponent<select_multipleInputSet>().SetProblemTxt((problemNum + 1) + "번 문제", p[3],  p[6], p[7], p[8], p[9],p[10]);
        }
        else
        {
            Debug.Log("뭔가 오류여");
            //임시 코드여
            problemNum++;
            SeeProblem();
        }

    }

    void SetProblem()
    {
        problemList = GameObject.Find("MainCode").GetComponent<mainCodeCs>().RandRandomQuiz(20, StudyCos);
        problemNum = 0;
        wrongP = new List<string[]> {};
        Debug.Log("비상" + wrongP.Count);
        SeeProblem();
    }

    public void InputAns(string ans)
    {
        if (Progress == "문제출력")
        {
            Progress = "채점";
            List<string> p = problemList[problemNum];
            ShowResults.SetActive(true);
            ShowResults.GetComponent<ModalWindowManager>().titleText = (problemNum + 1) + "번 문제";
            if (p[4] == "oxQuiz")
            {
                Debug.Log("입력은" + ans + "정답은:" + p[5] + "같나요?" + (p[5] == ans));
                if (p[5] == ans)
                {
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "정답입니다!"; // Change desc

                }
                else
                {
                    //Debug.Log("입력은" + ans + "정답은:" + p[5] + "같나요?" + p[5] == ans);
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "오답입니다.\n정답은 : " + p[5];
                    wrongP.Add(new string[] { p[2], (problemNum + 1).ToString() });
                }


            }
            else if (p[4] == "shortAns")
            {
                string a, b;
                a = getRemoveWhiteSpaces(p[5].ToString());
                b = getRemoveWhiteSpaces(ans);



                if (a == b)
                {
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "정답입니다!"; // Change desc

                }
                else
                {
                    //Debug.Log("입력은" + ans + "정답은:" + p[5] + "같나요?" + p[5] == ans);
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "오답입니다.\n정답은 : " + p[5];
                    wrongP.Add(new string[] { p[2], (problemNum + 1).ToString() });
                }


            }
            else if (p[4] == "select1")
            {
                string a, b;
                a = getRemoveWhiteSpaces(p[5].ToString());
                b = getRemoveWhiteSpaces(ans);

                Debug.Log("입력은" + b + "정답은:" + a + "같나요?" + (a == b));

                if (a == b)
                {
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "정답입니다!"; // Change desc

                }
                else
                {
                    //Debug.Log("입력은" + ans + "정답은:" + p[5] + "같나요?" + p[5] == ans);
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "오답입니다.\n정답은 : " + p[5];
                    wrongP.Add(new string[] { p[2], (problemNum + 1).ToString() });
                }


            }
            else if (p[4] == "selectM")
            {
                string a, b;
                a = getRemoveWhiteSpaces(p[5].ToString());
                b = getRemoveWhiteSpaces(ans);

                Debug.Log("입력은" + b + "정답은:" + a + "같나요?" + (a == b));

                if (a == b)
                {
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "정답입니다!"; // Change desc

                }
                else
                {
                    //Debug.Log("입력은" + ans + "정답은:" + p[5] + "같나요?" + p[5] == ans);
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "오답입니다.\n정답은 : " + p[5];
                    wrongP.Add(new string[] { p[2], (problemNum + 1).ToString() });
                }


            }
            else
            {
                Debug.LogError("뭔가 오류여");
            }


            ShowResults.GetComponent<ModalWindowManager>().UpdateUI();
            ShowResults.GetComponent<ModalWindowManager>().Open();
            // // Update UI
            // Open window
        }

    }

    public void ConfirmBtnDwn()
    {//문제 정답 여부 확인 완료 

        if (Progress == "채점")
        {
            List<string> p = problemList[problemNum];
            if (p[4] == "oxQuiz")
            {
                InputFildList[0].gameObject.SetActive(false);
            }
            else if (p[4] == "shortAns")
            {
                InputFildList[1].gameObject.SetActive(false);
            }
            else if (p[4] == "select1")
            {
                InputFildList[2].gameObject.SetActive(false);
            }
            else if (p[4] == "selectM")
            {
                InputFildList[3].gameObject.SetActive(false);
            }
            problemNum++;
            SeeProblem();
        }
    }

    void problemEnd()//문제 다 풀었어요
    {
        //page.DoLa
        page.transform.DOLocalMove(new Vector3(-1080*3, 0, 0), 1.0f).SetEase(Ease.OutBounce);
        Debug.Log("문제 다 풀었어요");
        Progress = "결과창";
        EndPageSet.GetComponent<EndPageSet>().SetEndPage(wrongP);


    }

    public void GoTitle()
    {
        page.transform.DOLocalMove(new Vector3(-1080 * 4, 0, 0), 2.0f).SetEase(Ease.OutBounce).OnComplete(() => {
            string currentSceneName = SceneManager.GetActiveScene().name;

            // 장면을 다시 로드
            SceneManager.LoadScene(currentSceneName);
        });
        

         
        Progress = "";
    }

    public void studyStartBtnDwn(int cos)
    {
        StudyCos = cos;
        page.transform.DOLocalMove(new Vector3(-1080 * 2, 0, 0), 1.0f).SetEase(Ease.OutBounce);
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

    public static string getRemoveWhiteSpaces(string input)
    {
        string text = input;
        char[] zeroWidthSpaces = { '\u200B', '\u200C', '\u200D' };

        foreach (char zeroWidth in zeroWidthSpaces)
        {
            text = text.Replace(zeroWidth.ToString(), "");
        }

        return text.Replace(" ", "").Replace("\n", "").Replace("\r", "");
    }
}


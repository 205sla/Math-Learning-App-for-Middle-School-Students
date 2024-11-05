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
    bool ���亰�н�, �����н�;

    List<List<string>> problemList;
    List<string[]> wrongP;
    int problemNum;

    public GameObject EndPageSet;

    public int StudyCos;
    void Start()
    {
        ������ҷ�����();






    }

    private void Update()
    {
        if (Progress == "������������")
        {
            Progress = "����������";
            SetProblem();
        }
        if (Progress == "���� ��")
        {
            problemEnd();
        }
    }
    void SeeProblem()
    {

        if (problemNum >= 4)//20���� �ٲ�� ��
        {
            Progress = "���� ��";
            return;
        }
        else
        {

            Progress = "�������";
        }
        List<string> p = problemList[problemNum];
        if (p[4] == "oxQuiz")
        {
            InputFildList[0].gameObject.SetActive(true);
            InputFildList[0].GetComponent<OXQuizInputSet>().SetProblemTxt((problemNum + 1) + "�� ����", p[3]);

        }
        else if (p[4] == "shortAns")
        {
            InputFildList[1].gameObject.SetActive(true);
            InputFildList[1].GetComponent<short_answerInputSet>().SetProblemTxt((problemNum + 1) + "�� ����", p[3]);

        }
        else if (p[4] == "select1")
        {
            InputFildList[2].gameObject.SetActive(true);
            InputFildList[2].GetComponent<select_oneInputSet>().SetProblemTxt((problemNum + 1) + "�� ����", p[3], p[5], p[6], p[7], p[8], p[9]);
        }
        else if (p[4] == "selectM")
        {
            InputFildList[3].gameObject.SetActive(true);
            InputFildList[3].GetComponent<select_multipleInputSet>().SetProblemTxt((problemNum + 1) + "�� ����", p[3],  p[6], p[7], p[8], p[9],p[10]);
        }
        else
        {
            Debug.Log("���� ������");
            //�ӽ� �ڵ忩
            problemNum++;
            SeeProblem();
        }

    }

    void SetProblem()
    {
        problemList = GameObject.Find("MainCode").GetComponent<mainCodeCs>().RandRandomQuiz(20, StudyCos);
        problemNum = 0;
        wrongP = new List<string[]> {};
        Debug.Log("���" + wrongP.Count);
        SeeProblem();
    }

    public void InputAns(string ans)
    {
        if (Progress == "�������")
        {
            Progress = "ä��";
            List<string> p = problemList[problemNum];
            ShowResults.SetActive(true);
            ShowResults.GetComponent<ModalWindowManager>().titleText = (problemNum + 1) + "�� ����";
            if (p[4] == "oxQuiz")
            {
                Debug.Log("�Է���" + ans + "������:" + p[5] + "������?" + (p[5] == ans));
                if (p[5] == ans)
                {
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "�����Դϴ�!"; // Change desc

                }
                else
                {
                    //Debug.Log("�Է���" + ans + "������:" + p[5] + "������?" + p[5] == ans);
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "�����Դϴ�.\n������ : " + p[5];
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
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "�����Դϴ�!"; // Change desc

                }
                else
                {
                    //Debug.Log("�Է���" + ans + "������:" + p[5] + "������?" + p[5] == ans);
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "�����Դϴ�.\n������ : " + p[5];
                    wrongP.Add(new string[] { p[2], (problemNum + 1).ToString() });
                }


            }
            else if (p[4] == "select1")
            {
                string a, b;
                a = getRemoveWhiteSpaces(p[5].ToString());
                b = getRemoveWhiteSpaces(ans);

                Debug.Log("�Է���" + b + "������:" + a + "������?" + (a == b));

                if (a == b)
                {
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "�����Դϴ�!"; // Change desc

                }
                else
                {
                    //Debug.Log("�Է���" + ans + "������:" + p[5] + "������?" + p[5] == ans);
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "�����Դϴ�.\n������ : " + p[5];
                    wrongP.Add(new string[] { p[2], (problemNum + 1).ToString() });
                }


            }
            else if (p[4] == "selectM")
            {
                string a, b;
                a = getRemoveWhiteSpaces(p[5].ToString());
                b = getRemoveWhiteSpaces(ans);

                Debug.Log("�Է���" + b + "������:" + a + "������?" + (a == b));

                if (a == b)
                {
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "�����Դϴ�!"; // Change desc

                }
                else
                {
                    //Debug.Log("�Է���" + ans + "������:" + p[5] + "������?" + p[5] == ans);
                    ShowResults.GetComponent<ModalWindowManager>().descriptionText = "�����Դϴ�.\n������ : " + p[5];
                    wrongP.Add(new string[] { p[2], (problemNum + 1).ToString() });
                }


            }
            else
            {
                Debug.LogError("���� ������");
            }


            ShowResults.GetComponent<ModalWindowManager>().UpdateUI();
            ShowResults.GetComponent<ModalWindowManager>().Open();
            // // Update UI
            // Open window
        }

    }

    public void ConfirmBtnDwn()
    {//���� ���� ���� Ȯ�� �Ϸ� 

        if (Progress == "ä��")
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

    void problemEnd()//���� �� Ǯ�����
    {
        //page.DoLa
        page.transform.DOLocalMove(new Vector3(-1080*3, 0, 0), 1.0f).SetEase(Ease.OutBounce);
        Debug.Log("���� �� Ǯ�����");
        Progress = "���â";
        EndPageSet.GetComponent<EndPageSet>().SetEndPage(wrongP);


    }

    public void GoTitle()
    {
        page.transform.DOLocalMove(new Vector3(-1080 * 4, 0, 0), 2.0f).SetEase(Ease.OutBounce).OnComplete(() => {
            string currentSceneName = SceneManager.GetActiveScene().name;

            // ����� �ٽ� �ε�
            SceneManager.LoadScene(currentSceneName);
        });
        

         
        Progress = "";
    }

    public void studyStartBtnDwn(int cos)
    {
        StudyCos = cos;
        page.transform.DOLocalMove(new Vector3(-1080 * 2, 0, 0), 1.0f).SetEase(Ease.OutBounce);
        Progress = "������������";
    }

    public void btndwn1()//�б⺰ ��ư ����
    {
        //page.DoLa
        page.transform.DOLocalMove(new Vector3(-1080, 0, 0), 1.0f).SetEase(Ease.OutBounce);
        Debug.Log("�б⺰ ����");
    }



    public void StartButDwn()//Ÿ��Ʋ���� ���۹�ư ����
    {
        startBut.transform.DOScale(0, 0.3f).OnComplete(() =>
        {
            Buttons[0].gameObject.SetActive(true);
            if (���亰�н�)
            {
                Buttons[1].gameObject.SetActive(true);

            }
            if (�����н�)
            {
                Buttons[2].gameObject.SetActive(true);
            }
        });



    }

    void ������ҷ�����()
    {
        if (ES3.KeyExists("���亰�н�"))
        {
            ���亰�н� = ES3.Load<bool>("���亰�н�");
        }
        else
        {
            ���亰�н� = false;
            ES3.Save("���亰�н�", ���亰�н�);
        }

        if (ES3.KeyExists("�����н�"))
        {
            �����н� = ES3.Load<bool>("�����н�");
        }
        else
        {
            �����н� = false;
            ES3.Save("�����н�", �����н�);
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


using System;
using UnityEngine;

public class mainCodeCs : MonoBehaviour
{
    public class BasicItem
    {
        public int index; //��ȣ
        public int semester; //�б�
        public string type; //�ܿ�
        public string question; //����
        public string img; //�̹���
    }


    [Serializable]
    public class OXQuiz : BasicItem
    {
        public string correct_answer; //�� OX
        public object[] LoadProblem()
        {
            return new object[] { index, semester, type, question, img, correct_answer };
        }

    }
    [Serializable]
    public class short_answer : BasicItem
    {
        public string correct_answer; //��
        public object[] LoadProblem()
        {
            return new object[] { index, semester, type, question, img, correct_answer };
        }
    }
    [Serializable]
    public class select_one : BasicItem
    {
        public string correct_answer; //��
        public string wrong_answer1; //����1
        public string wrong_answer2; //����2
        public string wrong_answer3; //����3
        public string wrong_answer4; //����4 

        public object[] LoadProblem()
        {
            return new object[] { index, semester, type, question, img, correct_answer, wrong_answer1, wrong_answer2, wrong_answer3, wrong_answer4 };
        }
    }



    [Serializable]
    public class select_multiple : BasicItem
    {
        public string number_of_correct_answers; //��
        public string answer1;
        public string answer2;
        public string answer3;
        public string answer4;
        public string answer5;

        public object[] LoadProblem()
        {
            return new object[] { index, semester, type, question, img, number_of_correct_answers, answer1, answer2, answer3, answer4, answer5 };
        }


    }

    public class FullQuestion
    {
        public OXQuiz[] OXQuiz;
        public short_answer[] short_answer;
        public select_one[] select_one;
        public select_multiple[] select_multiple;
    }

    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Json/mathProblem");

        FullQuestion QuestionList = JsonUtility.FromJson<FullQuestion>(textAsset.text);
        foreach (OXQuiz lt in QuestionList.OXQuiz)
        {
            Debug.Log("��ȣ: "+ lt.LoadProblem()[0] +"�б�: "+ lt.LoadProblem()[1]+"�ܿ�: "+ lt.LoadProblem()[2]+"����"+ lt.LoadProblem()[3]);

        }
    }

}
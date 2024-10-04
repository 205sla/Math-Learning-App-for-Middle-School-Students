using System;
using UnityEngine;

public class mainCodeCs : MonoBehaviour
{
    public class BasicItem
    {
        public int index; //번호
        public int semester; //학기
        public string type; //단원
        public string question; //문제
        public string img; //이미지
    }


    [Serializable]
    public class OXQuiz : BasicItem
    {
        public string correct_answer; //답 OX
        public object[] LoadProblem()
        {
            return new object[] { index, semester, type, question, img, correct_answer };
        }

    }
    [Serializable]
    public class short_answer : BasicItem
    {
        public string correct_answer; //답
        public object[] LoadProblem()
        {
            return new object[] { index, semester, type, question, img, correct_answer };
        }
    }
    [Serializable]
    public class select_one : BasicItem
    {
        public string correct_answer; //답
        public string wrong_answer1; //오답1
        public string wrong_answer2; //오답2
        public string wrong_answer3; //오답3
        public string wrong_answer4; //오답4 

        public object[] LoadProblem()
        {
            return new object[] { index, semester, type, question, img, correct_answer, wrong_answer1, wrong_answer2, wrong_answer3, wrong_answer4 };
        }
    }



    [Serializable]
    public class select_multiple : BasicItem
    {
        public string number_of_correct_answers; //답
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
            Debug.Log("번호: "+ lt.LoadProblem()[0] +"학기: "+ lt.LoadProblem()[1]+"단원: "+ lt.LoadProblem()[2]+"문제"+ lt.LoadProblem()[3]);

        }
    }

}
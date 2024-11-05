using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class mainCodeCs : MonoBehaviour
{
    public FullQuestion QuestionList;
    public class BasicItem
    {
        public int index; //번호
        public int semester; //학기
        public string type; //단원
        public string question; //문제
        public string img; //이미지 없음
    }


    [Serializable]
    public class OXQuiz : BasicItem//OX스타일
    {
        public string correct_answer; //답 OX
        public object[] LoadProblem()
        {
            return new object[] { index, semester, type, question, img, correct_answer };
        }

    }
    [Serializable]
    public class short_answer : BasicItem//단답식
    {
        public string correct_answer; //답
        public object[] LoadProblem()
        {
            return new object[] { index, semester, type, question, img, correct_answer };
        }
    }
    [Serializable]
    public class select_one : BasicItem //오지선다
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
    public class select_multiple : BasicItem //여러개 고르기
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

        QuestionList = JsonUtility.FromJson<FullQuestion>(textAsset.text);
        /*
        foreach (OXQuiz lt in QuestionList.OXQuiz)
        {
            Debug.Log("번호: "+ lt.LoadProblem()[0] +"학기: "+ lt.LoadProblem()[1]+"단원: "+ lt.LoadProblem()[2]+"문제"+ lt.LoadProblem()[3]);

        }
        */
    }



    public List<List<string>> RandRandomQuiz(int count = 10, int cos=1)
    {
        // Create a list to hold all valid quizzes from all types where semester == 1
        List<List<string>> selectedQuizzes = new List<List<string>>();

        // Get all OX quizzes with semester 1
        var oxQuizzes = QuestionList.OXQuiz
            .Where(q => q.semester == cos)
            .ToList();

        // Get all short answer quizzes with semester 1
        var shortAnswers = QuestionList.short_answer
            .Where(q => q.semester == cos)
            .ToList();

        // Get all select one quizzes with semester 1
        var selectOnes = QuestionList.select_one
            .Where(q => q.semester == cos)
            .ToList();

        // Get all select multiple quizzes with semester 1
        var selectMultiples = QuestionList.select_multiple
            .Where(q => q.semester == cos)
            .ToList();

        // Combine all quizzes into one list
        var allValidQuizzes = new List<BasicItem>();
        allValidQuizzes.AddRange(oxQuizzes);
        allValidQuizzes.AddRange(shortAnswers);
        allValidQuizzes.AddRange(selectOnes);
        allValidQuizzes.AddRange(selectMultiples);

        // Shuffle the combined list
        System.Random rng = new System.Random();
        allValidQuizzes = allValidQuizzes.OrderBy(q => rng.Next()).ToList();

        // Select up to 'count' quizzes
        foreach (var quiz in allValidQuizzes.Take(Math.Min(count, allValidQuizzes.Count)))
        {
            List<string> quizDetails = new List<string>();
            quizDetails.Add(quiz.index.ToString());
            quizDetails.Add(quiz.semester.ToString());
            quizDetails.Add(quiz.type.ToString());
            quizDetails.Add(quiz.question.ToString());

            // Add the correct answer if it's available
            if (quiz is OXQuiz oxQuiz)
            {
                quizDetails.Add("oxQuiz");
                quizDetails.Add(oxQuiz.correct_answer.ToString());
            }
            else if (quiz is short_answer shortAns)
            {
                quizDetails.Add("shortAns");
                quizDetails.Add(shortAns.correct_answer.ToString());
            }
            else if (quiz is select_one select1)
            {
                quizDetails.Add("select1");
                quizDetails.Add(select1.correct_answer);
                quizDetails.Add(select1.wrong_answer1);
                quizDetails.Add(select1.wrong_answer2);
                quizDetails.Add(select1.wrong_answer3);
                quizDetails.Add(select1.wrong_answer4);


            }
            else if (quiz is select_multiple selectM)
            {
                quizDetails.Add("selectM");

                quizDetails.Add(selectM.number_of_correct_answers);
                quizDetails.Add(selectM.answer1);
                quizDetails.Add(selectM.answer2);
                quizDetails.Add(selectM.answer3);
                quizDetails.Add(selectM.answer4);
                quizDetails.Add(selectM.answer5);
            }

            selectedQuizzes.Add(quizDetails);
        }

        return selectedQuizzes;
    }//*/
}
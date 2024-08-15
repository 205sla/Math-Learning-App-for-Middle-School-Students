using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCodeCs : MonoBehaviour
{
    [Serializable]
    public class Lotto
    {
        public int index;
        public string step;
        public string problem;
        public string correctAnswer;
        public string wrongAnswer1;
        public string wrongAnswer2;
        public string wrongAnswer3;
        public string wrongAnswer4;
        public string wrongAnswer5;
        public string wrongAnswer6;

        public string img;
        public int[] aaa;
        public int[] bbb;
        public int[] ccc;


        public void printNumbers()
        {

            Debug.Log("bonus : " + problem);
        }
    }

    public class LottoNumbers
    {
        public Lotto[] winning;
    }

    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Json/mathProblem");

        LottoNumbers lottoList = JsonUtility.FromJson<LottoNumbers>(textAsset.text);
        Debug.Log(lottoList);
        foreach (Lotto lt in lottoList.winning)
        {
            lt.printNumbers();
            Debug.Log("=============");
        }
        /*
        string classToJson = JsonUtility.ToJson(lottoList);
        Debug.Log(classToJson);
        */
    }

}
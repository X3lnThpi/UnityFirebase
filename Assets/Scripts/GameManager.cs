using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Questions[] questions = null;
    public Questions[] Questions{
        get{
            return questions;
        }
    }

    private List<int> FinishedQuestions = new List<int>();
    private int currentQuestion = 0;
    private int score;

    void Display(){
        
    }
}

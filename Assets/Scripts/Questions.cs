using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Answer{
    [SerializeField]private string info;
    public string Info{
        get{return info;}
    }

    [SerializeField]private bool isCorrect;
    public bool IsCorrect{
        get{
            return isCorrect;
        }
    }
}

[CreateAssetMenu(fileName = "Questions", menuName = "UnityFirebase/Questions", order = 0)]
public class Questions : ScriptableObject {
    
    public enum AnswerTypes{
        Multi, single
    }
    [SerializeField]private string info = string.Empty;
    public string Info{
        get{return info;}
    }

    [SerializeField] Answer[] answers = null;
    public Answer[] Answers{
        get{
            return answers;
        }
    }

    //Parameters
    [SerializeField]private bool useTimer = false;
    public bool UseTimer{
        get{
            return useTimer;
        }
    }

    [SerializeField]private int timer = 0;
    public int Timer{
        get{
            return timer;
        }
    }

    [SerializeField]private AnswerTypes answerTypes = AnswerTypes.Multi;
    public AnswerTypes GetAnswerType{
        get{
            return answerTypes;
        }
    }

    [SerializeField]private int addScore;
    public int Score{
        get{
            return addScore;
        }
    }

    public List<int> GetCorrectAnswers()
    {
        List<int> CorrectAnswers = new List<int>();
        for(int i = 0; i < Answers.Length; i++){
            if(Answers[i].IsCorrect){
                CorrectAnswers.Add(i);
            }
        }
        return CorrectAnswers;
    }
}


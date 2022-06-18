using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameMan : MonoBehaviour
{
    public Image[] Icons;
    public Image rayImageShow;

    private int[] COMBI_1 = new int[] { 1, 2, 3 };
    private int[] COMBI_2 = new int[] { 4, 5, 6 };
    private int[] COMBI_3 = new int[] { 7, 8, 9 };

    private int[] COMBI_4 = new int[] { 1, 4, 7 };
    private int[] COMBI_5 = new int[] { 2, 5, 8 };
    private int[] COMBI_6 = new int[] { 3, 6, 9 };

    private int[] COMBI_7 = new int[] { 1, 5, 9 };
    private int[] COMBI_8 = new int[] { 3, 6, 7 };

    public int Player_ClickCount;
    private int firstcombi_Count;
    private int seccombi_Count;
    private int thirdcombi_Count;
    private int forthombi_Count;
    private int fifthombi_Count;
    private int sixthcombi_Count;
    private int sevcombi_Count;
    private int eightcombi_Count;

    private int AI_ClickNumb;

    [Header("Int List")]
    private List<int> PlayerClickedNumbers;

    [Header("Texts")]
    public Text GameOver_Text;

    [Header("Bool")]
    public bool IsWin;


    private void Start()
    {
        PlayerClickedNumbers = new List<int>();
        Player_ClickCount = 0;
        firstcombi_Count = 0;
        seccombi_Count = 0;
        thirdcombi_Count = 0;
        forthombi_Count = 0;
        fifthombi_Count = 0;
        sixthcombi_Count = 0;
        sevcombi_Count = 0;
        eightcombi_Count = 0;

        SwitchText(1);
}

    public void ClickEvent(int count)
    {
        Player_ClickCount = Player_ClickCount + 1;
        if (Player_ClickCount >= 3)
        {
            GameOver_Text.text = "Game over";

            for (int i = 0; i < Icons.Length; i++)
            {
                Icons[i].GetComponent<Button>().enabled = false;
            }
        }

        Icons[count - 1].color = Color.green;
        PlayerClickedNumbers.Add(count);
        Debug.Log("Happening");
        
        Invoke("AI_Selectable", 0.10f);


        if (COMBI_1.Contains(count))
        {
            firstcombi_Count = firstcombi_Count + 1;

            if(firstcombi_Count >= 3)
            {
                IsWin = true;
                GameOver_Text.text = "you Win";
            }
        }

        if (COMBI_2.Contains(count))
        {
            seccombi_Count = seccombi_Count + 1;

            if (seccombi_Count >= 3)
            {
                IsWin = true;
                GameOver_Text.text = "you Win";
            }
        }

        if (COMBI_3.Contains(count))
        {
            thirdcombi_Count = thirdcombi_Count + 1;

            if (thirdcombi_Count >= 3)
            {
                IsWin = true;
                GameOver_Text.text = "you Win";
            }
        }


        if (COMBI_4.Contains(count))
        {
            forthombi_Count = forthombi_Count + 1;

            if (forthombi_Count >= 3)
            {
                IsWin = true;
                GameOver_Text.text = "you Win";
            }
        }

        if (COMBI_5.Contains(count))
        {
            fifthombi_Count = fifthombi_Count + 1;

            if (fifthombi_Count >= 3)
            {
                IsWin = true;
                GameOver_Text.text = "you Win";
            }
        }

        if (COMBI_6.Contains(count))
        {
            sixthcombi_Count = sixthcombi_Count + 1;

            if (sixthcombi_Count >= 3)
            {
                IsWin = true;
                GameOver_Text.text = "you Win";
            }
        }

        if (COMBI_7.Contains(count))
        {
            sevcombi_Count = sevcombi_Count + 1;

            if (sevcombi_Count >= 3)
            {
                IsWin = true;
                GameOver_Text.text = "you Win";
            }
        }

        if (COMBI_8.Contains(count))
        {
            eightcombi_Count = eightcombi_Count + 1;

            if (eightcombi_Count >= 3)
            {
                IsWin = true;
                GameOver_Text.text = "you Win";
            }
        }

    }

    void AI_Selectable()
    {
        if (IsWin)
        {
            return;
        }


        SwitchText(0);

        AI_ClickNumb = Random.Range(1, 10);

        if (PlayerClickedNumbers.Contains(AI_ClickNumb))
        {
            AI_Selectable(); 
        }
        else
        {
            PlayerClickedNumbers.Add(AI_ClickNumb);
        }

        Icons[AI_ClickNumb - 1].GetComponent<Button>().enabled = false;
        Icons[AI_ClickNumb - 1].color = Color.red;
        SwitchText(1);
    }

    void SwitchText(int cond)
    {
        if (cond ==1)
        {
            GameOver_Text.text = "Your Turn";
            rayImageShow.gameObject.SetActive(false);
        }
        else if (cond == 0)
        {
            GameOver_Text.text = "Opponent Turn";
            rayImageShow.gameObject.SetActive(true);
        }
    }

    [System.Obsolete]
    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

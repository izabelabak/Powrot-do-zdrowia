using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Text;
using UnityEngine.SceneManagement;

public class Game_Sentence : MonoBehaviour {

    private int clickCount = 0;
    public int questionNumber = 1;
    private string fileName = string.Empty;
    public Question[] questionsSentence;//tablica z pytaniami, pytania dodajemy w Unity
    public Question[] questionsMath;
    public Question[] questionsMatching;
    public static List<Question> unansweredQuestionsSentence;
    public static List<Question> unansweredQuestionsMath;
    public static List<Question> unansweredQuestionsMatching;
    public static List<List<Question>> unansweredQuestionsList;

    private Question currentQuestion;
    
    public Text txtSentence;
    public Text txtAnswerA;
    public Text txtAnswerB;
    public Text txtAnswerC;
    public Text txtAnswerD;
    
    private string clickedAnswer;

    public Canvas GameSentence;
    public Canvas CanvasWon;

    public Button NextSentence;
    public Button ExitGame;
    public Button OkButton;

    public Image GoodAnswer;
    public Image WrongAnswer;

    public Game_Sentence()
    {
        InitializeQuestionsList();
    }

    void InitializeQuestionsList()
    {
        unansweredQuestionsSentence = questionsSentence.ToList<Question>();
        unansweredQuestionsMath = questionsMath.ToList<Question>();
        unansweredQuestionsMatching = questionsMatching.ToList<Question>();
        unansweredQuestionsList = new List<List<Question>>();
        unansweredQuestionsList.Add(unansweredQuestionsSentence);
        unansweredQuestionsList.Add(unansweredQuestionsMath);
        unansweredQuestionsList.Add(unansweredQuestionsMatching);
    }

    void Start ()
    {
        GameSentence = GameSentence.GetComponent<Canvas>();
        CanvasWon = CanvasWon.GetComponent<Canvas>();
        CanvasWon.enabled = false;
        CreateFile();
        GoodAnswer = GoodAnswer.GetComponent<Image>();
        GoodAnswer.enabled = false;
        WrongAnswer = WrongAnswer.GetComponent<Image>();
        WrongAnswer.enabled = false;
        
        if (unansweredQuestionsList == null || unansweredQuestionsList.Count == 0)
        {
            InitializeQuestionsList();
        }

        GetRandomQuestion();
	}

    void GetRandomQuestion()
    {
        int randomListIndex = UnityEngine.Random.Range(0, unansweredQuestionsList.Count);
        List<Question> unansweredQuestions = unansweredQuestionsList[randomListIndex];
        unansweredQuestionsList.RemoveAt(randomListIndex);

        int randomQuestionIndex = UnityEngine.Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        txtSentence.text = currentQuestion.Sentence;
        txtAnswerA.text = currentQuestion.AnswerA;
        txtAnswerB.text = currentQuestion.AnswerB;
        txtAnswerC.text = currentQuestion.AnswerC;
        txtAnswerD.text = currentQuestion.AnswerD;

        unansweredQuestions.RemoveAt(randomQuestionIndex);
    }

    public void NextQuestion()
    {
        WriteToFile();

        if(questionNumber == 3)
        {
            //zakończenie gry
            GameSentence.enabled = false;
            CanvasWon.enabled = true;
            
            GameObject appleGameObj = GameObject.Find("apple");
            GameObject bedGameObj = GameObject.Find("bed");
            if (appleGameObj != null)
            {
                var apple = appleGameObj.GetComponent<Apple>();
                apple.IsCompleted = true;
                Debug.Log("apple=" + apple.IsCompleted);
                return;
            }
            else if (bedGameObj != null)
            {
                var bed = bedGameObj.GetComponent<Bed>();
                bed.IsCompleted = true;
                Debug.Log("bed=" + bed.IsCompleted);
                return;
            }
        }

        questionNumber++;
        clickCount = 0;
        WrongAnswer.enabled = false;
        GoodAnswer.enabled = false;
        GetRandomQuestion();
    }

    public void ExitGameCanva()
    {
        GameSentence.enabled = false;
        CanvasWon.enabled = false;
    }

    public void OnClicked(Button button)
    {
        clickCount++;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            clickedAnswer = button.GetComponentInChildren<Text>().text;
            if (clickedAnswer == currentQuestion.CorrectAnswer)
            {
                WrongAnswer.enabled = false;
                GoodAnswer.enabled = true;
            }
            else
            {
                GoodAnswer.enabled = false;
                WrongAnswer.enabled = true;
            }
        }
    }

    public void CreateFile()//utworzenie pliku
    {
        var fileNumber = 1;
        var date = DateTime.Now.ToString("yyyy-MM-dd");
        fileName = "wyniki " + date + " ";
        while (File.Exists(fileName + fileNumber.ToString()))
        {
            fileNumber++;
        }
        fileName += fileNumber + ".txt";

        using (StreamWriter streamWriter = new StreamWriter(File.Open(fileName, FileMode.Create), Encoding.Unicode))
        {
            streamWriter.WriteLine("Pytanie\t Ilość prób\t Odpowiedź");
            streamWriter.Close();
        }

    }

    public void WriteToFile()//zapis do pliku
    {
        var correctAnswer = GoodAnswer.enabled ? "tak" : "nie";

        using (StreamWriter streamWriter = new StreamWriter(File.Open(fileName, FileMode.Append), Encoding.Unicode))
        {
            streamWriter.WriteLine(questionNumber + "\t" + clickCount + "\t\t" + correctAnswer);
            streamWriter.Close();
        }
    }
    
}

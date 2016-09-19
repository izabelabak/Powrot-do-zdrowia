using UnityEngine;

public class Apple : MonoBehaviour {
    public Canvas AppleInfo; //Podpowiedź pojawiająca się po najechaniu na łóżko, że można wykonać zadanie
    public Canvas GameSentence;//Gra z dokończeniem przysłów
    public Canvas CanvasWon;
    public bool IsCompleted;

    void Start()
    {
        AppleInfo = AppleInfo.GetComponent<Canvas>();
        AppleInfo.enabled = false;
        GameSentence = GameSentence.GetComponent<Canvas>();
        GameSentence.enabled = false;
        CanvasWon = CanvasWon.GetComponent<Canvas>();
        CanvasWon.enabled = false;
    }

    public void OnMouseEnter()
    {

        if (GameSentence.enabled && CanvasWon.enabled)
        {
            AppleInfo.enabled = false;
        }
        else
            AppleInfo.enabled = true;//aktywujemy podpowiedź po najechaniu kursorem na łóżko
    }

    public void OnMouseExit()
    {
        AppleInfo.enabled = false;//chowamy podpowiedź gdy kursor zjedzie z łóżka
    }

    public void OnMouseUp()
    {
        GameSentence.enabled = true;//wyświetlamy naszą grę
        AppleInfo.enabled = false;//chowamy podpowiedź
    }

    public void ExitCanva()
    {
        GameSentence.enabled = false;
        AppleInfo.enabled = false;
    }
}

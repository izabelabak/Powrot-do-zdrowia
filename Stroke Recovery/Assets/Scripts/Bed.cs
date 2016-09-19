using UnityEngine;

public class Bed : MonoBehaviour {
    public Canvas BedInfo; //Podpowiedź pojawiająca się po najechaniu na łóżko, że można wykonać zadanie
    public Canvas GameSentence;//Gra z dokończeniem przysłów
    public Canvas CanvasWon;
    public bool IsCompleted;

    void Start ()
    {
        BedInfo = BedInfo.GetComponent<Canvas>();
        BedInfo.enabled = false;
        GameSentence = GameSentence.GetComponent<Canvas>();
        GameSentence.enabled = false;
        CanvasWon = CanvasWon.GetComponent<Canvas>();
        CanvasWon.enabled = false;
    }
	
    public void OnMouseEnter()
    {
        if (GameSentence.enabled == true && CanvasWon.enabled)
        {
            BedInfo.enabled = false;
        }
        else
            BedInfo.enabled = true;//aktywujemy podpowiedź po najechaniu kursorem na łóżko
    }

    public void OnMouseExit()
    {
        BedInfo.enabled = false;//chowamy podpowiedź gdy kursor zjedzie z łóżka
    }

    public void OnMouseUp()
    {
        GameSentence.enabled = true;//wyświetlamy naszą grę
        BedInfo.enabled = false;//chowamy podpowiedź
    }

    public void ExitCanva()
    {
        GameSentence.enabled = false;
        BedInfo.enabled = false;
    }
}

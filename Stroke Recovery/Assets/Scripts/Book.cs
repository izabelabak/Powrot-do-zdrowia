using UnityEngine;

public class Book : MonoBehaviour {
    public Canvas BookInfo; //Podpowiedź pojawiająca się po najechaniu na łóżko, że można wykonać zadanie
    public Canvas GameSentence;//Gra z dokończeniem przysłów

    void Start()
    {
        BookInfo = BookInfo.GetComponent<Canvas>();
        BookInfo.enabled = false;
        GameSentence = GameSentence.GetComponent<Canvas>();
        GameSentence.enabled = false;
    }

    public void OnMouseEnter()
    {
        BookInfo.enabled = true;//aktywujemy podpowiedź po najechaniu kursorem na łóżko
        if (GameSentence.enabled == true)
        {
            BookInfo.enabled = false;
        }
    }

    public void OnMouseExit()
    {
        BookInfo.enabled = false;//chowamy podpowiedź gdy kursor zjedzie z łóżka
    }

    public void OnMouseUp()
    {
        GameSentence.enabled = true;//wyświetlamy naszą grę
        BookInfo.enabled = false;//chowamy podpowiedź
    }

    public void ExitCanva()
    {
        GameSentence.enabled = false;
        BookInfo.enabled = false;
    }
}

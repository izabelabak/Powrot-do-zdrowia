using UnityEngine;

public class Cup : MonoBehaviour
{
    public Canvas CupInfo;
    public Canvas GameSentence;

    void Start()
    {
        CupInfo = CupInfo.GetComponent<Canvas>();
        CupInfo.enabled = false;
        GameSentence = GameSentence.GetComponent<Canvas>();
        GameSentence.enabled = false;
    }

    public void OnMouseEnter()
    {
        CupInfo.enabled = true;//aktywujemy podpowiedź po najechaniu kursorem na łóżko
        if (GameSentence.enabled == true)
        {
            CupInfo.enabled = false;
        }
    }

    public void OnMouseExit()
    {
        CupInfo.enabled = false;//chowamy podpowiedź gdy kursor zjedzie z łóżka
    }

    public void OnMouseUp()
    {
        GameSentence.enabled = true;//wyświetlamy naszą grę
        CupInfo.enabled = false;//chowamy podpowiedź
    }

    public void ExitCanva()
    {
        GameSentence.enabled = false;

    }
}

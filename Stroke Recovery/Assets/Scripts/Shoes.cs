using UnityEngine;

public class Shoes : MonoBehaviour {
    public Canvas ShoesInfo;
    public Canvas GameSentence;

    void Start()
    {
        ShoesInfo = ShoesInfo.GetComponent<Canvas>();
        ShoesInfo.enabled = false;
        GameSentence = GameSentence.GetComponent<Canvas>();
        GameSentence.enabled = false;
    }

    public void OnMouseEnter()
    {
        ShoesInfo.enabled = true;//aktywujemy podpowiedź po najechaniu kursorem na łóżko
        if (GameSentence.enabled == true)
        {
            ShoesInfo.enabled = false;
        }
    }

    public void OnMouseExit()
    {
        ShoesInfo.enabled = false;//chowamy podpowiedź gdy kursor zjedzie z łóżka
    }

    public void OnMouseUp()
    {
        GameSentence.enabled = true;//wyświetlamy naszą grę
        ShoesInfo.enabled = false;//chowamy podpowiedź
    }

    public void ExitCanva()
    {
        GameSentence.enabled = false;
        ShoesInfo.enabled = false;
    }
}

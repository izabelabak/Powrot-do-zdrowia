using UnityEngine;
using System.Collections;

public class StartGameInstruction : MonoBehaviour {
    public Canvas StartGameInformation;
    public Canvas WalkInstruction;


    void Start()
    {
        StartGameInformation = StartGameInformation.GetComponent<Canvas>();
        StartGameInformation.enabled = true;
        WalkInstruction = WalkInstruction.GetComponent<Canvas>();
        WalkInstruction.enabled = false;
    }
	
    public void StartGameInformationOK()
    {
        StartGameInformation.enabled = false;
        WalkInstruction.enabled = true;
    }

    public void WalkInstructionOK()
    {
        WalkInstruction.enabled = false;
    }
}

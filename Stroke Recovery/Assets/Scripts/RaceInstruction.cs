using UnityEngine;
using System.Collections;

public class RaceInstruction : MonoBehaviour {
    public Canvas RaceInstructionInfo;

	void Start ()
    {
        RaceInstructionInfo = RaceInstructionInfo.GetComponent<Canvas>();
        RaceInstructionInfo.enabled = false;
    }

    void OnTriggerEnter(Collider TriggerTime)
    {
        if (TriggerTime.CompareTag("Player"))
        {
            RaceInstructionInfo.enabled = true;
        }
    }

    public void PressOK()
    {
        RaceInstructionInfo.enabled = false;
    }

    void Update () {
	
	}
}

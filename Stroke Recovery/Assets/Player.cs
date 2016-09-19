using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Animator PlayerAnimation;
    private float vert;
    
	void Start ()
    {
        PlayerAnimation = GetComponent<Animator>();
	}
	
	void Update ()
    {	
        if (Input.GetKeyDown("d"))
        {
            PlayerAnimation.Play("Right", -1, 0f);
        }
        if (Input.GetKeyDown("a"))
        {
            PlayerAnimation.Play("Left", -1, 0f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            PlayerAnimation.Play("Walking", -1, 0f);
        }
    }
}

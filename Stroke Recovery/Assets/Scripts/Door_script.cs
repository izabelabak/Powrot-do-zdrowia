using UnityEngine;

public class Door_script : MonoBehaviour {
    public bool open = false;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smooth = 2f;
        
    void Update()
    {
        GameObject appleGameObj = GameObject.Find("apple");
        var apple = appleGameObj.GetComponent<Apple>();

        GameObject bedGameObj = GameObject.Find("bed");
        var bed = bedGameObj.GetComponent<Bed>();

        if (apple.IsCompleted && bed.IsCompleted)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        return;
    }
}

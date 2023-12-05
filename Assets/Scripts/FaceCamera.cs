using UnityEngine;
/*[ExecuteInEditMode]*/

public class FaceCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform cam;
    private Vector3 TargetAngle= Vector3.zero;

    void Start()
    {
        cam = Camera.main.transform;
        
    }

    void Update()
    {
        /*transform.LookAt(cam);
        TargetAngle = transform.localEulerAngles;
        TargetAngle.x = 0;
        TargetAngle.y = 0;
        transform.localEulerAngles = TargetAngle;*/

        transform.LookAt(cam);
    }
}

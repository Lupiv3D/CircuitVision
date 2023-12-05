using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private GameObject bBoard;
    private LeanDragTranslate move;
    private LeanPinchScale resize;
    private LeanTwistRotate rotate;

    // Start is called before the first frame update
    void Start()
    {
        UI.Instance.hintText.text = "Board Detected";
        UI.Instance.showTransform();
        bBoard = Instantiate(GameManager.Instance.requiredBoard, transform);
        move = bBoard.GetComponent<LeanDragTranslate>();
        rotate = bBoard.GetComponent<LeanTwistRotate>();
        resize = bBoard.GetComponent<LeanPinchScale>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleTransform(int type)
    {
        switch (type)
        {
            case 0: 
            move.enabled = !move.enabled;
            rotate.enabled = false;
            resize.enabled = false;
            break;
            case 1: 
            rotate.enabled = !rotate.enabled;
            move.enabled = false;
            resize.enabled = false;
            break;
            case 2: 
            resize.enabled = !resize.enabled;
            rotate.enabled = false;
            move.enabled = false;
            break;
            case 3:
            rotate.enabled = false;
            move.enabled = false;
            resize.enabled = false;
            resetPos();
            break;
        }
    }

    public void resetPos()
    {
        bBoard.transform.localPosition = new Vector3(0,0,0);
    }
}

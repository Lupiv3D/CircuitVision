using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUI : MonoBehaviour
{
    public GameObject[] transformObj;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void transformObjects()
    {
        foreach (GameObject t in transformObj)
        {
            Animatable anim = t.GetComponent<Animatable>();
            animate(anim.scale, anim.transform, anim.rotate, t);
        }
    }

    private void animate(bool Scale, bool Transform, bool Rotate, GameObject obj)
    {
        if (Scale) StartCoroutine(LerpScale(obj));
        if (Transform) StartCoroutine(LerpPosition(obj));
    }
    
    private IEnumerator LerpScale(GameObject obj)
    {
        float newScale = obj.transform.localScale.x;

        float time = 0;
        float startValue = obj.transform.localScale.x;
        float scale = obj.transform.localScale.x;
        Vector3 startScale = obj.transform.localScale;

        while (time < duration)
        {
            scale = Mathf.Lerp(startValue, newScale, smooth(time));
            transform.localScale = startScale * scale;
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale * newScale;
        scale = newScale;
    }

    private IEnumerator LerpPosition(GameObject obj)
    {
        RectTransform newRec = obj.GetComponent<Animatable>().newTransform;
        RectTransform Rec = obj.GetComponent<RectTransform>();

        float time = 0;
        RectTransform startPosition = Rec;

        while (time < duration)
        {
            Rec.anchoredPosition = Vector2.Lerp(startPosition.anchoredPosition, newRec.anchoredPosition, smooth(time));
            time += Time.deltaTime;
            yield return null;
        }
        Rec.anchoredPosition = newRec.anchoredPosition;
    }

    private float smooth(float time)
    {
        float t = time / duration;
        return t * t * (3f - 2f * t);
    }
}

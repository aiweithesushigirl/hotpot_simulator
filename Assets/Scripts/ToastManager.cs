using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text texty;
    public RectTransform rect;
    public float speed;
    private bool show;
    void Start()
    {
        //texty = GetComponent<Text>();
        //rect = GetComponent<RectTransform>();
        show = true;
    }

    // Update is called once per frame
    void Update()
    {
       if (show)
       {
           StartCoroutine(ShowToast());
       }
       
    }

    public void toast()
    {
        show = true;
    }

    public void setText(string text)
    {
        texty.text = text;
    }
    public void setColor(Color c)
    {
        texty.color = c;
    }

    public void OnDestroy()
    {
        texty.enabled = false;
    }
    IEnumerator ShowToast()
    {
        float time = 85f / speed;
        Vector3 dest = rect.position;
        Vector3 orig = rect.position;
        dest.y += 85f;
        for (float t = 0f; t < time; t += Time.deltaTime)
        {
            rect.position = Vector3.Lerp(rect.position, dest, t / time);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        for (float t = 0f; t < time; t += Time.deltaTime)
        {
            rect.position = Vector3.Lerp(rect.position, orig, t / time);
            yield return null;
        }
        show = false;
    }

}

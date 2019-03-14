using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TextHit : MonoBehaviour
{
    public float timeLife          = 5f;
    public float ElevationDistance = 2;
    public string sortingLayer     = "Text";

    public TextMesh textMesh;
    public float timeFadeOut;
    public Color _color;

    private bool fadeOut;
    private float actualDistance = 0;
    private Vector3 verticalMovement;
    private float amountAscend = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().sortingLayerName = sortingLayer;
        textMesh = GetComponent<TextMesh>();
        verticalMovement = new Vector3(0, amountAscend);
        Destroy(gameObject, timeLife);
    }

    // Update is called once per frame
    void Update()
    {
        if (actualDistance < ElevationDistance)
        {
            transform.localPosition += verticalMovement;
            actualDistance += amountAscend;
        }
        else
        {
            if (!fadeOut)
            {
                fadeOut = true;
                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeOut()
    {
        Color actualColor = textMesh.color;

        for (float alpha = 1; alpha > 0 ; alpha-=(1/timeLife)*Time.deltaTime)
        {
            actualColor.a = alpha;
            textMesh.color = actualColor;
            yield return new WaitForEndOfFrame();
        }
    } 
}

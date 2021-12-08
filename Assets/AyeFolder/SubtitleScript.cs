using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleScript : MonoBehaviour
{
    public TextMeshProUGUI Subtitle;
    public TextMeshProUGUI SubtitleEnglish;
    public int SubtitleReadTime;
    public string LineOne;
    public string LineOneEnglish;
    public string LineTwo;
    public string LineTwoEnglish;
    public string LineThree;
    public string LineThreeEnglish;
    private int Loop = 3;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(FadeIn(5));
        }
    }
    
    public IEnumerator FadeIn(float time)
    {
        yield return new WaitForSeconds(2);
        Debug.Log("fadein");
        switch(Loop)
        {
            case 3:
                Subtitle.text = LineOne;
                SubtitleEnglish.text = LineOneEnglish;
                break;
            case 2:
                Subtitle.text = LineTwo;
                SubtitleEnglish.text = LineTwoEnglish;
                break;
            case 1:
                Subtitle.text = LineThree;
                SubtitleEnglish.text = LineThreeEnglish;
                break;
            default:
                Subtitle.text = "";
                SubtitleEnglish.text = "";
                break;
        }

        float subTimer = 0;
        while(subTimer < time)
        {
            subTimer += Time.fixedDeltaTime;
            Subtitle.color = Color.Lerp(Color.clear, Color.white, subTimer);
            SubtitleEnglish.color = Color.Lerp(Color.clear, Color.white, subTimer);
            yield return null;
        }
        StartCoroutine(FadeOut(5));
    }

    public IEnumerator FadeOut(float time)
    {
        yield return new WaitForSeconds(1);
        Debug.Log("fadeout");
        float subTimer = 0;
        while (Subtitle.color != Color.clear)
        {
            subTimer += Time.fixedDeltaTime;
            Subtitle.color = Color.Lerp(Color.white, Color.clear, subTimer);
            SubtitleEnglish.color = Color.Lerp(Color.white, Color.clear, subTimer);
            yield return null;
        }
        Loop -= 1;
        if(Loop >= 1)
        {
            StartCoroutine(FadeIn(5));
        }
    }

    public void Rolling()
    {

    }



}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoriaTex : MonoBehaviour
{
    private Text uiText;
    private string textToWrite;
    private int characterIndex;
    private float timexCharacter;
    private float timer;

    public void AddWriter(Text uiText, string textToWrite, float timexCharacter)
    {
        this.uiText = uiText;   
        this.textToWrite = textToWrite;
        this.timexCharacter = timexCharacter;
        characterIndex = 0;
    }



    // Update is called once per frame
    void Update()
    {
        if(uiText != null)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                timer += timexCharacter;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);

                if(characterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return;
                }

            }
        }

    }


}

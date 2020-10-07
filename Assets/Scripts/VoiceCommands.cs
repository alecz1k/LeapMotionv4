using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceCommands : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    
    public MyGestureExtendedFingers refScript;
    

    void Start()
    {

        actions.Add("check", TakeAScreenshot);
        


        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        
        
    }

    // Update is called once per frame
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)

    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();


    }

    private void TakeAScreenshot()

    {
        if (refScript.callForGunIsTrue ==true)
        
        {
            ScreenCapture.CaptureScreenshot("SomeLevel");
            Debug.Log("You've nailed it!");
        }

        if (refScript.callForGunIsTrue ==false)
        
        
            Debug.Log("Screenshot script is not working bc bool callforgunistrue is false");
    }
}

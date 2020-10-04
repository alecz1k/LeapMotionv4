using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessEffects : MonoBehaviour
{

    public PostProcessVolume volume;
    private Bloom bloom;
    private Vignette vignette;
    public MyGestureActivation gestureActivationScript;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out bloom);
        volume.profile.TryGetSettings(out vignette);
        bloom.intensity.value = 0;
        vignette.intensity.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gestureActivationScript.gestureIsOn == true)
        {
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 50, .05f * Time.deltaTime);
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 1, .05f * Time.deltaTime);
        }

        else
        {
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 0, -.5f * Time.deltaTime);
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0, -.05f * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.ImageEffects;

public class MyGestureActivation : MonoBehaviour
{

    public MyGestureIndexes indexesScript;
    public MyGestureThumbs thumbsScript;
    public GameObject prefab;
    public bool gestureIsOn;
    public PostProcessVolume volume;
    private UnityEngine.Rendering.PostProcessing.Bloom bloom;
    private Vignette vignette;
    private ChromaticAberration chromatic;
    private ColorGrading colorGrading;
    private UnityEngine.Rendering.PostProcessing.DepthOfField depth;

    private UnityStandardAssets.ImageEffects.Bloom legacyBloom;
    private CreaseShading creaseShading;
    private EdgeDetection edgeDetection;

    void Start()
    {
        prefab.SetActive(false);
        gestureIsOn = false;
        volume.profile.TryGetSettings(out bloom);
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out chromatic);
        volume.profile.TryGetSettings(out colorGrading);
        volume.profile.TryGetSettings(out depth);
        bloom.intensity.value = 0;
        vignette.intensity.value = 0;
        chromatic.intensity.value = 0;
        colorGrading.saturation.value = 1;
        depth.focusDistance.value = 5;

    }


    void Update()
    {
        if ((indexesScript.indexesAreTouching == true) && (thumbsScript.thumbsAreTouching == true))
        {
            gestureIsOn = true;
            prefab.SetActive(true);
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 50, .075f * Time.deltaTime);
            colorGrading.saturation.value = Mathf.Lerp(colorGrading.saturation.value, 100, .075f * Time.deltaTime);
            depth.focusDistance.value = Mathf.Lerp(depth.focusDistance.value, 1, .025f * Time.deltaTime);
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 1, .05f * Time.deltaTime);
            chromatic.intensity.value = Mathf.Lerp(chromatic.intensity.value, 1, .05f * Time.deltaTime);
            Debug.Log("Indexes and Thumbs Are Touching, We are Gesture Ready");


        }

        else
        {
            prefab.SetActive(false);
            gestureIsOn = false;
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 1, .025f * Time.deltaTime);
            colorGrading.saturation.value = Mathf.Lerp(colorGrading.saturation.value, -50, .025f * Time.deltaTime);
            depth.focusDistance.value = Mathf.Lerp(depth.focusDistance.value, 5, .015f * Time.deltaTime);
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0, .025f * Time.deltaTime);
            chromatic.intensity.value = Mathf.Lerp(chromatic.intensity.value, 0, .025f * Time.deltaTime);
        }
            

    }
}

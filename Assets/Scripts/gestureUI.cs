using UnityEngine;
using System.Collections;
public class gestureUI : MonoBehaviour {

	Transform IndexA, IndexB, ThumbA, ThumbB;
	bool bothHandsOnScreen = false;
	float timeElapsed = 0.0f;
	bool gestureDetected = false;

	public float distanceMaximaleEntreDoigts = 0.10f;
	public float distanceMinimaleEntreIndexesEtPouces = 0.80f;
	public float gestureTime = 4.0f;
	public float bloomIntensityMultiplier = 8.0f;
	public float creaseIntensityMultiplier = 2.0f;
	public UnityStandardAssets.ImageEffects.Bloom bloomEffect;
	public UnityStandardAssets.ImageEffects.CreaseShading crease;

	void Update () 
	{
		gestureDetected = false;

		// Détection des doigts
		GameObject[] indexes = GameObject.FindGameObjectsWithTag("Index");
		GameObject[] thumbs  = GameObject.FindGameObjectsWithTag("Thumb");

		if (indexes.Length == 2 && thumbs.Length == 2) 
			{
				IndexA = indexes[0].transform;
				IndexB = indexes[1].transform;
				ThumbA = thumbs[0].transform;
				ThumbB = thumbs[1].transform;
				bothHandsOnScreen = true;
			Debug.Log("Both Hands on Screen");
		}

		else bothHandsOnScreen = false;

		// Reconnaissance du geste
		if (bothHandsOnScreen)
		{
				bool detected = true;

				// Vérification de la distance entre les doigts
				// -- On veut considérer que les doigts se touchent que si ils sont a une distance minimale entre eux
				float distIndexes = Vector3.Distance(IndexA.transform.position, IndexB.transform.position);
				float distThumbs = Vector3.Distance(ThumbA.transform.position, ThumbB.transform.position);
				if (distIndexes > distanceMaximaleEntreDoigts || distThumbs > distanceMaximaleEntreDoigts) detected = false;

				// Vérification de la distance entre les doigts et les pouces
				// -- On veut une certaine distance minimale entre les doigts et les pouces pour reconnaitre le geste
				Vector3 meanIndex = (IndexA.transform.position + IndexB.transform.position) / 2.0f;
				Vector3 meanThumb = (ThumbA.transform.position + ThumbB.transform.position) / 2.0f;
				float distFingers = Vector3.Distance(meanIndex, meanThumb);
				if (distFingers < distanceMinimaleEntreIndexesEtPouces) detected = false;

            // On considère le geste comme détecté
            gestureDetected = detected;
			Debug.Log("Gesture is being detected");

		}

		else gestureDetected = false;


		// Calculer le temps de pose
		if (gestureDetected) 
			{
				timeElapsed += Time.deltaTime;
				if (timeElapsed >= gestureTime)
					{
						timeElapsed = gestureTime;
						//Do something here when gesture is detected
						Debug.Log("Time Gesture is being detected");
					}
			}


		else
			{
				timeElapsed -= Time.deltaTime;
				if (timeElapsed <= 0) timeElapsed = 0;
			}
		
		// Appliquer les effets
		bloomEffect.bloomIntensity = timeElapsed * bloomIntensityMultiplier / gestureTime;
        crease.intensity = timeElapsed * creaseIntensityMultiplier / gestureTime;
		
	}
}

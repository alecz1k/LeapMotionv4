using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGestureIndexes : MonoBehaviour
{

	Transform IndexA, IndexB, ThumbA, ThumbB;
	bool bothHandsOnScreen = false;
	public bool indexesAreTouching = false;
	public UnityStandardAssets.ImageEffects.Bloom bloomEffect;
	public UnityStandardAssets.ImageEffects.CreaseShading crease;


	void Update()
	{
		GameObject[] indexes = GameObject.FindGameObjectsWithTag("Index");
		GameObject[] thumbs = GameObject.FindGameObjectsWithTag("Thumb");

		if (indexes.Length == 2 && thumbs.Length == 2)
		{
			IndexA = indexes[0].transform;
			IndexB = indexes[1].transform;
			ThumbA = thumbs[0].transform;
			ThumbB = thumbs[1].transform;
			bothHandsOnScreen = true;

		}

		else bothHandsOnScreen = false;

	}



	void OnTriggerEnter(Collider other)
	{
		if (bothHandsOnScreen)
		{

			if (other.gameObject.CompareTag("Index"))
			{
				indexesAreTouching = true;
				Debug.Log("Indexes are touching");

			}
		}
	}
	
	void OnTriggerExit (Collider other)
     {
			if (other.gameObject.CompareTag("Index"))
			{
				indexesAreTouching = false;
				Debug.Log("Indexes are separating");

			}

		
	}
}

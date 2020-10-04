using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGestureThumbs : MonoBehaviour
{


	
	public bool thumbsAreTouching = false;
	


	void Update()
	{
		

	}



	public void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag("Thumb"))
		{
			thumbsAreTouching = true;
			Debug.Log("Thumbs are touching");

		}

		

	}

	public void OnTriggerExit(Collider other)
	{

		if (other.gameObject.CompareTag("Thumb"))
		{
			thumbsAreTouching = false;
			Debug.Log("Thumbs are separating");

		}



	}
}

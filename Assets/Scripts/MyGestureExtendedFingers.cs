using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGestureExtendedFingers : MonoBehaviour
{

    
   
    public bool callForGunIsTrue;

    private void Start()
    {
        
        callForGunIsTrue = false;
        
    }

    

    public void CallForGun()
    {
        print("CallForGun = true");
        callForGunIsTrue = true;
        
       
    }


    
    public void ReleaseGun()
    {
        print("CallForGun = false");
        callForGunIsTrue = false;
        
        
    }

    
}

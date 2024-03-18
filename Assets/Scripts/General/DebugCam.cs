using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(GyroCam))]
public class DebugCam : MonoBehaviour 
{

	#region Variable Declarations
	// Serialized Fields
	[SerializeField] Camera ARCam;


    // Private

    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    

    private void Start () 
	{
		
	}
	#endregion
	
	
	
	#region Public Functions
	public void EnableDebugCam()
	{
        gameObject.GetComponent<Camera>().enabled = true;
        gameObject.tag = "MainCamera";
        ARCam.enabled = false;

        if (!Application.isEditor)
        {
			EnableGyroCam();
        }
    }
	#endregion
	
	
	
	#region Private Functions
	private void EnableGyroCam()
	{
		GetComponent<GyroCam>().enabled = true;
	}
	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}
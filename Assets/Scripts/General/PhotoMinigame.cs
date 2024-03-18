using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoMinigame : Minigame
{

	#region Variable Declarations
	// Serialized Fields
	[SerializeField] private PhotoButton photoButtonScript;

	// Private
	private Camera mainCamera;

	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
		
	}

    private void Update()
    {
		if (mainCamera != null)
		{

			Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.GetComponent<ARCharacter>())
				{
					Debug.Log("Sagencharacter wurde gehittet");
					photoButtonScript.SetButtonActive();
				}
				else
                {
					photoButtonScript.SetButtonInactive();
                }
			}
			else
            {
				photoButtonScript.SetButtonInactive();
			}
		}
	}

    public override void StartMinigame()
    {
		base.StartMinigame();
		mainCamera = Camera.main;
    }
	#endregion
	
	
	
	#region Public Functions
	
	#endregion
	
	
	
	#region Private Functions
	
	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumPage : MonoBehaviour 
{

	#region Variable Declarations
	// Serialized Fields
	[SerializeField] Station station;

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
	public void CheckSave()
	{
		if(station != null && station.stationCompleted)
		{
			Unlock();
		}
	}

    #endregion



    #region Private Functions
    private void Unlock()
    {
        Transform[] pageContent = GetComponentsInChildren<Transform>(true);

        foreach (Transform contentObject in pageContent)
        {
            if (contentObject.CompareTag("Unlocked"))
            {
                contentObject.gameObject.SetActive(true);
            }
            else if (contentObject.CompareTag("Locked"))
            {
                contentObject.gameObject.SetActive(false);
            }
        }
    }
    #endregion



    #region Coroutines

    #endregion
}
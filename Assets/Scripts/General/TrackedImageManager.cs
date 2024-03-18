using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackedImageManager : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    // Private

    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void Start () 
	{
		
	}
    #endregion



    #region Public Functions
    #endregion



    #region Private Functions
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            Debug.Log("Image Target Detected:");
            GameEvents.Instance.DetectARImage(trackedImage);
        }
    }
    #endregion



    #region Coroutines

    #endregion
}
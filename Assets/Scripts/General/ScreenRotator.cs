using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRotator : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] bool forcePortrait;

    // Private

    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    void Start()
    {
        if (forcePortrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
    #endregion



    #region Public Functions

    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}
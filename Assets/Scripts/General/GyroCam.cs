using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCam : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] private float xFactor;
    [SerializeField] private float yFactor;
    [SerializeField] private float zFactor;
    [SerializeField] private float wFactor;
    // Private

    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void Start () 
	{
		if(SystemInfo.supportsGyroscope)
		{
			Input.gyro.enabled = true;
		}
	}

	void Update()
	{
		if(SystemInfo.supportsGyroscope)
		{
			transform.rotation = GyroToUnity(Input.gyro.attitude);
			
		}
			
	}
	#endregion



	#region Public Functions

	#endregion



	#region Private Functions
	private Quaternion GyroToUnity (Quaternion q)
	{
		return new Quaternion(xFactor * q.x, yFactor * q.y, zFactor * q.z, wFactor * q.w);
	}
	#endregion



	#region Coroutines

	#endregion
}
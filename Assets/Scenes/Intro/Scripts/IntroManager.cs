using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour 
{

	#region Variable Declarations
	// Serialized Fields
	[SerializeField] private Dialogue introDialogue;
	[SerializeField] private Gamemanager gamemanager;

	// Private
	
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
		DialogueManager.instance.StartDialogue(introDialogue, exitIntro);
	}
	#endregion
	
	
	
	#region Public Functions
	
	#endregion
	
	
	
	#region Private Functions
	private void exitIntro()
	{
		gamemanager.LoadMenu();
	}

	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}
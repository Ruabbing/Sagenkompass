using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour 
{

	#region Variable Declarations
	// Serialized Fields
	[SerializeField] MapButton[] mapButtons;
	[SerializeField] Dialogue mapDefaultDialogue;

	// Private
	private MapButton selectedButton;

	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
		UnselectButton();
		DialogueManager.instance.StartDialogue(mapDefaultDialogue);
	}
	#endregion
	
	
	
	#region Public Functions
	public void ButtonSelect(MapButton mapButton)
	{
		selectedButton = mapButton;
		UnselectButton();
	}

	#endregion
	
	
	
	#region Private Functions
	private void UnselectButton()
	{
		foreach(MapButton button in mapButtons)
		{
			if(button != selectedButton)
			{
				button.UnselectButton();
			}
		}
	}
	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour 
{

	#region Variable Declarations
	// Serialized Fields
	[SerializeField] MapManager mapManager;
    [SerializeField] Sprite selectedSprite;
	[SerializeField] Sprite unselectedSprite;
	[SerializeField] Sprite completedSprite;
	[SerializeField] Sprite completedSpriteSelected;
	[SerializeField] GameObject startButton;
	[SerializeField] GameObject path;
	[SerializeField] Dialogue selectDialogue;
    [SerializeField] Dialogue completedDialogue;

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
	public void UnselectButton()
	{
		if(!station.stationCompleted)
		{
			GetComponent<Image>().sprite = unselectedSprite;
		}
		else
		{
			GetComponent<Image>().sprite = completedSprite;
		}
        
        path.SetActive(false);
		startButton.SetActive(false);
    }

	public void SelectButton()
	{
		if(!station.stationCompleted)
		{
            GetComponent<Image>().sprite = selectedSprite;
            path.SetActive(true);
            mapManager.ButtonSelect(this);
            startButton?.SetActive(true);
            DialogueManager.instance.StartDialogue(selectDialogue);
        }
		else
		{
            GetComponent<Image>().sprite = completedSpriteSelected;
            DialogueManager.instance.StartDialogue(selectDialogue, StartCompletedHintDialogue);

        }

		path.SetActive(true);
		mapManager.ButtonSelect(this);
		startButton?.SetActive(true);
	}

	public void StartCompletedHintDialogue()
	{
		DialogueManager.instance.StartDialogue(completedDialogue);
	}

	#endregion
	
	
	
	#region Private Functions
	
	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}
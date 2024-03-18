using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCharacter : MonoBehaviour 
{

	#region Variable Declarations
	// Serialized Fields
	[SerializeField] private Character characterData;

    [SerializeField] private Dialogue bumpDialogue;
    [SerializeField] private Dialogue clickDialogue;

	[SerializeField] private GameObject[] trinkets;

	// Private
	private bool dialogueInProgress;
	
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
		//sets trinkets inactive
		foreach(GameObject trinket in trinkets)
		{
			trinket.SetActive(false);
		}
	}

    // starts collision dialogue if camera collides with collider
    private void OnTriggerEnter(Collider other)
    {
        if (bumpDialogue != null && !DialogueManager.instance.dialogueInProgress && other.gameObject.CompareTag("MainCamera"))
        {
			DialogueManager.instance.StartDialogue(bumpDialogue);
			Debug.Log("Bump");
        }
    }

	// starts click dialogue if character is touched or clicked
    private void OnMouseDown()
    {
		if(clickDialogue != null && !DialogueManager.instance.dialogueInProgress)
		{
			DialogueManager.instance.StartDialogue(clickDialogue);
			Debug.Log("Click");
		}

		
	}
    #endregion



    #region Public Functions
    

    public void SetBumpDialogue(Dialogue dialogue)
    {
		bumpDialogue = dialogue;
		Debug.Log("Dialog set to " + bumpDialogue);
    }

	public void SetClickDialogue(Dialogue dialogue)
    {
		clickDialogue = dialogue;
        Debug.Log("Dialog set to " + clickDialogue);
    }

	public void DeactivateClickDialogue()
	{
		clickDialogue = null;
	}
    public void DeactivateBumpDialogue()
    {
        bumpDialogue = null;
    }

    //reveal character accessoires during minigames
    public void RevealTrinket(int trinketNumber)
	{
		trinkets[trinketNumber].SetActive(true);
		Debug.Log("Reveal Trinket " + gameObject.name);
	}


    #endregion



    #region Private Functions
	private void TestMethodDialogue()
    {
		Debug.Log("Method Triggered!");
    }
    #endregion



    #region Coroutines

    #endregion
}
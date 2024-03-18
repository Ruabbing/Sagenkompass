using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour 
{

    // Serialized Fields
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private float textSpeed;
    [SerializeField] private TextMeshProUGUI dialogueTextField;
    [SerializeField] private GameObject nextMessageButton;
    [SerializeField] private Image characterPortraitImage;
    [SerializeField] private TextMeshProUGUI characterNameText;



    // Private
    public static DialogueManager instance;

    private Dialogue currentDialogue;
    [SerializeField] private int currentMessage;

    public bool dialogueInProgress { get; private set; }
    private System.Action onDialogueEnd;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start () 
	{

    }
    
    //start dialogue
    public void StartDialogue(Dialogue dialogue, System.Action onComplete = null)
    {
        if (dialogueInProgress)
        {
            Debug.Log("Dialogue already in Progress, aborting " + dialogue);
            EndDialogue();
        }
           
            onDialogueEnd = onComplete;
            dialogueInProgress = true;
            dialoguePanel.SetActive(true);

            if(dialogue.character.ProfileImage)
            {
                characterPortraitImage.sprite = dialogue.character.ProfileImage;
            }

            characterNameText.text = dialogue.character.CharacterName;
            nextMessageButton.SetActive(true);
            currentDialogue = dialogue;
            currentMessage = 0;
            NextMessage();
    }

    public void NextMessage()
    {
        if(currentMessage < currentDialogue.TextMessages.Length)
        {
            WipeMessage();
            StopAllCoroutines();
            Debug.Log("Next Message");
            StartCoroutine(TypeMessage()); ;
            currentMessage++;
        }
        else
        {
            EndDialogue();
        }
    }

    //end dialogue and hide its elements, 
    public void EndDialogue()
    {
        Debug.Log("Deactivate Panel");
        currentMessage = 0;
        currentDialogue = null;
        nextMessageButton.SetActive(false);
        dialoguePanel.SetActive(false);
        dialogueInProgress = false;

        if (onDialogueEnd != null)
        {
            onDialogueEnd.Invoke();
        }
    }
    

    private void WipeMessage()
    {
        dialogueTextField.text = "";
    }

    IEnumerator TypeMessage()
    {
        foreach(char c in currentDialogue.TextMessages[currentMessage].ToCharArray())
        {
            dialogueTextField.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

}
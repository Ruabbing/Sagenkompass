using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Minigame : MonoBehaviour 
{
    public Stationmanager stationmanager;
	[SerializeField] private GameObject[] minigameAssets;
    [SerializeField] private string helpText;

	public Dialogue gameStartDialogue;
    public Dialogue gameEndDialogue;
    public Dialogue gameClickDialogue;
    public Dialogue gameBumpDialogue;


    public UnityEvent onMinigameStarted;
	public UnityEvent onMinigameCompleted;


    private void Start () 
	{
		
	}
	
    //play dialogues, set character dialogues, spawn minigame-specific assets
    //invoke events
	public virtual void StartMinigame()
	{
        stationmanager.SetHelpText(helpText);
        onMinigameStarted.Invoke();

        if (gameBumpDialogue != null)
        {
            stationmanager.Character.SetBumpDialogue(gameBumpDialogue);
        }
        else stationmanager.Character.DeactivateBumpDialogue();

        if (gameClickDialogue != null)
        {
            stationmanager.Character.SetClickDialogue(gameClickDialogue);
        }
        else stationmanager.Character.DeactivateClickDialogue();

        foreach (GameObject asset in minigameAssets)
        {
            asset.SetActive(true);
        }

        
    }

    //hide minigame-specific assets
	public virtual void EndMinigame()
	{
        foreach (GameObject asset in minigameAssets)
        {
            asset.SetActive(false);
        }
        onMinigameCompleted.Invoke();
        GameEvents.Instance.EndMinigame();
    }
}
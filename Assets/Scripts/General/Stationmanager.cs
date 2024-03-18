using RuntimeInspectorNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using static GameEvents;

public class Stationmanager : MonoBehaviour 
{

	

	[SerializeField] private Station currentStation;
	[SerializeField] private Gamemanager gameManager;
	[SerializeField] private TrackedImageManager trackedImageManager;
	
	[SerializeField] private GameObject arPrefab;
	[SerializeField] private Minigame[] minigames;
	[SerializeField] private float QRCodeHeightOffset;
	[SerializeField] private DebugCam debugcam;

	[SerializeField] private Dialogue stationStartDialogue;
    [SerializeField] private Dialogue stationEndDialogue;
    [SerializeField] private TextMeshProUGUI helpPanelText;

    private bool stationStarted = false;
	private bool aRDisabled;
	private int minigameIndex = 0;

    public ARCharacter Character { get; private set; }
	public GameObject ARAsset { get; private set; }
    


    private void OnEnable()
    {
        GameEvents.ARImageDetected += OnImageDetected; ;
        GameEvents.MinigameEnded += MinigameCompleted;
    }

    private void OnDisable()
	{
        GameEvents.ARImageDetected -= OnImageDetected;
        GameEvents.MinigameEnded -= MinigameCompleted;
    }
    private void Start () 
	{
		if(stationStartDialogue != null)
		{
			DialogueManager.instance.StartDialogue(stationStartDialogue);
		}
		

		foreach(Minigame minigame in minigames)
		{
			minigame.stationmanager = this;
		}
	}
	

	//ends station and loads map menu
	public void EndStation()
	{
		Debug.Log("Station Ended");
		currentStation.stationCompleted = true;
		gameManager.LoadMenu();
	}

	//skips ar image detection and set simulatin cam active
	public void SkipAR()
	{
		debugcam.EnableDebugCam();
        aRDisabled = true;
		SpawnAssets();
        StartNextMinigame();
    }

	//sets the help text in the upper right corner
	public void SetHelpText(string helpText)
	{
		helpPanelText.text = helpText;
	}


	//initializes asset spwan and starts minigame when image target is detected
	private void OnImageDetected(ARTrackedImage trackedImage)
	{
		if(!stationStarted)
		{
            SpawnARAssets(trackedImage);
			stationStarted = true;
			StartNextMinigame();
		}


	}
    

	//starts minigame
    private void StartNextMinigame()
	{
		Debug.Log("Start Minigame " + minigames[minigameIndex]);
		if (minigames[minigameIndex].gameStartDialogue != null)
		{
			DialogueManager.instance.StartDialogue(minigames[minigameIndex].gameStartDialogue, minigames[minigameIndex].StartMinigame);
		}
		else
		{
			minigames[minigameIndex].StartMinigame();

        }
		
	}

	//spawn all AR-Assets that should be visible all time in the scene (characters, environment etc.)
	private void SpawnARAssets(ARTrackedImage trackedImage)
	{
        
            Vector3 targetPosition = trackedImage.transform.position;
            Quaternion targetRotation = trackedImage.transform.rotation;
			targetPosition.y -= QRCodeHeightOffset;


            ARAsset = Instantiate(arPrefab, targetPosition, targetRotation);

			if(ARAsset.GetComponentInChildren<ARCharacter>())
			{
				Character = ARAsset.GetComponentInChildren<ARCharacter>();
            }
        

		Debug.Log(Character);
	}

	//debug: spawns assets at origin if ar image detection is skipped
	private void SpawnAssets()
	{
			ARAsset = Instantiate(arPrefab, transform.position, transform.rotation);

			if (ARAsset.GetComponentInChildren<ARCharacter>())
			{
				Character = ARAsset.GetComponentInChildren<ARCharacter>();
			}

    }

	//starts minigame end dialogue, starts next mingame or ends station if every minigame is completed
	private void MinigameCompleted()
	{
		Dialogue currentEndDialogue = minigames[minigameIndex].gameEndDialogue;
        minigameIndex++;

        if (minigameIndex <= minigames.Length - 1)
		{

			if (currentEndDialogue != null)
            {
                DialogueManager.instance.StartDialogue(currentEndDialogue, StartNextMinigame);
            }
            else
            {
                StartNextMinigame();

            }
        }
		else
		{
            if (currentEndDialogue != null)
            {
                DialogueManager.instance.StartDialogue(currentEndDialogue, EndStation);
            }
			else
			{
                if (stationEndDialogue != null)
                {
                    DialogueManager.instance.StartDialogue(stationEndDialogue, EndStation);
                }
				else
				{
					EndStation();
				}
                

            }

        }
    }

}
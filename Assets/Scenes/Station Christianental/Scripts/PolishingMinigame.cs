using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolishingMinigame : Minigame
{
	
	[SerializeField] GameObject trinketDisplay;
	[SerializeField] GameObject[] polishingObjects;


	private float zOffset = 1;
	private GameObject currentObject;
	private int objectCounter;
	private int objectTarget;

	private int swipesNeeded = 4;
	public int swipeCounter;

	private Color dirtyColor;
	private Color targetColor = Color.white;
	private Renderer currentObjectRenderer;

   
    private void OnEnable()
    {
        GameEvents.Swiped += OnSwipe;
    }

    private void OnDisable()
    {
        GameEvents.Swiped -= OnSwipe;
    }
    private void Start () 
	{
		
	}

	//set position for trinkets to appear in front of cam
	public void InitializeTrinketDisplay()
	{
		Debug.Log("Initialize Trinket Display");
		trinketDisplay.transform.position = Camera.main.transform.position + Camera.main.transform.forward * zOffset;
		trinketDisplay.transform.parent = Camera.main.transform;
		SpawnObject();
	}

	//spawn trinket
	private void SpawnObject()
	{
		currentObject = Instantiate(polishingObjects[objectCounter], trinketDisplay.transform.position, Quaternion.identity, trinketDisplay.transform);
		currentObjectRenderer = currentObject.GetComponentInChildren<Renderer>();
		dirtyColor = currentObjectRenderer.material.color;


	}

	private void NextObject()
	{
		Destroy(currentObject);
		SpawnObject();
	}

	private void OnSwipe()
	{
		swipeCounter++;
		ChangeColor();
		CheckSwipes();

	}

	//count swipes
	private void CheckSwipes()
	{
		if(swipeCounter == swipesNeeded)
		{
			stationmanager.Character.RevealTrinket(objectCounter);
            objectCounter++;
            swipeCounter = 0;
            CheckObjectCount();
		}
	}

	//count polished objects
	private void CheckObjectCount()
	{
		if(objectCounter == polishingObjects.Length)
		{
			Destroy(currentObject);
			EndMinigame();
		}
		else
		{
			NextObject();
		}
	}

	//make object one step brighter
	private void ChangeColor()
	{
		currentObjectRenderer.material.color = Color.Lerp(dirtyColor, targetColor, 0 + 0.25f * swipeCounter);
	}
	
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostTrinketsMinigame : Minigame 
{

	// Serialized Fields
	[SerializeField] private List<Transform> spawnLocations = new List<Transform>();
	[SerializeField] private GameObject[] spawnObjects;

	[SerializeField] private Dialogue[] trinketCountDialogues;
	[SerializeField] private AudioClip trinketSound;


	// Private
	private List<Transform> temporarySpawnPositions;
	private int objectsToFind;
	private int objectsFound;
	
	
	private void Start () 
	{
		objectsToFind = spawnObjects.Length;
	}
	
	//spawns trinkrts for search game random at predefined spawn positions
	public void SpawnObjects()
    {
		RestoreSpawnPositions();

		foreach(GameObject trinket in spawnObjects)
        {

			int randomNumber = Random.Range(0, temporarySpawnPositions.Count);
			GameObject SpawnedTrinket = Instantiate(trinket, stationmanager.ARAsset.transform.position + temporarySpawnPositions[randomNumber].position, Quaternion.identity, stationmanager.ARAsset.transform);
			SpawnedTrinket.GetComponent<LostTrinket>().Minigame = this;
			temporarySpawnPositions.RemoveAt(randomNumber);
        }
    }

	//resets spawn location list
	public void RestoreSpawnPositions()
    {
		temporarySpawnPositions = new List<Transform>(spawnLocations);
	}

	public void AddTrinket()
    {
		Debug.Log("Trinket Found!");
		Soundmanager.instance.PlaySound(trinketSound);
		DialogueManager.instance.StartDialogue(trinketCountDialogues[objectsFound], CheckTrinkets);
		
    }

	public void CheckTrinkets()
    {
		objectsFound++;
		if(objectsFound == objectsToFind)
        {
			EndMinigame();
        }
    }
	
}
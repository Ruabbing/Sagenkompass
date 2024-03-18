using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameEvents
{
    private static GameEvents instance;

    public static GameEvents Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEvents();
            }
            return instance;
        }
    }

    public delegate void SwipeHandler();

    public static event SwipeHandler Swiped;
    public void Swipe()
    {
        Debug.Log("Swiped");
        Swiped?.Invoke();
    }


    public delegate void MinigameStart();

    public static event MinigameStart MinigameStarted;
    public void StartMinigame()
    {
        Debug.Log("Minigame Started");
        MinigameStarted?.Invoke();
    }

    public delegate void MinigameEnd();

    public static event MinigameEnd MinigameEnded;
    public void EndMinigame()
    {
        Debug.Log("Swiped");
        MinigameEnded?.Invoke();
    }


    public delegate void ARImageDetector(ARTrackedImage trackedImage);

    public static event ARImageDetector ARImageDetected;
    public void DetectARImage(ARTrackedImage trackedImage)
    {
        Debug.Log("Image Detected");
        ARImageDetected?.Invoke(trackedImage);
    }

}

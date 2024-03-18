using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] Station[] stations;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    //load scenes
    public void LoadScene(Station station)
    {
        SceneManager.LoadScene(station.SceneName);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadAlbum()
    {
        DialogueManager.instance.EndDialogue();
        SceneManager.LoadScene(2);
    }
}

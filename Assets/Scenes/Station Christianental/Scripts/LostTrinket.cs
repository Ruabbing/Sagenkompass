using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostTrinket : MonoBehaviour
{
    public LostTrinketsMinigame Minigame;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Minigame.AddTrinket();
        Destroy(gameObject);
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Station", menuName = "Custom/Station")]
public class Station : ScriptableObject
{
    public string StationName;
    public string SceneName;

    public bool stationCompleted;
}

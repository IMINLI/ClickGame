using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private static GameFacade instance;
    public static GameFacade GetInstance()
    {
        if(instance == null)
        { 
            instance = GameObject.FindObjectOfType<GameFacade>();
            if(instance == null)
            {
             throw new System.Exception("GameFacade can't find , please add it.");
            }
        }
        return instance;
    }
    public StageData[] stageData;
}

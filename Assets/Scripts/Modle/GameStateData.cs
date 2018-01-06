using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateData
{
    public bool isFail;
    public StageData CurStageData
    {
        get
        {
            PlayerData playData = GameFacade.GetInstance().playerData;
            StageData[] stageDatas = GameFacade.GetInstance().stageData;
            return stageDatas[playData.stageIndex]; 
        }
    }
}

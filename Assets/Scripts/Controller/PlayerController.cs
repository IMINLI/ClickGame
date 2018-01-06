using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private PlayerData playerData;
    private LevelDate levelData;
    private ParticleSystem[] hitEffects = new ParticleSystem[3];
    private int hitEffeciUseIndex;

    private void Awake()
    {
        playerData = GameFacade.GetInstance().playerData;
        levelData = GameFacade.GetInstance().levelData;
        RefreshPlayerData();
    }

    private void RefreshPlayerData()
    {
        LevelDate.LevelSetting curLevelSetting = levelData.CurLevelSetting;
        playerData.attack = levelData.CurLevelSetting.attack;
        for (int i =0;i<hitEffects.Length;i++)
        {
            if(hitEffects[i]!=null)            
                Destroy(hitEffects[i].gameObject);
            hitEffects[i] = Instantiate(levelData.CurLevelSetting.hitEffect);
            
        }
    }

    public void OnClickEnemy(EnemyBehavier enemy)
    {
        enemy.DoDamage(playerData.attack);
        ParticleSystem hitEffect = hitEffects[hitEffeciUseIndex];
        hitEffect.transform.position = enemy.hitPoint.position;
        hitEffect.Stop();
        hitEffect.Play();
        hitEffeciUseIndex = (int) Mathf.Repeat(hitEffeciUseIndex+1,hitEffects.Length);
    }
}

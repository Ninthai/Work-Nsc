using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START , PLAYERTURN , ENEMYTURN , WON , LOST}


public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefeb;
    public GameObject enemyPrefeb;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;


    public BattleState state;

    Unity playerUnit;
    Unity enemyUnit;

    public Text dialogueText;


    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle() 
    {
        GameObject playerGo = Instantiate(playerPrefeb , playerBattleStation);
        playerUnit = playerGo.GetComponent<Unity>();

        GameObject EnemyGo = Instantiate(enemyPrefeb , enemyBattleStation);
        enemyUnit = EnemyGo.GetComponent<Unity>();

        dialogueText.text = enemyUnit.unityName;
    
    }

    
}

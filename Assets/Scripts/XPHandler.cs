using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>
public class XPHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GainXP;
    }

    private void OnDisable()
    {
        GameEvents.OnBattleConclude -= GainXP;
    }

    public void GainXP(BattleResultEventData data)
    {
        Debug.Log(data.outcome);
        Debug.Log(data.Xp);
        Debug.Log(data.player.xp);
        Debug.Log(data.npc.xp);

        if (data.outcome == 1)
        {
            data.player.xp += data.Xp;
            Debug.Log("Player has gained " + data.player.xp + "Xp");
        }

        if (data.player.xp >= 100)
        {
            data.player.level += 1;
            GameEvents.PlayerLevelUp(data.player.level);
            Debug.Log("Player has level is " + data.player.level);
           int numPoints = 5;
           StatsGenerator.AssignUnusedPoints(data.player, 5);
            data.player.xp = 0;
        }
        //Don't use this code - makes player level 500
        //data.player.level = 500;

        //data.player.xp += 1; /// add the xp to the player

        //check if player has leveled up
        //if they level up run this code
        // GameEvents.PlayerLevelUp(data.player.level);

        //when player levels up, call this line to add points to stats
        //int numPoints = 10;
        //StatsGenerator.AssignUnusedPoints(data.player, put points here);
    }
}

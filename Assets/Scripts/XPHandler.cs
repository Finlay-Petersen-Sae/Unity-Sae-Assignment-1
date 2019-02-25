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
        //Checking outcome and the data for xp, and debug logging it
        Debug.Log(data.outcome);
        Debug.Log(data.Xp);
        Debug.Log(data.player.xp);
        Debug.Log(data.npc.xp);

        if (data.outcome == 1)
        {
            data.player.xp += data.Xp;
            Debug.Log("Player has gained " + data.player.xp + "Xp");
            //if outcome = 1 add xp to the player and debug how much you gained
        }

        if (data.player.xp >= 100 + (data.player.level *50))
        {
            data.player.level += 1;
            //add 1 to the player level
            GameEvents.PlayerLevelUp(data.player.level);
            //broadcast level up message
            Debug.Log("Player has level is " + data.player.level);
            //debug which level the player is
           int numPoints = 5;
           StatsGenerator.AssignUnusedPoints(data.player, 5);
            // assign 5 points each time
            data.player.xp = 0;
            //set xp back to 0
        }
    }
}

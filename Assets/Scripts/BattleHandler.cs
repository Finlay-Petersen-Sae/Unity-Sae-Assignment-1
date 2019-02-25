using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class with method (function) to determine the outcome of a dance battle based on the player and NPC that are 
///     dancing off against each other.
///     
/// TODO:
///     Battle needs to use stats and random to determine the winner of the dance off
///       - outcome value to be a float value between 1 and negative 1. 1 being the biggest possible player win over NPC, 
///         through to -1 being the most decimating defeat of the player possible.
/// </summary>
public static class BattleHandler
{

    public static void Battle(BattleEventData data)
    {
        //This needs to be replaced with some actual battle logic, at present 
        // we just award the maximum possible win to the player
        float outcome = 1;
        data.player.luck = Random.Range(1, 7);
        data.npc.luck = Random.Range(1, 7);
        //Randomise the luck every time battle begins
        float playerBoogie = data.player.rhythm + data.player.style * 2 + data.player.luck * 2;
        float npcBoogie = data.npc.rhythm + data.npc.style * 2 + data.npc.luck * 2;
        //Find boogie power by using formula (rhythm + style *2 + luck * 2)
        int XpOutcome = Mathf.RoundToInt(playerBoogie - npcBoogie);
        //round xp to a int not float
        int Xp = 0;
        // your code between here
        data.player.luck = Random.Range(1, 7);
        data.npc.luck = Random.Range(1, 7);
        //Randomise the luck every time battle begins

        Debug.Log("Enemy Rhythm = " + data.npc.rhythm);
        Debug.Log("Enemy Style = " + data.npc.style);
        Debug.Log("Enemy Luck = " + data.npc.luck);
        Debug.Log("Enemy Boogie Power = " + npcBoogie);
        //Debug npc's stats

        Debug.Log("Player Rhythm = " + data.player.rhythm);
        Debug.Log("Player Style = " + data.player.style);
        Debug.Log("Player Luck = " + data.player.luck);
        Debug.Log("Player Boogie Power = " + playerBoogie);
        //Debug Player's Stats

       

        if (playerBoogie > npcBoogie)
        {
            outcome = 1;
            Debug.Log("Player wins the dance battle");
        }
        else if (playerBoogie < npcBoogie)
        {
            outcome = 0;
            Debug.Log("Player loses the dance battle");
        }
        else if (playerBoogie == npcBoogie)
        {
            Debug.Log("Player has drawn with the npc");
        }
        //figure out if player has won, lose, or drawn

        if (XpOutcome == 0 || XpOutcome == 1 || XpOutcome == 2)
        {
            Xp = Random.Range(10, 21);
        }
        else if (XpOutcome == 3 || XpOutcome == 4 || XpOutcome == 5)
        {
            Xp = Random.Range(20, 26);
        }
        else if (XpOutcome == 6 || XpOutcome == 7 || XpOutcome == 8 || XpOutcome == 9)
        {
            Xp = Random.Range(25, 36);
        }
        else if (XpOutcome == 10)
        {
            Xp = Random.Range(35, 51);
        }
        //assign xp based on how well the player performed

        var results = new BattleResultEventData(data.player, data.npc, outcome, Xp);
        Debug.Log("Player has attained " + Xp + " Xp");
        Debug.Log("Xp Outcome = " + XpOutcome);
        GameEvents.FinishedBattle(results);
        //Debug log and round up the code
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  A <see langword="static"/> class with methods (functions) for initialising or randomising the stats class.
///  
/// TODO:
///     Initialise a stats instance with generated starting stats
///     Handle the assignment of extra points or xp into an existing stats of a character
///         - this is expected to be used by NPCs leveling up to match the player.
/// </summary>
public static class StatsGenerator
{
    public static void InitialStats(Stats stats)
    {
        // all characters start at level 1
        stats.level = 1;

        // start at 0 experience points 
        stats.xp = 0;
        
        // for you to do - set the other stats
        //stats.rhythm
        stats.rhythm = Random.Range(3, 7);
        //stats.luck
        stats.luck = 0;
        //stats.style
        stats.style = Random.Range(3, 7);
        
       
    }

    public static void AssignUnusedPoints(Stats stats, int points)
    {
        //Assign unused points in a way that favours the lower stat
        if(stats.rhythm <= stats.style)
        {
            stats.rhythm += Mathf.RoundToInt(points * 0.60f);

            stats.style += Mathf.RoundToInt(points * 0.40f);
            points = 0;
        }
        else if (stats.style <= stats.rhythm)
        {
            stats.style += Mathf.RoundToInt(points * 0.60f);
            stats.rhythm += Mathf.RoundToInt(points * 0.40f);
            points = 0;
        }
        Debug.Log(stats.rhythm);
        Debug.Log(stats.style);
        Debug.Log(stats.luck);
        //Debug log new stats
    }
}

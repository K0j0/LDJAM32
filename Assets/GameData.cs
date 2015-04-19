using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData
{
    public Zone currentZone;











    /* *********************************************************
     * START - SINGLETON STUFF
     * ********************************************************* */
    private static GameData _instance;
    public static GameData instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameData();
            }
            return _instance;
        }
    }

    private GameData()
    {
        
    }
    /* *********************************************************
     * END - SINGLETON STUFF
     * ********************************************************* */

}
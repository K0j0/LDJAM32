using UnityEngine;
using System.Collections;

public class EventManager {
    public delegate void OnHeroActionFunc ();
    public static event OnHeroActionFunc onHeroAction;

    public static void callHeroAction ()
    {
        onHeroAction();
    }
}

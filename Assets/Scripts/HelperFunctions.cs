using UnityEngine;
using System.Collections;

public class HelperFunctions : MonoBehaviour {

    static HelperFunctions instance;

    public void Awake()
    {
        instance = this;
    }

    public delegate void Callback();
    public static void DelayCallback(float delay, Callback callback)
    {
        instance.StartCoroutine(DelayCallbackCoroutine(delay, callback));
    }

    static IEnumerator DelayCallbackCoroutine(float delay, Callback callback)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }

    public static void tick(float duration, int count, Callback callback, bool doNow = false)
    {
        instance.StartCoroutine(tickCoroutine(duration, count, callback, doNow));
    }

    static IEnumerator tickCoroutine(float delay, int count, Callback callback, bool doNow = false)
    {
        if (doNow) callback();

        while (count-- >= 0)
        {
            yield return new WaitForSeconds(delay);
            callback();
        }
    }

    public static void waitLoadScene(float waitTime, string sceneName)
    {
        instance.StartCoroutine(waitLoadSceneRoutine(waitTime, sceneName));
    }

    static IEnumerator waitLoadSceneRoutine(float waitTime, string sceneName)
    {
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public static int distance;
    public static int previousDistance;
    public static bool setScore = true;
    public static bool ballStopped = false;
    public static bool chooseTom = false;
    public static bool chooseAmy = false;
    public static bool showBubble = false;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }


}

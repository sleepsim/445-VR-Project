using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static bool switch1, switch2, switch3 = false;

    public static List<int> numSequence = new List<int>();

    public static bool doorUnlocked = false;

    public static bool checkSequence()
    {
        for (int i = 0; i < numSequence.Count - 1; i++)
        {
            if (numSequence[i] > numSequence[i + 1])
            {
                doorUnlocked = false;
                break;  // Stop checking if we find an unordered pair
            }
        }

        doorUnlocked = true;
        return true;
    }
}

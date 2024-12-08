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
            Debug.Log("number i: " + numSequence[i] + "  number i+1: " + numSequence[i + 1]);
            if (numSequence[i] > numSequence[i + 1]) // If the current element is greater than the next, it's not ascending
            {
                return false;
            }
        }
        doorUnlocked = true;
        return true;
    }
}

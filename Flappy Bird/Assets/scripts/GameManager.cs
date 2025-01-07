using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int points = 0;
    public static List<GameObject> poles = new List<GameObject>();

    private void Start()
    {
        points = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static int wishesLeft = 4;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SplashLoad : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}

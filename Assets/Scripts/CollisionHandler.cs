using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //ok as long as this is the only script loading scenes.

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] float levelLoadDelay = 2f;
    int currentLevel;

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("player dying");
        SendMessage("OnPlayerDeath");
        deathFx.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
}

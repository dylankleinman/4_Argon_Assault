using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SplashLoad : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip themeMusic;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("StopAudioSource", 5f);
    }

    private void StopAudioSource()
    {
        audioSource.Stop();
    }

}

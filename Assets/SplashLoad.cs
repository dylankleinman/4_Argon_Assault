using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SplashLoad : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip themeMusic;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("LoadFirstLevel", 2f);
    }


    private void LoadFirstLevel()
    {
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        //if (objs.Length > 1)  //if there is more than one instance of "music" destroy other musics
        //{
        //    Destroy(this.gameObject);
        //}
        //DontDestroyOnLoad(this.gameObject);
        //audioSource.Stop();
        SceneManager.LoadScene(1);
    }

}

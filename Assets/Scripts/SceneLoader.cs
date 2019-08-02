using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class options : MonoBehaviour
{
    //nera
   // public GameObject memory;
   // public float timer;
   // public bool memoryplaying;
   // PlayerGosht player;


    // Start is called before the first frame update
    void Start()
    {
      //  memory.SetActive(false);
       // memoryplaying = false;

      //  player = gameObject.GetComponent<PlayerGosht>();
    }

    // Update is called once per frame
    void Update()
    {


    }



    public void tutorial()
    {
      //  memory.SetActive(true);
       // player.pausemenu2.SetActive(false);
       // player.pausemenu.SetActive(false);

        //memoryplaying = true;

       // VideoPlayer video = memory.GetComponent<VideoPlayer>();
        //video.loopPointReached += OnVideoFinished;

       // video.prepareCompleted += OnPrepareCompleted;
       // video.loopPointReached += OnVideoFinished;
       // video.Prepare();


       // Time.timeScale = 1.0f;


        /* memory.GetComponent<VideoPlayer>().Play();

        memory.GetComponent<VideoPlayer>().prepareCompleted += Opciones_prepareCompleted;
       */

        /*if (memoryplaying == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                timer = 0.0f;
                memory.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }*/



    }

    void OnPrepareCompleted(VideoPlayer vp)
    {
       // vp.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
      //  memory.SetActive(false); // ocultar video al terminar
       // memoryplaying = false;

        // restaurar tiempo
       // Time.timeScale = 1.0f;

        // quitar eventos para evitar duplicación
      //  vp.prepareCompleted -= OnPrepareCompleted;
       // vp.loopPointReached -= OnVideoFinished;
    }
    public void volver_a_inicio_2()
    {
        SceneManager.LoadScene("Inicio2");
    }

    public void ExitGame()
    {
        Application.Quit();

        //EditorApplication.Exit(0);
    }
}

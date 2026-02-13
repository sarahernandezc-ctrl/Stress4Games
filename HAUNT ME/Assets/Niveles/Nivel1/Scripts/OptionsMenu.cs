using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OptionsMenu : MonoBehaviour
{
    //nera
 
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

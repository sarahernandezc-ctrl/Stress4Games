using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionss : MonoBehaviour
{
    //nerea
    public void volver_a_inicio_2()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Inicio2");
    }

    public void ExitGame()
    {
        Application.Quit();

        //EditorApplication.Exit(0);
    }
}

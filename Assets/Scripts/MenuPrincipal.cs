using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    
    public void IniciarJogo()
    {
        SceneManager.LoadScene(1);
    }
    public void EncerrarJogo()
    {
        Application.Quit();
    }
}

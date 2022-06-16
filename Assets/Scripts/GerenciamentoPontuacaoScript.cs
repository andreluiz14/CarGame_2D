using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciamentoPontuacaoScript : MonoBehaviour
{
    private int carga;
    [SerializeField] Text textoCarga;

    public int Carga 
    { 
        get { return carga; } 
        set {
            carga = value; textoCarga.text = carga.ToString();
            PlayerPrefs.SetInt("Carga: ", carga);
        } 
    }
}

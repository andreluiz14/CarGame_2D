using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciamentoPontuacaoScript : MonoBehaviour
{
    private int carga;
    private int entregasQtd;
    [SerializeField] Text textoCarga;
    [SerializeField] Text textoEntregas;
    public int Carga 
    { 
        get { return carga; } 
        set {
            carga = value; 
            textoCarga.text = "Carga: " + carga.ToString();
            PlayerPrefs.SetInt("Carga: ", carga);
        } 
    }
    public int Entregas
    {
        get { return entregasQtd; }
        set
        {
            entregasQtd = value;
            textoEntregas.text = "Entregas: " + entregasQtd.ToString();
            PlayerPrefs.SetInt("Entregas: ", entregasQtd);
        }
    }
}

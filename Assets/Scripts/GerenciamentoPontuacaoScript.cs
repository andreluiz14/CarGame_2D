using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciamentoPontuacaoScript : MonoBehaviour
{
    private int carga;
    private int entregasQtd;
    private int entregasTotal;
    [SerializeField] Text textoCarga;
    [SerializeField] Text textoEntregas;
    [SerializeField] Text textoEntregasTotal;
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
    public int EntregasTotal
    {
        get { return entregasTotal; }
        set
        {
            entregasTotal = value;
            textoEntregasTotal.text = "Total de encomendas: " + entregasTotal.ToString();
            PlayerPrefs.SetInt("Total de encomendas: ", entregasTotal);
        }
    }

}

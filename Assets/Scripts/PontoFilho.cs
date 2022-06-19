using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
    public enum IdPonto
    {
        p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12,
    }

public class PontoFilho : MonoBehaviour
{
    PontosEntregas pontosEntega;
    VeiculoScript veiculo;
    [SerializeField] TextMeshPro textoQuantidadeEntrega;
    public int numRandom;
    public IdPonto id = new IdPonto();
    public int entrega;
    // Start is called before the first frame update
    void Start()
    {
        GerarQuantidaEntrega();
        veiculo = FindObjectOfType<VeiculoScript>();
        pontosEntega = FindObjectOfType<PontosEntregas>();
    }
    private void OnTriggerStay2D(Collider2D veiculo)
    {
        if (veiculo.gameObject.name == "Veiculo" && Input.GetKeyDown(KeyCode.R))
        {
            pontosEntega.EntrouNoTrigger2D(veiculo, id);
            textoQuantidadeEntrega.text = CalculaEntrega(numRandom).ToString();
            PlayerPrefs.SetInt(null, numRandom);
            print(CalculaEntrega(numRandom));
        }
    }
    private void GerarQuantidaEntrega()
    {
        numRandom = Random.Range(1, 4);
        textoQuantidadeEntrega.text = numRandom.ToString();
    }
    private int CalculaEntrega(int num)
    {
        //Ajustar logíca
        if(veiculo.carga >= num)
        {
            veiculo.carga -= num;
            numRandom = numRandom - numRandom;
            entrega += num;
        }else if(veiculo.carga > 0)
        {
            numRandom = numRandom - veiculo.carga;
        }
        
        
        return numRandom;
    }

}

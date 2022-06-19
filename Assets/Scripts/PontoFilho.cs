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
    VeiculoScript veiculoScript;
    private GerenciamentoPontuacaoScript pontuacao;

    [SerializeField] TextMeshPro textoQuantidadeEntrega;
    public int numRandom;
    public IdPonto id = new IdPonto();
    public int entregas;
    // Start is called before the first frame update
    void Start()
    {
        GerarQuantidaEntrega();
        veiculoScript = FindObjectOfType<VeiculoScript>();
        pontosEntega = FindObjectOfType<PontosEntregas>();
        pontuacao = FindObjectOfType<GerenciamentoPontuacaoScript>();
    }
    private void OnTriggerStay2D(Collider2D veiculo)
    {
        if (veiculoScript.gameObject.name == "Veiculo" && Input.GetKey(KeyCode.R) && veiculoScript.carga >= numRandom)
        {
            pontosEntega.EntrouNoTrigger2D(veiculo, id);
            numRandom = CalculaEntrega(numRandom);
            textoQuantidadeEntrega.text = numRandom.ToString();
            //PlayerPrefs.SetInt(null, numRandom);
            print(CalculaEntrega(numRandom));
        }else if(veiculoScript.gameObject.name == "Veiculo" && Input.GetKey(KeyCode.R) && veiculoScript.carga < numRandom && veiculoScript.carga > 0)
        {
            numRandom = CalculaEntregaSeg(numRandom);
            textoQuantidadeEntrega.text = numRandom.ToString();
            //PlayerPrefs.SetInt(null, numRandom);
            print(CalculaEntregaSeg(numRandom));
        }
    }
    private void GerarQuantidaEntrega()
    {
        numRandom = Random.Range(1, 4);
        textoQuantidadeEntrega.text = numRandom.ToString();
    }
    private int CalculaEntrega(int num)
    {
        print("if1");
        veiculoScript.carga -= num;
        numRandom = numRandom - numRandom;
        veiculoScript.entrega += num;
        return numRandom;
    }
    private int CalculaEntregaSeg(int num)
    {
        print("if2");
        veiculoScript.entrega += veiculoScript.carga;
        numRandom = numRandom - veiculoScript.carga;
        veiculoScript.carga = 0;
        return numRandom;
    }

    private void LateUpdate()
    {
        DesativaObjeto();
    }

    private void DesativaObjeto()
    {
        for (int i = 0; i < 12; i++)
        {
            if (numRandom == 0)
                gameObject.SetActive(false);
        }
    }

}

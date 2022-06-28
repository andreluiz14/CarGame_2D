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
    [SerializeField] VeiculoScript[] veiculoScript;
    private GerenciamentoPontuacaoScript pontuacao;

    [SerializeField] TextMeshPro textoQuantidadeEntrega;
    public int numRandom;
    public IdPonto id = new IdPonto();
    public int entregas;
    // Start is called before the first frame update
    private void Awake()
    {
        GerarQuantidaEntrega();

    }
    void Start()
    {
        //pontuacao = FindObjectOfType<GerenciamentoPontuacaoScript>();
    }
    private void OnTriggerStay2D(Collider2D veiculo)
    {
        if (veiculo.CompareTag("Jogador1"))
        {
            print("Jogador 1");
            Jogador1(veiculo);
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
        veiculoScript[0].carga -= num;
        numRandom = numRandom - numRandom;
        veiculoScript[0].entrega += num;
        return numRandom;
    }
    private int CalculaEntregaSeg(int num)
    {
        print("if2");
        veiculoScript[0].entrega += veiculoScript[0].carga;
        numRandom = numRandom - veiculoScript[0].carga;
        veiculoScript[0].carga = 0;
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
    private void Jogador1(Collider2D jogador)
    {
        if (Input.GetKey(KeyCode.P) && veiculoScript[0].carga >= numRandom)
        {
            pontosEntega.EntrouNoTrigger2D(jogador, id);
            numRandom = CalculaEntrega(numRandom);
            textoQuantidadeEntrega.text = numRandom.ToString();
            //PlayerPrefs.SetInt(null, numRandom);
            print(CalculaEntrega(numRandom));
        }
        else if (Input.GetKey(KeyCode.P) && veiculoScript[0].carga < numRandom && veiculoScript[0].carga > 0)
        {
            numRandom = CalculaEntregaSeg(numRandom);
            textoQuantidadeEntrega.text = numRandom.ToString();
            //PlayerPrefs.SetInt(null, numRandom);
            print(CalculaEntregaSeg(numRandom));
        }
    }

}

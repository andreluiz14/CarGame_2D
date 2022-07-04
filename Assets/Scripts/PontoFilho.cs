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
        pontosEntega = GetComponent<PontosEntregas>();
        //pontuacao = FindObjectOfType<GerenciamentoPontuacaoScript>();
    }
    private void OnTriggerStay2D(Collider2D veiculo)
    {
        if (veiculo.CompareTag("Jogador1"))
        {
            Jogador1(veiculo);
        }
        else if (veiculo.CompareTag("Jogador2"))
        {
            Jogador2(veiculo);
        }
    }
    private void GerarQuantidaEntrega()
    {
        numRandom = Random.Range(1, 4);
        textoQuantidadeEntrega.text = numRandom.ToString();
    }
    private int CalculaEntrega(int num, int id)
    {
        print("if1");
        veiculoScript[id].cargaVeiculo.Carga -= num;
        numRandom = numRandom - numRandom;
        veiculoScript[id].cargaVeiculo.EntregasTotal += num;
        return numRandom;
    }
    private int CalculaEntregaSeg(int num, int id)
    {
        print("if2");
        veiculoScript[id].cargaVeiculo.EntregasTotal += veiculoScript[id].cargaVeiculo.Carga;
        numRandom = numRandom - veiculoScript[id].cargaVeiculo.Carga;
        veiculoScript[id].cargaVeiculo.Carga = 0;
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
        if (Input.GetKey(KeyCode.P) && veiculoScript[0].cargaVeiculo.Carga >= numRandom)
        {
            //pontosEntega.EntrouNoTrigger2D(jogador, id);
            numRandom = CalculaEntrega(numRandom, 0);
            textoQuantidadeEntrega.text = numRandom.ToString();
            print(CalculaEntrega(numRandom, 0));
        }
        else if (Input.GetKey(KeyCode.P) && veiculoScript[0].cargaVeiculo.Carga < numRandom && veiculoScript[0].cargaVeiculo.Carga > 0)
        {
            numRandom = CalculaEntregaSeg(numRandom, 0);
            textoQuantidadeEntrega.text = numRandom.ToString();
            print(CalculaEntregaSeg(numRandom, 0));
        }
    }
    private void Jogador2(Collider2D jogador)
    {
        if (Input.GetKey(KeyCode.R) && veiculoScript[1].cargaVeiculo.Carga >= numRandom)
        {
            //pontosEntega.EntrouNoTrigger2D(jogador, id);
            numRandom = CalculaEntrega(numRandom, 1);
            textoQuantidadeEntrega.text = numRandom.ToString();
            print(CalculaEntrega(numRandom, 1));
        }
        else if (Input.GetKey(KeyCode.R) && veiculoScript[1].cargaVeiculo.Carga < numRandom && veiculoScript[1].cargaVeiculo.Carga > 0)
        {
            numRandom = CalculaEntregaSeg(numRandom, 1);
            textoQuantidadeEntrega.text = numRandom.ToString();
            print(CalculaEntregaSeg(numRandom, 1));
        }
    }

}

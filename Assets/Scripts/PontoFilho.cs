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
    [SerializeField] TextMeshPro textoQuantidadeEntrega;
    public int numRandom;
    public IdPonto id = new IdPonto();
    // Start is called before the first frame update
    void Start()
    {
        GerarQuantidaEntrega();
        pontosEntega = FindObjectOfType<PontosEntregas>();
    }
    private void OnTriggerStay2D(Collider2D veiculo)
    {
        if(veiculo.gameObject.name == "Veiculo" && Input.GetKey(KeyCode.R) && numRandom > 0)
        {
            pontosEntega.EntrouNoTrigger2D(veiculo, id);
            textoQuantidadeEntrega.text = SubtraiQuantidadeEntrega(numRandom).ToString();
            PlayerPrefs.SetInt(null, numRandom);
            print(SubtraiQuantidadeEntrega(numRandom));
        }
    }
    private void GerarQuantidaEntrega()
    {
        numRandom = Random.Range(1, 4);
        textoQuantidadeEntrega.text = numRandom.ToString();
    }
    private int SubtraiQuantidadeEntrega(int num)
    {
        numRandom = numRandom - numRandom;
        return numRandom;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PontosEntregas : MonoBehaviour
{
    [SerializeField] PontoFilho[] pontoEntrega = new PontoFilho[12];
    [SerializeField] TextMeshPro[] textoQdt = new TextMeshPro[12];
    public int totalEntregas;
    int rad;
    // Start is called before the first frame update
    private void Start()
    {
        GerarPontosEntrega();
    }
    public void EntrouNoTrigger2D(Collider2D veiculo, IdPonto id)
    {
    }
    private void CalcularTotalEntrega()
    {
        for(int i = 0; i < pontoEntrega.Length; i++)
        {
            
        }
    }
    private void GerarPontosEntrega()
    {
        for (int i = 0; i < pontoEntrega.Length; i++)
        {
            rad = Random.Range(0, 2);
            if(rad == 0)
            {
                pontoEntrega[i].gameObject.SetActive(true);
                totalEntregas += pontoEntrega[i].numRandom;
            }
            else
            {
                pontoEntrega[i].gameObject.SetActive(false);
            }
        }
    }
}

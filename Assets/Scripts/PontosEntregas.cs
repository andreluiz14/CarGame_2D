using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PontosEntregas : MonoBehaviour
{
    [SerializeField] PontoFilho[] pontoEntrega = new PontoFilho[12];
    [SerializeField] TextMeshPro[] textoQdt = new TextMeshPro[12];
    private int[] num = new int[12];
    public int totalEntregas;
    // Start is called before the first frame update
    private void Start()
    {
        CalculoTotalEntrega();
    }
    public void EntrouNoTrigger2D(Collider2D veiculo, IdPonto id)
    {
    }
    public void CalculoTotalEntrega()
    {
        for(int i = 0; i < 12; i++)
        {
            totalEntregas += pontoEntrega[i].numRandom;
        }
    }

}

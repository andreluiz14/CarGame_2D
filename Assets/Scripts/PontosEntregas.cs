using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PontosEntregas : MonoBehaviour
{
    [SerializeField] GameObject[] pontoEntrega = new GameObject[12];
    [SerializeField] TextMeshPro[] textoQdt = new TextMeshPro[12];
    private int[] num = new int[12];
    public int totalEntregas;
    // Start is called before the first frame update
    private void Start()
    {
        GerarQuantidaEntrega();
    }
    public void EntrouNoTrigger2D(Collider2D veiculo, IdPonto id)
    {
        print(veiculo + "  " + id + " Qtd ");
    }
    private void GerarQuantidaEntrega()
    {
        for (int i = 0; i < textoQdt.Length; i++)
        {
            num[i] = Random.Range(1, 4);
            totalEntregas += num[i];
            textoQdt[i].text = num[i].ToString();
        }
    }
}

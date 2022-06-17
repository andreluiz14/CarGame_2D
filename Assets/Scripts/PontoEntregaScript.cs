using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PontoEntregaScript : MonoBehaviour
{
    private int quantidadeEntrega;
    private int randomQtd;
    [SerializeField] TextMeshPro TextoQuantidadeEntrega;
    [SerializeField] List<GameObject> pontoEntrega;
    public int QuantidadeEntrega
    {
        get 
        {
            return quantidadeEntrega; 
        }
        set 
        {
            quantidadeEntrega = value;
            TextoQuantidadeEntrega.text = quantidadeEntrega.ToString();
            PlayerPrefs.SetInt(null, QuantidadeEntrega);
        }
    }
    private void Start()
    {
        randomQtd = Random.Range(1, 3);
        QuantidadeEntrega = randomQtd;
    }
    private void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.R))
        {
            if(QuantidadeEntrega > 0)
            {
                QuantidadeEntrega -= 1;
                print(QuantidadeEntrega);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PontoEntregaScript : MonoBehaviour
{
    private int quantidadeEntrega;
    //[SerializeField] TextMeshProUGUI TextoQuantidadeEntrega;
    [SerializeField] TextMeshPro TextoQuantidadeEntrega;
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
            quantidadeEntrega = Random.Range(1, 4);
            PlayerPrefs.SetInt(null, QuantidadeEntrega);
        }
    }

}

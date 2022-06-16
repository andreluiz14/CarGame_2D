using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class PontoEntregaScript : MonoBehaviour
{
    private int quantidadeEntrega;
    [SerializeField] Text TextoQuantidadeEntrega;
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
            quantidadeEntrega = Random.Range(0, 4);
            PlayerPrefs.SetInt(null, QuantidadeEntrega);
        }
    }

}

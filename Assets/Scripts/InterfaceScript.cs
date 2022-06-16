using UnityEngine;
using UnityEngine.UI;

public class InterfaceScript : MonoBehaviour
{
    private VeiculoScript veiculo;
    private GerenciamentoPontuacaoScript pontuacao;
    private PontoEntregaScript pontosEntregaScript;
    //[SerializeField] Text carga;
    // Update is called once per frame
    private void Start()
    {
        veiculo = FindObjectOfType<VeiculoScript>();
        pontuacao = FindObjectOfType<GerenciamentoPontuacaoScript>();
        pontosEntregaScript = FindObjectOfType<PontoEntregaScript>();

        pontuacao.Carga = PlayerPrefs.GetInt("Carga: ",0);
        pontuacao.Entregas = PlayerPrefs.GetInt("Entregas: ", 0);
        pontosEntregaScript.QuantidadeEntrega = PlayerPrefs.GetInt(null, 0);
    }
    void Update()
    {
        //pontuacao.Carga = veiculo.carga;
        pontuacao.Entregas = veiculo.entrega;
        pontosEntregaScript.QuantidadeEntrega = PlayerPrefs.GetInt (null, 0);
    }
}

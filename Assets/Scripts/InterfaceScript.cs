using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InterfaceScript : MonoBehaviour
{
    [SerializeField]
    private VeiculoScript[] veiculos = new VeiculoScript[2];
    private PontosEntregas pontosEntregas;

    [SerializeField] Text textoCargaJogador1;
    [SerializeField] Text textoEntregasQtdJogador1;
    [SerializeField] Text textoEntregasTotalJogador1;
    [SerializeField] Text textoCargaJogador2;
    [SerializeField] Text textoEntregasTotalJogador2;
    [SerializeField] Text textoEntregasQtdJogador2;


    [SerializeField] GameObject menuInGame;

    // Update is called once per frame
    private void Start()
    {
        menuInGame.SetActive(false);

        pontosEntregas = FindObjectOfType<PontosEntregas>();

        
    }
    void LateUpdate()
    {
        ApresentarDadosInterface();
        MenuInGame();
        
    }
    private void ApresentarDadosInterface()
    {

        textoCargaJogador1.text = "Carga: " + veiculos[0].cargaVeiculo.Carga;
        textoEntregasQtdJogador1.text = "Total de encomenda: " + pontosEntregas.totalEntregas.ToString();
        textoEntregasTotalJogador1.text = "Entregas: " + veiculos[0].cargaVeiculo.EntregasTotal.ToString();

        textoCargaJogador2.text = "Carga: " + veiculos[1].cargaVeiculo.Carga;
        textoEntregasQtdJogador2.text = "Total de encomenda: " + pontosEntregas.totalEntregas.ToString();
        textoEntregasTotalJogador2.text = "Entregas: " + veiculos[1].cargaVeiculo.EntregasTotal.ToString();
    }
    private void MenuInGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuInGame.SetActive(true);
            PausarJogo();
        }

    }
    public void ContinuarJogo()
    {
        menuInGame.SetActive(false);
        Despausar();
    }
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(1);
        Despausar();
    }
    public void RetornarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
        Despausar();
    }
    private void PausarJogo()
    {
        Time.timeScale = 0;
    }
    private void Despausar()
    {
        Time.timeScale = 1;
    }
}

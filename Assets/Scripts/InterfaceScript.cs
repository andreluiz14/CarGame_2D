using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class InterfaceScript : MonoBehaviour
{

    [SerializeField] private  VeiculoScript[] veiculos = new VeiculoScript[2];
    private PontosEntregas pontosEntregas;

    [SerializeField] Text textoCargaJogador1;
    [SerializeField] Text textoEntregasQtdJogador1;
    [SerializeField] Text textoEntregasTotalJogador1;
    [SerializeField] Text textoCargaJogador2;
    [SerializeField] Text textoEntregasTotalJogador2;
    [SerializeField] Text textoEntregasQtdJogador2;


    [SerializeField] GameObject menuInGame;
    [SerializeField] GameObject menuVitoria;
    private bool menuVitoriaAtivo;
    [SerializeField] TextMeshProUGUI textoGanhador;

    // Update is called once per frame
    private void Start()
    {
        menuInGame.SetActive(false);
        menuVitoria.SetActive(false);

        pontosEntregas = FindObjectOfType<PontosEntregas>();
    }
    void LateUpdate()
    {
        ApresentarDadosInterface();
        DefinirGanhador();
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
    private void DefinirGanhador()
    {
        if (veiculos[0].cargaVeiculo.EntregasTotal >= pontosEntregas.pontosVitoria)
        {
            PausarJogo();
            menuVitoria.SetActive(true);
            textoGanhador.color = Color.magenta;
            textoGanhador.text = "Jogador 1 ganhou!";
        }else if (veiculos[1].cargaVeiculo.EntregasTotal >= pontosEntregas.pontosVitoria)
        {
            PausarJogo();
            menuVitoria.SetActive(true);
            textoGanhador.color = Color.blue;
            textoGanhador.text = "Jogador 2 ganhou!";
        }
        /*else if(veiculos[0].cargaVeiculo.EntregasTotal == pontosEntregas.pontosVitoria - 1 && veiculos[1].cargaVeiculo.EntregasTotal == pontosEntregas.pontosVitoria - 1)
        {
            PausarJogo();
            menuVitoria.SetActive(true);
            textoGanhador.color = Color.black;
            textoGanhador.text = "Empate!";
        }*/
        else
        {
            Despausar();
        }
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
        Despausar();
        menuInGame.SetActive(false);
    }
    public void ReiniciarJogo()
    {
        menuVitoria.SetActive(false);
        Despausar();
        SceneManager.LoadScene(1);
    }
    public void RetornarMenuPrincipal()
    {
        Despausar();
        SceneManager.LoadScene(0);
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

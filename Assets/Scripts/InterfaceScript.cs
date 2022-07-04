using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InterfaceScript : MonoBehaviour
{
    private VeiculoScript veiculo;
    private GerenciamentoPontuacaoScript pontuacao;
    private PontosEntregas pontosEntregas;


    [SerializeField] GameObject menuInGame;
    // Update is called once per frame
    private void Start()
    {
        menuInGame.SetActive(false);

        veiculo = FindObjectOfType<VeiculoScript>();
        pontuacao = FindObjectOfType<GerenciamentoPontuacaoScript>();
        pontosEntregas = FindObjectOfType<PontosEntregas>();

        pontuacao.Carga = PlayerPrefs.GetInt("Carga: ",0);
        pontuacao.Entregas = PlayerPrefs.GetInt("Entregas: ", 0);
        pontuacao.EntregasTotal = PlayerPrefs.GetInt("Total de encomendas: ", 0);
    }
    void LateUpdate()
    {
        ApresentarDadosInterface();
        MenuInGame();
        
    }
    private void ApresentarDadosInterface()
    {
        pontuacao.Carga = veiculo.carga;
        pontuacao.Entregas = veiculo.entrega;
        pontuacao.EntregasTotal = pontosEntregas.totalEntregas;
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

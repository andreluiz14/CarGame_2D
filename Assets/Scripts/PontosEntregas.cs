using UnityEngine;
using UnityEngine.UI;


public class PontosEntregas : MonoBehaviour
{
    [SerializeField] PontoFilho[] pontoEntrega = new PontoFilho[24];
    public int totalEntregas;
    int rad;
    public int pontosVitoria;
    // Start is called before the first frame update
    private void Start()
    {
        GerarPontosEntrega();
    }
    public void EntrouNoTrigger2D(Collider2D veiculo, IdPonto id)
    {
    }
    private void GerarPontosEntrega()
    {
        for (int i = 0; i < pontoEntrega.Length; i++)
        {
            rad = Random.Range(0, 2);
            if(rad == 0)
            {
                totalEntregas += pontoEntrega[i].numRandom;
                pontoEntrega[i].gameObject.SetActive(true);
            }
            else
            {
                pontoEntrega[i].gameObject.SetActive(false);
            }
        }
            pontosVitoria = totalEntregas / 2 + 1;
    }
}

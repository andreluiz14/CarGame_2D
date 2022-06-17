using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public enum IdPonto
    {
        p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12,
    }

public class PontoFilho : MonoBehaviour
{
    PontosEntregas pontosEntega;

    public IdPonto id = new IdPonto();
    // Start is called before the first frame update
    void Start()
    {
        pontosEntega = FindObjectOfType<PontosEntregas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D veiculo)
    {
        if(veiculo.gameObject.name == "Veiculo")
            pontosEntega.EntrouNoTrigger2D(veiculo, id);
    }
}

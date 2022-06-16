using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceScript : MonoBehaviour
{
    private VeiculoScript veiculo;
    private GerenciamentoPontuacaoScript pontuacao;
    // Update is called once per frame
    private void Start()
    {
        pontuacao = FindObjectOfType<GerenciamentoPontuacaoScript>();
        pontuacao.Carga = PlayerPrefs.GetInt("Carga: ", 0);
    }
    void Update()
    {
        pontuacao.Carga = veiculo.carga;       
    }
}

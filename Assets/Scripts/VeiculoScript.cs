using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Jogador
{
    jogador1,
    jogador2,
}
public class VeiculoScript : MonoBehaviour
{
    Rigidbody2D veiculoRb;
    [Header("Atalhos")]
    [SerializeField] KeyCode teclaInteracao;

    //Movimento baseado na direção que o jogador escolhe
    [Header("Movimentação")]
    [SerializeField] float aceleracaoForca = 5f;
    [SerializeField] float rotacaoForca = 5f;
    [SerializeField] float rotacaoQuantidade, direcao, velocidade;
    [SerializeField] float velocidadeRotacao;

    //Entregas
    [Header("Carga do veículo")]
    [SerializeField] int cargaMaxima;
    public int carga, entrega;


    // jogador1
    private float horizontalSeta;
    public VeiculoCarga cargaVeiculo;
    public Jogador jogador = new Jogador();
    void Start()
    {
        cargaVeiculo = GetComponent<VeiculoCarga>();
        veiculoRb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MovimentarJogadores();
        //MovimentoRelativoDirecao();
    }
    void MovimentarJogadores()
    {
        if(jogador == Jogador.jogador1)
        InputPrimJogador();
        if(jogador == Jogador.jogador2)
        InputSegJogador();
        direcao = Mathf.Sign(Vector2.Dot(veiculoRb.velocity, veiculoRb.GetRelativeVector(Vector2.up)));
        veiculoRb.rotation += horizontalSeta * rotacaoForca * veiculoRb.velocity.magnitude * direcao;
        veiculoRb.AddRelativeForce(Vector2.up * velocidade);
        veiculoRb.AddRelativeForce(-Vector2.right * veiculoRb.velocity.magnitude * horizontalSeta / 2);
        if (velocidade <= 0.5f)
            veiculoRb.angularVelocity = 0f;
    }
    private void InputPrimJogador()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalSeta = -1f;
        }
        else
        {
            horizontalSeta = 0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalSeta = 1f;
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocidade = 1f * aceleracaoForca;
        }
        else
        {
            velocidade = 0f * aceleracaoForca;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocidade = -1f * aceleracaoForca;
        }
    }
    private void InputSegJogador()
    {
        if (Input.GetKey(KeyCode.D))
        {
            horizontalSeta = -1f;
        }
        else
        {
            horizontalSeta = 0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalSeta = 1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            velocidade = 1f * aceleracaoForca;
        }
        else
        {
            velocidade = 0f * aceleracaoForca;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocidade = -1f * aceleracaoForca;
        }
    }
    void MovimentoRelativoDirecao()
    {
        rotacaoQuantidade = - Input.GetAxis("Horizontal");
        velocidade = Input.GetAxis("Vertical") * aceleracaoForca;
        direcao = Mathf.Sign(Vector2.Dot(veiculoRb.velocity, veiculoRb.GetRelativeVector(Vector2.up)));

        if(velocidade != 0)
            veiculoRb.rotation += rotacaoQuantidade * rotacaoForca * veiculoRb.velocity.magnitude * direcao;

        veiculoRb.AddRelativeForce(Vector2.up * velocidade);
        if(velocidade != 0)
            veiculoRb.AddRelativeForce(-Vector2.right * veiculoRb.velocity.magnitude * rotacaoQuantidade / 2);

        if (velocidade <= 0.5f)
            veiculoRb.angularVelocity = 0f;
    }
    private void OnTriggerStay2D(Collider2D outro)
    {
        
        // Reabastecimento
        if (outro.gameObject.CompareTag("Produto") && Input.GetKey(teclaInteracao))
        {
            cargaVeiculo.Carga = cargaMaxima;
        }
    }
}

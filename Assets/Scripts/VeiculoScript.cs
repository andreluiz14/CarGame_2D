using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeiculoScript : MonoBehaviour
{
    Rigidbody2D veiculoRb;
    [Header("Atalhos")]
    [SerializeField] KeyCode teclaInteracao;

    //Movimento baseado na dire��o que o jogador escolhe
    [Header("Movimenta��o")]
    [SerializeField] float aceleracaoForca = 5f;
    [SerializeField] float rotacaoForca = 5f;
    [SerializeField] float rotacaoQuantidade, direcao, velocidade;

    //Entregas
    [Header("Carga do ve�culo")]
    [SerializeField] int cargaMaxima;
    public int carga, entrega;
    
    void Start()
    {
        veiculoRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        MovimentoRelativoDirecao();
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
        if (outro.gameObject.CompareTag("Produto") && Input.GetKeyDown(teclaInteracao))
        {
            carga = cargaMaxima;
        }
        //Entrega
        if(outro.gameObject.CompareTag("Entrega") && Input.GetKeyDown(teclaInteracao) && carga > 0)
        {
            carga -= 1;
            entrega += 1;
        }
    }
}

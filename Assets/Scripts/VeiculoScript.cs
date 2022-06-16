using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeiculoScript : MonoBehaviour
{
    Rigidbody2D veiculoRb;
    
    //Movimento baseado na direção que o jogador escolhe
    [SerializeField] float aceleracaoForca = 5f;
    [SerializeField] float rotacaoForca = 5f;
    [SerializeField] float rotacaoQuantidade, direcao, velocidade;

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
            veiculoRb.AddRelativeForce(-Vector2.right * veiculoRb.velocity.magnitude * rotacaoQuantidade /2);

        if (velocidade <= 0.5f)
            veiculoRb.angularVelocity = 0f;
    }
}

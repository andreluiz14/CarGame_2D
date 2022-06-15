using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeiculoScript : MonoBehaviour
{
    Rigidbody2D veiculoRb;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movDirecao;

    [SerializeField] float velocidade ;
    [SerializeField] float velocidadeRotacao = 60;
    // Start is called before the first frame update

    //Movimento baseado na direção que o jogador escolhe
    [SerializeField] float aceleracaoForca = 5f;
    [SerializeField] float rotacaoForca = 5f;
    [SerializeField] float rotacaoQuantidade, direcao;

    void Start()
    {
        veiculoRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimento();
    }
    private void FixedUpdate()
    {
        //MovimentoRb();
        MovimentoRelativoDirecao();
    }
    void Movimento()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.forward * -horizontalInput * Time.deltaTime * velocidadeRotacao);
        //transform.Translate(Vector2.up * verticalInput * Time.deltaTime * velocidade);
    }
    void MovimentoRb()
    {
        movDirecao = transform.up * Input.GetAxis("Vertical") * Time.deltaTime * velocidade;
        veiculoRb.MovePosition(transform.position + movDirecao);
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
    }
}

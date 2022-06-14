using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeiculoScript : MonoBehaviour
{
    Rigidbody2D veiculoRb;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movDirecao;

    [SerializeField] float velocidade = 20;
    [SerializeField] float velocidadeRotacao = 60;
    // Start is called before the first frame update

    //Movimento baseado na direção que o jogador escolhe
    private Vector2 carroLocalizacao;
    float carroDirecao;
    float carroVelocidade;
    float direcaoAngulo;
    float rodaDinstancia;
    void Start()
    {
        veiculoRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }
    private void FixedUpdate()
    {
        MovimentoRb();
    }
    void Movimento()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.forward * -horizontalInput * Time.deltaTime * velocidadeRotacao);
        //transform.Translate(Vector2.up * verticalInput * Time.deltaTime * velocidade);
    }
   
    private void OnCollisionEnter2D(Collision2D outro)
    {
        //if (outro.gameObject.CompareTag("Quadra"))
        //{
           
        //}
    }
    void MovimentoRb()
    {
        movDirecao = transform.up * Input.GetAxis("Vertical") * Time.deltaTime * velocidade;
        veiculoRb.MovePosition(transform.position + movDirecao);
    }
    void MovimentoBaseadoDirecao()
    {
        Vector2 frenteRoda = carroLocalizacao + rodaDinstancia / 2 * new Vector2(Mathf.Cos(carroDirecao), Mathf.Sin(carroDirecao));
        Vector2 trasRoda = carroLocalizacao - rodaDinstancia / 2 * new Vector2(Mathf.Cos(carroDirecao), Mathf.Sin(carroDirecao));

        trasRoda += carroVelocidade
    }
}

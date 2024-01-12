using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour    
{
    [SerializeField]
    private float velocidade;

    private int contador;

    private Rigidbody rb;

    public TMP_Text contar;

    public TMP_Text vitoria;

    public float forcaDeSalto = 5f;
    private bool estaNoChao;


    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        rb = GetComponent<Rigidbody>();
        Contador();
        vitoria.text = "";
    }

    void Contador()
    {
        contar.text = "Contador: "  + contador.ToString();  
        if (contador >= 12)
        {
            vitoria.text = "Ganhou! Parabens";
        }
    }

    private void FixedUpdate()
    {
        float moverNaHorizontal = Input.GetAxis("Horizontal");
        float moverNaVertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(moverNaHorizontal, 0.0f, moverNaVertical);

        rb.AddForce(movimento * velocidade);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coletavel1"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            Contador();
        }else if (other.gameObject.CompareTag("Coletavel2"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 2;
            Contador();
        }
        else if (other.gameObject.CompareTag("Coletavel3"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 3;
            Contador();
        }
    }

    // Update is called once per frame
    void Update()
    {

        estaNoChao = Physics.Raycast(transform.position, Vector3.down, 0.5f);


        if (estaNoChao && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, forcaDeSalto, rb.velocity.z);
        }
    }

}

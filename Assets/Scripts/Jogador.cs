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
        if (contador >= 6)
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
        if(other.gameObject.CompareTag("Coletavel"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            Contador();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

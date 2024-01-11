using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jogador : MonoBehaviour    
{
    [SerializeField]
    private float velocidade;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

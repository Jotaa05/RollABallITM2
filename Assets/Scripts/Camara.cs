using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public GameObject jogador;

    private Vector3 oofset;

    // Start is called before the first frame update
    void Start()
    {
        oofset = transform.position - jogador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = jogador.transform.position + oofset;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fim : MonoBehaviour
{
    // Start is called before the first frame update

    public float tempoLimite = 60f; 
    private float tempoAtual = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtual += Time.deltaTime;

        if (tempoAtual >= tempoLimite)
        {
            EncerrarJogo();
        }

    }

    void EncerrarJogo()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        {
            Application.Quit();
        #endif
    }
}

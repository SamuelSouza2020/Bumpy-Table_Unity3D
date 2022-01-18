using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OndeEstou : MonoBehaviour
{
    //Todos os comandos são encontrados no Unity Documentation
    
    //Método singleton - Para garantir que somente uma instância do objeto exista
    public static OndeEstou instance;

    public int fase = -1;
    public string faseN;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += VerificaFase;
    }
    //Verifica o número da fase pelo BuildIndex e o nome.
    void VerificaFase(Scene cena, LoadSceneMode modo)
    {
        fase = SceneManager.GetActiveScene().buildIndex;
        faseN = SceneManager.GetActiveScene().name;
    }
}

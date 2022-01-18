using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //Todos os comandos são encontrados no Unity Documentation
    //Script para iniciar o jogo, encontrado no Menu Principal
    //Comtém o Botão (Start) par começar a jogar e o botão (?) informando que é um jogo demonstrativo
    [SerializeField]
    Button iniciarGm, quest, fecP;
    GameObject painAviso;

    void Start()
    {
        painAviso = GameObject.Find("PanelAviso");
        fecP = GameObject.Find("Fechar").GetComponent<Button>();
        painAviso.SetActive(false);
        iniciarGm = GameObject.Find("StartGM").GetComponent<Button>();
        quest = GameObject.Find("Quest").GetComponent<Button>();

        iniciarGm.onClick.AddListener(FaseInicial);
        //onClick.AddListener() é usado para adicionar um evento no botão.
        //Quando clicar no botão vai ser chamado o void com o nome que está entre parênteses ()
        quest.onClick.AddListener(AbrirP);
        fecP.onClick.AddListener(FechaP);
    }
    void FaseInicial()
    {
        SceneManager.LoadScene(1);
    }
    void AbrirP()
    {
        painAviso.SetActive(true);
    }
    void FechaP()
    {
        painAviso.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
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
        quest.onClick.AddListener(AbrirP);
        fecP.onClick.AddListener(FechaP);
    }

    // Update is called once per frame
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

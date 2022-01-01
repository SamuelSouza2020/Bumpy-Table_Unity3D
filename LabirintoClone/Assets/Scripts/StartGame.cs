using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    Button iniciarGm, quest;

    void Awake()
    {
        iniciarGm = GameObject.Find("Start").GetComponent<Button>();
        quest = GameObject.Find("Quest").GetComponent<Button>();

        iniciarGm.onClick.AddListener(FaseInicial);
    }

    // Update is called once per frame
    void FaseInicial()
    {
        SceneManager.LoadScene(1);
    }
}

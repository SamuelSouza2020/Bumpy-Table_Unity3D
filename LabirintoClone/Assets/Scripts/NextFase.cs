using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFase : MonoBehaviour
{
    //Todos os comandos são encontrados no Unity Documentation
    /*
    proFase (int) utilizado para saber o número da próxima fase, em caso de muitas fases criar um nome script GameManager com Singleton.
    Nele será armazenado o número da fase e pode utilizar incremento para avançar de fase (para não fazer tudo manualmente)
    Ou utilizando o script OndeEstou, Exemplo:
    SceneManager.LoadScene(OndeEstou.instance.fase++);
    */
    [SerializeField]
    int proFase = 2;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ProxFase());
        }
    }
    IEnumerator ProxFase()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(proFase);
    }
}

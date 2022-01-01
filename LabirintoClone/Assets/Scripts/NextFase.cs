using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFase : MonoBehaviour
{
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    //Todos os comandos são encontrados no Unity Documentation
    /*Script utilizado para movimentar a parede na fase 2
    Método simples para movimentar um objeto em zigue-zague
    Existe varios métodos para fazer essa função, como animação e motores
    */
    
    //variavel (lado) utilizada para não dar conflito no IF
    int lado = 0;

    private void Update()
    {
        //Movimento por limite. Caso ele chegue no limite proposto no IF ele vai para o outro lado.
        if (transform.position.z <= 3.7 && lado == 0)
        {
            transform.Translate(new Vector3(0, 0, 4 * Time.deltaTime));
            if (transform.position.z >= 2.8)
            {
                lado = 1;
            }
        }
        if (transform.position.z >= -3.7 && lado == 1)
        {
            transform.Translate(new Vector3(0, 0, -4 * Time.deltaTime));
            if (transform.position.z <= -2.8)
            {
                lado = 0;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiCod : MonoBehaviour
{
    [SerializeField]
    private Animator caixaAnim;

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("heroiAtaca"))
        {
            caixaAnim.SetTrigger("heroiDano");
            caixaAnim.Play("caixa");
            NASCADENA.instance.Nascimento(transform.position);
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);

        }

    }


  
}
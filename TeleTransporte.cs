using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TeleTransporte : MonoBehaviour
{

    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private Tilemap tileAlvo;
    [SerializeField]
    private Image fundoP;
    [SerializeField]
    private GameObject animaText;

    private void Awake()
    {
        fundoP.enabled = false;
    }

    IEnumerator OnTriggerEnter2D(Collider2D outro)
    {
        if(outro.gameObject.CompareTag("hero"))
        {
            fundoP.enabled = true;
            Animator anim = fundoP.GetComponent<Animator>();
            anim.Play("FUNDO_ANIM");
            outro.GetComponent<MovePersonagem>().enabled = false;
            outro.GetComponent<Animator>().enabled = false;

            yield return new WaitForSeconds(1);
            outro.transform.position = alvo.transform.GetChild(0).position;
            CameraSegue.instance.tileM = tileAlvo;
            CameraSegue.instance.StartMapa();

            anim.Play("FUNDO_ANIM_INVERS");

            StartCoroutine(animaText.GetComponent<TextFade>().MostraTexto(tileAlvo.tag));
            outro.GetComponent<MovePersonagem>().enabled = true;
            outro.GetComponent<Animator>().enabled = true;
        }
    }
}

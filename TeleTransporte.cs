MIT License

Direitos autorais (c) [2023] [JoãoAbreu]

Permissão é concedida, gratuitamente, a qualquer pessoa que obtenha uma cópia deste software e dos arquivos de documentação associados (o "Software"), para lidar com o Software sem restrição, incluindo, sem limitação, os direitos de uso, cópia, modificação, fusão, publicação, distribuição, sublicenciamento e/ou venda de cópias do Software, e permitir pessoas a quem o Software seja fornecido a fazê-lo, sujeito às seguintes condições:

O aviso de direitos autorais acima e este aviso de permissão devem ser incluídos em todas as cópias ou partes substanciais do Software.

O SOFTWARE É FORNECIDO "COMO ESTÁ", SEM GARANTIA DE QUALQUER TIPO, EXPRESSA OU IMPLÍCITA, INCLUINDO, MAS NÃO SE LIMITANDO ÀS GARANTIAS DE COMERCIALIZAÇÃO, ADEQUAÇÃO A UM DETERMINADO FIM E NÃO VIOLAÇÃO. EM NENHUMA CIRCUNSTÂNCIA, OS AUTORES OU PROPRIETÁRIOS DE DIREITOS DE AUTOR PODERÃO SER RESPONSABILIZADOS POR QUAISQUER REIVINDICAÇÕES, DANOS OU OUTRAS RESPONSABILIDADES, SEJA EM AÇÃO DE CONTRATO, DELITO OU DE OUTRA FORMA, DECORRENTES DE, OU EM CONEXÃO COM O SOFTWARE OU O USO OU OUTRAS NEGOCIAÇÕES NO PROGRAMAS.

[Jogo Demon's Rebirth]

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

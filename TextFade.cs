MIT License

Direitos autorais (c) [2023] [JoãoAbreu]

Permissão é concedida, gratuitamente, a qualquer pessoa que obtenha uma cópia deste software e dos arquivos de documentação associados (o "Software"), para lidar com o Software sem restrição, incluindo, sem limitação, os direitos de uso, cópia, modificação, fusão, publicação, distribuição, sublicenciamento e/ou venda de cópias do Software, e permitir pessoas a quem o Software seja fornecido a fazê-lo, sujeito às seguintes condições:

O aviso de direitos autorais acima e este aviso de permissão devem ser incluídos em todas as cópias ou partes substanciais do Software.

O SOFTWARE É FORNECIDO "COMO ESTÁ", SEM GARANTIA DE QUALQUER TIPO, EXPRESSA OU IMPLÍCITA, INCLUINDO, MAS NÃO SE LIMITANDO ÀS GARANTIAS DE COMERCIALIZAÇÃO, ADEQUAÇÃO A UM DETERMINADO FIM E NÃO VIOLAÇÃO. EM NENHUMA CIRCUNSTÂNCIA, OS AUTORES OU PROPRIETÁRIOS DE DIREITOS DE AUTOR PODERÃO SER RESPONSABILIZADOS POR QUAISQUER REIVINDICAÇÕES, DANOS OU OUTRAS RESPONSABILIDADES, SEJA EM AÇÃO DE CONTRATO, DELITO OU DE OUTRA FORMA, DECORRENTES DE, OU EM CONEXÃO COM O SOFTWARE OU O USO OU OUTRAS NEGOCIAÇÕES NO PROGRAMAS.

[Jogo Demon's Rebirth]

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour {

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        anim = GetComponent<Animator>();

    }

    public IEnumerator MostraTexto(string nome) {
        {
            anim.Play("TEXT_ANIM");
            txt.text = nome;
            yield return new WaitForSeconds(1);
            anim.Play("TEXT_ANIM2");   
        }
    }
}

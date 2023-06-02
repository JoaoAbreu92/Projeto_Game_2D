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

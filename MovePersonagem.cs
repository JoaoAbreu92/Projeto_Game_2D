using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePersonagem : MonoBehaviour
{

    private float vel;
    private Vector2 direcao;
    public Animator anim;
    private Rigidbody2D heroiRB;
    private Vector2 direcaoHeroi;

    private SpriteRenderer heroiR;
    private bool liberaCor = false;
    [SerializeField]

    private bool danoCritico = false;
    [SerializeField]

    private CircleCollider2D ataqueEfeito;
    
    void Start(){

        AtaqueEnab();
        heroiRB = GetComponent<Rigidbody2D>();
        vel = 2;
        direcao = Vector2.zero;

        heroiR = GetComponent<SpriteRenderer>();

    }

    
    void Update(){
       
        InputPersonagem();

        if(direcao != Vector2.zero)
        {
            ataqueEfeito.offset = new Vector2(direcao.x / 2, direcao.y /2);
        }
    
        if(direcao.x != 0 || direcao.y != 0)
        {
            Animacao(direcao);
        }
        else
        {
            anim.SetLayerWeight(1, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            AnimacaoAtaque ();
            ataqueEfeito.enabled = true;
        }

        if(liberaCor == true)
        {
            PingPongColor(8);
        }

        if(danoCritico == true)
        {
            PingPongColor(1);
        }   

    }

    public void AtaqueEnab()
    {
        ataqueEfeito.enabled = false;
    }

    void PingPongColor(int x)
    {
        heroiR.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(x * Time.time, 0.5f));
    }

    private void FixedUpdate()
    {
        heroiRB.MovePosition(heroiRB.position + direcao * vel * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("morte"))
        {
            StartCoroutine(KnockBack(3f, 50, direcaoHeroi));
            DanoCor();
        }
    }

    void InputPersonagem()
{
    
    direcao = Vector2.zero;
    

    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
    {
        direcao += Vector2.up;
        direcaoHeroi = direcao;
    }
    if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
    {
        direcao += Vector2.down;
        direcaoHeroi = direcao;
    }
    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
    {
        direcao += Vector2.left;
        direcaoHeroi = direcao;
    }
    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
    {
        direcao += Vector2.right;
        direcaoHeroi = direcao;
    }
   
}

    void Animacao(Vector2 dir)
    {
        anim.SetLayerWeight(1, 1);

        anim.SetFloat("x", dir.x);
        anim.SetFloat("y", dir.y);

    }

    void AnimacaoAtaque()
    {
        anim.SetTrigger ("ataque");
    }

    public IEnumerator KnockBack(float duracao, float poder, Vector2 direcao)
    {
        float tempo = 0;

        while(duracao > tempo)
        {
            tempo += Time.deltaTime;
            heroiRB.AddForce(new Vector2(direcao.x * -poder, direcao.y * -poder), ForceMode2D.Force);
        }

        yield return 0;
    }

    void DanoCor()
    {
        liberaCor = true;
        StartCoroutine(LiberaCor());
    }

    IEnumerator LiberaCor()
    {
        yield return new WaitForSeconds(0.5f);
        liberaCor = false;
        heroiR.color = new Color(1,1,1,1);
    }
}

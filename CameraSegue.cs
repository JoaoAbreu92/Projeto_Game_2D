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

public class CameraSegue : MonoBehaviour{

    public static CameraSegue instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    
       
    }
    public Transform alvo;
    private float xMax, xMin, yMax, yMin;

    public Tilemap tileM;
    private Vector3 minTile, maxTile;
   
    void Start () {
        

        StartMapa();
    }

    public void StartMapa()
    {
        minTile = tileM.CellToWorld(tileM.cellBounds.min);
        maxTile = tileM.CellToWorld(tileM.cellBounds.max);

        Limites(minTile, maxTile);
    }
    
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(alvo.position.x,xMin,xMax), Mathf.Clamp(alvo.position.y,yMin,yMax), -10);
    }

    void Limites(Vector3 minTile, Vector3 maxTile)
    {
        Camera cam = Camera.main;
        float altura = 2f * cam.orthographicSize;
        float largura = altura * cam.aspect;

        xMin = minTile.x + largura / 2;
        xMax = maxTile.x - largura / 2;
        yMin = minTile.y + altura / 2;
        yMax = maxTile.y - altura / 2;


    }
}
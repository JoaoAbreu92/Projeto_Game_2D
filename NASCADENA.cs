using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NASCADENA : MonoBehaviour
{
    public static NASCADENA instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    [SerializeField]
    private GameObject adena;
    [SerializeField]
    private int nasc = 0;

    public void Nascimento(Vector3 pos) {
        {
            nasc = Random.Range(0, 3);
            if(nasc == 1) 
            {
                Instantiate(adena,pos,Quaternion.identity);
            }
        }
    }

}

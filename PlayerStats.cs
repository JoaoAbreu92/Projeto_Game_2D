using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public Text txt1, txt2, txt3;

    //XP

    public int xpMultiplica = 2;
    public float xpLevel = 100;
    public float fatDificult = 2.0f;
    private float xpProxLevel;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            AddXP(100);
            txt1.text = PegaXPAtual().ToString();
            txt2.text = PegaLevelAtual().ToString();
            txt3.text = PegaProxXP().ToString();
        }

       if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }

    }
    //Metodo XP

    public void AddXP(float xpAdd)
    {
        float novoXP = PlayerPrefs.GetFloat("xpAtual") + xpAdd * xpMultiplica;

        //metodo xp continuo

        while(novoXP >= PegaProxXP())
        {
            novoXP -= PegaProxXP();
            AddLevel();
        }

        PlayerPrefs.SetFloat("xpAtual", novoXP);
    }

    public float PegaXPAtual()
    {
        return PlayerPrefs.GetFloat("xpAtual");
    }

    public int PegaLevelAtual()
    {
        return PlayerPrefs.GetInt("LevelAtual");
    }

    public void AddLevel()
    {
        int novoLevel = PegaLevelAtual() + 1;
        PlayerPrefs.SetInt("LevelAtual", novoLevel);
    }

    public float PegaProxXP()
    {
        return xpLevel * (PegaLevelAtual() + 1) * fatDificult;
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class PannelloViteScript : MonoBehaviour
{

    public Image[] immaginiVite;

    public static PannelloViteScript singleton;

    public int ViteRimaste
    {
        get
        {
            return immaginiVite.Count(v => v.enabled);
        }
    }

    void Awake()
    {
        singleton = this;
    }

    public void PerdiVita()
    {
        if (ViteRimaste > 0)
        {
            immaginiVite.Last(v => v.enabled).enabled = false;
        }
        else
        {
            StartCoroutine(GameManagerScript.singleton.GameOver());
        }
    }

}
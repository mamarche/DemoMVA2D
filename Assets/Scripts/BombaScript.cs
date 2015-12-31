using UnityEngine;
using System.Collections;

public class BombaScript : MonoBehaviour
{

    public GameObject esplosionePrefab;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(esplosionePrefab, transform.position, transform.rotation);
        if (collision.gameObject.name == "Personaggio")
        {
            if (PannelloViteScript.singleton.ViteRimaste == 0)
                Destroy(collision.gameObject);
            PannelloViteScript.singleton.PerdiVita();
        }
        GameManagerScript.singleton.IncrementaPunteggio();
        Destroy(gameObject);
    }
}

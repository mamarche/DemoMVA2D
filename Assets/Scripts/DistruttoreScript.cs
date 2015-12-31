using UnityEngine;
using System.Collections;

public class DistruttoreScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Personaggio")
            StartCoroutine(GameManagerScript.singleton.GameOver());
        else
            Destroy(collision.gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class IsolaScript : MonoBehaviour {

    public float velocita = 5f;

	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * velocita;
	}
	
}

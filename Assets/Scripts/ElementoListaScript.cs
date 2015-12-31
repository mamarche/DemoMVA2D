using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ElementoListaScript : MonoBehaviour {

    public Text testoNome;
    public Text testoLivello;
    public Text testoPunti;

    public void SetDati(string nome, int livello, int punti)
    {
        testoNome.text = nome;
        testoLivello.text = string.Format("Livello: {0}", livello);
        testoPunti.text = string.Format("Punti: {0}", punti);
    }
}

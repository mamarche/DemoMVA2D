using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public Transform[] puntiEmissioneIsole;
    public Transform[] puntiEmissioneBombe;
    public GameObject isolaPrefab;
    public GameObject bombaPrefab;
    public Text testoPunteggio;
    public Button startButton;

    private int punteggio = -1;

    public static GameManagerScript singleton;

    void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        IncrementaPunteggio();
        Time.timeScale = 0;
    }

    void GeneraIsola()
    {
        Instantiate(isolaPrefab, puntiEmissioneIsole[Random.Range(0, puntiEmissioneIsole.Length)].position, Quaternion.identity);
        Invoke("GeneraIsola", 2f);
    }

    void GeneraBomba()
    {
        Instantiate(bombaPrefab, puntiEmissioneBombe[Random.Range(0, puntiEmissioneBombe.Length)].position, Quaternion.identity);
        Invoke("GeneraBomba", 2f);
    }

    public IEnumerator GameOver()
    {
        yield return StartCoroutine(AzureManagerScript.singleton.PostPunteggio(1, 2, punteggio));
        Application.LoadLevel("GameScene");
    }

    public void IncrementaPunteggio()
    {
        punteggio++;
        testoPunteggio.text = string.Format("Bombe Schivate: {0}", punteggio);
    }

    public void IniziaGioco()
    {
        Time.timeScale = 1;
        Invoke("GeneraIsola", 2f);
        Invoke("GeneraBomba", 3f);
        startButton.gameObject.SetActive(false);
    }
    public void CreaGiocatore()
    {
        StartCoroutine(AzureManagerScript.singleton.PostGiocatore("Marcello"));
    }
}

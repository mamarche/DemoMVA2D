using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void AzureManegerHandler(object dati);
public class AzureManagerScript : MonoBehaviour {

    public static AzureManagerScript singleton;

    public event AzureManegerHandler OnClassificaReceived;

    private const string ApiUrl = "http://localhost:3101/api/";

    void Awake()
    {
        singleton = this;
    }
	
    public IEnumerator PostGiocatore(string nome)
    {
        WWWForm form = new WWWForm();
        form.AddField("Nome", nome);

        WWW web = new WWW(string.Format("{0}{1}", ApiUrl, "Giocatori"), form);

        do { yield return null; } while (!web.isDone);

        string error = web.error;

        if (string.IsNullOrEmpty(error))
        {
            print("Giocatore salvato!");
        }
        else
        {
            print(error);
        }

    }

    public IEnumerator PostPunteggio(int giocatoreId, int livelloId, int punti)
    {
        WWWForm form = new WWWForm();
        form.AddField("GiocatoreId", giocatoreId);
        form.AddField("LivelloId", livelloId);
        form.AddField("Punti", punti);

        WWW web = new WWW(string.Format("{0}{1}", ApiUrl, "Punteggi"), form);

        do { yield return null; } while (!web.isDone);

        string error = web.error;

        if (string.IsNullOrEmpty(error))
        {
            print("Punteggio salvato!");
        }
        else
        {
            print(error);
        }

    }

    public IEnumerator GetClassifica()
    {

        WWW web = new WWW(string.Format("{0}{1}", ApiUrl, "Punteggi"));

        do { yield return null; } while (!web.isDone);

        string error = web.error;

        if (string.IsNullOrEmpty(error))
        {
            List<object> punteggi = MiniJSON.Json.Deserialize(web.text) as List<object>;
            if (OnClassificaReceived != null) OnClassificaReceived(punteggi);
        }
        else
        {
            print(error);
        }
    }

}

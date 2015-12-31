using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClassificaManagerScript : MonoBehaviour
{

    public GameObject elementoListaPrefab;
    public GameObject pannelloElementi;

    void Start()
    {
        AzureManagerScript.singleton.OnClassificaReceived += Singleton_OnClassificaReceived;
        StartCoroutine(AzureManagerScript.singleton.GetClassifica());
    }

   

    private void Singleton_OnClassificaReceived(object dati)
    {

        foreach (Dictionary<string,object> item in dati as List<object> )
        {
            GameObject elemento = Instantiate(elementoListaPrefab) as GameObject;
            ElementoListaScript es = elemento.GetComponent<ElementoListaScript>();

            es.SetDati((item["Giocatore"] as Dictionary<string, object>)["Nome"].ToString(),
                       int.Parse(item["LivelloId"].ToString()),
                       int.Parse(item["Punti"].ToString()));

            elemento.transform.SetParent(pannelloElementi.transform);
            elemento.transform.localScale = Vector3.one;
        }

    }

    public void OnDisable()
    {
        AzureManagerScript.singleton.OnClassificaReceived -= Singleton_OnClassificaReceived;
    }
}

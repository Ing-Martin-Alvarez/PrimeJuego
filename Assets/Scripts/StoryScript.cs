using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class StoryScript : MonoBehaviour
{
    //Variables de seleccion
    public GameObject Respuestas_btn, VozNarrador, Mensaje;
    //Variable de registro
    private string RegAns, Mensaje_txt;    
    private int TotalText=0, ActualText=1;
    private float TimeText, IniTimeText;
    private InfoGuardaScript IGS;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CargarRespuestas");
        IGS = GameObject.Find("InfoData").GetComponent<InfoGuardaScript>();

    }

    // Update is called once per frame
    void Update()
    {        
        
    }

    //Funcion para cambiar la escena y saber que respondio el usuario
    public void SeleccionRespuesta(GameObject _Text)
    {
        IGS.Registro += "Escena " + IGS.NextScene + ": " + _Text.GetComponent<Text>().text + "\n";
        IGS.NextScene++;
        SceneManager.LoadScene(IGS.NextScene);
        Debug.Log("El boton fue presionado y dice: " + _Text.GetComponent<Text>().text);
    }

    //Funcion para que una vez cargado el nivel se reproduzca la voz del narrador y una vez termine de leer le permita responder
    private IEnumerator CargarRespuestas()
    {
        //Seccion que carga el texto del mensaje y tambien inicia su auto escritura        
        Mensaje_txt = Mensaje.GetComponent<Text>().text;
        IniTimeText = VozNarrador.GetComponent<AudioSource>().clip.length/ Mensaje_txt.Length;        
        TimeText = IniTimeText;
        TotalText = Mensaje_txt.Length;
        ActualText = 0;
        StartCoroutine("EscribeTextoN");
        //Seccion que carga la voz y carga las respuestas una vez la voz termina de reproducirse.
        VozNarrador.GetComponent<AudioSource>().Play();        
        yield return new WaitForSeconds(VozNarrador.GetComponent<AudioSource>().clip.length);
        foreach (Transform gami in Respuestas_btn.transform)
        {
            gami.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }        

    }
    //Parte de la funcion que escribe texto de manera mas natural a la par que la voz(Este codigo es parte de la funcion Cargar respuestas
    private IEnumerator EscribeTextoN()
    {
        for(ActualText=0; ActualText<TotalText; ActualText++)
        {
            Mensaje.GetComponent<Text>().text = Mensaje_txt.Substring(0, ActualText);
            yield return new WaitForSeconds(IniTimeText);
        }
    }
}

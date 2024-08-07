using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class InfoGuardaScript : MonoBehaviour
{
    public InputField Nombre_obj, Edad_obj;
    public Button BTNSalir;
    public Dropdown Sexo_obj;
    public string Registro;
    public int NextScene;
    private string CasoName;
    public GameObject ComenzarUI, RegistroUI;
    //Llamamos la funcion de despertar para poder configurar el juego a un limite de 60fps para evitar fuga de rendimiento
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        Registro = "";
        NextScene = 0;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuardarDatos()
    {
        if (!File.Exists(Application.streamingAssetsPath + "/Casos/" + CasoName + ".txt")){
            File.WriteAllText(Application.streamingAssetsPath + "/Casos/" + CasoName + ".txt","");
        }        
        StreamWriter guardar = new StreamWriter(Application.streamingAssetsPath + "/Casos/" + CasoName + ".txt");
        guardar.WriteLine(Registro);
        guardar.Close();
    }

    public void CambiaEscena()
    {
        if (CheckifEmpty())
        {
            Registro += "Nombre: " + Nombre_obj.GetComponent<InputField>().text + "\nEdad: " + Edad_obj.GetComponent<InputField>().text + "\nSexo: " + Sexo_obj.GetComponentInChildren<Text>().text + "\n";
            CasoName = Nombre_obj.text;
            NextScene++;
            SceneManager.LoadScene(NextScene);
            Debug.Log(Registro);
        }else
        {
            Debug.Log("Falta un campo");
        }
    }

    private bool CheckifEmpty()
    {
        if (Nombre_obj.text == "" | Edad_obj.text == "")
            return false;
        else
            return true;
    }

    public void Comenzar()
    {
        ComenzarUI.SetActive(false);
        RegistroUI.SetActive(true);
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
}

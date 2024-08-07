using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Terminar()
    {
        GameObject.Find("InfoData").GetComponent<InfoGuardaScript>().GuardarDatos();
        Destroy(GameObject.Find("InfoData"));
        SceneManager.LoadScene(0);
    }
}

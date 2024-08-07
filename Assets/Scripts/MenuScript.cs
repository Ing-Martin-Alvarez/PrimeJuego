using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    //Variables de los objeto usados en botones
    public GameObject Menu, MenuPrincipal, MenuOpciones, GameInterface;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Lectura de la tecla Escape para mostrar u ocultar el menu del juego(no pausa el gameplay).
        if (Input.GetKeyUp(KeyCode.Escape)){
            if (Menu.activeSelf)
            {
                Menu.SetActive(false);
                GameInterface.SetActive(true);
            }
            else
            {
                Menu.SetActive(true);
                GameInterface.SetActive(false);
            }
        }
    }

    //Funciones para moverse por el menu(Cuando esta visible)
    public void MenuOpciones_Btn()
    {
        MenuPrincipal.SetActive(false);
        MenuOpciones.SetActive(true);
    }

    public void MenuPrincipal_Btn()
    {
        MenuPrincipal.SetActive(true);
        MenuOpciones.SetActive(false);
    }

    public void MenuContinuar_Btn()
    {
        Menu.SetActive(false);
        GameInterface.SetActive(true);
    }

}

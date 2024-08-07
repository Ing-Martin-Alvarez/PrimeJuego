using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AlumnosClass
{
    //Datos de los alumnos que seran guardados
    public string nombre;
    public int edad;
    public bool sexo;

    public AlumnosClass(string _nombre, int _edad, bool _sexo)
    {
        nombre = _nombre;
        edad = _edad;
        sexo = _sexo;
    }
}

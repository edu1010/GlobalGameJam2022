using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Language
{
    English = 1,
    Catalan,
    Spanish
}
public class Localizator : MonoBehaviour
{
    //Variable del csv
    //un singleton para acceder desde cualquier lado
    //Un dicionario

    //Delegado para que al cambiar el idoma todos los elementos suscritos cambien de idioma
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Funcion que lea el texto y guarde las variables en el dicionario
    //clave y 2 idiomas
    //Empezamos en uno para saltarnos la primera linea del csv
}

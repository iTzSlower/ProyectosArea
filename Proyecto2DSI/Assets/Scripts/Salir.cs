﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
    public void Salida() {

        Application.Quit();
        Debug.Log("Se ah cerrado el juego");
    }
}
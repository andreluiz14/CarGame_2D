using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeiculoCarga : MonoBehaviour
{
    private int carga;
    private int entregasQtd;
    private int entregasTotal;
    public int Carga
    {
        get { return carga; }
        set
        {
            carga = value;
        }
    }
    public int EntregasQtd
    {
        get { return entregasQtd; }
        set
        {
            entregasQtd = value;
        }
    }
    public int EntregasTotal
    {
        get { return entregasTotal; }
        set
        {
            entregasTotal = value;
        }
    }
}

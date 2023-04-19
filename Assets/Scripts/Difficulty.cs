using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Difficulty
{
    // Variables for multiplier trigger
    // potatosLow, potatosMid, potatosHigh
    public int potatosTL;
    public int potatosTM;
    public int potatosTH;

    // Variables for multiplier ammounts
    // fewAmmount, someAmmount, lotsAmmount
    public int MultiplierFew;
    public int MultiplierSome;
    public int MultiplierLots;

    // Variables for incrementation update
    // PotatoGardenLimit, PotatoFarmLimit, PotatoFactoryLimit
    public int GardenLimit;
    public int FarmLimit;
    public int FactoryLimit;
}

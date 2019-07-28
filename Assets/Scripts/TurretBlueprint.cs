using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretBlueprint {

    public GameObject prefab;
    
    public Image prefabImage;
    public int cost;


    public GameObject upgradedPrefab;
    public int upgradeCost;
    public float timeToBuild;

    public GameObject popup;


    public int GetSellAmount()
    {
        return cost / 2;
    }
}

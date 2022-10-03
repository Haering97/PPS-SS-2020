using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFManager : MonoBehaviour
{
    [SerializeField] private GameObject shelf;
    [SerializeField] public int numberOfShelves;
    [SerializeField] public int shelfHeight;
    [SerializeField] public int shelfLength;
    [SerializeField] public int trayWidth;
    [SerializeField] public int trayLength;
    
    static public Transform vfOrigin;
    
    public float spacingShelves = 2f;
    public float spacingLayer = 2f;
    public float spacingTrays = 2f;
    public float spacingPlants = 0.1f;

    public float spacingShelvesDynamic;
    public float spacingTraysDynamic;
    
    public float globalsize = 1f;

    void Start()
    {
        vfOrigin = transform;
        spacingShelvesDynamic = spacingShelves + trayWidth;
        //spacingTraysDynamic = spacingTrays + trayLength;
        
        
        for (int i = 0; i < numberOfShelves; i++)
        {
            var shelfInstance = Instantiate(shelf, vfOrigin);
            shelfInstance.transform.position += new Vector3(i, 0, 0) * spacingShelvesDynamic;
            var shelfScript = shelfInstance.GetComponent<ShelfScript>();
            shelfScript.id = i;
        }
        

    }
    
    void Update()
    {
        
    }

    public float getSpacingTraysDynamic()
    {
        return spacingTrays + trayLength;
    }
}

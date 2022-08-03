using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Color = System.Drawing.Color;

public class VFBuilder : MonoBehaviour
{
    [SerializeField] private GameObject cube;


    [SerializeField] public int shelves;
    [SerializeField] public int shelfHeight;
    [SerializeField] public int shelfLength;
    [SerializeField] public int trayWidth;
    [SerializeField] public int trayLength;

    public Transform origin;

    static public Vector3 cubeSize = new Vector3(0.5f, 0.5f, 0.5f);

    //Classes

    public class VerticalFarm
    {
        public Shelf[] Shelves { get; set; }

        public VerticalFarm(int amount, int shelfHeight, int shelfLength, int trayWidth, int trayLength)
        {
            Shelves = new Shelf[amount];
            for (int i = 0; i < amount; i++)
            {
                Shelves[i] = new Shelf(shelfHeight, shelfLength, trayWidth, trayLength);
            }
        }
    }

    public class Shelf
    {
        public Tray[,] Trays { get; set; }

        public Shelf(int shelfHeight, int shelfLength, int trayWidth, int trayLength)
        {
            Trays = new Tray[shelfHeight, shelfLength];

            for (int i = 0; i < shelfHeight; i++)
            {
                for (int j = 0; j < shelfLength; j++)
                {
                    Trays[i, j] = new Tray(trayWidth, trayLength);
                }
            }
        }
    }

    public class Tray
    {
        public PlantUnit[,] PlantUnits { get; set; }

        public Tray(int trayWidth, int trayLength)
        {
            PlantUnits = new PlantUnit[trayWidth, trayLength];
            for (int i = 0; i < trayWidth; i++)
            {
                for (int j = 0; j < trayLength; j++)
                {
                    PlantUnits[i, j] = new PlantUnit();
                    PlantUnits[i, j].OriginalSize = cubeSize;
                }
            }
        }
    }

    public class PlantUnit
    {
        
        public GameObject Instance { get; set; }
        public string Id { get; set; }
        public float Humidity { get; set; }
        public float GrowthFactor { get; set; } = 0;

        public Vector3 OriginalSize;
        public Color Color = Color.Chartreuse;
    }


    void Start()
    {
        Debug.Log("PP-Log: Start");
        origin = transform;

        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.sharedMaterial.SetColor("_Color", UnityEngine.Color.green);

        VerticalFarm myFirstFarm = new VerticalFarm(shelves, shelfHeight, shelfLength, trayWidth, trayLength);

        Debug.Log(myFirstFarm.Shelves[0].Trays[0, 0].PlantUnits[0, 0].Humidity);

        var activeShelf = myFirstFarm.Shelves[0];

        InstantiateTray(myFirstFarm,0,0,0);
        
        Debug.Log("PP-Log: Finished");
    }

    void Update()
    {
        
    }
    

    void InstantiateTray(VerticalFarm farm,int shelfNumber, int trayPositionX, int trayPositionY)
    {
        //TODO make grid to instaniate cubes on.

        var plants = farm.Shelves[shelfNumber].Trays[trayPositionX, trayPositionY].PlantUnits;
        
        for (int i = 0; i < trayWidth; i++)
        {
            for (int j = 0; j < trayLength; j++)
            {
                plants[i, j].Instance = Instantiate(cube,origin);
            }
        }
        
        
    }
}
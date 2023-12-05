using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component
{
    string cName { get; set; }
   int ID { get; set; }//reference from the database
    GameObject prefab { get; set; }//3d comp
    componentType type { get; set; }//Component
    string description { get; set; }
    bool polarity { get; set; }//where the power is avaiable(which rows)
    //Vector3 conPosition { get; set; }//connected positin in vector3 form
    
    List<int> Capcity { get; set; }


    public int[,] grid;

    public void setPrefab(GameObject g)
    {
        this.prefab = g;
    }

    public GameObject getPrefab()
    {
        return prefab;
    }
    public string getCname()
    {
        return this.cName;
    }
    public List<int> getCapcity()
    {
    return Capcity;
    }
    public int capcityCount()
    {
        return Capcity.Count;
    }
    public int getCapcityrow()
    {
        return Capcity[0];
    }

    public bool getPolarity()
    {
        return polarity;
    }
    //constructor
    public Component(string name, string description, bool polarity, List<int>  Capacity) {
        this.cName= name;
        this.description= description;
        this.polarity = polarity;
        this.Capcity = Capacity;

    }


/*    public List<Vector2> OccupiedTiles(GameObject Tile)
    {
        float avgX = 0;//should be avg
        float avgY = 0;
        List<Vector2> ocTiles = new List<Vector2>();
        int OccupiedTiles = 0;

        if (this.type == componentType.Resistor)
        {
            OccupiedTiles = 5;
        }
        else if (this.type == componentType.Light) { OccupiedTiles = 2; }

        float disX = 0;
        float disY = 0;
        for (int i = 0; i < ocTiles.Count; i++)
        {
            disX += Tile.transform.position.x;
            disY += Tile.transform.position.y;
        }
        avgX = disX / ocTiles.Count;
        avgY = disY / ocTiles.Count;

        ocTiles = new Vector2(avgX, avgY);

        return ocTiles;

    }*/
}

public enum componentType
{
    Light,
    Resistor,
    Wire
}

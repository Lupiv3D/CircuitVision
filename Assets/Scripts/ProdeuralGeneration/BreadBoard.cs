// using System.Collections;
// using System.Collections.Generic;
// using System.ComponentModel;
// using Unity.VisualScripting;
// using Unity.XR.CoreUtils;
// using UnityEngine;
// using UnityEngine.UIElements;
// using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

// public class BreadBoard : MonoBehaviour
// {
//     public Transform parentPos;

//     [SerializeField] public float buffer = 1.5f;//add buffer around the tile
//     //path for the connection
//     public static List<GameObject> GeneratedTiles = new List<GameObject>();
//     public static List<float> MainTilesX = new List<float>();
//     public static List<float> MainTilesZ = new List<float>();
//     public static List<GameObject> PowerTiles = new List<GameObject>();


//    // public List<GameObject> listComponents = new List<GameObject>();//list of Component that come from the models
//    // public LineRenderer lineRendererPrefab;
//     [SerializeField] private GameObject linePrefab;


//     [Header("Prefab Department")]
//     //private Component c1 = new Component(tilePrefab.gameObject, "bulib", " -something- ", false);
//     [SerializeField] private GameObject tilePrefab;
//     [SerializeField] private GameObject activePrefab;
//     [SerializeField] private GameObject putPrefab;
//     [SerializeField] private GameObject parent;
//     private int v = 60;//vertical
//     private int h = 13;//horizontal

//     [Header("Components Prefab")]
//     [SerializeField] private GameObject resistor;
//     [SerializeField] private GameObject LED;
//     [SerializeField] private GameObject switches;
//     [SerializeField] private GameObject diode;
//     Dictionary<string,GameObject> prefabDic= new Dictionary<string,GameObject>();

//     List<Component> userComp = new List<Component>();
//     List<GameObject> compList = new List<GameObject>();
//     List<Component> listComponent = new List<Component>();//list of Component that come from the models
//     Component c1 = new Component("resistor", "Something", false, new List<int> { 3 , 0 });
//     Component c2 = new Component("switch", "Something", false, new List<int> { 3, 3 });
//     Component c3 = new Component("LED", "Something", true, new List<int> { 0, 2 });
//     Component c4 = new Component("diode", "Something", false, new List<int> { 2,0  });
    
    
    

//     void createCompList(List<string> list)
//     {
//         for (int i=0;i<list.Count;i++)
//         {
//             for(int j=0;j< listComponent.Count;j++)
//             {

//                 if (list[i] == listComponent[j].getCname())
//                 {
//                     userComp.Add(listComponent[j]);
//                 }
            
//             }
//             if (prefabDic.ContainsKey(list[i]))
//             {
//                 compList.Add(prefabDic[list[i]]);
//             }
//         }
//     }
// void powerRail(int x)
//     {
//         for (int z = 0; z <= v; z++)
//         {//+ - 
//             if (z % 6 != 0)
//             { //postive lane
//                 GameObject posTile = Instantiate(tilePrefab,
//                        new Vector3(x * buffer, 0, z * buffer),
//                        Quaternion.identity, parent.transform);
//                 //negative lane
//                 GameObject negaTile = Instantiate(tilePrefab,
//                        new Vector3((x + 1) * buffer, 0, z * buffer),
//                        Quaternion.identity, parent.transform);

//                 PowerTiles.Add(posTile);
//                 PowerTiles.Add(negaTile);

//             }
//         }
//     }

//     void MainConnection()
//     //- a b c d e - f g h i j -
//     {
//         for (int x = 3; x <= h; x++)
//         {
//             for (int z = 0; z < v; z++)
//             {

//                 if (x % 8 != 0)
//                 {
//                     //z dowmward x sidways
//                     GameObject midTile = Instantiate(tilePrefab,
//                     new Vector3(x * buffer, 0, z * buffer),
//                     Quaternion.identity, parent.transform);

//                     GeneratedTiles.Add(midTile);
//                     //Debug.Log(midTile.transform.position);
//                     MainTilesZ.Add(z * buffer);
//                 }
//             }
//             if (x % 8 != 0)
//             {
//                 MainTilesX.Add(x * buffer);
//             }
//         }
//     }

//     //Show the rows that has power






//     void CreateAndConnectGameObjects(List<Component> userComp, List<GameObject> compList)
//     {//Here we place the prefab on the virtual breadboard
//         List<int> temp = new List<int>();
//         temp.Add(0);
//         temp.Add(0);
//         //  CreateLine(PowerTiles[0].transform.position, new Vector3(GeneratedTiles[0].transform.position.x,0,PowerTiles[0].transform.position.z));
//         for (int i = 0; i < userComp.Count; i++)
//         {//component list area getting components
//             Debug.Log("Obj no:"+i+"  "+ userComp[i].getCname());
//             temp=PlaceGameObject(userComp[i], compList[i], temp);
//         }
//     }
//     // to store the value so that we know whats the current x and y axis being used 
//     float Xspace = 0;
//     float Zspace = 0;
//     float midpointX(Component c,int space,float currX)
//     {
//         float total = 0;
//         float midpointX;
//         if (c.getCapcity()[0] != 0 && space<5)
//         {
//             //it takes the total and then get the avg and give it in the list
//             for (int i = 1; i <= c.getCapcity()[0]; i++)
//             {
//                 total += MainTilesX[i + space];
//             }
//             midpointX = total / c.getCapcity()[0];
//             Debug.Log("mid point forX " + c.getCapcity()[0] + ": " + midpointX);
//             return midpointX;
//         }
//         //  Debug.Log("mid point forX 0: " + midpointX);
//         //midpointX = Xspace+buffer;
//         /*  Debug.Log( buffer);
//           Debug.Log(Xspace );
//           Debug.Log("mid point forX 0: "+ (Xspace + buffer));*/
//         Debug.Log(" pre midpointX: " + currX);
//         return currX;
//     }
   
//     float midpointZ(Component c, int space,float currZ)
//     {
//         float midpointZ;
//         float total = 0;
//         //if its 0 the program gives a Nan error
//         if (c.getCapcity()[1] != 0)
//         {
//             //it takes the total and then get the avg and give it in the list
//             for (int i = 0; i < c.getCapcity()[1]; i++)
//             {
//                 total += MainTilesZ[i + space];
//             }

//             midpointZ = total / c.getCapcity()[1];
//             Debug.Log("midpointZ: " + midpointZ);
//             return midpointZ;
//         }
//         Debug.Log(" pre midpointZ: " + currZ);
//         return currZ;

//     }

//     int maxspace = 5;
//     float currpowerindex = 0;
//     void elePower(GameObject g,Component c,float ZAxis)
//     {

//         if (c.getCname()== "LED")
//         {
//             //rules 
//             // one of the two block should be on the green for this we use Is Conected
//             Debug.Log(currpowerindex + "currpowerindex");
//             Debug.Log(ZAxis - (buffer) + "ZAxis-(buffer/2)");

//             if ((ZAxis-(buffer / 2))== currpowerindex)
//             {
//                 Debug.Log(g.transform.position.z+" Connected");
//                 power(g.transform.position.z + buffer,5);
//                 currpowerindex = g.transform.position.z + buffer;
//                // power(g.transform.position.z +(buffer / 2));
//             }
//         }

//         else if(c.getCname() == "switches"){

//         }

//         else
//         {
            
//             if (currpowerindex== ZAxis)
//             {
//                 Debug.Log(g.transform.position.z + " Connected"+c.getCname());
//                // power(g.transform.position.z + buffer);
//                 // power(g.transform.position.z +(buffer / 2));
//             }
//         }


//     }

//     bool InGeneratedX(float pos,Component c)
//     {
//         bool flag=false ;
//         Debug.Log(pos);
//         Debug.Log("c.getCapcity()[0]: "+c.getCapcity()[0]);
//         if (c.getCapcity()[0] == 0)
//         {
//             Debug.Log("c.getCapcity()[0]: in " + c.getCapcity()[0]);
//             for (int i = 0; i < GeneratedTiles.Count; i++)
//             {
//                 Debug.Log(GeneratedTiles[i].transform.position.x);
//                 Debug.Log(pos);
//                 if (pos==(0.42f))
//                 {
//                     Debug.Log("pos*100 " + (pos * 100));
//                     Debug.Log("Found");
//                     flag = true;
//                     Debug.Log(flag);
//                     break;
//                 }

//             }
//         }
       
//         return flag;
//     }
//     bool InGeneratedZ(float pos, Component c)
//     { bool flag=false; 
//         Debug.Log("c.getCapcity()[1]: " + c.getCapcity()[1]);
//         if (c.getCapcity()[1] == 0)
//         {
//             for (int i = 0; i < GeneratedTiles.Count; i++)
//             {
//                 if (GeneratedTiles[i].transform.position.z == pos)
//                 {
//                     flag = true;
//                     break;
//                 }
                                   
//             }
//         }
//         return flag;
//     }

//     void prefabPos(GameObject gameObject,Component component , float X,float Z) {
//         GameObject newGameObject = Instantiate(gameObject, new Vector3(X,0,Z), Quaternion.identity, parent.transform);
//     }

//     void LEDplacer(List<Component>listprevcomp,GameObject gameObject, Component component, float X, float Z)
//     {
//         X += componentBUf(listprevcomp[0].getCname(), X);
//         GameObject newGameObject = Instantiate(gameObject, new Vector3(X, 0, Z), Quaternion.identity, parent.transform);
//         newGameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
//     }

//     float componentBUf(string c,float curr)
//     { 
//         float newPos =0;
//         if (c == "switch"||c=="resistor")
//         {
//             //enough space from the mid point of the switch ending point
//             newPos =  buffer * 2;
//         }

//         else if (c == "LED" || c=="diode")
//         {
//             //enough space from the mid point of the switch ending point
//             newPos = buffer / 2+buffer;
//         }

//         return newPos;

//     }
//     //for placing the components
//     int Xmax = 4;
//     float Xmidpoint=0;
//     float Zmidpoint=0;
//     List<Component> procomp = new List<Component>();
//     List<Component> listprevcomp = new List<Component>();
//     List<int> PlaceGameObject(Component component, GameObject gameObject, List<int> holes)
//     {

//         Xmax -= component.getCapcity()[0];
//         //preventing from moving to the other side of the board
//         if (holes[0] >= Xmax || holes[0]-Xmax<= component.getCapcity()[0])
//         {
//             if (Xmax == 1 && component.getCname()=="LED")
//             {
//                 Debug.Log("LED");
//             }
//             else
//             {
//                 Debug.Log("Xmax: " + Xmax);
//                 Debug.Log("holes[0]: " + (holes[0]));
//                 Debug.Log("holes[0] >= Xmax: " + (holes[0] >= Xmax));
//                 Debug.Log("holes[0]-Xmax: " + (holes[0] - Xmax));
//                 holes[0] = 0;
//             }

//         }
//         //reducing the spaces base on the component capcity
      
//         Debug.Log("Xmax: " + Xmax);



//         //creating variable to store Xmidpoint and ZmidPoint

//         //get the mid point from the function
//         Xmidpoint = midpointX(component, holes[0], Xmidpoint);
//         Zmidpoint = midpointZ(component, holes[1], Zmidpoint);
//         Debug.Log("Count: " + procomp.Count);
//         if (procomp.Count == 1)
//         {
//             //ADD THE BUFFERS 
//             Zmidpoint += componentBUf(procomp[0].getCname(), Zmidpoint);
//         }
        
//         if (Xmax > 0)
//         {
//             // function call to initialize the prefab at a given position given(component , Vector3)
//             Debug.Log("Curr Xmidpoint: "+Xmidpoint);
//             Debug.Log("Curr Zmidpoint: " + Zmidpoint);
//             if (component.getCname() != "LED")
//             {
//                 prefabPos(gameObject, component, Xmidpoint, Zmidpoint);
//             }
//             else {
//                 LEDplacer(listprevcomp, gameObject, component, Xmidpoint, Zmidpoint); 
//                 listprevcomp.Clear();
//             }


//         }

//         else
//         {
//         //resets
//         Xmax = 4;
        
//         //holes[1] += component.getCapcity()[1];

//             for ( int i=0;i<MainTilesZ.Count;i++)
//         {
//           if (MainTilesZ[i] ==Zmidpoint)
//           {
//                     holes[1] +=2;//for swtich
//                     //when we get the number same to the currZ we change to the new line
//                     Zmidpoint = MainTilesZ[i+1];
//                     break;
//           }
//         }
//         //Vector3 pos= new Vector3(Xmidpoint,0,Zmidpoint);
//         prefabPos(gameObject, component, Xmidpoint, Zmidpoint);

//             //put them in the list so in the next run we catch the column problem
//             if (component.getCname() == "LED" || component.getCname() == "switch") { 
//                 procomp.Add(component);
//                 Debug.Log("ADD");
//                 Debug.Log("Count: " + procomp.Count);
//             }
        
//             Debug.Log("New Zmidpoint: "+ Zmidpoint);

//             Debug.Log("Hello World");
//         }

//         Debug.Log("holes[0]" + holes[0] + " " + "holes[1]" + holes[1]);
//         holes[0] += component.getCapcity()[0];
//         if (holes[1]!=0) { holes[1] += component.getCapcity()[1]; }
//         listprevcomp.Add(component);


//         Debug.Log(" NEW: holes[0]" + holes[0] + " " + "holes[1]" + holes[1]);

//         //Hardcore code
//         CreateCircuit();

//         return holes;
//     }


//     void power(float zpos,int limit)
//     {
//         int num = 0;
//         for(int i=0;i<GeneratedTiles.Count;i++)
//         {
//             if (zpos == GeneratedTiles[i].transform.position.z  )
//             {
//                 if (num < limit) {
//                     Renderer Renderer = GeneratedTiles[i].GetComponent<Renderer>();
//                     Renderer.material.color = new Color(0.569f, 0.671f, 0.380f);
//                     num++;
//                 }
//             }
//         }
//     }

//     bool IsConnected(GameObject comp)
//     {
//         bool flag= false;
//         for (int i=0;i<GeneratedTiles.Count;i++)
//         {
//             if (GeneratedTiles[i].transform.position.z == comp.transform.position.z)
//             {
//                 Renderer renderer = GeneratedTiles[i].GetComponent<Renderer>();
//                 if(renderer.material.color==new Color(0.569f, 0.671f, 0.380f))
//                 {
//                     flag= true;
//                     break;
//                 }
//                 else
//                 {
//                    flag=false;
//                 }
//             }
            
//         }
//         return flag;
//     }

//     //Create a "line" when the Game Object is given ->red, black depending on the connection

//     void CreateLine(GameObject startBlock, GameObject endBlock,Color color)
//     {
//         Renderer startRenderer = startBlock.GetComponent<Renderer>();
//         Renderer endRenderer = endBlock.GetComponent<Renderer>();
//         startRenderer.material.color = color;
//         endRenderer.material.color = color;
//     }



//     void WCreateLine( GameObject endBlock, Color color)
//     {

//         Renderer endRenderer = endBlock.GetComponent<Renderer>();
//         endRenderer.material.color = color;

//     }

//     //right now we have the component placed in places and now we have to connect them togther first let start with connecting the power rails to battery
//     void CreateCircuit()
//     {
//         //battery connection to the power source
//         WCreateLine(PowerTiles[0], Color.red);
//         WCreateLine( PowerTiles[1], Color.black);
//         power(GeneratedTiles[0].transform.position.z, 5);
//         //connect the positive to the starting of the main board 
//         CreateLine(PowerTiles[2], GeneratedTiles[0], Color.red);
//         power(GeneratedTiles[1].transform.position.z, 5);
//         CreateLine(PowerTiles[5], GeneratedTiles[1], Color.black);
//         // power(GeneratedTiles[0].transform.position.z,5);


//     }




//     //MAIN
//     void Start()
//     {
//         listComponent.Add(c1);
//         listComponent.Add(c2);
//         listComponent.Add(c3);
//         listComponent.Add(c4);

//         prefabDic.Add("resistor", resistor);
//         prefabDic.Add("switch", switches);
//         prefabDic.Add("LED", LED);
//         prefabDic.Add("diode", diode);

//         //creating a breadboard
//         powerRail(0);
//         MainConnection();
//         powerRail(15);

//         List<string> basicInput = new List<string> { "resistor", "LED" };
//         createCompList(basicInput);

//         // Validate compList count and content
//         Debug.Log("compList Count: " + compList.Count); // Expected output: 4
//                                                         // Check userComp count and content (if needed)
//         Debug.Log("userComp Count: " + userComp.Count); // Expected output: Depends on listComponent items

//         // Validate if compList contains the correct GameObjects based on input
//         // Iterate through compList and log the names or other properties for validation
//         foreach (GameObject obj in compList)
//         {
//             Debug.Log("Component Name: " + obj.name);
//             // Add further validations as needed
//         }

//         // placing the objects
//         CreateAndConnectGameObjects(userComp,compList);

//         // transform.position = parentPos.position;
//         StartCoroutine(moveToParent());
//     }

//     private IEnumerator moveToParent()
//     {
//         yield return new WaitForSeconds(1.0f);
//         transform.position = parentPos.position;
//     }

// }

using System.Collections.Generic;
using UnityEngine;

public class BreadBoard : MonoBehaviour
{


    [SerializeField] public float buffer = 1.5f;//add buffer around the tile
    //path for the connection
    public static List<GameObject> GeneratedTiles = new List<GameObject>();
    public static List<float> MainTilesX = new List<float>();
    public static List<float> MainTilesZ = new List<float>();
    public static List<GameObject> PowerTiles = new List<GameObject>();


   // public List<GameObject> listComponents = new List<GameObject>();//list of Component that come from the models
   // public LineRenderer lineRendererPrefab;
    [SerializeField] private GameObject linePrefab;


    [Header("Prefab Department")]
    //private Component c1 = new Component(tilePrefab.gameObject, "bulib", " -something- ", false);
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject activePrefab;
    [SerializeField] private GameObject putPrefab;
    [SerializeField] private GameObject parent;
    private int v = 60;//vertical
    private int h = 13;//horizontal

    [Header("Components Prefab")]
    [SerializeField] private GameObject resistor;
    [SerializeField] private GameObject LED;
    [SerializeField] private GameObject switches;
    [SerializeField] private GameObject diode;
    Dictionary<string,GameObject> prefabDic= new Dictionary<string,GameObject>();

    List<Component> userComp = new List<Component>();
    List<GameObject> compList = new List<GameObject>();
    List<Component> listComponent = new List<Component>();//list of Component that come from the models
    Component c1 = new Component("resistor", "Something", false, new List<int> { 3 , 0 });
    Component c2 = new Component("switch", "Something", false, new List<int> { 3, 3 });
    Component c3 = new Component("LED", "Something", true, new List<int> { 0, 2 });
    Component c4 = new Component("diode", "Something", false, new List<int> { 2,0  });
    
    
    

void createCompList(List<string> list)
    {
        for (int i=0;i<list.Count;i++)
        {
            for(int j=0;j< listComponent.Count;j++)
            {

                if (list[i] == listComponent[j].getCname())
                {
                    userComp.Add(listComponent[j]);
                }
            
            }
            if (prefabDic.ContainsKey(list[i]))
            {
                compList.Add(prefabDic[list[i]]);
            }
        }
    }
    
void powerRail(float x)
    {
        for (int z = 0; z <= v; z++)
        {//+ - 
            if (z % 6 != 0)
            { //postive lane
                GameObject posTile = Instantiate(tilePrefab,
                       new Vector3(x * buffer, 0, z * buffer),
                       Quaternion.identity, parent.transform);
                //negative lane
                GameObject negaTile = Instantiate(tilePrefab,
                       new Vector3((x + 1) * buffer, 0, z * buffer),
                       Quaternion.identity, parent.transform);

                PowerTiles.Add(posTile);
                PowerTiles.Add(negaTile);

            }
        }
    }

    void MainConnection()
    //- a b c d e - f g h i j -
    {
        for (int x = 3; x <= h; x++)
        {
            for (int z = 0; z < v; z++)
            {

                if (x % 8 != 0)
                {
                    //z dowmward x sidways
                    GameObject midTile = Instantiate(tilePrefab,
                    new Vector3(x * buffer, 0, z * buffer),
                    Quaternion.identity, parent.transform);

                    GeneratedTiles.Add(midTile);
                    //Debug.Log(midTile.transform.position);
                    MainTilesZ.Add(z * buffer);
                }
            }
            if (x % 8 != 0)
            {
                MainTilesX.Add(x * buffer);
            }
        }
    }

    //Show the rows that has power
    void CreateAndConnectGameObjects(List<Component> userComp, List<GameObject> compList)
    {//Here we place the prefab on the virtual breadboard
        List<int> temp = new List<int>();
        temp.Add(0);
        temp.Add(0);
        //  CreateLine(PowerTiles[0].transform.position, new Vector3(GeneratedTiles[0].transform.position.x,0,PowerTiles[0].transform.position.z));
        for (int i = 0; i < userComp.Count; i++)
        {//component list area getting components
            Debug.Log("Obj no:"+i+"  "+ userComp[i].getCname());
            temp=PlaceGameObject(userComp[i], compList[i], temp);
        }
    }

    float midpointX(Component c,int space,float currX)
    {
        float total = 0;
        float midpointX;
        if (c.getCapcity()[0] != 0 && space<5)
        {
            //it takes the total and then get the avg and give it in the list
            for (int i = 1; i <= c.getCapcity()[0]; i++)
            {
                total += MainTilesX[i + space];
            }
            midpointX = total / c.getCapcity()[0];
            Debug.Log("mid point forX " + c.getCapcity()[0] + ": " + midpointX);
            return midpointX;
        }
        Debug.Log(" pre midpointX: " + currX);
        return currX;
    }
   
    float midpointZ(Component c, int space,float currZ)
    {
        float midpointZ;
        float total = 0;
        //if its 0 the program gives a Nan error
        if (c.getCapcity()[1] != 0)
        {
            //it takes the total and then get the avg and give it in the list
            for (int i = 0; i < c.getCapcity()[1]; i++)
            {
                total += MainTilesZ[i + space];
            }

            midpointZ = total / c.getCapcity()[1];
            Debug.Log("midpointZ: " + midpointZ);
            return midpointZ;
        }
        Debug.Log(" pre midpointZ: " + currZ);
        return currZ;

    }


    

    void prefabPos(List<Component> listprevcomp,GameObject gameObject,Component component , float X,float Z) {

        if (component.getCname() != "LED") {
            GameObject newGameObject = Instantiate(gameObject, new Vector3(X, 0, Z), Quaternion.identity, parent.transform);
        }
        else
        {
            X += componentBUf(listprevcomp[0].getCname(), X);
            GameObject newGameObject = Instantiate(gameObject, new Vector3(X, 0, Z), Quaternion.identity, parent.transform);
            newGameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            listprevcomp.Clear();
        }  
    }

    float componentBUf(string c,float curr)
    { 
        float newPos =0;
        if (c == "switch"||c=="resistor")
        {
            //enough space from the mid point of the switch ending point
            newPos =  buffer * 2;
        }

        else if (c == "LED" || c=="diode")
        {
            //enough space from the mid point of the switch ending point
            newPos = buffer / 2+buffer;
        }

        return newPos;

    }
    //for placing the components
    int Xmax = 4;
    float Xmidpoint=0;
    float Zmidpoint=0;
    List<Component> procomp = new List<Component>();
    List<Component> listprevcomp = new List<Component>();
    List<int> PlaceGameObject(Component component, GameObject gameObject, List<int> holes)
    {

        Xmax -= component.getCapcity()[0];
        //preventing from moving to the other side of the board
        if (holes[0] >= Xmax || holes[0]-Xmax<= component.getCapcity()[0])
        {
            if (Xmax == 1 && component.getCname()=="LED")
            {
                Debug.Log("LED");
            }
            else
            {

                holes[0] = 0;
            }

        }
        //reducing the spaces base on the component capcity
      
        //get the mid point from the function
        Xmidpoint = midpointX(component, holes[0], Xmidpoint);
        Zmidpoint = midpointZ(component, holes[1], Zmidpoint);
        Debug.Log("Count: " + procomp.Count);
        if (procomp.Count == 1)
        {
            //ADD THE BUFFERS 
            Zmidpoint += componentBUf(procomp[0].getCname(), Zmidpoint);
        }
        
        if (Xmax > 0)
        {
            // function call to initialize the prefab at a given position given(component , Vector3)
            prefabPos(listprevcomp, gameObject, component, Xmidpoint, Zmidpoint);
            Debug.Log("Curr Xmidpoint: "+Xmidpoint);
            Debug.Log("Curr Zmidpoint: " + Zmidpoint);
           
             
            

        }

        else
        {
        //resets
        Xmax = 4;
        
        //holes[1] += component.getCapcity()[1];

            for ( int i=0;i<MainTilesZ.Count;i++)
        {
          if (MainTilesZ[i] ==Zmidpoint)
          {
                    holes[1] +=2;//for swtich
                    //when we get the number same to the currZ we change to the new line
                    Zmidpoint = MainTilesZ[i+1];
                    break;
          }
        }
            //Vector3 pos= new Vector3(Xmidpoint,0,Zmidpoint);
            prefabPos(listprevcomp, gameObject, component, Xmidpoint, Zmidpoint);

            //put them in the list so in the next run we catch the column problem
            if (component.getCname() == "LED" || component.getCname() == "switch") { 
                procomp.Add(component);
                Debug.Log("ADD");
                Debug.Log("Count: " + procomp.Count);
            }
        
            Debug.Log("New Zmidpoint: "+ Zmidpoint);

            Debug.Log("Hello World");
        }

        Debug.Log("holes[0]" + holes[0] + " " + "holes[1]" + holes[1]);
        holes[0] += component.getCapcity()[0];
        if (holes[1]!=0) { holes[1] += component.getCapcity()[1]; }
        listprevcomp.Add(component);


        Debug.Log(" NEW: holes[0]" + holes[0] + " " + "holes[1]" + holes[1]);

        //Hardcore code
        CreateCircuit(); 


        return holes;
    }


    void power(float zpos,int limit)
    {
        int num = 0;
        for(int i=0;i<GeneratedTiles.Count;i++)
        {
            if (zpos == GeneratedTiles[i].transform.position.z  )
            {
                if (num < limit) {
                    Renderer Renderer = GeneratedTiles[i].GetComponent<Renderer>();
                    Renderer.material.color = new Color(0.569f, 0.671f, 0.380f);
                    num++;
                }
                
            }
        }
    }
    //Create a "line" when the Game Object is given ->red, black depending on the connection

    void CreateLine(GameObject startBlock, GameObject endBlock,Color color)
    {
        Renderer startRenderer = startBlock.GetComponent<Renderer>();
        Renderer endRenderer = endBlock.GetComponent<Renderer>();
        startRenderer.material.color = color;
        endRenderer.material.color = color;
    }

    //right now we have the component placed in places and now we have to connect them togther first let start with connecting the power rails to battery
    void CreateCircuit()
    {
        //battery connection to the battery power source
        power(GeneratedTiles[0].transform.position.z, 5);
        //connect the positive to the starting of the main board 
        CreateLine(PowerTiles[2], GeneratedTiles[0], Color.red);
        power(GeneratedTiles[1].transform.position.z, 5);
        CreateLine(PowerTiles[5], GeneratedTiles[1], Color.black);
        //power(GeneratedTiles[0].transform.position.z,5);


    }




    //MAIN
    void Start()
    {
        listComponent.Add(c1);
        listComponent.Add(c2);
        listComponent.Add(c3);
        listComponent.Add(c4);

        prefabDic.Add("resistor", resistor);
        prefabDic.Add("switch", switches);
        prefabDic.Add("LED", LED);
        prefabDic.Add("diode", diode);

        //creating a breadboard
        powerRail(transform.position.x);
        MainConnection();
        // powerRail(15);

        List<string> basicInput = new List<string> { "resistor", "LED" };
        createCompList(basicInput);

        // Validate compList count and content
        Debug.Log("compList Count: " + compList.Count); // Expected output: 4
                                                        // Check userComp count and content (if needed)
        Debug.Log("userComp Count: " + userComp.Count); // Expected output: Depends on listComponent items

        // Validate if compList contains the correct GameObjects based on input
        // Iterate through compList and log the names or other properties for validation
        foreach (GameObject obj in compList)
        {
            Debug.Log("Component Name: " + obj.name);
            // Add further validations as needed
        }



        // placing the objects
        CreateAndConnectGameObjects(userComp,compList);

    }

}
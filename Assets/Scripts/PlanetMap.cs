using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class PlanetMap : MonoBehaviour
{
    //scal;
    //public int production;
    public GameObject planet;

    private int planetCount = 10;
    private RectTransform rectTr;

    public List<Planet> instantiatePlanets;
    [HideInInspector]
    public List<Transform> planetsTransform;

    //private static PlanetGenerator instanc = null;

   // private float height;
    //private float width;

    /*public static PlanetGenerator Instance
    {
        get
        {
            return instanc;
        }
    }
    */

    public void Awake()
    {
        rectTr = GetComponent<RectTransform>();
      //  height = Screen.height;
        //width = Screen.width;

    }

    public void SpawnPlanets()
    {
        for (int i = 0; i < planetCount; i++)
        {
            Vector2 planetPos = SetPosition();
            instantiatePlanets.Add(Instantiate(planet, planetPos, Quaternion.identity, transform).GetComponent<Planet>());
            instantiatePlanets[i].GetComponent<Planet>().Init();
        }
        FixPosition();
    }

    public void FixPosition()
    {
        for (int i = 0; i < instantiatePlanets.Count; i++)
        {
            for (int j = i + 1; j < instantiatePlanets.Count; j++)
            {
                if (Vector2.Distance(instantiatePlanets[i].transform.position, instantiatePlanets[j].transform.position) < 75)
                {
                    instantiatePlanets[j].transform.position = SetPosition();
                    FixPosition();
                    for (int k = 0; k < instantiatePlanets.Count/5; k += 1)
                    {
                        instantiatePlanets[k].transform.localScale = new Vector2(2, 2);
                        instantiatePlanets[k].production = 9;
                    }
                    for (int k = instantiatePlanets.Count / 5; k < instantiatePlanets.Count / 3; k += 1)
                    {
                        instantiatePlanets[k].transform.localScale = new Vector2(1.5f, 1.5f);
                        instantiatePlanets[k].production = 5;

                    }
                    for (int k = instantiatePlanets.Count / 3; k < instantiatePlanets.Count; k += 1)
                    {
                        instantiatePlanets[k].transform.localScale = new Vector2(1.0f, 1.0f);
                        instantiatePlanets[k].production = 2;
                    }
                }
            }
        }
    }

/*    public int setProduction()
    {
        for (int i = 0; i < 30; i++)
        {
            if (instantiatePlanets[i].transform.localScale.x == 2)
                instantiatePlanets[i].production = 3;
            else if (instantiatePlanets[i].transform.localScale.x == 1.5)
                instantiatePlanets[i].production = 2;
            else
                instantiatePlanets[i].production = 1;
        }
        return 0;// production;
    }*/
    public Planet MinShipsPlanet()
    {
        int counter = 0;
        for (int i = 1; i < instantiatePlanets.Count; i++)
        {
            if (instantiatePlanets[counter].PlanetShips > instantiatePlanets[i].PlanetShips)
            {
                counter = i;
            }
        }
        return instantiatePlanets[counter];
    }
   
    public Planet nearestplanet(  Planet me)
    {
      //  Planet perfect;
     float distance=  Vector2.Distance(me.transform.position, instantiatePlanets[0].transform.position);
;
     int counter=0;
     for(int i=0 ; i < planetCount ; i++)
    {
        if (Vector2.Distance(me.transform.position, instantiatePlanets[i].transform.position) < distance)
        {
            counter = i;
           //perfect = instantiatePlanets[i];
        }
    }
    return  instantiatePlanets[counter];
    }
   
    Vector2 SetPosition()
    {
        Vector2 correctPos = new Vector2(Random.Range(-460 , 460), Random.Range(-275, 275));
        return correctPos;
    }
   
}

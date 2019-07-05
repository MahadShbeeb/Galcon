using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager: MonoBehaviour
{
    public GameObject ship;
    public Transform shipsParent;
    public List<Planet> enemyPlanets;
    private Ship spawnedShip;
    private PlanetMap planetMap;
    private Planet firstPlanet, secondPlanet1,secondPlanet;
    private Planet perfect;

    public void Init()
    {
        float delay = 3.0f;
        float repeatRate = 1.0f;
        planetMap = GameManager.Instance.planetMap;
        SelectStartPlanet();
        enemyPlanets[0].PlanetShips = 50;
        if (enemyPlanets.Count > 0)
            if (IsInvoking("SelectTargetPlanets") == false)
            {
                InvokeRepeating("SelectTargetPlanets", delay, repeatRate);
       
            }
    }

/*    public Planet perfectplanet()
    {
        float distance = 300;

        int counter = 0,counter2=0;

        for( int i=0 ;i< enemyPlanets.Count;i++)
        {
            if (enemyPlanets[counter].PlanetShips <  enemyPlanets[i].PlanetShips)
                counter = i;
             
        }
        Planet myplanet = planetGenerator.instantiatePlanets[counter];
        for( int i=0;i< planetGenerator.instantiatePlanets.Count;i++)
            if (Vector2.Distance(myplanet.transform.position, planetGenerator.instantiatePlanets[i].transform.position) < distance)
            {
                distance = Vector2.Distance(myplanet.transform.position, planetGenerator.instantiatePlanets[i].transform.position);
                counter2 = i;

            }
        Planet myplanet1 = planetGenerator.instantiatePlanets[counter2];
        return myplanet1;

    }*/

   /* public Planet nearestplanet(Planet me)
    {
        //  Planet perfect;
        float distance = Vector2.Distance(me.transform.position, planetMap.instantiatePlanets[0].transform.position);
        
        int counter = 0;
        for (int i = 0; i < 30; i++)
        {
            if (Vector2.Distance(me.transform.position,planetMap.instantiatePlanets[i].transform.position) < distance)
            {
                distance = Vector2.Distance(me.transform.position, planetMap.instantiatePlanets[i].transform.position);
                counter = i;
     
            }
        }
        return planetMap.instantiatePlanets[counter];
    }*/
   
    public Planet MaxShipsenemyPlanet()
    {
        int counter = 0;
        for (int i = 1; i < enemyPlanets.Count; i++)
        {
            if (enemyPlanets[counter].PlanetShips < enemyPlanets[i].PlanetShips)
            {
                counter = i;
            }
        }
        return enemyPlanets[counter];
    }

 /*   public Planet perfectplanetg()
    {
        int counter = 0; 
        for (int i = 1; i < enemyPlanets.Count; i++) 
        {
            if (enemyPlanets[counter].PlanetShips < enemyPlanets[i].PlanetShips)
            {
                counter = i;
            }
        }
        return enemyPlanets[counter];
    }*/
   

    public void SelectTargetPlanets()
    {
    // firstPlanet = enemyPlanets[Random.Range(0, enemyPlanets.Count)];
        firstPlanet = MaxShipsenemyPlanet();
//        Planet tt=firstPlanet;
        //tt = MainController.Instance.planetGenerator.MinShipsPlanet();
       secondPlanet =planetMap.MinShipsPlanet();

            //enemyPlanets[Random.Range(0, enemyPlanets.Count)];

      //  secondPlanet =MainController.Instance.planetGenerator.MinShipsPlanet() ;
       // secondPlanet = MainController.Instance.planetGenerator.perfectplanet(firstPlanet);
//        secondPlanet = nearestplanet(firstPlanet);

        if (firstPlanet.PlanetShips / 2 > secondPlanet.PlanetShips)
        {
            SpawnShip();
        }
        else
        {
            return;
        }
    }
 
    public void SpawnShip()
    {
        int ShipsCount = firstPlanet.PlanetShips /= 2;
        spawnedShip = Instantiate(ship, firstPlanet.transform.position, Quaternion.identity, shipsParent).GetComponent<Ship>();
        spawnedShip.SetShip(firstPlanet.transform, secondPlanet.transform, GameManager.Side.Enemy, ShipsCount);
    }

    Planet SelectStartPlanet()
    {
        Planet result = null;

        while (result != PlayerManager.Instance.playerPlanet[0])
        { 
            result = planetMap.instantiatePlanets[Random.Range(0, planetMap.instantiatePlanets.Count)];
            result.ChangeSide(GameManager.Side.Enemy);

            return result;
        }
        return result;
    }
}
 
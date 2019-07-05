using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject ship;
    public Transform shipsParent;
    //public AudioClip s;
    //public AudioClip ss;

    private Ship spawnedShip;
    public List<Planet> playerPlanet;
    private Planet FirstSelectPlanet, SecondSelectPlanet;

    private PlanetMap PlanetMap;

    //    private PlanetGenerator PlanetGenerator;
    private RaycastHit2D hitInfo;
    private int SelectedCount;
    public Planet planetUnderMouse;
    public int planetships;

    private static PlayerManager instance = null;
    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    public void Init()
    {
        PlanetMap = GameManager.Instance.planetMap;
        PlanetMap = FindObjectOfType<PlanetMap>();
        PlanetMap.instantiatePlanets[Random.Range(0, PlanetMap.instantiatePlanets.Count)].ChangeSide(GameManager.Side.Player);
        playerPlanet[0].PlanetShips = planetships;

    }



    public void SetFirstPlanet(Planet planet)
    {
        FirstSelectPlanet = planet;
    }
    public Planet GetFirstPlanet()
    {
        return FirstSelectPlanet;
    }

    public Planet GetSecondPlanet()
    {
        return SecondSelectPlanet;
    }

    public void SetSecondPlanet(Planet planet)
    {
        SecondSelectPlanet = planet;
    }

    public void SpawnShip()
    {
        FirstSelectPlanet.outline.SetActive(false);
        SecondSelectPlanet.outline.SetActive(false);
        int ShipsCount = FirstSelectPlanet.PlanetShips /= 2;
        spawnedShip = Instantiate(ship, FirstSelectPlanet.transform.position, Quaternion.identity, shipsParent).GetComponent<Ship>();
        spawnedShip.SetShip(FirstSelectPlanet.transform, SecondSelectPlanet.transform, GameManager.Side.Player, ShipsCount);
        FirstSelectPlanet = null;
        SecondSelectPlanet = null;

        //  SoundManager.instance.PlaySingle(s);
    }
    public void setshipsfirst()
    {
        planetships = 150;
    }
    public void setshipssecond()
    {
        planetships = 150;
    }
    public void setshipstherd()
    {
        planetships = 125;
    }
    public void setshipsforth()
    {
        planetships = 125;
    }
    public void setshipsfifth()
    {
        planetships = 100;
    }
    public void setshipssixth()
    {
        planetships = 100;
    }
    public void setshipsseventh()
    {
        planetships = 75;
    }
    public void setshipseight()
    {
        planetships = 75;
    }
    public void setshipsninth()
    {
        planetships = 50;
    }
    public void setshipstenth()
    {
        planetships = 25;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Planet : MonoBehaviour
{
    public  PlanetMap planetMap;
    public int production;

    int i;
    public GameManager.Side planetSide;
    public int PlanetShips;
  //  public int PlanetShip;

    public GameObject outline;
    private Image image;
    private Text countText;
    private bool mouseOver;
    public void Init()
    {
        image = transform.GetComponentInChildren<Image>();
        countText = transform.GetComponentInChildren<Text>();

        PlanetShips = UnityEngine.Random.Range(5, 50);
        countText.text = PlanetShips.ToString();
    }
    
  
    void Awake()
    {
        planetMap = FindObjectOfType<PlanetMap>();
 
    }
    public void OnMouseOver()
    {
    
       if (planetSide == GameManager.Side.Player)
        {
            outline.SetActive(true);
        }
        else if (PlayerManager.Instance.GetFirstPlanet() != null)
        {
            outline.SetActive(true);
        }

    }
    public void OnMouseExit()
    {
        if (PlayerManager.Instance.GetFirstPlanet() != this)
            outline.SetActive(false);
    }

    public void OnMouseUp()
    {
        if (planetSide == GameManager.Side.Player && PlayerManager.Instance.GetFirstPlanet() == null)
        {
            PlayerManager.Instance.SetFirstPlanet(this);
            return;
        }
        if (PlayerManager.Instance.GetFirstPlanet() != null)
        {
            PlayerManager.Instance.SetSecondPlanet(this);
            PlayerManager.Instance.SpawnShip();
        }
    }

    public void PlanetShipCount(int captureShipsCount, GameManager.Side shipSide)
    {
        if (planetSide != shipSide)
        {
            PlanetShips -= captureShipsCount;
            countText.text = PlanetShips.ToString();
        }
        else
        {
            PlanetShips += captureShipsCount;
            countText.text = PlanetShips.ToString();
        }

        if (PlanetShips <= 0)
        {
            ChangeSide(shipSide);

        }
    }

    public void ChangeSide(GameManager.Side side)
    {
      //  gameObject.name = side.ToString();
        if (side == GameManager.Side.Player)
        {
            PlayerManager.Instance.playerPlanet.Add(this);
            GameManager.Instance.enemyManager.enemyPlanets.Remove(this);
            if (GameManager.Instance.enemyManager.enemyPlanets.Count == 0 && PlayerManager.Instance.playerPlanet.Count >= 2)
            {
                string end = "YOU WIN!!!";
               GameManager.Instance.EndGame(end);
            }
        }

        else
        {
            GameManager.Instance.enemyManager.enemyPlanets.Add(this);
            PlayerManager.Instance.playerPlanet.Remove(this);
            if (PlayerManager.Instance.playerPlanet.Count == 0 && GameManager.Instance.enemyManager.enemyPlanets.Count >= 2)
            {
                string end = "Game Over";
                GameManager.Instance.EndGame(end);
            }
        }
        PlanetShips = Mathf.Abs(PlanetShips);
  
        if (planetSide == GameManager.Side.Neitral &&  production==9)
        {   InvokeRepeating("AddShip", 0f, 0.9f); }
        else if (planetSide == GameManager.Side.Neitral && production == 5)
            InvokeRepeating("AddShips", 0f, 1.2f);
        else if (planetSide == GameManager.Side.Neitral && production == 2)
            InvokeRepeating("AddShipss", 0f, 1.5f);
            planetSide = side;
            image.color = GameManager.Instance.SideColor[side];
    }


    public void AddShip()
    {
                  PlanetShips += 1;
                 countText.text = PlanetShips.ToString();
    }



    public void AddShips()
    {
        PlanetShips += 1;
            countText.text = PlanetShips.ToString();

    }
    public void AddShipss()
    {
        PlanetShips += 1;
        countText.text = PlanetShips.ToString();

    }
}


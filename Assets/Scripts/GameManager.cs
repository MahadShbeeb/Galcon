using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GameManager: MonoBehaviour
{
   
    public event Action OnRestart;
    public GameObject EndGameUI;
    public Text engGameText;
    public Dictionary<Side, Color> SideColor;
    [HideInInspector]
    public PlanetMap planetMap;
    [HideInInspector]
    public EnemyManager enemyManager;
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void Awake()
    {
        planetMap = FindObjectOfType<PlanetMap>();
        enemyManager = FindObjectOfType<EnemyManager>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;

        SideColor = new Dictionary<Side, Color>();
        SideColor.Add(Side.Neitral, Color.gray);
        SideColor.Add(Side.Player, Color.blue);
        SideColor.Add(Side.Enemy, Color.red);
    }

    public void StartGame()
    {
       //SoundManager.instance.RandomizeSfx(startgame, startgame2);
       // SoundManager.instance.PlaySingle(s);
      //  startgame.isReadyToPlay(s);
        planetMap.SpawnPlanets();
        PlayerManager.Instance.Init();
        enemyManager.Init();

    }

    public void PauseGame()
    { 
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale =1;
    }

    public void EndGame(string whoWin)
    {
        Time.timeScale = 0f;
        EndGameUI.SetActive(true);
        engGameText.text = whoWin;
    }

    public void Restart()
    {
        if (OnRestart != null)
            OnRestart();
        for (int i = 0; i < planetMap.instantiatePlanets.Count; i++)
        {
            Destroy(planetMap.instantiatePlanets[i].gameObject);
        }
        planetMap.instantiatePlanets.Clear();
        planetMap.planetsTransform.Clear();
        PlayerManager.Instance.playerPlanet.Clear();
        enemyManager.enemyPlanets.Clear();
        Time.timeScale = 1;
        StartGame();
    }


    public enum Side
    {
        Player,
        Enemy,
        Neitral
    }

    public void quitegame()
    {
        Application.Quit();
    }
}

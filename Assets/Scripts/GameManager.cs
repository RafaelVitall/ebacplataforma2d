using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Singleton;

public class GameManager : Singleton<GameManager>
{
    [Header("Referencies")]
    public Transform startPoint;
    [Space(5)]

    [Header("Player Setting")]
    public GameObject player;
    [Space(5)]

    [Header("Enemy Settings")]
    public List<GameObject> enemies;

    GameObject _currentPlayer;

    void Start()
    {
        Init();
    }
    public void Init()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        _currentPlayer = Instantiate(player);
        _currentPlayer.transform.position = startPoint.position;

    }
}

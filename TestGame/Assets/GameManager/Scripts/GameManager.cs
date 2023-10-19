using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private SpawnPlayer _spawnPlayer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _spawnPlayer.Spawn();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

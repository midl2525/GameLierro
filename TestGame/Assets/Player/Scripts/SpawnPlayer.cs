using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _prefabPlayer;
    [SerializeField] private float _speedPlayer;

    [SerializeField] private SpawnCellGround _spawnCellGround;
    [SerializeField] private PlayerManager _playerManager;

    public void Spawn()
    {
        int index = Random.Range(0, _spawnCellGround.CellsGround.Count);
        GameObject player = Instantiate(_prefabPlayer);
        player.transform.position = _spawnCellGround.CellsGround[index].transform.position;
        _playerManager.Construct(player, _speedPlayer, _spawnCellGround.CellsGround[index].transform.localScale.x, player.transform.position, _spawnCellGround.CellsGround);
    }
}

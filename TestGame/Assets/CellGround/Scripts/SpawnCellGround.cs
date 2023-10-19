using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnCellGround : MonoBehaviour
{
    public List<GameObject> CellsGround;

    [SerializeField] private int _countWidth;
    [SerializeField] private int _countLength;

    [SerializeField] private GameObject _prefabCellGround;

    private void Awake()
    {
        SpawnCell();
    }

    private void SpawnCell()
    {
        for (int x = 0; x < _countWidth; x++)
        {
            for (int y = 0; y < _countLength; y++)
            {
                GameObject cell = Instantiate(_prefabCellGround, transform);
                cell.transform.position = SetPosition(x, y);
                CellsGround.Add(cell);
            }
        }
        CellsGround[CellsGround.Count - 1].GetComponent<Cell>().Active = true;
        CellsGround[CellsGround.Count - 1].GetComponent<Cell>().UpdateInfo();
    }

    private Vector2 SetPosition(int numX, int numY)
    {
        float countWidth = _countWidth;
        float countLength = _countLength;
        float sizeX = _prefabCellGround.transform.localScale.x;
        float sizeY = _prefabCellGround.transform.localScale.y;
        float positionX = ((countWidth / 2 * sizeX) - (sizeX / 2)) - (sizeX) * numX;
        float positionY = ((countLength / 2 * sizeY) - (sizeY / 2)) - (sizeY) * numY;
        return new Vector2(positionX, positionY);
    }
}

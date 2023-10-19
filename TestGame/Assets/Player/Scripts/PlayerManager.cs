using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerManager : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private Vector3 _position;
    private float _progress;

    private GameObject _player;
    private float _speedPlayer;
    private float _distance;
    private List<GameObject> _cellsGround;

    public void Construct(GameObject player, float speedPlayer, float distance, Vector3 position, List<GameObject> cellsGround)
    {
        _player = player;
        _speedPlayer = speedPlayer;
        _distance = distance;
        _position = position;
        _cellsGround = cellsGround;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 position = _position;
        if((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if(eventData.delta.x > 0)
            {
                // Свайп вправо
                if (CheckCellGround(new Vector2(position.x += _distance, position.y)))
                {
                    _progress = 0;
                    _position.x += _distance;
                    ScoreManager.Instance.Score++;
                    ScoreManager.Instance.UpdateInfo();
                }
            }
            else
            {
                // Свайп влево
                if (CheckCellGround(new Vector2(position.x -= _distance, position.y)))
                {
                    _progress = 0;
                    _position.x -= _distance;
                    ScoreManager.Instance.Score++;
                    ScoreManager.Instance.UpdateInfo();
                }
            }
        }
        else
        {
            if(eventData.delta.y > 0)
            {
                // Свайп вверх
                if(CheckCellGround(new Vector2(position.x, position.y += _distance)))
                {
                    _progress = 0;
                    _position.y += _distance;
                    ScoreManager.Instance.Score++;
                    ScoreManager.Instance.UpdateInfo();
                }
            }
            else
            {
                // Свайп вниз
                if(CheckCellGround(new Vector2(position.x, position.y -= _distance)))
                {
                    _progress = 0;
                    _position.y -= _distance;
                    ScoreManager.Instance.Score++;
                    ScoreManager.Instance.UpdateInfo();
                }
            }    
        }   
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    private bool CheckCellGround(Vector2 position)
    {
        bool active = false;

        foreach (var item in _cellsGround)
        {
            if(new Vector2(item.transform.position.x, item.transform.position.y) == position)
            {
                active = true;
                if(item.GetComponent<Cell>().Active)
                {
                    GameManager.Instance.RestartGame();
                }
            }
        }

        return active;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _player.transform.position = Vector2.Lerp(_player.transform.position, _position, _progress);
        _progress += _speedPlayer;
    }
}

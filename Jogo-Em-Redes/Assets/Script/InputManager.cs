using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int column = Mathf.RoundToInt(mousePos.x);

            if (column >= 0 && column < GameManager.Instance.columns)
            {
                GameManager.Instance.PlacePiece(column);
            }
        }
    }
}


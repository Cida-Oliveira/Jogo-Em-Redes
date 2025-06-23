using UnityEngine;

public class Piece : MonoBehaviour
{
    public GameManager.Player owner;

    public SpriteRenderer renderer;
    public Color player1Color = Color.red;
    public Color player2Color = Color.yellow;

    public void SetOwner(GameManager.Player player)
    {
        owner = player;

        if (player == GameManager.Player.Player1)
            renderer.color = player1Color;
        else if (player == GameManager.Player.Player2)
            renderer.color = player2Color;
    }
}

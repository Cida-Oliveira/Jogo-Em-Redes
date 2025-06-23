using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int rows = 6;
    public int columns = 7;
    public GameObject[,] grid;

    public GameObject piecePrefab;
    public Transform boardHolder;

    public enum Player { None, Player1, Player2 }
    public Player currentPlayer = Player.Player1;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        grid = new GameObject[columns, rows];
    }

    public void PlacePiece(int column)
    {
        for (int row = 0; row < rows; row++)
        {
            if (grid[column, row] == null)
            {
                Vector2 pos = new Vector2(column, row);
                GameObject piece = Instantiate(piecePrefab, pos, Quaternion.identity, boardHolder);
                piece.GetComponent<Piece>().SetOwner(currentPlayer);

                grid[column, row] = piece;

                if (CheckWin(column, row))
                {
                    Debug.Log(currentPlayer + " venceu!");
                    return;
                }

                SwitchPlayer();
                return;
            }
        }
        Debug.Log("Coluna cheia!");
    }

    void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == Player.Player1) ? Player.Player2 : Player.Player1;
    }

    bool CheckWin(int lastCol, int lastRow)
    {
        return (CountDirection(lastCol, lastRow, 1, 0) + CountDirection(lastCol, lastRow, -1, 0) >= 3) // Horizontal
            || (CountDirection(lastCol, lastRow, 0, 1) + CountDirection(lastCol, lastRow, 0, -1) >= 3) // Vertical
            || (CountDirection(lastCol, lastRow, 1, 1) + CountDirection(lastCol, lastRow, -1, -1) >= 3) // Diagonal \
            || (CountDirection(lastCol, lastRow, 1, -1) + CountDirection(lastCol, lastRow, -1, 1) >= 3); // Diagonal /
    }

    int CountDirection(int col, int row, int dCol, int dRow)
    {
        int count = 0;
        Player owner = currentPlayer;

        int c = col + dCol;
        int r = row + dRow;

        while (c >= 0 && c < columns && r >= 0 && r < rows)
        {
            if (grid[c, r] != null && grid[c, r].GetComponent<Piece>().owner == owner)
            {
                count++;
                c += dCol;
                r += dRow;
            }
            else
                break;
        }
        return count;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SnakePart : MonoBehaviour {
    private SnakePart snakePartBefore; //The snake body part in front of this body part
    private SnakePart snakePartAfter; //The snake body part following this body part
    private BoardCell currentBoardCell;

    public int GetCoordinateX()
    {
        return Board.GetCoordinateX(this.transform.position);
    }

    public int GetCoordinateY()
    {
        return Board.GetCoordinateY(this.transform.position);
    }

    public BoardCell GetBoardCell()
    {
        return Board.GetActiveBoardCell(this.transform.position);
    }

    internal SnakePart GetSnakePartBefore()
    {
        return snakePartBefore;
    }

    internal void SetSnakePartBefore(SnakePart snakePart)
    {
        snakePartBefore = snakePart;
    }

    internal SnakePart GetSnakePartAfter()
    {
        {
            return snakePartAfter;
        }
    }

    internal void SetSnakePartAfter(SnakePart snakePart)
    {
        snakePartAfter = snakePart;
    }

    internal void Move()
    {
        gameObject.transform.position -= gameObject.transform.up * Time.deltaTime * Board.speed;

        BoardCell nextBoardCell = this.GetBoardCell();

        if (nextBoardCell == null) return;
        if (nextBoardCell == currentBoardCell) return; //We are still in the same cell
        if (!nextBoardCell.IsBeyondCenter(gameObject.transform)) return; // We wont make the tern until we reached the middle of the cell

        currentBoardCell = nextBoardCell;

        int xCurrent = this.GetCoordinateX();
        int yCurrent = this.GetCoordinateY();

        int xBefore = this.GetSnakePartBefore().GetCoordinateX();
        int yBefore = this.GetSnakePartBefore().GetCoordinateY();

        //Set direction down
        if (xCurrent == xBefore && yCurrent > yBefore) {
//            gameObject.transform.rotation = GetSnakePartBefore().transform.rotation;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //Set direction up
        else if (xCurrent == xBefore && yCurrent < yBefore)
        {
///            gameObject.transform.rotation = GetSnakePartBefore().transform.rotation;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        //Set direction right
        else if (xCurrent < xBefore && yCurrent == yBefore)
        {
//            gameObject.transform.rotation = GetSnakePartBefore().transform.rotation;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        //Set direction left
        else if (xCurrent > xBefore && yCurrent == yBefore) {
//            gameObject.transform.rotation = GetSnakePartBefore().transform.rotation;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }
}

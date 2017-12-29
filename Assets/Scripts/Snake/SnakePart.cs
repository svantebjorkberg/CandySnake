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
        if (!this.PassedCenter(nextBoardCell)) return; // We wont make the tern until we reached the middle of the cell

        currentBoardCell = nextBoardCell;

        gameObject.transform.position = currentBoardCell.GetPosition(); //Make sure bodypart sticks to grid
        gameObject.transform.Rotate(Vector3.forward, this.GetBoardCell().GetRotation());


        //Remove this code when tail-object is created !!!
        if (this.GetSnakePartAfter() == null)
        {
            currentBoardCell.SetRotation(0);
        }
    }

    public bool PassedCenter(BoardCell boardCell)
    {

        if (Vector3.Dot(-gameObject.transform.up, boardCell.GetPosition() - gameObject.transform.position) <= 0)
        {
            return true;
        }

        return false;
    }
}

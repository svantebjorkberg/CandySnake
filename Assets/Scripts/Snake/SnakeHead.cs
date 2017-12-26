using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakePart {
    internal enum Rotation { clockwise, anticlockwise, none }
    private Rotation rotate;
    private BoardCell currentBoardCell;

    new internal void Move()
    {
        this.transform.position -= gameObject.transform.up * Time.deltaTime * Board.speed;
        Vector3 nextPosition = this.transform.position - gameObject.transform.up * Time.deltaTime * Board.speed;

        float x = nextPosition.x;
        float y = nextPosition.y;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rotate = Rotation.anticlockwise;

        } else if (Input.GetKeyDown(KeyCode.M))
        {
            rotate = Rotation.clockwise;

        } else if (x < 0) {
            int direction = (int)(Random.Range(0, 0.999999f) * 2 + 1); //Random number 1 or 2
            
            if (direction == 1)
            {
                rotate = Rotation.anticlockwise;
            }
        }


        if (rotate == Rotation.none) return;
        BoardCell nextBoardCell = this.GetBoardCell();

        if (nextBoardCell == null) return;
        if (nextBoardCell == currentBoardCell) return; //We are still in the same cell
        if (!nextBoardCell.IsBeyondCenter(gameObject.transform)) return; // We wont make the tern until we reached the middle of the cell

        currentBoardCell = nextBoardCell;

        if (rotate == Rotation.anticlockwise)
        {
            gameObject.transform.Rotate(Vector3.forward, 90);
            rotate = Rotation.none;

        }
        else if (rotate == Rotation.clockwise)
        {
            gameObject.transform.Rotate(Vector3.forward, -90);
            rotate = Rotation.none;
        }
    }
}

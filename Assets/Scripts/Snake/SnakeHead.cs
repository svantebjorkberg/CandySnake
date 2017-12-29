using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakePart {
    internal enum Rotation { clockwise, anticlockwise, none }
    private Rotation rotate = Rotation.none;
    private BoardCell currentBoardCell;
    public enum Direction { up, down, left, right, undefined };
    private Direction snakeHeadDirection;

    public void Awake()
    {
        UnityEngine.UI.Button CWbutton = GameObject.Find("CW").GetComponent<UnityEngine.UI.Button>();
        CWbutton.onClick.AddListener(RotateClockwise);
        UnityEngine.UI.Button CCWbutton = GameObject.Find("CCW").GetComponent<UnityEngine.UI.Button>();
        CCWbutton.onClick.AddListener(RotateCounterClockwise);
    }

    new internal void Move()
    {
        BoardCell nextBoardCell = this.GetBoardCell();

        //Check if snakehead has passed center in the next cell.
        if (nextBoardCell != currentBoardCell && 
            this.PassedCenter(nextBoardCell))
        {
            currentBoardCell = nextBoardCell;

            float rotationAngle = GetRotationAngle(); //Check for keyboard input
            gameObject.transform.Rotate(Vector3.forward, rotationAngle);
            float directionX = gameObject.transform.rotation.x;
            float directionY = gameObject.transform.rotation.y;
            print("direction=" + directionX + " / " + directionY + " / " + gameObject.transform.rotation);
        }


        //Move one step
        this.transform.position -= gameObject.transform.up * Time.deltaTime * Board.speed;

        //Check for turn request
        Vector3 nextPosition = this.transform.position - gameObject.transform.up * Time.deltaTime * Board.speed;

        float x = nextPosition.x;
        float y = nextPosition.y;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            RotateCounterClockwise();

        } else if (Input.GetKeyDown(KeyCode.M))
        {
            RotateClockwise();

        }
    }

    private void RotateClockwise()
    {
        rotate = Rotation.clockwise;
    }

    private void RotateCounterClockwise()
    {
        rotate = Rotation.anticlockwise;
    }

    private float GetRotationAngle()
{
    float rotationAngle = 0;

        if (rotate == Rotation.anticlockwise) rotationAngle = 90;
        else if (rotate == Rotation.clockwise) rotationAngle = -90;

        if (rotationAngle != 0)
        {
            this.GetBoardCell().SetRotation(rotationAngle);
            snakeHeadDirection = GetSnakeHeadDirection(snakeHeadDirection, rotationAngle);
            gameObject.transform.position = currentBoardCell.GetPosition(); //Make sure bodypart sticks to grid
        }

        rotate = Rotation.none; //This rotation is consumed (if any)

        //Force a turn if board-bounds are reached and no turn has been initiated
        BoardCell boardCell = this.GetBoardCell();

        if (boardCell.GetRotation() == 0)
        {
            int x = boardCell.GetCoordinateX();
            int y = boardCell.GetCoordinateY();

            if (x <= 0 || x >= Board.BOARD_WIDTH-1 && (snakeHeadDirection == Direction.left || snakeHeadDirection == Direction.right) ||
                y <= 0 || y >= Board.BOARD_HEIGHT- 1 && (snakeHeadDirection == Direction.up || snakeHeadDirection == Direction.down))
            {
                int direction = (int)(Random.Range(0, 0.999999f) * 2 + 1); //Random number 1 or 2

                if (direction == 1)
                {
                    this.GetBoardCell().SetRotation(90);
                }
                else
                {
                    this.GetBoardCell().SetRotation(-90);
                }

            }
        }

        return this.GetBoardCell().GetRotation();
    }

    /// <summary>
    /// Set the current direction of the snakehead (up, down, left or right). Currently only used at game startup to point snakehead to the right.
    /// </summary>
    /// <param name="d"></param>
    public void SetInitialDirection(Direction d)
    {
        switch (d)
        {
            case Direction.up:
                throw new System.Exception("This method is not implememted");

            case Direction.down:
                throw new System.Exception("This method is not implememted");

            case Direction.left:
                throw new System.Exception("This method is not implememted");

            case Direction.right:
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }

        snakeHeadDirection = d;
    }

    private Direction GetSnakeHeadDirection(Direction currentSnakeHeadDirection, float rotationAngle)
    {
        Direction newSnakeHeadDirection = Direction.undefined;
        if (currentSnakeHeadDirection == Direction.up && rotationAngle == 90) newSnakeHeadDirection = Direction.left;
        else if (currentSnakeHeadDirection == Direction.up && rotationAngle == -90) newSnakeHeadDirection = Direction.right;
        else if (currentSnakeHeadDirection == Direction.down && rotationAngle == 90) newSnakeHeadDirection = Direction.right;
        else if (currentSnakeHeadDirection == Direction.down && rotationAngle == -90) newSnakeHeadDirection = Direction.left;
        else if (currentSnakeHeadDirection == Direction.left && rotationAngle == 90) newSnakeHeadDirection = Direction.down;
        else if (currentSnakeHeadDirection == Direction.left && rotationAngle == -90) newSnakeHeadDirection = Direction.up;
        else if (currentSnakeHeadDirection == Direction.right && rotationAngle == 90) newSnakeHeadDirection = Direction.up;
        else if (currentSnakeHeadDirection == Direction.right && rotationAngle == -90) newSnakeHeadDirection = Direction.down;

        return newSnakeHeadDirection;
    }
}

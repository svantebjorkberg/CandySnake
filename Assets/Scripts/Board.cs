using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    static BoardCell[,] boardCells;
    private Snake snake;
    public static float speed = 0.5f;
    private const int CHILD_SNAKEHEAD = 0;
    public const int BOARD_WIDTH = 12;
    public const int BOARD_HEIGHT = 6;
    public const float BOARD_VIEW_DISTANCE = -10;

    // Use this for initialization
    public void Awake()
    {
        //Position main camera
        GameObject mainCameraObject = GameObject.Find("Main Camera");
        mainCameraObject.transform.position = new Vector3(BOARD_WIDTH / 2 - 0.5f, BOARD_HEIGHT / 2 - 0.5f, BOARD_VIEW_DISTANCE);

        //Position board
        this.transform.position = new Vector3(BOARD_WIDTH/2 - 0.5f, BOARD_HEIGHT/2 - 0.5f, 0.04f);
        this.transform.localScale = new Vector3(BOARD_WIDTH, BOARD_HEIGHT, 1f);

        //Load snake
        GameObject snakeObject = Instantiate(Resources.Load("Snake/SnakeObject") as GameObject);
        snake = snakeObject.GetComponent<Snake>();

        boardCells = new BoardCell[BOARD_WIDTH, BOARD_HEIGHT];

        for (int y = 0; y < BOARD_HEIGHT; y++)
        {
            for (int x = 0; x < BOARD_WIDTH; x++)
            {
                boardCells[x, y] = new BoardCell(new Vector3(x, y));
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public static int GetCoordinateX(Vector3 position)
    {
        return (int)(position.x + 0.5);
    }

    public static int GetCoordinateY(Vector3 position)
    {
        return (int)(position.y + 0.5);
    }

    public static BoardCell GetActiveBoardCell(Vector3 position)
    {
        int cellX = GetCoordinateX(position);
        int cellY = GetCoordinateY(position);
        //print("Active cell: " + cellX + "/" + cellY + ", ix=" + ix + "y=" + y);

        if (cellX < 0) cellX = 0;
        if (cellX > BOARD_WIDTH - 1) cellX = BOARD_WIDTH - 1;
        if (cellY < 0) cellY = 0;
        if (cellY > BOARD_HEIGHT - 1) cellY = BOARD_HEIGHT - 1;

        BoardCell boardCell = boardCells[cellX, cellY];
        return boardCell;
    }
}

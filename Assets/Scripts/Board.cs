using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    public int cellsX;
    public int cellsY;
    BoardCell[] boardCells;
    private Snake snake;
    public static float speed = 0.5f;
    bool isInitialized = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void Initialize() 
    {
        snake = new Snake();

        float boardWidth = GetComponent<MeshRenderer>().bounds.size.x;
        float boardHeight = GetComponent<MeshRenderer>().bounds.size.y;

        float snakeHeadWidth = snake.getSnakeHead().GetComponent<MeshRenderer>().bounds.size.x;
        float snakeHeadHeight = snake.getSnakeHead().GetComponent<MeshRenderer>().bounds.size.y;
        float cellSide = snakeHeadWidth > snakeHeadHeight ? snakeHeadWidth : snakeHeadHeight;

        cellsX = (int)(boardWidth / cellSide);
        cellsY = (int)(boardHeight / cellSide);

        boardCells = new BoardCell[cellsX * cellsY];

        for (int x = 0; x < cellsX; x++)
        {
            for (int y = 0; y < cellsY; y++)
            {
                int ix = x * cellsX + y;
                boardCells[ix] = new BoardCell();
            }
        }

        isInitialized = true;
    }


}

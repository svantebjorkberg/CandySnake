using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {
    private SnakeHead snakeHead;
    public Snake()
    {
        snakeHead = new SnakeHead();
    }

    public SnakeHead getSnakeHead()
    {
        return snakeHead;
    }
}

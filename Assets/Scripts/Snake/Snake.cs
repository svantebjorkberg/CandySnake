using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {
    private SnakeHead snakeHead;
    private List<SnakeBody> snakeBodies = new List<SnakeBody>();

    public void Awake()
    {
        //Create snake head
        GameObject snakeHeadObject = Instantiate(Resources.Load("Snake/SnakeHeadObject") as GameObject);
        snakeHead = snakeHeadObject.GetComponent<SnakeHead>();

        //Position SnakeHead
        int startY = (int)(Board.BOARD_HEIGHT / 2);
        snakeHead.gameObject.transform.position = new Vector3(3f, startY);
        snakeHead.SetInitialDirection(SnakeHead.Direction.right);

        //Add bodyparts
        AddBodyPart(new Vector3(2f, startY));
        AddBodyPart(new Vector3(1f, startY));
        AddBodyPart(new Vector3(0f, startY));
    }

    public void Update()
    {
        //Move head
        snakeHead.Move();

        //Move body parts
        foreach (SnakeBody snakeBody in snakeBodies)
        {
            snakeBody.Move();
        }

    }
    public void AddBodyPart(Vector3 position)
    {
        GameObject snakeBodyObject = Instantiate(Resources.Load("Snake/SnakeBodyObject")as GameObject);
        snakeBodyObject.transform.GetChild(0).transform.Rotate(Vector3.forward, Random.Range(0, 360));

        SnakeBody snakeBody = snakeBodyObject.GetComponent<SnakeBody>();

        //Position Bodypart
        snakeBody.gameObject.transform.position = position;
        
        //Set snake bodypart before this one
        SnakePart snakeBodyBefore = snakeHead; //Assume snake-head is before this bodypart
        if (snakeBodies.Count > 0) snakeBodyBefore = snakeBodies[snakeBodies.Count - 1]; //If bodyparts already exists set the last one as before this new one.
        snakeBody.SetSnakePartBefore(snakeBodyBefore);
        snakeBodyBefore.SetSnakePartAfter(snakeBody);

        //snakeBody.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        snakeBody.gameObject.transform.rotation = snakeBody.GetSnakePartBefore().transform.rotation;
        snakeBodies.Add(snakeBody);
    }
 
}

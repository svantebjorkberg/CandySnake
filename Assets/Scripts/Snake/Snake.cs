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
        snakeHead.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);

        //Add bodyparts
        AddBodyPart(new Vector3(2f, startY));
        AddBodyPart(new Vector3(1f, startY));
        AddBodyPart(new Vector3(0f, startY));
    }
    private int x;
    private int y;
    public void Update()
    {
        //Move head
        snakeHead.Move();

        //Move body parts
        foreach (SnakeBody snakeBody in snakeBodies)
        {
            snakeBody.Move();
        }

        if (x != snakeHead.GetCoordinateX() || y != snakeHead.GetCoordinateY())
        {
            print("---------------------------------- Move");
            int acc = 1;
            foreach (SnakeBody snakeBody in snakeBodies)
            {
                print("Body("+acc+"): " + snakeBody.GetCoordinateX() + ", " + snakeBody.GetCoordinateY());
                acc++;
            }
            print("Head: " + snakeHead.GetCoordinateX() + ", " + snakeHead.GetCoordinateY());
            x = snakeHead.GetCoordinateX();
            y = snakeHead.GetCoordinateY();
        }

    }
    public void AddBodyPart(Vector3 position)
    {
        GameObject snakeBodyObject = Instantiate(Resources.Load("Snake/SnakeBodyObject")as GameObject);
        SnakeBody snakeBody = snakeBodyObject.GetComponent<SnakeBody>();

        //Position Bodypart
        snakeBody.gameObject.transform.position = position;
        
        //Set snake bodypart before this one
        SnakePart snakeBodyBefore = snakeHead; //Assume snake-head is before this bodypart
        if (snakeBodies.Count > 0) snakeBodyBefore = snakeBodies[snakeBodies.Count - 1]; //If bodyparts already exists set the last one as before this new one.
        snakeBody.SetSnakePartBefore(snakeBodyBefore);
        snakeBodyBefore.SetSnakePartAfter(snakeBody);

        snakeBody.gameObject.transform.rotation = snakeBody.GetSnakePartBefore().transform.rotation;
        snakeBodies.Add(snakeBody);
    }
 
}

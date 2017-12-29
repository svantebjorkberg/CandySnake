using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardCell
{
    public float rotationAngle = 0;
    private Vector3 position;

    public BoardCell(Vector3 position)
    {
        this.position = position;
    }

    public int GetCoordinateX()
    {
        return Board.GetCoordinateX(position);
    }

    public int GetCoordinateY()
    {
        return Board.GetCoordinateY(position);
    }

    public void SetRotation(float rotationAngle)
    {
        this.rotationAngle = rotationAngle;
    }

    public float GetRotation()
    {
        return rotationAngle;
    }

    public Vector3 GetPosition()
    {
        return position;
    }
}

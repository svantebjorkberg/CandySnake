using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell {
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

    public bool IsBeyondCenter(Transform aTransform)
    {

        if (Vector3.Distance(aTransform.position, this.position) > 0.2)
        {
            return false;
        }

        return true;
    }
}

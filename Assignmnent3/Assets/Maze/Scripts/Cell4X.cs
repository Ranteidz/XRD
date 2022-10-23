using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell4X : CellInterface
{

    public GameObject upWall;
    public GameObject downWall;
    public GameObject rightWall;
    public GameObject leftWall;


    public override void destroyWallsOnDirectionOf(int x, int y)
    {
        if (getX() == x)
        {//up or down
            if (getY() < y)
            { 
                DestroyUpWall();
            }
            else
            {
                DestroyDownWall();
            }
        }
        else
        { // y are equals
            if (getX() < x)
            { 
                DestroyRightWall();
            }
            else
            { 
                DestroyLeftWall();
            }
        }
    }

    public override List<CellInterface> getNeighboutsNotvisitedOfCurrentCell(CellInterface[,] fullGrid)
    {
        int width = fullGrid.GetLength(0);
        int height = fullGrid.GetLength(1);
        List<CellInterface> returnList = new List<CellInterface>();
        if (getX() + 1 < width && !fullGrid[getX() + 1, getY()].getVisited())
            returnList.Add(fullGrid[getX() + 1, getY()]);

        if (getX() - 1 >= 0 && !fullGrid[getX() - 1, getY()].getVisited())
            returnList.Add(fullGrid[getX() - 1, getY()]);

        if (getY() + 1 < height && !fullGrid[getX(), getY() + 1].getVisited())
            returnList.Add(fullGrid[getX(), getY() + 1]);

        if (getY() - 1 >= 0 && !fullGrid[getX(), getY() - 1].getVisited())
            returnList.Add(fullGrid[getX(), getY() - 1]);

        return returnList;
    }

    public void DestroyLeftWall()
    {
        GameObject.DestroyImmediate(leftWall);
    }
    public void DestroyRightWall()
    {
        GameObject.DestroyImmediate(rightWall);
    }
    public void DestroyUpWall()
    {
        GameObject.DestroyImmediate(upWall);
    }
    public void DestroyDownWall()
    {
        GameObject.DestroyImmediate(downWall);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell6X : CellInterface { 

 
    [SerializeField]
    GameObject leftWall;
    [SerializeField]
    GameObject rightWall;
    [SerializeField]
    GameObject upRightWall;
    [SerializeField]
    GameObject upLeftWall;
    [SerializeField]
    GameObject downRightWall;
    [SerializeField]
    GameObject downLeftWall;

    public override void destroyWallsOnDirectionOf(int x, int y)
    {
      //  Debug.Log("Destroy: " + getX() + "," + getY() + " : " + x + "," + y);

        if (getX() < x && getY() == y)
        {
            DestroyRightWall();
            return;
        }

        if (getX() > x && getY() == y)
        {
            DestroyLeftWall();
            return;
        }

        if (getY() % 2 == 0)
        {


            if (getX() == x && getY() < y)
            {
                DestroyUpRightWall();
                return;
            }

            if (getX() == x && getY() > y)
            {
                DestroyDownRightWall();
                return;
            }

            if (getX() > x && getY() > y)
            {
                DestroyDownLeftWall();
                return;
            }

            if (getX() > x && getY() < y)
            {
                DestroyUpLeftWall();
                return;
            }
        }
        else
        {
            if (getX() == x && getY() < y)
            {
                DestroyUpLeftWall();
                return;
            }

            if (getX() == x && getY() > y)
            {
                DestroyDownLeftWall();
                return;
            }

            if (getX() < x && getY() < y)
            {
                DestroyUpRightWall();
                return;
            }

            if (getX() < x && getY() > y)
            {
                DestroyDownRightWall();
                return;
            }

        }

    }
    


    public void DestroyUpRightWall () {

   //     Debug.Log("UP Right");
        GameObject.DestroyImmediate(upRightWall);
    }
    public void DestroyUpLeftWall ()
    {
       // Debug.Log("UP left");
        GameObject.DestroyImmediate(upLeftWall);
    }


    public void DestroyDownRightWall ()
    {
       // Debug.Log("down Right");
        GameObject.DestroyImmediate(downRightWall);
    }
    public void DestroyDownLeftWall ()
    {
      //  Debug.Log("Down left");
        GameObject.DestroyImmediate(downLeftWall);
    }

    public void DestroyLeftWall ()
    {
     //   Debug.Log("Left");
        GameObject.DestroyImmediate(leftWall);
    }
    public void DestroyRightWall ()
    {
      //  Debug.Log("Right");
        GameObject.DestroyImmediate(rightWall);
    }

    public override List<CellInterface> getNeighboutsNotvisitedOfCurrentCell(CellInterface[,] fullGrid)
    {//revisar solo pùede cambiar 1 nro

        int width = fullGrid.GetLength(0);
        int height = fullGrid.GetLength(1);
        List<CellInterface> returnList = new List<CellInterface>();

        if (getX() - 1 >= 0 && !fullGrid[getX() - 1, getY()].getVisited())
            returnList.Add(fullGrid[getX() - 1, getY()]);

        if (getY() - 1 >= 0 && !fullGrid[getX(), getY()-1].getVisited())
            returnList.Add(fullGrid[getX(), getY()-1]);

        if (getX() + 1 < width && !fullGrid[getX() + 1, getY()].getVisited())
             returnList.Add(fullGrid[getX() + 1, getY()]);

        if (getY() + 1 < height && !fullGrid[getX(), getY() + 1].getVisited())
             returnList.Add(fullGrid[getX(), getY() + 1]);
        
        if (getY() % 2 == 0)
        {
            if (getY() - 1 >= 0 && getX() - 1 >= 0 && !fullGrid[getX()-1, getY() - 1].getVisited())
                returnList.Add(fullGrid[getX()-1, getY() - 1]);
            if ( getX() - 1 >= 0 && getY() + 1 < height && !fullGrid[getX() - 1, getY() + 1].getVisited())
                returnList.Add(fullGrid[getX() - 1, getY() + 1]);

        } else
        {
            if (getY() - 1 >= 0 && getX() + 1 < width && !fullGrid[getX() + 1, getY() - 1].getVisited())
                returnList.Add(fullGrid[getX() + 1, getY() - 1]);
            if (getX() + 1 < width && getY() + 1 < height && !fullGrid[getX() + 1, getY() + 1].getVisited())
                returnList.Add(fullGrid[getX() + 1, getY() + 1]);

        }
        
        return returnList;
    }
}

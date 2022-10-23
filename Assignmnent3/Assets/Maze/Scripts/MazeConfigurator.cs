using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MazeConfigurator : MonoBehaviour {
    [Tooltip("Scale factor for this maze.")]
    public float scale = 1;
    [Tooltip("Configuration to place the player. In this MazePosition you must fill the Game Object with the player GameObject and the cell where the player must begins. You can configure a rotation and the amount of shifts from the center of the cell where it will be generated.")]
    public MazePositions playerConfiguration;
    [Tooltip("Objects to generate and the positions where it will be generated.")]
    public List<MazePositions> positionsToGenerate;
    private GeneratorBaseClass generator;

    /// <summary>
    /// This Method place the player and the objects indicated in the configuration Script
    /// </summary>
    public void MazeConfiguration()
    {
        generator = GetComponent<GeneratorBaseClass>();
        //Scaling Maze
        transform.localScale = transform.localScale * scale;
        for (int i = 0; i < positionsToGenerate.Count; i++)
        {
            Vector3 worldPositionOfGo = AssignPosition(positionsToGenerate[i]);
            GameObject go = Instantiate(positionsToGenerate[i].go);
         
            go.transform.position = worldPositionOfGo;
            go.transform.rotation = positionsToGenerate[i].rotation;
            go.transform.position = go.transform.position + positionsToGenerate[i].transformShifts;
           

        }
        GameObject playerIsInstatiated = GameObject.Find(playerConfiguration.go.name);
        if (playerIsInstatiated == null && playerConfiguration.go!=null)
            playerConfiguration.go = Instantiate(playerConfiguration.go);
        //Placing player
        playerConfiguration.go.transform.position = generator.PositionOf(playerConfiguration.cellposition.x, playerConfiguration.cellposition.y);
        playerConfiguration.go.transform.position = playerConfiguration.go.transform.position + playerConfiguration.transformShifts;
        playerConfiguration.go.transform.rotation = playerConfiguration.rotation;
       

    }


    private Vector3 AssignPosition(MazePositions mazePositions)
    {
        if (IsViablePosition(mazePositions.cellposition))
        {
            return generator.PositionOf(mazePositions.cellposition.x, mazePositions.cellposition.y);
        }
        return Vector3.zero;
    }

    /// <summary>
    /// Return if this position is valid
    /// </summary>
    /// <param name="cellposition"></param>
    /// <returns></returns>
    private bool IsViablePosition(CellPosition cellposition)
    {
        if (cellposition.x>=0 && cellposition.x < generator.width)
        {
            if (cellposition.y >= 0 && cellposition.y < generator.heigh)
                return true;
        }
        return false;
    }
}

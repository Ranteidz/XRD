using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CellPosition
{
    public int x;
    public int y;
}

[System.Serializable]
public class MazePositions {
    [Tooltip("Position in the Maze.")]
    public CellPosition cellposition;
    [Tooltip("Object to generate in this position")]
    public GameObject go;
    [Tooltip("Rotation aplied to this gameObject")]
    public Quaternion rotation;
    [Tooltip("Shifting of the object in transform Position.")]
    public Vector3 transformShifts;
}

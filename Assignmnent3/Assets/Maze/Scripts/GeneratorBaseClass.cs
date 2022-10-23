using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Generator class, can be extended by other GameObjects to speciallice his behaviour. 
/// </summary>
public class GeneratorBaseClass : MonoBehaviour {


    /*Make the initial cell the current cell and mark it as visited
    While there are unvisited cells
        If the current cell has any neighbours which have not been visited
            Choose randomly one of the unvisited neighbours
            Push the current cell to the stack
            Remove the wall between the current cell and the chosen cell
            Make the chosen cell the current cell and mark it as visited
        Else if stack is not empty
            Pop a cell from the stack
            Make it the current cell*/

    [HideInInspector]
    protected int initialCellX = 0;
    [HideInInspector]
    protected int initialCelly = 0;
    [Tooltip("Horizontal number of cells")]
    public int width;
    [Tooltip("Vertical number of cells")]
    public int heigh;
    [Tooltip("Cell base to generate maze")]
    public CellInterface cellGameObject;
    [Tooltip("Horizontal shifts, used when a cell has not a squared base.")]
    [SerializeField]
    float xShift = 0f;
    [Tooltip("Vertical shifts, used when a cell has not a squared base.")]
    [SerializeField]
    float yShift = 0f;
    [Tooltip("Builds an entrance when the generation ends.")]
    public bool buildEntrance = false;
    [Tooltip("Builds an exit on the last cell generated when the generation ends.")]
    public bool buildExit = false;


    [HideInInspector]
    protected CellInterface currentCell;
    [HideInInspector]
    protected Stack<CellInterface> cellsStack = new Stack<CellInterface>();
    [HideInInspector]
    protected CellInterface[,] fullGrid;

    private bool generated = false;

    [HideInInspector]
    protected Vector3 cellSize;

    private void Awake()
    {
        if (transform.childCount==0)
            Init();

    }

    /// <summary>
    /// This function will a Maze
    /// </summary>
    public void Init()
    {
        transform.localScale = new Vector3(1,1,1);
        fullGrid = new CellInterface[width, heigh];
        InitAllCells();
        InitGeneration();
    }

    /// <summary>
    /// Method to configure the Maze Generator
    /// </summary>
    /// <param name="cell">Cell to build the maze</param>
    /// <param name="w">Width in nº of cells </param>
    /// <param name="h">Height in nº of cells</param>
    public static void LaunchGenerator(CellInterface cell, int w, int h)
    {
          GeneratorBaseClass gen;
          gen = GameObject.FindObjectOfType<GeneratorBaseClass>();
          if (gen == null) {
              GameObject go = new GameObject("Generator");
              go.AddComponent<GeneratorBaseClass>();
              gen = go.GetComponent<GeneratorBaseClass>();
                go.AddComponent<MazeConfigurator>();
          }
          gen.width = w;
          gen.heigh = h;
          gen.cellGameObject = cell;

    }

    /// <summary>
    /// This method resets the scale of this object and destroy the maze generated(if exists).
    /// </summary>
    public void ResetGenerator()
    {
        
       transform.localScale = new Vector3(1, 1, 1);
        DestroyMyChildrens();

    }

    /// <summary>
    /// Recursive function to destroy childrens from editor.
    /// </summary>
    private void DestroyMyChildrens()
    {
        if (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
            DestroyMyChildrens();
        }
        
    }

    /// <summary>
    /// Build the grid with all cells and walls
    /// </summary>
    private void InitAllCells()
    {
        for (int i = 0; i < width; i++)
            for (int j = 0; j < heigh; j++)
            {
                Vector3 position = PositionOf(i, j);
                fullGrid[i, j] = Instantiate(cellGameObject);
                fullGrid[i, j].transform.position = position + transform.position;
                fullGrid[i, j].transform.parent = transform;
                fullGrid[i, j].setX(i);
                fullGrid[i, j].setY(j);
            }

    }

    /// <summary>
    /// Return the world position of the cell in the position i and j.
    /// </summary>
    /// <param name="i"> Horizontal position of the maze</param>
    /// <param name="j"> Vertical position of the maze</param>
    /// <returns></returns>
    public Vector3 PositionOf(int i, int j)
    {
        if (j % 2 == 0)
        {
            return new Vector3(i * cellSize.x * transform.localScale.x, 0, j * (1 - yShift) * cellSize.z * transform.localScale.z);
        }
        else
        {
            return new Vector3(((i * cellSize.x) + xShift) * transform.localScale.x, 0,  j*(1- yShift) * cellSize.z * transform.localScale.z);
        }

    }

    /// <summary>
    /// With the grid builded, this functions will use backtrack algorith to remove the walls and make the paths of the maze.
    /// </summary>
    public void InitGeneration()
    {
        currentCell = fullGrid[initialCellX, initialCelly];
        currentCell.setVisited(true);
        while (AreUnvisitedCells())
        {
            List<CellInterface> neigboursNotVisited = currentCell.getNeighboutsNotvisitedOfCurrentCell(fullGrid);
            if (neigboursNotVisited.Count > 0)
            {
                int ranNeigbour = UnityEngine.Random.Range(0, neigboursNotVisited.Count);
                CellInterface nextCell = neigboursNotVisited[ranNeigbour];
                cellsStack.Push(currentCell);
                currentCell.destroyWallsOnDirectionOf(nextCell.getX(), nextCell.getY());
                nextCell.destroyWallsOnDirectionOf(currentCell.getX(), currentCell.getY());
                currentCell = nextCell;
                currentCell.setVisited(true);
            }
            else if (cellsStack.Count > 0)
            {
                currentCell = cellsStack.Pop();
            }
        }
        NotifyEndGeneration();


    }

    /// <summary>
    /// This Method is launched when the maze generator end to generate a maze. In this function is launched the configuration for each maze.
    /// </summary>
    protected virtual void NotifyEndGeneration()
    {
        generated = true;
        Debug.Log("Generation End");
        if (buildEntrance)
        {
            fullGrid[0, 0].destroyWallsOnDirectionOf(0, -1);

        }
        if (buildExit)
        {

            fullGrid[width - 1, heigh - 1].destroyWallsOnDirectionOf(width - 1, heigh);
        }

        MazeConfigurator configurator = GetComponent<MazeConfigurator>();
        if (configurator != null)
            configurator.MazeConfiguration();

    }

    private bool AreUnvisitedCells()
    {
        for (int i = 0; i < width; i++)
            for (int j = 0; j < heigh; j++)
                if (!fullGrid[i, j].getVisited())
                    return true;

        return false;
    }

    /// <summary>
    /// Checks in Editor mode the size of cell, and launcha  Warning if this object are not with a scale of 1.
    /// </summary>
    private void OnValidate()
    {
        cellSize = cellGameObject.GetComponent<Renderer>().bounds.size;
        if (transform.childCount == 0 && transform.localScale.x!=1 || transform.localScale.y != 1 || transform.localScale.z != 1)
        {
            Debug.LogWarning("The Scale of generator must be 1 to generate the maze correctly.");
        }
    }

    public bool isGenerated()
    {
        return generated;
    }
}

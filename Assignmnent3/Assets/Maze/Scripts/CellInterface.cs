using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CellAbstract class Each new cell must add the walls and implement the methods to find neighbors and the function to choose which wall must be destroyed. 
/// </summary>
public abstract class CellInterface : MonoBehaviour {

    [Tooltip("X Position in the grid")]
	private
	int x;

    [Tooltip("Y Position in the grid")]
    private
    int y;

    [Tooltip("Is this cell visited?")]
    private
	bool visited;
	
	public void setX (int newX) {
		x = newX;
	}

	public void setY (int newY) {
		y = newY;
	}

	public void setVisited (bool b) {
		visited = b;
	}
	public int getX () {
		return x;
	}
	public int getY () {
		return y;
	}
	public bool getVisited () {
		return visited;
	}

    /// <summary>
    /// Destroy the wall between this cell and the direction of the cell on position x, y sended.
    /// </summary>
    /// <param name="x"> X Direction</param>
    /// <param name="y"> Y Direction</param>
    public abstract void destroyWallsOnDirectionOf(int x, int y);

    /// <summary>
    /// Get a list of cells that are neighbors of this cell and are not visited.
    /// </summary>
    /// <param name="fullGrid"> FullGrid to obtain the neighbours </param>
    /// <returns>List of neighbors cells and not visited.</returns>
    public abstract List<CellInterface> getNeighboutsNotvisitedOfCurrentCell(CellInterface[,] fullGrid);

}

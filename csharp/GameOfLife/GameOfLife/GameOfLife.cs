using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
  public class GameOfLife
  {
    public List<Cell> Cells;
    List<Cell> NextLifeCells;
    internal readonly int Size;

    public GameOfLife( int size )
    {
      Cells = new List<Cell>();
      NextLifeCells = new List<Cell>();
      Size = size;
      Populate();
    }

    private void Populate()
    {
      for ( int i = 0; i < Size; i++ )
      {
        for ( int j = 0; j < Size; j++ )
        {
          Cells.Add( new Cell( new Coordinate( i, j ) ) );
        }
      }
    }

    internal void Live()
    {
      for ( int i = 0; i < Size; i++ )
      {
        for ( int j = 0; j < Size; j++ )
        {
          NextLifeCells.Add( SetNextLivingStatus( Cells.First( c => c.Coordinate.Y == i && c.Coordinate.X == j ) ) );
        }
      }

      ReplaceLifeCellsWithNew();
    }

    private void ReplaceLifeCellsWithNew()
    {
      var temp = Cells;
      Cells.Clear();
      Cells = NextLifeCells;
      NextLifeCells = temp;
    }

    public Cell SetNextLivingStatus( Cell cell ) =>
      new Cell( cell.Coordinate, CalculateNextLivingStatus( GetLivingNeighbors( cell ), cell ) );

    private string CalculateNextLivingStatus( int livingNeighbors, Cell cell )
    {
      if ( livingNeighbors == 2 )
      {
        return cell.LivingStatus;
      }

      if ( livingNeighbors == 3 )
      {
        return AliveStatus.Alive;
      }

      return AliveStatus.Dead;
    }

    private int GetLivingNeighbors( Cell cell )
    {
      var livingNeighbors = 0;
      for ( int i = cell.Coordinate.X - 1; i < cell.Coordinate.X + 2; i++ )
      {
        if ( Cells.Where( c => c.Coordinate.Y == cell.Coordinate.Y - 1 ).FirstOrDefault( c => c.Coordinate.X == i )?.LivingStatus == AliveStatus.Alive )
        {
          livingNeighbors++;
        }

        if ( Cells.Where( c => c.Coordinate.Y == cell.Coordinate.Y ).FirstOrDefault( c => c.Coordinate.X == i && c.Coordinate.X != cell.Coordinate.X )?.LivingStatus == AliveStatus.Alive )
        {
          livingNeighbors++;
        }

        if ( Cells.Where( c => c.Coordinate.Y == cell.Coordinate.Y + 1 ).FirstOrDefault( c => c.Coordinate.X == i )?.LivingStatus == AliveStatus.Alive )
        {
          livingNeighbors++;
        }
      }

      return livingNeighbors;
    }
  }
}

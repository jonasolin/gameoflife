using System.Linq;
using Xunit;

namespace GameOfLife.Tests
{
  public class GameOfLifeTests
  {
    // Any live cell with fewer than two live neighbors dies, as if by underpopulation.
    // Any live cell with two or three live neighbors lives on to the next generation.
    // Any live cell with more than three live neighbors dies, as if by overpopulation.
    // Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
    [Theory]
    [InlineData( 0, AliveStatus.Dead, AliveStatus.Alive )]
    [InlineData( 1, AliveStatus.Dead, AliveStatus.Alive )]
    [InlineData( 2, AliveStatus.Alive, AliveStatus.Alive )]
    [InlineData( 3, AliveStatus.Alive, AliveStatus.Alive )]
    [InlineData( 4, AliveStatus.Dead, AliveStatus.Alive )]
    [InlineData( 5, AliveStatus.Dead, AliveStatus.Alive )]
    [InlineData( 0, AliveStatus.Dead, AliveStatus.Dead )]
    [InlineData( 1, AliveStatus.Dead, AliveStatus.Dead )]
    [InlineData( 2, AliveStatus.Dead, AliveStatus.Dead )]
    [InlineData( 3, AliveStatus.Alive, AliveStatus.Dead )]
    [InlineData( 4, AliveStatus.Dead, AliveStatus.Dead )]
    [InlineData( 5, AliveStatus.Dead, AliveStatus.Dead )]
    public void LivingStatusTest( int livingNeighbors, string expectedLivingStatus, string startingLivingStatus )
    {
      // Arrange
      var gol = new GameOfLife( 3 );
      GenerateStartingGridWithLiveNeighbors( livingNeighbors, gol );
      var cellToCheck = gol.Cells.FirstOrDefault( c => c.Coordinate.Y == 1 && c.Coordinate.X == 1 );
      cellToCheck.LivingStatus = startingLivingStatus;

      // Act
      var cell = gol.SetNextLivingStatus( cellToCheck );

      // Assert
      Assert.Equal( expectedLivingStatus, cell.LivingStatus );
    }

    private void GenerateStartingGridWithLiveNeighbors( int livingNeighbors, GameOfLife gameOfLife )
    {
      // The middle cell of 3x3 is the one we use in tests
      // therefore we need to make one more neighbor 
      // when we want to test with more than 3 living neighbors
      if ( livingNeighbors > 3 )
      {
        livingNeighbors++;
      }

      for ( int i = 0; i < livingNeighbors; i++ )
      {
        gameOfLife.Cells[i].LivingStatus = AliveStatus.Alive;
      }
    }
  }
}

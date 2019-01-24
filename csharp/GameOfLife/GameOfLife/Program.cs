using System;
using System.Linq;

namespace GameOfLife
{
  class Program
  {
    static GameOfLife gol;
    static int Size = 10;
    static int Iterations = 10;
    static Random random = new Random();

    static void Main( string[] args )
    {
      if ( !ValidateArgs( args ) )
      {
        return;
      }

      gol = new GameOfLife( Size );
      GenerateLivingCells();

      Print();
      ItsAlive();
    }

    private static void ItsAlive()
    {
      for ( int i = 0; i < Iterations; i++ )
      {
        gol.Live();
        Print();
      }
    }

    private static void GenerateLivingCells()
    {
      for ( int i = 0; i < Size * 3; i++ )
      {
        var randomY = random.Next( Size );
        var randomX = random.Next( Size );
        gol.Cells.FirstOrDefault( c => c.Coordinate.Y == randomY && c.Coordinate.X == randomX ).LivingStatus = AliveStatus.Alive;
      }
    }

    private static bool ValidateArgs( string[] args )
    {
      if ( args?.Length != 2 )
      {
        Error();
        return false;
      }

      bool sizeTest = int.TryParse( args?[0], out int size );
      bool iterationsTest = int.TryParse( args?[1], out int iterations );
      if ( !sizeTest || !iterationsTest )
      {
        Error();
        return false;
      }

      Size = size;
      Iterations = iterations;

      return true;
    }

    private static void Error()
    {
      Console.WriteLine( "Please enter numeric arguments for size and iterations." );
      Console.WriteLine( "Usage: GameOfLife <size> <iterations>" );
    }

    private static void Print()
    {
      Console.Clear();
      for ( int i = 0; i < gol.Size; i++ )
      {
        Console.WriteLine( string.Join( "|", gol.Cells.Where( c => c.Coordinate.Y == i ).Select( c => c.LivingStatus ).ToArray() ) );
      }
    }
  }
}

namespace GameOfLife
{
  public class Coordinate
  {
    public Coordinate( int y, int x )
    {
      X = x;
      Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }
  }
}

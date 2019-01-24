namespace GameOfLife
{
  public class Cell
  {
    public string LivingStatus { get; set; }

    public Coordinate Coordinate { get; set; }

    public Cell( Coordinate coordinate, string aliveStatus = AliveStatus.Dead )
    {
      LivingStatus = aliveStatus;
      Coordinate = coordinate;
    }
  }
}

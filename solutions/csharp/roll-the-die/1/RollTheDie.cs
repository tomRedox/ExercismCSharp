public class Player
{
    private Random _random = new();
    
    public int RollDie() => _random.Next(1,19);

    public double GenerateSpellStrength() => 100 * _random.NextDouble();
}
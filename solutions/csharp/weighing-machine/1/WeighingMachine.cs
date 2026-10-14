
class WeighingMachine
{
    public WeighingMachine(int precision) { Precision = precision; }
    
    public int Precision { get; private set; }
    
    private double _weight;
    public double Weight 
    { 
        get { return _weight; }
        set { _weight = value < 0 ? throw new ArgumentOutOfRangeException() : value; }
    }

    public double TareAdjustment{ get; set; } = 5.0d;
    
    public string DisplayWeight => $"{(Weight - TareAdjustment).ToString($"F{Precision}")} kg";
}

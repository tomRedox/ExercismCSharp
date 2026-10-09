class RemoteControlCar
{
    private const int MetresPerDrive = 20;
    private int TimesDriven = 0;
    
    private int DistanceDriven() => MetresPerDrive * TimesDriven;
    
    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {DistanceDriven()} meters";

    public string BatteryDisplay() => TimesDriven == 100 ? "Battery empty" : $"Battery at {100 - TimesDriven}%";

    public void Drive()
    {
        if (TimesDriven < 100) TimesDriven++;
    }
}

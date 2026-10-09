class RemoteControlCar
{
    private readonly int _speed;
    private readonly int _batteryDrain;
    private int _timesDriven;
    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    // Battery is considered drained if the car cannot complete an additional Drive.
    public bool BatteryDrained() => _batteryDrain * (_timesDriven + 1) > 100;

    public int DistanceDriven() => _timesDriven * _speed;

    public void Drive()
    {
        if (BatteryDrained()) return;
        _timesDriven++;
    }

    public int TotalRange() => 100 / _batteryDrain * _speed;
    
    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private readonly int _distance;
    
    public RaceTrack(int distance) => _distance = distance;

    public bool TryFinishTrack(RemoteControlCar car) => car.TotalRange() >= _distance;
}

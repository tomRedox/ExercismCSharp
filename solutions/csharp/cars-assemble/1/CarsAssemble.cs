static class AssemblyLine
{
    public const int baseCarsPerHour = 221;
    
    public static double SuccessRate(int speed)
    {
        if (speed == 0) return 0;
        if (speed <= 4) return 1;
        if (speed <= 8) return .9;
        if (speed == 9) return .8;
        if (speed == 10) return .77; 
        return 0;
    }
    
    public static double ProductionRatePerHour(int speed) => baseCarsPerHour * speed * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) => (int)(ProductionRatePerHour(speed) / 60);
}

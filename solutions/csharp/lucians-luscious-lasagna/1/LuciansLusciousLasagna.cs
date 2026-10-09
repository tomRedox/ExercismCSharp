class Lasagna
{
    public const int LasagnaTotalCookTime = 40;
    public const int MinutesPerLayer = 2;
    
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven()
    {
        return LasagnaTotalCookTime;
    }
    
    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int minutesAlreadyCooked)
    {
        return ExpectedMinutesInOven() - minutesAlreadyCooked;
    }

    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int noLayers)
    {
        return MinutesPerLayer * noLayers;
    }

    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int noLayers, int minutesAlreadyCooked)
    {
        return PreparationTimeInMinutes(noLayers) + minutesAlreadyCooked;
    }
}

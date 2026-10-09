class Lasagna
{
    public const int LasagnaTotalCookTime = 40;
    public const int MinutesPerLayer = 2;
    
    public int ExpectedMinutesInOven() => LasagnaTotalCookTime;
    
    public int RemainingMinutesInOven(int minutesAlreadyCooked) => 
        ExpectedMinutesInOven() - minutesAlreadyCooked;

    public int PreparationTimeInMinutes(int noLayers) => MinutesPerLayer * noLayers;

    public int ElapsedTimeInMinutes(int noLayers, int minutesAlreadyCooked) => 
        PreparationTimeInMinutes(noLayers) + minutesAlreadyCooked;
}

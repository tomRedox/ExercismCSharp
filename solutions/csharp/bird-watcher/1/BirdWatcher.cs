class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] {0, 2, 5, 3, 7, 8, 4};

    public int Today() => birdsPerDay[birdsPerDay.Count() - 1];

    public void IncrementTodaysCount() => birdsPerDay[birdsPerDay.Count() - 1]++;

    public bool HasDayWithoutBirds()
    {
        foreach(int dayCount in birdsPerDay)
        {
            if(dayCount == 0) return true;
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int runningTotal = 0;
        for (int i = 0 ; i < numberOfDays; i++)
        {
            runningTotal += birdsPerDay[i];
        }
        return runningTotal;
    }

    public int BusyDays()
    {
        int busyCount = 0;

        foreach(int dayCount in birdsPerDay)
        {
            if (dayCount >= 5) busyCount++;
        }
        return busyCount;
    }
}

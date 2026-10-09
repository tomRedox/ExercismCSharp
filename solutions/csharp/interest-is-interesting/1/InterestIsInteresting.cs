static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0m ) return 3.213f;
        if (balance < 1000m) return 0.5f;
        if (balance < 5000m) return 1.621f;
        if (balance >= 5000m) return 2.475f;
        return 0f;
    }

    // NB: There is a potential inaccuracy here that should really be addressed, which is that casting 
    // the InterestRate to a decimal can introduce inaccuracies because of the change from a base 2 to base 10
    // numeric representation - decimal is not just a more accurate version of float.
    public static decimal Interest(decimal balance) => (decimal)InterestRate(balance) / 100 * balance;

    public static decimal AnnualBalanceUpdate(decimal balance) => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        if (balance == 0 && targetBalance != 0) throw new Exception ("Initial balance was zero, but target balance was not, so target balance will never be reached.");
        if (balance < 0 && targetBalance > balance ) throw new Exception ("Initial balance was negative; a target balance higher than the intial balance can never be reached.");

        int yearCount = 0;
        decimal runningBalance = balance;

        while (runningBalance < targetBalance)
        {
            yearCount++;
            runningBalance = AnnualBalanceUpdate(runningBalance);
        }
        return yearCount;
    }
}

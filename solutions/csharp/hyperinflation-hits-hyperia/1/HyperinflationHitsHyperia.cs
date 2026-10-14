public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            checked 
            {
                return $"{@base * multiplier}";
            }
        }
        catch (OverflowException _)
        {
            return "*** Too Big ***";
        }
        return "";
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float result = @base * multiplier;

        return (double.IsInfinity(result)) ? "*** Too Big ***" : result.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            checked 
            {
                return $"{@salaryBase * multiplier}";
            }
        }
        catch (OverflowException _)
        {
            return "*** Much Too Big ***";
        }
        return "";
    }
}

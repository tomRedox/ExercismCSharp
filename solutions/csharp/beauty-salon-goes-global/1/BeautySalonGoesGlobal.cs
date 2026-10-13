using System.Runtime.InteropServices;
using System.Linq;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early = 24 * 60,
    Standard = 105,
    Late = 30
}

public static class Appointment
{
    private static TimeZoneInfo GetTimeZoneInfo(Location location)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            if (location == Location.NewYork) return TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
            if (location == Location.London) return TimeZoneInfo.FindSystemTimeZoneById("Europe/London");
            if (location == Location.Paris) return TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris");
        }  
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            if (location == Location.NewYork) return TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            if (location == Location.London) return TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            if (location == Location.Paris) return TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
        }
        throw new Exception("Unexpected timezone");
    }

    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();
    
    public static DateTime Schedule(string appointmentDateDescription, Location location)
        => TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), GetTimeZoneInfo(location));
    

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
        => appointment.AddMinutes(-1 * (int)alertLevel);

    public static bool HasDaylightSavingChanged(DateTime dt, Location location) 
        => GetTimeZoneInfo(location).GetAdjustmentRules()
            .Any(r => (r.DateStart >= dt.AddDays(-7) && r.DateStart <= dt)
                || (r.DateEnd >= dt.AddDays(-7) && r.DateStart <= dt));

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        string cultureCode = location switch
        {
            Location.London => "en-GB",
            Location.NewYork =>  "en-US",
            Location.Paris =>  "fr-FR",
        };

        DateTime dateValue;
        bool parsed = DateTime.TryParse(dtStr, new CultureInfo(cultureCode), DateTimeStyles.None, out dateValue);

        return parsed ? dateValue : new DateTime(1, 1, 1);
    }
}

static class LogLine
{
    public static string Message(string logLine)
        => logLine.Remove(0, logLine.IndexOf(" ")).Trim();

    public static string LogLevel(string logLine)
        => logLine.Substring(1, logLine.IndexOf("]") - 1).ToLower();

    public static string Reformat(string logLine)
        => $"{Message(logLine)} ({LogLevel(logLine)})";
}

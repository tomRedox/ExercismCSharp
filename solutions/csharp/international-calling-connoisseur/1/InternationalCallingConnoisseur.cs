using System.Linq;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary() => new Dictionary<int, string>();

    public static Dictionary<int, string> GetExistingDictionary()
        => new Dictionary<int, string> {{ 1, "United States of America"}, { 55, "Brazil" }, { 91, "India"} };

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName) 
        => AddCountryToExistingDictionary(GetEmptyDictionary(), countryCode, countryName);

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode) 
        => CheckCodeExists(existingDictionary, countryCode) ? existingDictionary[countryCode] : "";

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
        => existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (CheckCodeExists(existingDictionary, countryCode)) existingDictionary[countryCode] = countryName;
        return existingDictionary;
    }
        
    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        // Not checking if the code exists in the collection here as the instructions 
        // do not state how to handle this scenario, so better to raise an exception 
        // than to silently hide the issue.
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
        => existingDictionary.OrderByDescending(x => x.Value.Length).Select(x => x.Value).FirstOrDefault("");
}
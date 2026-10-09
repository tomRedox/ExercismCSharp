// There are questions about this class's desired behavior:  For methods like 
// ReverseList a string list is taken as a param, that list is then manipulated
// and then returned as the return value.  Returning that list is potentially 
// ambiguous, because there is no need to return it as the param is passed by ref, 
// so you are changing the list, so that method could just return void.  Returning the 
// list can be useful for method chaining, but it could also be mistaken for implying
// that the method is a pure functioning returning a new list.  It would probably be 
// good to make it clearer what the behaviour is in the method naming.
public static class Languages
{
    public static List<string> NewList() => new();

    public static List<string> GetExistingLanguages() => new(){"C#", "Clojure", "Elm"};

    public static List<string> AddLanguage(List<string> languages, string language) 
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages) => languages.Count;

    public static bool HasLanguage(List<string> languages, string language) => languages.Contains(language);

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages) 
        => languages.Count > 0 && (languages[0] == "C#" 
        || (languages[1] == "C#" && (languages.Count == 2 || languages.Count == 3)));

    public static List<string> RemoveLanguage(List<string> languages, string language) 
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages) 
    {
        if (languages.Count <= 1) return true;
        
        languages.Sort();
        for(int i=1; i < languages.Count; i++)
        {
            if (languages[i] == languages[i-1]) return false;
        }
        return true;
    }
}

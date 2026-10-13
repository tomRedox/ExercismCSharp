using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var chars = identifier.ToCharArray();
        var outputBuilder = new StringBuilder();
            
        for(int i = 0; i < chars.Length; i++)
        {
            if (Char.IsWhiteSpace(chars[i])) outputBuilder.Append('_');
            else if (Char.IsControl(chars[i])) outputBuilder.Append("CTRL");
            else if (!Char.IsLetter(chars[i])) outputBuilder.Append("");
            else if ((int)chars[i] >= (int)'α' && (int)chars[i] <= (int)'ω') outputBuilder.Append("");
            else if (i>0 && chars[i-1]=='-' && Char.IsLower(chars[i])) outputBuilder.Append(Char.ToUpper(chars[i]));
            else outputBuilder.Append(chars[i]);
        }

        return outputBuilder.ToString();
    }
}

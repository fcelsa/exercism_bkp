using System.Text;

public static class Identifier
{
    public static string Clean(string identifier) 
    {
        StringBuilder sb = new StringBuilder(identifier.Length);
        bool nextToMaiusc = false;

        foreach (char c in identifier) 
        {
            // kebab-case a camelCase deve essere la prima condizione per settare a true l'upper del prox carattere.
            if (c == '-') {
                nextToMaiusc = true;
                continue;
            }
            
            if (Char.IsWhiteSpace(c)) {
                sb.Append('_');
                continue;
            }
            
            if (c == '\0') {
                sb.Append("CTRL");
                continue;
            }

            if (c >= 'α' && c <= 'ω' && !nextToMaiusc) {
                continue;
            }

            if (!Char.IsLetter(c)) {
                continue;
            }

            if (nextToMaiusc)
            {
                sb.Append(Char.ToUpperInvariant(c));
                nextToMaiusc = false;
            }
            else
            {
                sb.Append(c);
            }
            
        }

        return sb.ToString();
        
    }
}

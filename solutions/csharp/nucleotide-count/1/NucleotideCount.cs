public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var Nucleotides = new Dictionary<char, int>{{'A', 0}, {'C', 0}, {'G', 0}, {'T', 0}};

        foreach (var c in sequence)
            {
            if (Nucleotides.ContainsKey(c))
                Nucleotides[c] += 1;
            else
                throw new ArgumentException("Invalid sequence.");
            }

        return Nucleotides;
        
    }
}

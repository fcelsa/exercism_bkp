public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>();
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
        var numbers = new Dictionary<int, string>
        {
            {1, "United States of America"},
            {55, "Brazil"},
            {91, "India"}
        };
        return numbers;
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        var numbers = new Dictionary<int, string>();
        numbers.Add(countryCode, countryName);
        return numbers;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        var numbers = new Dictionary<int, string>();
        numbers = existingDictionary;
        numbers.Add(countryCode, countryName);
        return numbers;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        var numbers = new Dictionary<int, string>();
        string countryValue = "";
        numbers = existingDictionary;
        if (numbers.TryGetValue(countryCode, out countryValue)) 
        {
            return countryValue;
        }
        else
        {
            return "";
        }
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        var numbers = new Dictionary<int, string>();
        numbers = existingDictionary;
        if (numbers.ContainsKey(countryCode)) {
            numbers[countryCode] = countryName;    
        }
        return numbers;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        var numbers = new Dictionary<int, string>();
        numbers = existingDictionary;
        numbers.Remove(countryCode);
        return numbers;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longest = existingDictionary.Values.MaxBy(v => v.Length);
        if (longest == null) {
            return "";            
        }
        else {
            return longest;    
        }
        
    }

}
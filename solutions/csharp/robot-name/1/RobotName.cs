public class Robot
{
    string name = null;
    private static List<string> robotNames=[];
   
    public string Name 
    {
        get
        {
            name ??= generateName();
            return name;
        }
    }

    private string generateName() 
    {
        var newName = "";
        do {
            int number = Random.Shared.Next(1000);
            char alpha1 = (char)Random.Shared.Next(65, 91);
            char alpha2 = (char)Random.Shared.Next(65, 91);
            newName = $"{alpha1}{alpha2}{number:D3}";
        }
        while(robotNames.Contains(newName));

        robotNames.Add(newName);
        return newName;
    }

    public void Reset()
    {
        robotNames.Remove(name);
        name = null;
    }
}

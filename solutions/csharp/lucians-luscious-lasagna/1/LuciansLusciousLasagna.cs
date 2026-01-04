class Lasagna
{
    private const int ExpectedOvenTime = 40;
    private const int PrepTimePerLayer = 2;
    
    public int ExpectedMinutesInOven() => ExpectedOvenTime;
    
    public int RemainingMinutesInOven(int actualMinInOven) 
    {
        return  ExpectedMinutesInOven() - actualMinInOven;
    }

    public int PreparationTimeInMinutes(int numOfLayers) 
    {
        return numOfLayers * PrepTimePerLayer;
    }
    
    public int ElapsedTimeInMinutes(int numOfLayer, int actualMinInOven) 
    {
        int prepTime = PreparationTimeInMinutes(numOfLayer);
        return prepTime + actualMinInOven;
    }
}

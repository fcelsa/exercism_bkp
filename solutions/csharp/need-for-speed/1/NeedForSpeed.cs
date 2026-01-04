class RemoteControlCar
{
    public int Speed { get; set;}
    public int BatteryDrain { get; set;}
    public int Distance { get; set;}
    public int BatteryLevel { get; set;}
    
    public RemoteControlCar(int speed, int drain)
    {
        Speed = speed;
        BatteryDrain = drain;
        Distance = 0;
        BatteryLevel = 100;
    }
    
    public bool BatteryDrained()
    {
        return BatteryLevel < BatteryDrain;
    }

    public int DistanceDriven()
    {
        return Distance;
    }

    public void Drive()
    {
        if (!BatteryDrained() && BatteryLevel >= BatteryDrain)
        {
            Distance = Distance + Speed;
        }
        BatteryLevel = BatteryLevel - BatteryDrain;
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    public int Distance { get; set; } = 800;
    
    public RaceTrack(int distance)
    {
        Distance = distance;
    }
    
    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();
        }
        return car.Distance >= this.Distance;
    }
}

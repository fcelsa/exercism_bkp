class RemoteControlCar
{
    public int DistDriven { get; set; } = 0;
    public byte BatteryLevel { get; set; } = 100;
    public static RemoteControlCar Buy() => new();
    public string DistanceDisplay() => $"Driven {DistDriven} meters";
    
    public string BatteryDisplay()
    {
        if (BatteryLevel >= 1) {
            return $"Battery at {BatteryLevel}%";
        }
        else {
            return "Battery empty";    
        }
    }

    public void Drive()
    {
        if (BatteryLevel >= 1)
        {
            DistDriven += 20;
            BatteryLevel --;
        }
        else
        {
            return;
        }
    }
}

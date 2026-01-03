public class BirdCount
{
    private readonly int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }

    public int Today()
    {
        if (birdsPerDay == null || birdsPerDay.Length == 0)
            return 0;
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        if (birdsPerDay == null || birdsPerDay.Length == 0)
            return;
        birdsPerDay[birdsPerDay.Length - 1] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        return birdsPerDay != null && birdsPerDay.Any(b => b == 0);
    }

    public int CountForFirstDays(int numberOfDays)
    {
        if (birdsPerDay == null || numberOfDays <= 0)
            return 0;
        int n = System.Math.Min(numberOfDays, birdsPerDay.Length);
        int sum = 0;
        for (int i = 0; i < n; i++)
            sum += birdsPerDay[i];
        return sum;
    }

    public int BusyDays()
    {
        return birdsPerDay != null ? birdsPerDay.Count(b => b >= 5) : 0;
    }

}

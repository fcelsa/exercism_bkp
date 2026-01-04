public static class SwiftScheduling
{
    public static DateTime DeliveryDate(DateTime meetingStart, string description) 
    {
        if (description.Contains("NOW")) { return meetingStart.AddHours(2); }
        else if (description.Contains("ASAP")) { return asapMeeting(meetingStart); }
        else if (description.Contains("EOW"))  { return eowMeeting(meetingStart); }
        else if (description.Contains("M"))    { return monthMeeting(meetingStart, int.Parse(description[..^1])); }
        else if (description.Contains("Q"))    { return quarterMeeting(meetingStart, int.Parse(description[1..])); }
        else { return meetingStart; }        
    }

    static DateTime asapMeeting(DateTime start)
    {
        DateTime target;
        if (start.Hour < 13) {
            target = new DateTime(start.Year, start.Month, start.Day, 17, 0, 0);
        }
        else {
            var tmpTarget = start.AddDays(1);
            target = new DateTime(tmpTarget.Year, tmpTarget.Month, tmpTarget.Day, 13, 0, 0);
        }
        return target;
    }

    static DateTime eowMeeting(DateTime start)
    {
        DateTime target;
        int dow = (int)start.DayOfWeek;
        if (dow >= 4 || dow == 0) {
            var tmpTarget = start.AddDays((7 - dow) % 7);
            target = new DateTime(tmpTarget.Year, tmpTarget.Month, tmpTarget.Day, 20, 0, 0);
        }
        else {
            int daysToFri = (int)DayOfWeek.Friday - dow;
            var tmpTarget = start.AddDays(daysToFri);
            target = new DateTime(tmpTarget.Year, tmpTarget.Month, tmpTarget.Day, 17, 0, 0);
        }
        return target;
    }

    static DateTime monthMeeting(DateTime start, int intDescription)
    {
        DateTime target;
        if (start.Month < intDescription) {
            var tmpTargetYMD = GetWDayInMonth(start.Year, intDescription, true);
            target = tmpTargetYMD.AddHours(8);
        }
        else {
            var tmpTargetYMD = GetWDayInMonth(start.Year + 1, intDescription, true);
            target = tmpTargetYMD.AddHours(8);
        }
        return target;
    }

    static DateTime quarterMeeting(DateTime start, int intDescription)
    {
        DateTime target;
        int currentQuarter = start.quarterNum();
        if (currentQuarter <= intDescription) {
            var tmpTargetYMD = GetWDayInMonth(start.Year, intDescription * 3, false);
            target = tmpTargetYMD.AddHours(8);
        }
        else {
            var tmpTargetYMD = GetWDayInMonth(start.Year + 1, intDescription * 3, false);
            target = tmpTargetYMD.AddHours(8);
        }
        return target;
    }

    static int quarterNum(this DateTime date) {
        return ((date.Month - 1) / 3) + 1;
    }

    static DateTime GetWDayInMonth ( int year, int month, bool first) 
    {
        DateTime date = first
        ? new DateTime(year, month, 1)
        : new DateTime(year, month, DateTime.DaysInMonth(year, month));

    while (date.DayOfWeek == DayOfWeek.Saturday ||
           date.DayOfWeek == DayOfWeek.Sunday)
    {
        date = first ? date.AddDays(1) : date.AddDays(-1);
    }
    return date;
    }
}
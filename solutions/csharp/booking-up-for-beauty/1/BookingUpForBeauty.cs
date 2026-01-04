using System;
using System.Globalization;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        //DateTime parsedAppointment;
        if (DateTime.TryParse(appointmentDateDescription, out DateTime parsedAppointment)) {
            return parsedAppointment;    
        }
        else {
            throw new NotImplementedException("error in parsing input date");
        }
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        DateTime currentDate = DateTime.Now;
        if (DateTime.Compare(appointmentDate, currentDate) < 0 ) {
            return true;
        }
        else {
            return false;
        }        
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        if ( appointmentDate.Hour >= 12 && appointmentDate.Hour < 18 ) {
            return true;
        }
        else {
            return false;
        }
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate:M/d/yyyy h:mm:ss tt}.";
    }

    public static DateTime AnniversaryDate()
    {
        DateTime currentDate = DateTime.Now;
        return new DateTime(currentDate.Year, 9, 15, 0, 0 ,0);
    }
}

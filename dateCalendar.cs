using System;
class Calen{
static void Main(string[] args)
{
    Calendar newCalendar = new Calendar();//instanciating Object (implictly default constructor)
    //holidays                          Year/Month/Day HH:MM:SS   
    newCalendar.setRecurringHoliday(new DateTime(2004, 05, 17));
    newCalendar.setHoliday(new DateTime(2004, 05, 27));
    newCalendar.setHoliday(new DateTime(2004, 05, 31));
    //increment
    double increment = -5; 
    //start date        Year/Month/Day HH:MM:SS   
    DateTime start = new DateTime(2004, 05, 24, 18, 3, 0);
    //start and end time                     Year/Month/Day HH:MM:SS
    newCalendar.setWorkdayStartAndStop(new DateTime(2004, 1, 1, 8, 3, 0), 
                                       new DateTime(2004, 1, 1, 16, 0, 0));
    //printing formating output                                   
    Console.WriteLine(start+" with the addition of "+
    increment+" working days is "+
    newCalendar.getWorkdayIncrement(start, increment).ToString("dd/MM/yyyy HH:mm"));
}

}
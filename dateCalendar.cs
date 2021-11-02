using System;
class Calen{
static void Main(string[] args)
{
    Calendar newCalendar = new Calendar();//instanciating Object (implictly default constructor)
    //holidays                          Year/Month/Day HH:MM:SS   
    newCalendar.setRecurringHoliday(new DateTime(2004, 05, 17, 0, 0, 0));
    newCalendar.setHoliday(new DateTime(2004, 05, 27));
    //increment
    double increment = -5; 
    //start date                  Year/Month/Day HH:MM:SS   
    DateTime start = new DateTime(2004, 05, 24, 19, 03, 0);
    //start and end time                        Year/Month/Day HH:MM:SS
    newCalendar.setWorkDayStartAndStop(new DateTime(2004, 05, 1, 8, 0, 0), 
                                       new DateTime(2004, 05, 1, 16, 0, 0));
    //calling mehtod and returning values into result DateTime
    DateTime result = newCalendar.getWorkDayIncrement(start, increment);
    //calling printing method
    //newCalendar.printWorkDate(start, increment, result);
    newCalendar.getDate(start, (int)increment);
}

}
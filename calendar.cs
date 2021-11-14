using System;
//using classCalendar;
class globalClass{

    static void Main(string[] args){
        DateTime start = new DateTime(2004, 05, 24, 18, 05, 0);
        double incrementInDays = -5.5;
        //instancing obj
        classCalendar calendarObj = new classCalendar();
        //setting start/end time and Date disregard
        calendarObj.setWorkdayStartAndStop(new DateTime(2004, 01, 01, 08, 0, 0),
                                           new DateTime(2004, 01, 01, 16, 0, 0));
        //setting holidays
        calendarObj.setRecurrentHoliday(new DateTime(2004, 05, 17));
        calendarObj.setHoliday(new DateTime(2004, 05, 27));
        //formatted output
        Console.WriteLine(start.ToString("dd/MM/yyyy HH:mm")+" with the adition of "+incrementInDays+
        " days is "+calendarObj.getWorkdayIncrement(start, incrementInDays).ToString("dd/MM/yyyy HH:mm"));
    }
}
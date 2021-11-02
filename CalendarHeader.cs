using System; //for IO standard handling
using System.Collections.Generic; //for List
partial class Calendar
{
    //private members
    private DateTime holiday;
    private DateTime recurringHoliday;
    private DateTime sTime;
    private DateTime eTime;
    //default constructor
    public Calendar()
    {   //init... all members 
        holiday = new DateTime();
        recurringHoliday = new DateTime();
        sTime = new DateTime();
        eTime = new DateTime();
    }
    //public setters and getters
    public void setHoliday(DateTime _holiday)
    {
        holiday = _holiday; //setting holiday
    }
    public void setRecurringHoliday(DateTime recurrentDate)
    {
        recurringHoliday = recurrentDate; //setting recurring date
    }

    public void getDate(DateTime initDate, int increment){
        DateTime startDate = initDate;
        int x = 0;
        for(int counter = 0; counter <= increment; counter++){
                if(startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday){
                    //startDate = startDate.AddDays(1);
                    Console.WriteLine(startDate.ToString("dd/MM/yyyy"));
                    x++;
                }
                else{startDate = startDate.AddDays(1);}
                startDate = startDate.AddDays(1);
        }
        int op = x / 7 * 2;
        Console.WriteLine("Final Date: "+startDate.AddDays(op).ToString("dd/MM/yyyy"));
        Console.WriteLine("x: "+x);
    }
}
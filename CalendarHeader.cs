using System; //for IO standard handling
using System.Collections.Generic; //for List
partial class Calendar
{
    //private members
    private int sHour;
    private int eHour;
    private List<DateTime> listHolidays;
    //default constructor
    public Calendar()
    {   //init... all members 
        listHolidays = new List<DateTime>();
        sHour = 0;
        eHour = 0;
    }
    //public setters and getters
    public void setHoliday(DateTime _holiday)
    {
        listHolidays.Add(_holiday);//Adding holiday to List
    }
    public void setRecurringHoliday(DateTime recurrentDate)
    {
        listHolidays.Add(recurrentDate); //adding recurring date to List
    }

    public void setWorkdayStartAndStop(DateTime startTime, DateTime endTime){
        sHour = startTime.Hour;
        eHour = endTime.Hour; //disregarding Date only getting hours 
    }
    public DateTime getWorkdayIncrement(DateTime initDate, double increment){
        DateTime startDate = initDate;
        double converted = Math.Abs(increment);//getting absolute value to avoid overflow
                                              //when working with negative numbers in loop   
        int x = 0;//for counting later in loop
        
        //if value increment it's a negative value
        if(increment<0)
        {
            increment = 0; //assigning 0 it's value not need it to this point.
           for(int counter = 0; counter <= converted + 1; counter++){
                if(startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday
                                                             && !listHolidays.Contains(startDate)){
                    startDate = startDate.AddDays(-1);//adding 1 day if it's not weekend or holiday
                    x--;//decrementing to handle it later.
                }
                startDate = startDate.AddDays(-1);//re-assigning value changes.
        }
        }
        //if value increment is not negative 
        else
        {      
        for(int counter = 0; counter < increment; counter++){
                if(startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday
                                                             && !listHolidays.Contains(startDate)){
                    x++;//incrementing x to handle days later on Date
                }
                else{startDate = startDate.AddDays(1);}//adding 1 day if it's weekend or holiday
                startDate = startDate.AddDays(1);
        }
        }
        int rest = x / 7 * 2;//some math tricks to hack calendar position days
        int calculateHours = sHour + startDate.Day; //calculate hours
        return startDate.AddDays(rest).AddHours(calculateHours);//returning added days and hours
    }
}

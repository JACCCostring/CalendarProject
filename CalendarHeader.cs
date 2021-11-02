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

    public void setWorkDayStartAndStop(DateTime _sTime, DateTime _eTime){
            sTime = _sTime; //setting start and stop time
            eTime = _eTime;//Day, Month and Year is disregard
            Console.WriteLine("sTime: "+ holiday);
    }
    public void printWorkDate(DateTime start, double increment, DateTime result){
                    Console.WriteLine(//printing and formatting date 
                    start.ToString("dd/MM/yyyy HH:mm:ss")+ 
                    " with the addition of "+increment+" Working days is "+
                    result.ToString("dd/MM/yyyy HH:mm:ss")
                    );
    }

    private void addToDate(DateTime addDate, double addTo){
        DateTime testTime = addDate.AddDays(addTo);
        Console.WriteLine("added date: "+testTime.ToString("dd/MM/yyyy"));
        for(DateTime date = addDate; date <= testTime; date = date.AddDays(1)){
        if(addDate.DayOfWeek != DayOfWeek.Saturday || addDate.DayOfWeek != DayOfWeek.Sunday){
            //addDate = addDate.AddDays(1);
        }
        else{addDate = addDate.AddDays(1);}
        }
        Console.WriteLine("added date: "+addDate.ToString("dd/MM/yyyy"));
    }
    public int getDays(DateTime numofDays, double numDays){
        DateTime newDate = numofDays.AddDays(numDays);//adding days e.x 01/05/2004 + 4
        int count = 0;                               //= 06/05/2004         
        int excluded = 0;                     

        for(DateTime date = numofDays; date <= newDate; date = date.AddDays(1))
        {
            if(date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                count++; //incrementing count debuging purpose
                }
                else{excluded++;} //incrementing for returning later
                numofDays = numofDays.AddDays(1); //adding day by 1 
        }
        Console.WriteLine("Counted Days: "+count); //commented line debugin purpose 
        Console.WriteLine("Excluded Days: "+excluded); //commented line debugin purpose
        //Console.WriteLine("num of Days: "+numofDays.AddDays(excluded).ToString("dd/MM/yyyy"));
        addToDate(numofDays, excluded);
        return excluded-1; //returning values - 1
    }
    private int getNumDays(DateTime numofDays, List<DateTime> listHoly, double numDays){
        DateTime newDate = numofDays.AddDays(numDays);//adding days e.x 01/05/2004 + 4
        int count = 0;                               //= 06/05/2004         
        int excluded = 0;                     

        for(DateTime date = numofDays.AddDays(1); date <= newDate.AddDays(1); date = date.AddDays(1))
        {
            if(date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday
                )
                {
                count++; //incrementing count debuging pourpus
                }
                else{excluded++;} //incrementing for returning later
                numofDays = numofDays.AddDays(1); //adding day by 1 
        }
        Console.WriteLine("Counted Days: "+count); //commented line debugin pourpus 
        Console.WriteLine("Excluded Days: "+excluded); //commented line debugin pourpus
        return excluded-1; //returning values - 1
    }
    public DateTime getWorkDayIncrement(DateTime startDate, double increment)
    {
        List<DateTime> listHolidays = new List<DateTime>(); //list for adding holiday
        //adding holiday and recurring date to list (holiday/reccurringH.. allready exist)
        listHolidays.Add(holiday);//adding holiday 
        listHolidays.Add(recurringHoliday);//and it can be retrieve in the future
        //getting values from private method
        int numDays = getNumDays(startDate, listHolidays, increment);//getting weekends and holiday
        double hoursCalc = startDate.Hour + increment;//calculating hours
        DateTime DateToReturn = startDate.AddDays(increment + numDays);//incrementing days and assigining                //to a new instance 
                                                                      //new Date to DateToReturn               
    return DateToReturn.AddHours(hoursCalc);//adding hours and returning modified Date
    }//end of getWorkdayIncrement method
}//end of namespace
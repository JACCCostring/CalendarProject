using System;
using System.Collections.Generic;
partial class classCalendar{

    List<DateTime> listHolidays;
    private int startDayHour;
    private int endDayHour;
    public classCalendar(){//defualt constructor
        listHolidays = new List<DateTime>();//initializing list
        startDayHour = 0;//init..
        endDayHour = 0;//init...
    }
    public void setWorkdayStartAndStop(DateTime _startTime, DateTime _endTime){
            startDayHour = _startTime.Hour;
            endDayHour = _endTime.Hour;
    }
    public void setHoliday(DateTime _holiday){
           listHolidays.Add(_holiday);
    }
    public void setRecurrentHoliday(DateTime _holiday){
           //regarding only Month and Day not Year
           DateTime recurrentHoli = new DateTime(_holiday.Year, _holiday.Month, _holiday.Day);
           listHolidays.Add(recurrentHoli);
    }
    private bool isHoliday(DateTime holidayDate)
    {
            //re-assigning Date just regarding Date and not time component
            DateTime tempDate = new DateTime(holidayDate.Year, holidayDate.Month, holidayDate.Day);
            //looping the hole list, listHolidays allready exist
            foreach(DateTime dateH in listHolidays){
            if(dateH == tempDate){
            return true;//return true if Date exist in the list
        }
        }
        return false;//otherwise false
    }
public DateTime getWorkdayIncrement(DateTime _startDate, double incrementInDays)
{
    DateTime testDate = _startDate;
    int hoursPastWorkingDay = 0;
    bool isNegative = false;
    //converting from fractions days to decimal days in case of 0.25 or 0.5 values
    if(incrementInDays > 0.0 && incrementInDays < 0.99){incrementInDays *= 24 / 2-3;}
    //if days to increment are negative days then
    if(incrementInDays < 0){isNegative = true;}
    //make incrementInDays no signed
    incrementInDays = Math.Abs(incrementInDays);
    //for loop from 0 to incrementIndays
    for(int i = 0; i < incrementInDays-1; i++){
        //weekends
        if(_startDate.DayOfWeek == DayOfWeek.Saturday || 
           _startDate.DayOfWeek == DayOfWeek.Sunday){
            //adding days to skip counting weekends
            //if it's no negative then add
            if(!isNegative){
            _startDate = _startDate.AddDays(2);
            testDate = testDate.AddDays(2);
            }
            //if it's negative then substract instead
            if(isNegative){
            _startDate = _startDate.AddDays(-2);
            testDate = testDate.AddDays(-2);    
            }
        }
        //weekdays
        //if time is less then 08:00 then add day by 1
        if(testDate.Hour < startDayHour){
            while(testDate.Hour < startDayHour){//add day by 1 while time < 08:00
            testDate = testDate.AddHours(1);//make time valid for wokring hours
            }
        }
        //if time is more then 16:00 then
        if(testDate.Hour >= endDayHour){
            while(testDate.Hour > endDayHour){//substract day by 1 while time > 16:00
            testDate = testDate.AddHours(-1);//make time valid to fit in working hours
            }
        }
        //checking if hours > 16:00 
        if(testDate.Hour >= endDayHour){
            hoursPastWorkingDay++; //re-assigning same date but different start time
    
            DateTime restartTime = //new DateTime regarding only the time
            new DateTime(testDate.Year, testDate.Month, testDate.Day, startDayHour+hoursPastWorkingDay, 0, 0);
            
            testDate = restartTime;//restarting time
            testDate = testDate.AddHours(hoursPastWorkingDay-1).AddMinutes(_startDate.Minute);//adding rest of hours
        }
        //add or substract hours and weekdays by 1 and not weekend days
        if(isNegative){ //in negative case
        testDate = testDate.AddHours(- startDayHour).AddMinutes(- _startDate.Minute); //substract hour ad minute by 1
        testDate = testDate.AddDays(-1);//substract day by 1
        _startDate = _startDate.AddDays(-1);//substract day by 1 for offset
        }
        //normal case 
        if(!isNegative){
        testDate = testDate.AddHours(1).AddMinutes(_startDate.Minute); //adding hour by 1
        testDate = testDate.AddDays(1);//adding day by 1
        _startDate = _startDate.AddDays(1);//adding day by 1 for offset
        }
        //checking if its holiday
        if(isHoliday(_startDate)){//skipping day by 1 if it's a holiday
                if(!isNegative){
                testDate = testDate.AddDays(1);
                testDate = testDate.AddHours(1).AddMinutes(_startDate.Minute);
                }

                if(isNegative){//in negative case
                testDate = testDate.AddDays(-1);//substract day
                testDate = testDate.AddHours(1).AddMinutes(_startDate.Minute);//no need to substrac
                }
            }

    }
    return testDate;//returning Date
}//end of method

}//end of namespace
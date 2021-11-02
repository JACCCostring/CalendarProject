C# Application for calculating Working days. made in (Tuesday 02, 2021)

using System is need it for DateTime, Class Calendar is made partial allowing to call/implemented out of the header file, from the main function are objects instancieted and calls. 

Calendar newCalendar = new Calendar() is instancieted for future use, all of it public methods can be access from an instance axcept 'getNumDays()' what is a private method that can be access form inside the class not from object instanciation.

Calendar class it has a printing method to print format data and 'setWorkdayStartAndStop()' it will receive two parameters DateTime type where Day, Month  and Year is disregard, it just need the start and end time.

'getWorkdayIncrement()' method receive 2 parameters DateTime and double types and in the method another private method is invoked to count number of days from a given Date, it's where all the important bussiness logic is. Returning values are not accurate it has many bugs yet, and just give aproximate values.

Examples:

24/05/2004 - 5.5 working days = 14/05/2004 expected (13/05/2004) solution "Substract 1 more days"
24/05/2004 - 6.74 working days = 13/05/2004 expected (11/05/2004) solution "Substract 1 more days"
24/05/2004 + 44.72 working days = 26/07/2004 expected (27/07/2004) solution "Add 1 more days"
24/05/2004 + 12 working days = 10/06/2004 expected (10/06/2004) passed
24/05/2004 + 08 working days = 04/06/2004 expected (05/06/2004) passed

'getWorkdayIncrement()' calculate hours adding the hour from the given Date as parameter 'startDate' and hour from a modified Date allready instancieted in 'getWorkdayIncrement()' same mehtod return the wanted Date.

issues: Bussiness logic is doing what it's requaired adding days to an existing Date, but some issues with signed and unsigned variable casting i tried to converted to non signed one but anyway there is the fraccion problem with the increment days passed to 'getWorkdayIncrement' as a parameter.

Solution: Set the Date only if day element in calendar is not Weekend or holiday incrementing forward or backward in calendar DateTime.

Compilation from VScode used: css *.csc

In case of issues with the excitable re-compilation is needed.

I found a better solution in C++ but still some pitfulls.

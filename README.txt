C# Application for calculating Working days. made in (Tuesday 02, 2021) and modified on (Sunday 14, 2021)

using System is need it for DateTime and Class Calendar is made partial allowing calls/implementations out of the header file,
from Main method are objects instancies and calls to corresponds methods.

'getWorkdayIncrement()' method receive 2 arguments DateTime and a double type. Inside this method DateTime
variable received as parameter is modified before returned, using a 'For' loop to identify where in are DateTime 
is Weekends, holidays and etc.. Any day that is not a weekday it won't count for adding it to the returned DateTime.

In the method a private function has been invoked to solve holidays on each iteration.
A working day goes from 08:00 AM to 16:00 PM therefore a day time going from 15:00 PM to 18:00 PM on 
22/08/2011 gives a result of 23/08/2011 10:00 AM, same as with negative input values.


Examples:

24/05/2004 - 5.5 working days = 14/05/2004 expected (14/05/2004) passed
24/05/2004 - 6.74 working days = 13/05/2004 expected (13/05/2004) passed
24/05/2004 + 44.72 working days = 27/07/2004 expected (27/07/2004) passed
24/05/2004 + 12 working days = 10/06/2004 expected (10/06/2004) passed
24/05/2004 + 08 working days = 04/06/2004 expected (04/06/2004) passed

Compilation from Mac OS using VScode IDE: css *.csc

In case of issues with the excitable re-compilation is needed.
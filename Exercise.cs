using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public  class Exercise
    {
        public decimal NormalHourlyRate { get { return 25; } }

        public decimal OvertimeHourlyRate { get { return 10; } }

        public int HoursWorked { get; set; }

        public int overTimeHour { get; set; }   

        public int NoOfDaysWorked { get; set; }

        public decimal MonthlyGrossPay { get; set; }

        public decimal WeeklyGrossPay { get; set; }

        public decimal MonthlyNetpay { get; set; }  

        public decimal Deduction { get; set; }

        public const int MAXIMUMHOURSWORKED = 8;
        
        public string PaymentCalculation()
        {
            var hoursWorked = GetTotalNumberOfHoursWorked(NoOfDaysWorked);
            HoursWorked = hoursWorked.Item1;
            overTimeHour = hoursWorked.Item2;

             MonthlyGrossPay  = (NormalHourlyRate * HoursWorked) + (OvertimeHourlyRate * overTimeHour);

             WeeklyGrossPay = MonthlyGrossPay / 4;

            MonthlyNetpay =  MonthlyGrossPay - TaxCalculation(MonthlyGrossPay);

            Deduction = TaxCalculation(MonthlyGrossPay);
            
            return $"Normal hours worked:{HoursWorked}hrs\nMonthly Gross pay: ${MonthlyGrossPay}\nNormal Hours Worked: {HoursWorked}hrs\nOvertime: {overTimeHour}hrs\nWeekly Gross Pay: ${WeeklyGrossPay}\nMonthly Net Pay: ${MonthlyNetpay}\nDedution:${Deduction}";
        }

        private decimal TaxCalculation(decimal monthlyGrossPay)
        {
            decimal taxRate = 0.00m;

            if (monthlyGrossPay <= 1000)
            {
                taxRate += monthlyGrossPay * 1.5m / 100;
            }
            else if (monthlyGrossPay > 1000 && monthlyGrossPay <= 2500)
            {
                taxRate += monthlyGrossPay * 2.5m / 100;
            }
            else if (monthlyGrossPay > 2500)
            {
                taxRate += monthlyGrossPay * 4.5m / 100;
            }

            return taxRate;
        }


        private Tuple<int, int> GetTotalNumberOfHoursWorked(int noOfDaysWorked)
        {
            int sumOfNormalHoursWorked = 0;
            int sumOfOvertimeWorked = 0;
            int normalHoursWorked = 0;

            for(int i = 1; i <= NoOfDaysWorked; i++)
            {
                Console.Write($"Enter hours worked for day {i}: ");
                int hoursWorked = int.Parse(Console.ReadLine());

                if(hoursWorked > 15)
                {
                    hoursWorked = 15;
                }
                
                if(hoursWorked > MAXIMUMHOURSWORKED)
                {
                    sumOfOvertimeWorked += hoursWorked - MAXIMUMHOURSWORKED;
                }
                normalHoursWorked += hoursWorked;
                sumOfNormalHoursWorked = normalHoursWorked - sumOfOvertimeWorked;
            }

            var result = new Tuple<int, int>(sumOfNormalHoursWorked, sumOfOvertimeWorked);
            return result;
        }

    }
}

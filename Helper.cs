using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public static class Helper
    {
        public static string GenerateCode()
        {
            Random rand = new();

            return $"EMP-{rand.Next(99999)}";
        }


       
    }
}

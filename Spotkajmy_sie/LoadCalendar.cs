using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmLibrary;
using Newtonsoft.Json;

namespace Spotkajmy_sie
{
    public class LoadCalendar : ILoadCalendar
    {
        public Calendar GetCalendar()
        {
            Calendar calendar = null;

            try
            {
                Console.WriteLine("Enter calendar (Json)");
                calendar = JsonConvert.DeserializeObject<Calendar>(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Conversion Error");
            }
            return calendar;
        }
    }
}

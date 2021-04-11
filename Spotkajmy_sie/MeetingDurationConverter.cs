using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotkajmy_sie
{
    public class MeetingDurationConverter : IMeetingDurationConverter
    {
        public int DurationToInt()
        {
            Console.WriteLine("Enter meeting duration for example [00:30]: ");
            string text = Console.ReadLine();
            try
            {
                text = text.Replace("[", string.Empty);
                text = text.Replace("]", string.Empty);
                var tab = text.Split(':');
                int duration = int.Parse(tab[0]) * 60 + int.Parse(tab[1]);
                return duration;
            }
            catch (Exception)
            {

                Console.WriteLine("Can't conver to minutes");
            }
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Scribestar.Code.Challenge.Spellers;
using Scribestar.Code.Challenge.Spellers.Interfaces;
using Scribestar.Code.Challenge.ExtensionMethods;

namespace Scribestar.Code.Challenge
{
    public static class SegmentSpellerFactory
    {
        public static INumberSpeller GetNumberSpellers(int number)
        {
            if(number== 0) return new ZeroSpeller();
            var isNegativeNumber = number < 0;
            var segments = GetNumberSegments(Math.Abs(number));

            if (isNegativeNumber)
            {
                return new NegativeSpeller(segments);
            }
            if (segments.Count() == 1)
            {
                return segments.FirstOrDefault();
            }
            return segments;


        }

        private static MultiSegmentSpeller GetNumberSegments(int number)
        {
            var segments = new MultiSegmentSpeller();
            var index = 0;
            while (number > 0)
            {
                var segment = number%1000;
                if (segment > 0)
                {
                    segments.Add(new Segment(segment, index));
                }
                number = number / 1000;
                index++;
            }
            segments.Sort((x, y) => string.CompareOrdinal(x?.BigNumberSpeller?.Value.ToString(), y?.BigNumberSpeller?.Value.ToString()) * -1);

            return segments;
        }

    }


}

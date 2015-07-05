using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scribestar.Code.Challenge.Enumerations;
using Scribestar.Code.Challenge.Spellers.Interfaces;

namespace Scribestar.Code.Challenge.Spellers
{
    public class TensAndUnitsSpeller : INumberSpeller
    {
        public IList<INumberSpeller> DigitSpellers { get; set; }

        public int Value
        {
            get
            {
                return DigitSpellers.Sum(digit => digit.Value);
            }
        }

        public TensAndUnitsSpeller(IList<INumberSpeller> digitSpellers)
        {
            DigitSpellers = digitSpellers;
        }

        public string Spell()
        {
            return
                DigitSpellers.Where(speller => speller.Value > 0)
                    .Aggregate("", (current, speller) => current + (speller.Spell() + " "))
                    .Trim();
        }
    }
}

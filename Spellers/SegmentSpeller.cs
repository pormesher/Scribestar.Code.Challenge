using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scribestar.Code.Challenge.Spellers.Interfaces;

namespace Scribestar.Code.Challenge.Spellers
{
    public class Segment:INumberSpeller
    {
        public Segment(int segment, int bigNumberIndex=0)
        {
            var tensAndUnits = segment%100;
            var hundreds = segment/100;

            var units = tensAndUnits % 10;
            var tens = tensAndUnits/10;

            if (tens == 1 && units > 0)
            {
                TensAndUnitsSpeller = new ElevenToNineteenSpeller(tensAndUnits);
            }
            else
            {
                var digitSpellers = new List<INumberSpeller>();

                if (tens > 0)
                {
                    digitSpellers.Add(new TensSpeller(tens));
                }
                if (units > 0)
                {
                    digitSpellers.Add(new UnitsSpeller(units));
                }
                if (digitSpellers.Count == 1)
                {
                    TensAndUnitsSpeller = digitSpellers.First();
                }
                else if (digitSpellers.Count > 1)
                {
                    TensAndUnitsSpeller = new TensAndUnitsSpeller(digitSpellers);
                }

            }

            if (hundreds > 0)
            {
                HundredsSpeller = new UnitsSpeller(hundreds);
            }

            if (bigNumberIndex > 0)
            {
                BigNumberSpeller = new BigNumberSpeller(bigNumberIndex);
            }

        }

        public INumberSpeller HundredsSpeller { get; set; }
        public INumberSpeller TensAndUnitsSpeller { get; set; }
        public INumberSpeller BigNumberSpeller { get; set; }

        #region INumberSpeller members
        public string Spell()
        {
            var sb = new StringBuilder();
            if (HundredsSpeller != null && HundredsSpeller.Value > 0)
            {
                sb.Append($"{HundredsSpeller.Spell()} hundred");
                if (TensAndUnitsSpeller != null && TensAndUnitsSpeller.Value > 0)
                {
                    sb.Append(" and ");
                }
            }
            if (TensAndUnitsSpeller?.Value > 0)
            {
                sb.Append(TensAndUnitsSpeller.Spell());
            }
            if (BigNumberSpeller != null && BigNumberSpeller.Value > 0)
            {
                sb.Append(" ").Append(BigNumberSpeller.Spell());
            }
            return sb.ToString();
        }

        public int Value => (HundredsSpeller?.Value??0) * 100 + (TensAndUnitsSpeller?.Value??0);

        #endregion
    }
}

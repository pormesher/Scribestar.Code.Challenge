using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scribestar.Code.Challenge.Spellers.Interfaces;

namespace Scribestar.Code.Challenge.Spellers
{
    public class MultiSegmentSpeller:List<Segment>,INumberSpeller
    {

        public string Spell()
        {
            var sb = new StringBuilder();

            foreach (var segment in this.Where(s=>s.BigNumberSpeller != null))
            {
                sb.Append(segment.Spell());
                sb.Append(", ");
            }

            var lastSegment = this.FirstOrDefault(s => s.BigNumberSpeller==null);
            if (lastSegment?.HundredsSpeller == null || lastSegment.HundredsSpeller.Value == 0)
            {
                sb.Remove(sb.Length - 2, 1);
                if (sb.Length > 0 && lastSegment?.Value > 0)
                {
                    sb.Append("and ");
                }
            }

            if (lastSegment?.Value > 0)
            {
                sb.Append(lastSegment.Spell());
            }
            return sb.ToString();

     
        }

        public int Value { get; }

 }
}

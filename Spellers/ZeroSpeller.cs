using Scribestar.Code.Challenge.Enumerations;
using Scribestar.Code.Challenge.Spellers.Interfaces;

namespace Scribestar.Code.Challenge.Spellers
{

    public class ZeroSpeller :  INumberSpeller
    {
        public string Spell()
        {
            return "zero";
        }

        public int Value => 0;
    }
}

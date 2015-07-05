using Scribestar.Code.Challenge.Enumerations;
using Scribestar.Code.Challenge.Spellers.Interfaces;

namespace Scribestar.Code.Challenge.Spellers
{

    public class NegativeSpeller :  INumberSpeller
    {
        private readonly INumberSpeller _spellers;

        public NegativeSpeller(INumberSpeller spellers)
        {
            _spellers = spellers;
        }

        public string Spell()
        {
            return $"negative {_spellers.Spell()}";
        }

        public int Value => -1*+_spellers.Value;
    }
}

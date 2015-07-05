using Scribestar.Code.Challenge.Abstract;
using Scribestar.Code.Challenge.Enumerations;
using Scribestar.Code.Challenge.Spellers.Interfaces;

namespace Scribestar.Code.Challenge.Spellers
{
    public class BigNumberSpeller : SpellNumberBase<BigNumberEnum>, INumberSpeller
    {

        public BigNumberSpeller(int value):base(value)
        {

        }

    }}

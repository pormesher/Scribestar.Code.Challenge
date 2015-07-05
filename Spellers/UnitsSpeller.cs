using System;
using Scribestar.Code.Challenge.Abstract;
using Scribestar.Code.Challenge.Enumerations;
using Scribestar.Code.Challenge.Spellers.Interfaces;

namespace Scribestar.Code.Challenge.Spellers
{

    public class UnitsSpeller : SpellNumberBase<UnitsEnum>, INumberSpeller
    {
        public UnitsSpeller(int value) : base(value)
        {
            if (value < 1 || value > 9)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

    }
}

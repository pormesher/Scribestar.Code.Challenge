using System;
using Scribestar.Code.Challenge.Abstract;
using Scribestar.Code.Challenge.Enumerations;
using Scribestar.Code.Challenge.Spellers.Interfaces;

namespace Scribestar.Code.Challenge.Spellers
{

    public class ElevenToNineteenSpeller : SpellNumberBase<ElevenToNineteenEnum>, INumberSpeller
    {
        public ElevenToNineteenSpeller(int value) : base(value)
        {
            if (value < 11 || value > 19)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}

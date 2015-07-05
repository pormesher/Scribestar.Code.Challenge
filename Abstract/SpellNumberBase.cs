using System;

namespace Scribestar.Code.Challenge.Abstract
{
    public abstract class SpellNumberBase<T> where T : struct
    {
        private readonly int _value;
        protected SpellNumberBase(int value)
        {
            _value = value;
        }
        
        public virtual int Value => _value;


        public virtual string Spell()
        {
            return (_value > 0)
                ? Enum.GetName(typeof (T), _value)?.ToLower()
                : string.Empty;
        }
    }
}

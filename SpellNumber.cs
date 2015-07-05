namespace Scribestar.Code.Challenge
{
    public class NumberSpeller
    {
        public static string Spell(int number)
        {
            var speller = SegmentSpellerFactory.GetNumberSpellers(number);
            return speller.Spell();
        }


    }
}


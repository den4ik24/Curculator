namespace Curculator
{
    class CalcModel
    {


        public string Res { get; set; }
        public string Deistvie { get; set; }
        public string NumberA { get; set; }
        public string NumberB { get; set; }
        
        public CalcModel(string res, string deistvie, string numberA, string numberB)
        {
            Res = res;
            Deistvie = deistvie;
            NumberA = numberA;
            NumberB = numberB;
        }

        public CalcModel()
        {
         
        }

        public override string ToString()
        {
            return Res + " = " + NumberA + " " + Deistvie + " " + NumberB;

        }
    }
}
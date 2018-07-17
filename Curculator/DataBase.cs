namespace Curculator
{
    class CalcModel
    {


        public string Res { get; set; }
        
        
        public CalcModel(string res)
        {
            Res = res;
            
        }

        public CalcModel()
        {
         
        }

        public override string ToString()
        {
            return Res;

        }
    }
}
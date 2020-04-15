using System;

namespace interfaces
{ 
    interface ICodeChecker
    {
         bool CheckCodeSyntax(string str, string lang);
        
    }
    interface IConvertible
    {
         string ConvertToCSharp(string str);
         string ConvertToVB(string str);
        
    }
    class Program 
    {
       
        static void Main(string[] args)
        {

            object[] list = new object[6];
            ProgramConverter str1 = new ProgramConverter(); 
            ProgramConverter str2 = new ProgramHelper();             
            ProgramConverter str3 = new ProgramConverter();
            ProgramConverter str4 = new ProgramHelper();
            ProgramConverter str5 = new ProgramConverter();    
            ProgramConverter str6 = new ProgramHelper();
            list[0] = str1;
            list[1] = str2;
            list[2] = str3;
            list[3] = str4;
            list[4] = str5;
            list[5] = str6;
            string a = "#include library";
            string b = "using library";
            bool check;
            string ans, ans1, ans2;
            for (int i=0; i<list.Length; i++) {
                ProgramHelper PrHlp = list[i] as ProgramHelper;
                    if (list[i] is ICodeChecker)     
                {
                    Console.WriteLine("{0} Реализует IСodeChecker", i);
                    check= PrHlp.CheckCodeSyntax(a, "using");
                    if (check == true) {
                        Console.WriteLine("{0}-C#", i);
                        ans= PrHlp.ConvertToVB(a);
                        Console.WriteLine(ans);
                        Console.WriteLine("-------------------------------------------------------------------------");
                    }
                    else  { 
                        Console.WriteLine("{0}-VB", i);
                        ans = PrHlp.ConvertToCSharp(a);
                        Console.WriteLine(ans);
                        Console.WriteLine("-------------------------------------------------------------------------");
                    }

                } 
                    else
                    {
                    ProgramConverter PrHlp1 = list[i] as ProgramConverter;
                    Console.WriteLine("{0} не реализует IСodeChecker", i);
                   ans2 = PrHlp1.ConvertToCSharp(b);
                    ans1 = PrHlp1.ConvertToVB(b);
                   Console.WriteLine("To C#| {0} |; \n To VB| {1} |;", ans2,ans1);
                    Console.WriteLine("-------------------------------------------------------------------------");
                     }
                }
            Console.ReadLine();
        }
    }
  class ProgramConverter :IConvertible
    {
            public  string ConvertToCSharp(string str)
        {
            return  str + ": converted to C#";
        }
       public string ConvertToVB(string str)
        {
            return  str + ": converted to VB";
        }
    }
 class ProgramHelper : ProgramConverter, ICodeChecker
    {
       public bool CheckCodeSyntax(string str, string leng)
        {
            if (str.Contains(leng)) {return true; }
            else { return false; }
            
        }
    }
}
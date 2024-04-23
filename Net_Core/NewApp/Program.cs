public class Program
    {
        public static void Main(string[] args)
        {
        // lệnh break  
    for(int i = 0; i < 10; i++)
      {
        if(i ==5) break;
        System.Console.WriteLine("Vòng lặp thứ {0}",i);
      }
// lệnh continue       
   for(int i = 0; i < 10; i++)
      {
        if(i ==5) break;
        if(i ==5) continue;
        System.Console.WriteLine("Vòng lặp thứ {0}",i);
    }
        }
    }

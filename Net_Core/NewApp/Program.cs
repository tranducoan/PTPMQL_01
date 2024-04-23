 public class Program
    {
        public static void Main(string[] args)
        {
            int i= 1;
          do
          {
            System.Console.WriteLine("vòng lặp thứ {0} ",i);
            //tăng i lên 1 đơn vị để đảm bảo rằng có lúc i>=10
            //i>=10 thì vòng lặp kết thúc 
            i++;
          } while(i<10);
        }
    }

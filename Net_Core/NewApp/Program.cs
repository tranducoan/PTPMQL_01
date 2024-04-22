using System;

namespace NewApp
{
    public class Program
    {
        // đề bài : Toán tử so sánh:
//Thực hành: Nhập vào 2 số từ bàn phím, tiến hành so sánh 2 số vào in kết quả màn hình. 
        private static void Main(string[] args)
        {
            int a = 2;
            int b = 3;

            Console.WriteLine("{0} / {1} = {2}", a, b, a / b);
            Console.WriteLine("{0} % {1} = {2}", a, b, a % b);

            if (a < b)
            {
                Console.WriteLine("{0} nhỏ hơn {1}", a, b);
            }
            else
            {
                Console.WriteLine("{0} lớn hơn {1}", a, b);
            }
        }
    }
}

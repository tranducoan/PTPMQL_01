using System.Dynamic;
namespace NewApp;

using System;

internal class Program
{
    // ví dụ về chuyển đổi dữ liệu chương 5 C# trang 29 sử dung lớp Convert
    private static void Main(string[] args)
    {
        //giá trị đầu vào của chuyển đổi 
string str ="123";
//chuyển đổi kiểu dữ liệu string giá trị ="123"
//sang kiểu dữ liệu int giá trị sau khi chuyển đổi = 123
int a = Convert.ToInt32(str);
System.Console.WriteLine("a" + a);
    }
}

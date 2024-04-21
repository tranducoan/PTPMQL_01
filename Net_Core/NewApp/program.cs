namespace NewApp;

using System;

internal class Program
{
    // ví dụ về chuyển đổi dữ liệu chương 5 C# trang 29
    private static void Main()
    {
        //giá trị đầu vào của chuyển đổi 
string str ="123";
//biến lưu kết quả sau khi chuyển đổi 
int ketqua;
//kiểm tra chuyển đổi có thành công không 
bool kiemtra = false;
//chuyển đổi kiểu dư liệu 
kiemtra = int.TryParse(str,out(ketqua));
System.Console.WriteLine("ket qua" +ketqua);
    }
}
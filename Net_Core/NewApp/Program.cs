//nhập 2 số từ bàn phím và thực hiện các yêu cầu sau:
//tính hiệu
internal class Program
{
    private static void Main(string[] args)
    {
       int a;//khai bao bien a kieu int
       int b;//khai báo bien b kieu int
       //thong bao cho người dùng nhập vào a
       System.Console.Write("a = ");
       //doc du lieu nhap vao tu ban phim chuyen sang kieu int va gan cho a
       a = Convert.ToInt32(Console.ReadLine());
       System.Console.Write("b = ");
       b = Convert.ToInt32(Console.ReadLine());
       //in hieu a-b ra ngoai man hinh
       System.Console.WriteLine("{0} - {1} = {2}",a,b,a-b);
//tính tổng của 2 số và in ra màn hình 
         System.Console.WriteLine("{0} + {1} = {2}",a,b,a+b);
//tinh tich 2 so va in ra man hinh
        System.Console.WriteLine("{0} * {1} = {2}",a,b,a*b);
//thuc hien phep chia lay phan nguyen va lay du 2 so => in ra man hinh//
        System.Console.WriteLine("{0} / {1} = {2}",a,b,a/b);
        System.Console.WriteLine("{0} % {1} = {2}", a, b, a%b);
    }
}

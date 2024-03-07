using System.CodeDom.Compiler;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System .ComponentModel.DataAnnotations;
namespace MvcMovie.Models;

public class MvcMovie
{
    public int id { get;set;}

public string? title { get; set; }
[DataType(DataType.Date)]

public DateTime releaseDate { get; set; }

public string? Genre { get; set; }

public decimal price { get; set; }

}



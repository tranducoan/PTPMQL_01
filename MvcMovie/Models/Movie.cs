using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Movie 
{
    public int id { get;set; } 

    public string? title {get; set; }
[DataType(DataType.Date)]

public DateTime releaseDate { get; set;}

public string? genre {get; set; }

public decimal price { get; set ;}



}
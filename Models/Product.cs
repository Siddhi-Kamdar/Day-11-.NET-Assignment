using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Range(1, double.MaxValue)]
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string Category { get; set; }
}
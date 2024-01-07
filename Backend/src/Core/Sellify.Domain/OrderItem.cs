using System.ComponentModel.DataAnnotations.Schema;
using Sellify.Domain.Common;

namespace Sellify.Domain;

public class OrderItem : BaseDomainModel{

    public Product? Product { get; set; }

    public int ProductId { get; set; }

    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public Order? Order { get; set; }

    public int OrderId { get; set; }

    public int ProductItemId { get; set; }

    public string? ProductNombre { get; set; }

    public string? ImagenURL { get; set; }
}
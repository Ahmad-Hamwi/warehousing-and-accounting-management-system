using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Common.Mappings;
using Domain.Entities;
using Domain.Events;

namespace Infrastructure.Persistence.Database.Models;

[Table("Products")]
public class ProductDb : IDbModel, IMapFrom<Product>, IHasDomainEvents
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default;
    
    public string Name { get; set; } = default!;

    public int CategoryId { get; set; } = default;
    [ForeignKey("CategoryId")]
    public CategoryDb? Category { get; set; } = default!;

    public int ManufacturerId { get; set; } = default;
    [ForeignKey("ManufacturerId")]
    public ManufacturerDb? Manufacturer { get; set; } = default!;
    
    public int CountryOriginId { get; set; } = default;
    [ForeignKey("CountryOriginId")]
    public CountryOriginDb? CountryOrigin { get; set; } = default!;

    public int UnitId { get; set; } = default;
    [ForeignKey("UnitId")]
    public UnitDb? Unit { get; set; } = default!;

    public string Barcode { get; set; } = default!;

    public double Price { get; set; } = default;
    
    public int CurrencyId { get; set; } = default;
    [ForeignKey("CurrencyId")]
    public CurrencyDb? Currency { get; set; } = default!;

    public int MinLevel { get; set; } = default;

    [NotMapped] public IList<DomainEvent> Events { get; set; }
}
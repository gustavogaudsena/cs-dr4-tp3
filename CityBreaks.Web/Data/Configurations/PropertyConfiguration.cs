using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(150)
            .HasColumnName("PropertyName");

        builder.HasData(
            new Property { Id = 1, Name = "Apartamento Vista Rio", PricePerNight = 120.50m, CityId = 1 },
            new Property { Id = 2, Name = "Estúdio Torre Eiffel", PricePerNight = 200.00m, CityId = 2 }
        );
    }
}
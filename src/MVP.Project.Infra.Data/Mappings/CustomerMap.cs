using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVP.Project.Domain.Models;

namespace MVP.Project.Infra.Data.Mappings;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.DocumentNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.Phone)
            .HasMaxLength(20);

        builder.Property(c => c.StateInscription)
            .HasMaxLength(50);

        builder.Property(c => c.StreetAddress)
            .HasMaxLength(200);

        builder.Property(c => c.BuildingNumber)
            .HasMaxLength(20);

        builder.Property(c => c.SecondaryAddress)
            .HasMaxLength(100);

        builder.Property(c => c.Neighborhood)
            .HasMaxLength(100);

        builder.Property(c => c.ZipCode)
            .HasMaxLength(20);

        builder.Property(c => c.City)
            .HasMaxLength(100);

        builder.Property(c => c.State)
            .HasMaxLength(2);

        builder.Property(c => c.Active)
            .IsRequired();

        // Índices
        builder.HasIndex(c => c.Email)
            .IsUnique();

        builder.HasIndex(c => c.DocumentNumber)
            .IsUnique();
    }
}

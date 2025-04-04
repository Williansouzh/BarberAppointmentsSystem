using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberFlow.Infra.Data.EntityConfiguration;

internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("Id");
        builder.Property(a => a.Notes)
            .HasMaxLength(500)
            .IsRequired(false)
            .HasColumnName("Notes");
        builder.Property(a => a.Status)
            .IsRequired()
            .HasColumnName("Status");
        builder.Property(a => a.CreatedAt)
            .IsRequired()
            .HasColumnName("CreatedAt");
        builder.Property(a => a.DateTime)
            .IsRequired()
            .HasColumnName("DateTime");
        builder.Property(a => a.Duration)
            .IsRequired()
            .HasColumnName("Duration");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Domain.Validation;

namespace BarberFlow.Domain.Entities;

public sealed class Appointment : Entity
{
    public DateTime DateTime { get; set; }
    public bool Status { get; set; }
    public string Notes { get; set; }
    public TimeSpan Duration { get; set; }

    public Appointment(DateTime dateTime, bool status, string notes, TimeSpan duration )
    {
        DateTime = dateTime;
        Status = status;
        Notes = notes;
        Duration = duration;
    }
    public Appointment(Guid id, DateTime dateTime, bool status, string notes, TimeSpan duration)
    {
        DomainExceptValidation.When(id == Guid.Empty, "Id is required");
        Id = id;
        ValidateDomain(dateTime, status, notes, duration);

    }
    public void ValidateDomain(DateTime dateTime, bool status, string notes, TimeSpan duration)
    {
        DomainExceptValidation.When(DateTime == default, "DateTime is required");
        DomainExceptValidation.When(Status == default, "Status is required");
        DomainExceptValidation.When(string.IsNullOrEmpty(Notes), "Notes is required");
        DomainExceptValidation.When(Duration == default, "Duration is required");

        DateTime = dateTime;
        Status = status;
        Notes = notes;
        Duration = duration;
    }

    public void Update(DateTime dateTime, bool status, string notes, TimeSpan duration)
    {
        ValidateDomain(dateTime, status, notes, duration);
    }
}

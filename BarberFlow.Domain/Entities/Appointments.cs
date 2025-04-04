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

    public void ValidateDomain()
    {
        DomainExceptValidation.When(DateTime == default, "DateTime is required");
        DomainExceptValidation.When(Status == default, "Status is required");
        DomainExceptValidation.When(string.IsNullOrEmpty(Notes), "Notes is required");
        DomainExceptValidation.When(Duration == default, "Duration is required");
    }

    public void UpdateStatus(bool status)
    {
        Status = status;
    }
}

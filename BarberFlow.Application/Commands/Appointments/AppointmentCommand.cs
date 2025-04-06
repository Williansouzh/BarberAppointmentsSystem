using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Domain.Entities;
using MediatR;

namespace BarberFlow.Application.Commands.Appointments;

public abstract class AppointmentCommand : IRequest<Appointment>
{
    public DateTime DateTime { get; set; }
    public bool Status { get; set; }
    public string Notes { get; set; }
    public TimeSpan Duration { get; set; }
}

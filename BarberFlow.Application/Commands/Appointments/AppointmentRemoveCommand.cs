using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Domain.Entities;
using MediatR;

namespace BarberFlow.Application.Commands.Appointments;

public class AppointmentRemoveCommand : IRequest<Appointment>
{
    public Guid Id { get; set; }
    public AppointmentRemoveCommand(Guid id)
    {
        Id = id;
    }
}

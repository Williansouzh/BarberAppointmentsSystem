using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberFlow.Application.Commands.Appointments;

public class AppointmentUpdateCommand : AppointmentCommand
{
    public Guid Id { get; set; }
}

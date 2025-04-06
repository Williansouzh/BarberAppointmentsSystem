using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Domain.Entities;
using MediatR;

namespace BarberFlow.Application.Queries.Appointments;

public  class GetAppointmentByIdQuery : IRequest<Appointment>
{
    public Guid Id { get; set; }
    public GetAppointmentByIdQuery(Guid id)
    {
        Id = id;
    }
}

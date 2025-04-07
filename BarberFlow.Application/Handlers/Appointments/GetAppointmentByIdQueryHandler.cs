using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Application.Queries.Appointments;
using BarberFlow.Domain.Entities;
using BarberFlow.Domain.Interfaces;
using BarberFlow.Infra.Data.Persistence;
using MediatR;

namespace BarberFlow.Application.Handlers.Appointments;

public  class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, Appointment>
{
    private readonly IAppointmentRepository _appointmentRepository;
    public GetAppointmentByIdQueryHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Appointment> Handle(
        GetAppointmentByIdQuery request,
        CancellationToken cancelationToken)
    {
        return await _appointmentRepository.GetByIdAsync(request.Id);

    }
}

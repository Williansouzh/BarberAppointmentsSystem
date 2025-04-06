using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Application.Commands.Appointments;
using BarberFlow.Domain.Entities;
using BarberFlow.Domain.Interfaces;
using MediatR;

namespace BarberFlow.Application.Handlers.Appointments;

public class AppointmentRemoveCommandHandler : IRequestHandler<AppointmentRemoveCommand, Appointment>
{
    private readonly IAppointmentRepository _appointmentRepository;
    public AppointmentRemoveCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository ?? throw new
            ArgumentNullException(nameof(appointmentRepository));
    }
    public async Task<Appointment> Handle(AppointmentRemoveCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.Id, cancellationToken);
        if (appointment == null)
        {
            throw new ApplicationException("Entity could not be found");
        }

        var deleted = await _appointmentRepository.DeleteAsync(appointment.Id);
        if (!deleted) 
        {
            throw new ApplicationException("Error removing Appointment");
        }

        return appointment;
    }

}

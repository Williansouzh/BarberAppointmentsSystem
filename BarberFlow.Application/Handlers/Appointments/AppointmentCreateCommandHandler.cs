using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Application.Commands.Appointments;
using BarberFlow.Domain.Entities;
using BarberFlow.Domain.Interfaces;

namespace BarberFlow.Application.Handlers.Appointments;

public class AppointmentCreateCommandHandler
{
    private readonly IAppointmentRepository _appointmentRepository;
    public AppointmentCreateCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Appointment> Handle(ApppointmentCreateCommand request, CancellationToken cancellation)
    {
        var appointment = new Appointment(request.DateTime, request.Status, request.Notes, request.Duration);
        if (appointment == null)
        {
            throw new ApplicationException("Error creating Appointment, appointment is null");
        }
        else
        {
            return await _appointmentRepository.AddAsync(appointment);
        }
    }
}

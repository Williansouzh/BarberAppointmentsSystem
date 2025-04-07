using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Application.Commands.Appointments;
using BarberFlow.Domain.Entities;
using BarberFlow.Domain.Interfaces;
using BarberFlow.Infra.Data.Persistence;
using MediatR;

namespace BarberFlow.Application.Handlers.Appointments;

public class AppointmentUpdateCommandHandler : IRequestHandler<AppointmentUpdateCommand, Appointment>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AppointmentUpdateCommandHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
    {
        _appointmentRepository = appointmentRepository ?? throw new
            ArgumentNullException(nameof(appointmentRepository));
        _unitOfWork = unitOfWork;
    }

    public async Task<Appointment> Handle(AppointmentUpdateCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.Id, cancellationToken);
        if (appointment == null)
        {
            throw new ApplicationException("Entity could not be found");
        }
        else
        {
            appointment.Update(request.DateTime, request.Status, request.Notes, request.Duration);
            var updated = await _appointmentRepository.UpdateAsync(appointment);
            if (updated == null)
            {
                throw new ApplicationException("Error updating Appointment");
            }
            await _unitOfWork.CommitAsync();
            return updated;
        }

    }

}

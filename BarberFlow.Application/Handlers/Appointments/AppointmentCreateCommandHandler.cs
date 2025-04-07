using BarberFlow.Application.Commands.Appointments;
using BarberFlow.Domain.Entities;
using BarberFlow.Domain.Interfaces;
using BarberFlow.Infra.Data.Persistence;

public class AppointmentCreateCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentCreateCommandHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
    {
        _appointmentRepository = appointmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Appointment> Handle(AppointmentCreateCommand request, CancellationToken cancellationToken)
    {
        var appointment = new Appointment(request.DateTime, request.Status, request.Notes, request.Duration);

        var result = await _appointmentRepository.AddAsync(appointment, cancellationToken);
        await _unitOfWork.CommitAsync();

        return result;
    }
}

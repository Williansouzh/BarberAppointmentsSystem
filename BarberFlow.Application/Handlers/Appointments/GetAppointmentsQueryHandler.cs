using BarberFlow.Application.Queries.Appointments;
using BarberFlow.Domain.Entities;
using BarberFlow.Domain.Interfaces;
using MediatR;

namespace BarberFlow.Application.Handlers.Appointments;

public class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentQuery, IEnumerable<Appointment>>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetAppointmentsQueryHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    public async Task<IEnumerable<Appointment>> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        return await _appointmentRepository.GetAllAsync(cancellationToken);
    }
}

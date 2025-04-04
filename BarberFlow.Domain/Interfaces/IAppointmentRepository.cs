using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Domain.Entities;

namespace BarberFlow.Domain.Interfaces;

public interface IAppointmentRepository : IRepository<Appointment>
{
    Task<IReadOnlyCollection<Appointment>> GetAllByDateAsync(DateTime date, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Appointment>> GetAllByStatusAsync(bool status, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Appointment>> GetAllByDateAndStatusAsync(DateTime date, bool status, CancellationToken cancellationToken = default);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Domain.Entities;
using BarberFlow.Domain.Interfaces;
using BarberFlow.Infra.Data.Context;

namespace BarberFlow.Infra.Data.Repositories;

public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
{
    private readonly ApplicationDbContext _context;

    public AppointmentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public Task<IReadOnlyCollection<Appointment>> GetAllByDateAndStatusAsync(DateTime date, bool status, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Appointment>> GetAllByDateAsync(DateTime date, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Appointment>> GetAllByStatusAsync(bool status, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

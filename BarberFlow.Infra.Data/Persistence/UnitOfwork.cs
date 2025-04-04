using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Domain.Interfaces;
using BarberFlow.Infra.Data.Context;

namespace BarberFlow.Infra.Data.Persistence;

public  class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;


    public IAppointmentRepository AppointmentRepository { get; }

    public UnitOfWork(ApplicationDbContext context, IAppointmentRepository appointments)
    {
        _context = context;
        AppointmentRepository = appointments;

    }
    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}

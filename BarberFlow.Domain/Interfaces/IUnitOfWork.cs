using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Domain.Interfaces;

namespace BarberFlow.Infra.Data.Persistence;

public interface IUnitOfWork : IDisposable
{
    IAppointmentRepository AppointmentRepository { get; }
    Task<int> CommitAsync();
}

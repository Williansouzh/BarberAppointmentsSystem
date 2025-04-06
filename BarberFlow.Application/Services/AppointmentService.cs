using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BarberFlow.Application.DTOs;
using BarberFlow.Application.Interfaces;
using MediatR;
namespace BarberFlow.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AppointmentService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public Task<AppointmentDTO> Create(AppointmentDTO appointmentDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AppointmentDTO>> getAppointments()
    {
        throw new NotImplementedException();
    }

    public Task<AppointmentDTO> GetById(int? id)
    {
        throw new NotImplementedException();
    }

    public Task<AppointmentDTO> Update(AppointmentDTO appointmentDTO)
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BarberFlow.Application.Commands.Appointments;
using BarberFlow.Application.DTOs;
using BarberFlow.Application.Interfaces;
using BarberFlow.Application.Queries.Appointments;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BarberFlow.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ILogger<AppointmentService> _logger;

    public AppointmentService(IMapper mapper, IMediator mediator, ILogger<AppointmentService> logger)
    {
        _mapper = mapper;
        _mediator = mediator;
        _logger = logger;
    }

    public async Task<AppointmentDTO> Create(AppointmentDTO appointmentDTO)
    {
        //_logger.LogInformation("Creating appointment for {Customer}", appointmentDTO.CustomerName);

        var command = _mapper.Map<AppointmentCreateCommand>(appointmentDTO);
        await _mediator.Send(command);

        //_logger.LogInformation("Successfully created appointment for {Customer}", appointmentDTO.CustomerName);
        return appointmentDTO;
    }

    public async Task<bool> Delete(Guid id)
    {
        _logger.LogInformation("Deleting appointment with ID: {Id}", id);

        var command = new AppointmentRemoveCommand(id);
        await _mediator.Send(command);

        _logger.LogInformation("Successfully deleted appointment with ID: {Id}", id);
        return true;
    }

    public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
    {
        _logger.LogInformation("Retrieving all appointments");

        var result = await _mediator.Send(new GetAppointmentQuery());

        _logger.LogInformation("Retrieved {Count} appointments", result?.Count() ?? 0);
        return _mapper.Map<IEnumerable<AppointmentDTO>>(result);
    }

    public async Task<AppointmentDTO> GetById(Guid? id)
    {
        if (id == null)
        {
            _logger.LogWarning("GetById called with null ID");
            throw new ArgumentNullException(nameof(id));
        }

        _logger.LogInformation("Retrieving appointment with ID: {Id}", id);

        var result = await _mediator.Send(new GetAppointmentByIdQuery(id.Value));

        if (result == null)
        {
            _logger.LogWarning("No appointment found with ID: {Id}", id);
            throw new KeyNotFoundException($"Appointment with ID {id} not found.");
        }

        _logger.LogInformation("Successfully retrieved appointment with ID: {Id}", id);
        return _mapper.Map<AppointmentDTO>(result);
    }

    public async Task<AppointmentDTO> Update(AppointmentDTO appointmentDTO)
    {
        _logger.LogInformation("Updating appointment with ID: {Id}", appointmentDTO.Id);

        var command = _mapper.Map<AppointmentUpdateCommand>(appointmentDTO);
        var result = await _mediator.Send(command);

        if (result == null)
        {
            _logger.LogWarning("Failed to update appointment with ID: {Id}", appointmentDTO.Id);
            throw new Exception("Update failed or appointment not found.");
        }

        _logger.LogInformation("Successfully updated appointment with ID: {Id}", appointmentDTO.Id);
        return _mapper.Map<AppointmentDTO>(result);
    }
}

using BarberFlow.Application.DTOs;

namespace BarberFlow.Application.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDTO>> GetAppointments();
    Task<AppointmentDTO> GetById(Guid? id);
    Task<AppointmentDTO> Create(AppointmentDTO appointmentDTO);
    Task<AppointmentDTO> Update(AppointmentDTO appointmentDTO);
    Task<bool> Delete(Guid id);
}


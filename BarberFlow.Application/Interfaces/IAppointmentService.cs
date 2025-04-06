using BarberFlow.Application.DTOs;

namespace BarberFlow.Application.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDTO>> getAppointments();
    Task<AppointmentDTO> GetById(int? id);
    Task<AppointmentDTO> Create(AppointmentDTO appointmentDTO);
    Task<AppointmentDTO> Update(AppointmentDTO appointmentDTO);
    Task<bool> Delete(int id);
}


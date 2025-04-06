using AutoMapper;
using BarberFlow.Application.DTOs;
using BarberFlow.Domain.Entities;
namespace BarberFlow.Application.Mappings;

public  class DomainToDTOMapingProfile : Profile
{
    public DomainToDTOMapingProfile()
    {
        CreateMap<Appointment, AppointmentDTO>();
    }
}

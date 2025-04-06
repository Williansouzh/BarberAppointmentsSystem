using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BarberFlow.Application.DTOs;
using BarberFlow.Domain.Entities;

namespace BarberFlow.Application.Mappings;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<AppointmentDTO, Appointment>();
    }
}

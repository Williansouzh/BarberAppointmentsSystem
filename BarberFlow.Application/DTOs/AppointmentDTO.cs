using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BarberFlow.Application.DTOs
{
    public class AppointmentDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A data e hora são obrigatórias.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data e Hora")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDateTimeUtc { get; set; }

        // This is a read-only property for display purposes in Brazil timezone (UTC-3)
        [Display(Name = "Data e Hora (Horário de Brasília)")]
        public string AppointmentDateTimeBr
        {
            get
            {
                var brazilTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"); // Windows ID
                var brazilDateTime = TimeZoneInfo.ConvertTimeFromUtc(AppointmentDateTimeUtc, brazilTimeZone);
                return brazilDateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.GetCultureInfo("pt-BR"));
            }
        }

        public bool Status { get; set; }

        [Display(Name = "Observações")]
        public string Notes { get; set; }

        [Display(Name = "Duração")]
        public TimeSpan Duration { get; set; }
    }
}

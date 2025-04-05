namespace BarberFlow.API.Middlewares.Logging;

public class CustomerLoggerProviderConfiguration
{
    public LogLevel loglevel { get; set; } = LogLevel.Warning;
    public int EventId { get; set; } = 0;

}

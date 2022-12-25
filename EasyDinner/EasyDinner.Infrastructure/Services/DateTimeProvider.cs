using EasyDinner.Application.Common.Interfaces.Services;

namespace EasyDinner.Infrastrcuture.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
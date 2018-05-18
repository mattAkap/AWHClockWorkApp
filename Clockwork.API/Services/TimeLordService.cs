using System;
using NodaTime;

namespace Clockwork.API.Services
{
    public static class TimeLordService
    {
        public static string CurrentTimeZone { get; set; }

        public static DateTime ConvertTime(DateTime dateTime, string timeZoneCode)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
                dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

            var zone = DateTimeZoneProviders.Tzdb[timeZoneCode];
            var instant = Instant.FromDateTimeUtc(dateTime);

            return instant.InZone(zone).ToDateTimeUnspecified();
        }
    }
}

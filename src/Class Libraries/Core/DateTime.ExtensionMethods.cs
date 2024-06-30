namespace WhenFresh.Utilities;

using System.Globalization;

public static class DateTimeExtensionMethods
{
#if NET20
        public static Date ToDate(DateTime value)
#else
    public static Date ToDate(this DateTime value)
#endif
    {
        return new Date(value);
    }

    public static string ToFileName(this DateTime value)
    {
        // code is assuming that everything runs in the UK
        // so to make it work, we do a bit of gymnastics
        
        var ukTime = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        // return value.ToLocalTime(ukTime);
        var converted = value.Kind switch
            {
                DateTimeKind.Utc => value,
                DateTimeKind.Unspecified => TimeZoneInfo.ConvertTimeToUtc(value, ukTime),
                DateTimeKind.Local => value.ToUniversalTime()
            };
        // var converted = 
        
        return converted.ToString(@"yyyy-MM-dd HH\hmm ss,fff G\MT", CultureInfo.InvariantCulture);
    }

    [Obsolete("This method converts with zone id but does not validate zone ids, please use the overload taking a TimeZoneInfo", true)]
    public static DateTime ToLocalTime(this DateTime value,
                                       string zone)
    {
        ArgumentNullException.ThrowIfNull(zone);

        if (zone.Length == 0)
            throw new ArgumentOutOfRangeException(nameof(zone));
        //
        // if (value.Kind != DateTimeKind.Utc)
        //     throw new ArgumentOutOfRangeException(nameof(value), "Cannot convert non-UTC times");

        return value.ToLocalTime(TimeZoneInfo.FindSystemTimeZoneById(zone));
    }

    public static DateTime ToLocalTime(this DateTime value,
                                       TimeZoneInfo zone)
    {
        ArgumentNullException.ThrowIfNull(zone);
        //
        // if (value.Kind != DateTimeKind.Utc)
        //     throw new ArgumentOutOfRangeException(nameof(value), "Cannot convert non-UTC times");

        return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(value, zone.Id);
    }


#if NET20
        public static Month ToMonth(DateTime value)
#else
    public static Month ToMonth(this DateTime value)
#endif
    {
        return new Month(value);
    }
}
﻿namespace WhenFresh.Utilities;

using System;

public sealed class DateTimeExtensionMethodsFacts
{
    [Fact]
    public void a_definition()
    {
        Assert.True(typeof(DateTimeExtensionMethods).IsStatic());
    }

    [Fact]
    public void op_ToDate_DateTime()
    {
        var expected = Date.Today;
        var actual = DateTime.Today.ToDate();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ToFileName_DateTime()
    {
        var localTime = new DateTime(1999, 1, 31, 8, 1, 5, 123);
        const string expected = "1999-01-31 08h01 05,123 GMT";
        var actual = localTime.ToFileName();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ToFileName_DateTime_whenDaylightSavings()
    {
        var localTime = new DateTime(1999, 6, 1, 20, 1, 5, 123);
        const string expected = "1999-06-01 19h01 05,123 GMT";
        var actual = localTime.ToFileName();

        Assert.Equal(expected, actual);
    }
 
    [Fact]
    public void op_ToLocalTime_DateTime_TimeZoneInfo()
    {
        var obj = DateTime.UtcNow;

        var value = TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time");

        var expected = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(obj, value.Id);
        var actual = obj.ToLocalTime(value);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void op_ToLocalTime_DateTime_TimeZoneInfoNull()
    {
        Assert.Throws<ArgumentNullException>(() => DateTime.UtcNow.ToLocalTime(null as TimeZoneInfo));
    }

    [Fact, Obsolete]
    public void op_ToLocalTime_DateTime_string()
    {
        var utcTime = DateTime.UtcNow;

        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time");

        var expected = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcTime, timeZone.Id);
        
        var actual = utcTime.ToLocalTime(timeZone.Id);

        Assert.Equal(expected, actual);
    }

    [Fact, Obsolete]
    public void op_ToLocalTime_DateTime_stringEmpty()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => DateTime.UtcNow.ToLocalTime(string.Empty));
    }

    [Fact, Obsolete]
    public void op_ToLocalTime_DateTime_stringInvalid()
    {
        Assert.Throws<TimeZoneNotFoundException>(() => DateTime.UtcNow.ToLocalTime("Not a valid time zone"));
    }

    [Fact, Obsolete]
    public void op_ToLocalTime_DateTime_stringNull()
    {
        Assert.Throws<ArgumentNullException>(() => DateTime.UtcNow.ToLocalTime(null as string));
    }

    [Fact]
    public void op_ToMonth_DateTime()
    {
        var expected = Date.Today.LocalTime.ToMonth();
        var actual = DateTime.Today.ToMonth();

        Assert.Equal(expected, actual);
    }
}
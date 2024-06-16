﻿namespace WhenFresh.Utilities.Core.Facts
{
    using System;
    using WhenFresh.Utilities.Core;

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
            var date = new DateTime(1999, 1, 31, 8, 1, 5, 123);
            const string expected = "1999-01-31 08h01 05,123 GMT";
            var actual = date.ToFileName();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void op_ToFileName_DateTime_whenDaylightSavings()
        {
            var date = new DateTime(1999, 6, 1, 20, 1, 5, 123);
            const string expected = "1999-06-01 19h01 05,123 GMT";
            var actual = date.ToFileName();

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

        [Fact]
        public void op_ToLocalTime_DateTime_string()
        {
            var obj = DateTime.UtcNow;

            var value = TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time");

            var expected = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(obj, value.Id);
            var actual = obj.ToLocalTime(value.StandardName);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void op_ToLocalTime_DateTime_stringEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DateTime.UtcNow.ToLocalTime(string.Empty));
        }

        [Fact]
        public void op_ToLocalTime_DateTime_stringInvalid()
        {
            Assert.Throws<TimeZoneNotFoundException>(() => DateTime.UtcNow.ToLocalTime("Not a valid time zone"));
        }

        [Fact]
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
}
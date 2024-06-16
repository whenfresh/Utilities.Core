namespace WhenFresh.Utilities.Core;

public interface IGetCalendarPeriod
{
    DateTimePeriod Month { get; }

    DateTimePeriod Week { get; }

    DateTimePeriod Year { get; }
}
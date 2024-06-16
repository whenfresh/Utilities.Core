namespace WhenFresh.Utilities.Core
{
    public interface ICalculateDateTimeCalendar
    {
        DateTimePeriod Month { get; }

        DateTimePeriod Week { get; }

        DateTimePeriod Year { get; }
    }
}
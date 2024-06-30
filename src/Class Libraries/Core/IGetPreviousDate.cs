namespace WhenFresh.Utilities;

public interface IGetPreviousDate : IGetPreviousMonth,
                                    IGetPreviousWeekday
{
    Date Day { get; }

    Date Month { get; }

    Date Week { get; }

    Date Year { get; }
}
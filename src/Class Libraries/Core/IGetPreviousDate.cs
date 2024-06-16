namespace WhenFresh.Utilities.Core
{
    public interface IGetPreviousDate : IGetPreviousMonth,
                                        IGetPreviousWeekday
    {
        Date Day { get; }

        Date Month { get; }

        Date Week { get; }

        Date Year { get; }
    }
}
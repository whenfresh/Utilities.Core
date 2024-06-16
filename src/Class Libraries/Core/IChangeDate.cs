namespace WhenFresh.Utilities.Core;

public interface IChangeDate : IChangeMonth<Date>
{
    Date Day(int value);
}
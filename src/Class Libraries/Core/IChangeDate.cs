namespace WhenFresh.Utilities;

public interface IChangeDate : IChangeMonth<Date>
{
    Date Day(int value);
}
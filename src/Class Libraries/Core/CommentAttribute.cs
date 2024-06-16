namespace WhenFresh.Utilities.Core;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class CommentAttribute : Attribute
{
    public CommentAttribute(string value)
        : this()
    {
        Value = value;
    }

    private CommentAttribute()
    {
    }

    public string Value { get; private set; }
}
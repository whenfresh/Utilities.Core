namespace WhenFresh.Utilities.Core.Globalization;

using System.ComponentModel;
using System.Runtime.Serialization;
#if NET20 || NET35
    using System.Security.Permissions;
#endif

[ImmutableObject(true)]
[Serializable]
public struct Translation<T> : ISerializable,
                               IEquatable<Translation<T>>
{
    public Translation(T value)
        : this()
    {
        Value = value;
    }

    public Translation(T value,
                       Language language)
        : this(value)
    {
        Language = language;
    }

    private Translation(SerializationInfo info,
                        StreamingContext context)
        : this()
    {
        Language = info.GetString("_language");
        Value = (T)info.GetValue("_value", typeof(T));
    }

    public Language Language { get; private set; }

    public T Value { get; private set; }

    public static bool operator ==(Translation<T> obj,
                                   Translation<T> comparand)
    {
        return obj.Equals(comparand);
    }

    public static bool operator !=(Translation<T> obj,
                                   Translation<T> comparand)
    {
        return !obj.Equals(comparand);
    }

    public override bool Equals(object obj)
    {
        return !ReferenceEquals(null, obj) && Equals((Translation<T>)obj);
    }

    public bool Equals(Translation<T> other)
    {
        if (Language != other.Language)
        {
            return false;
        }

        return ReferenceEquals(null, Value)
                   ? ReferenceEquals(null, other.Value)
                   : Value.Equals(other.Value);
    }

    public override int GetHashCode() => ToString().GetHashCode();

    public override string ToString() => $"{Language}: {Value}";

    void ISerializable.GetObjectData(SerializationInfo info,
                                     StreamingContext context)
    {
        if (null == info)
        {
            throw new ArgumentNullException("info");
        }

        info.AddValue("_language", Language);
        info.AddValue("_value", Value);
    }
}
namespace WhenFresh.Utilities;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using WhenFresh.Utilities.IO;
using WhenFresh.Utilities.Xml;

public static class ObjectExtensionMethods
{
#if NET20
        public static bool IsNotNull(object value)
#else
    public static bool IsNotNull(this object value)
#endif
    {
        return !ReferenceEquals(null, value);
    }

#if NET20
        public static string NullOrToString(object value)
#else
    public static string NullOrToString(this object value)
#endif
    {
        return ReferenceEquals(null, value)
                   ? null
                   : value.ToString();
    }

#if NET20
        public static string ToXmlString(object value)
#else
    public static string ToXmlString(this object value)
#endif
    {
        if (null == value)
        {
            return null;
        }

        var s = value as string;
#if NET20
            if (ObjectExtensionMethods.IsNotNull(s))
#else
        if (s.IsNotNull())
#endif
        {
            return s;
        }

        if (value is bool)
        {
            return XmlConvert.ToString((bool)value);
        }

        if (value is DateTime)
        {
            return XmlConvert.ToString((DateTime)value, XmlDateTimeSerializationMode.Utc);
        }

#if !NET20
        if (value is DateTimeOffset)
        {
            return XmlConvert.ToString((DateTimeOffset)value);
        }

#endif

        if (value is decimal)
        {
            return XmlConvert.ToString((decimal)value);
        }

        if (value is double)
        {
            return XmlConvert.ToString((double)value);
        }

        if (value is float)
        {
            return XmlConvert.ToString((float)value);
        }

        if (value is TimeSpan)
        {
            return XmlConvert.ToString((TimeSpan)value);
        }

        if (value is IConvertible)
        {
            return (string)Convert.ChangeType(value, typeof(string), CultureInfo.InvariantCulture);
        }

        return value.ToString();
    }

#if NET20
        public static IXPathNavigable XmlSerialize(object value)
#else
    [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "This is an odd rule that seems to be impossible to actually pass.")]
    public static IXPathNavigable XmlSerialize(this object value)
#endif
    {
        if (null == value)
        {
            throw new ArgumentNullException("value");
        }

        var result = new XmlDocument();

        var buffer = new StringBuilder();

        var exception = value as Exception;

        {
            using (TextWriter writer = new EncodedStringWriter(buffer, CultureInfo.InvariantCulture, Encoding.UTF8))
            {
                XmlSerializerNamespaces namespaces;
                var obj = value as IXmlSerializerNamespaces;
                if (null == obj)
                {
                    namespaces = new XmlSerializerNamespaces();
                    namespaces.Add(string.Empty, string.Empty);
                }
                else
                {
                    namespaces = obj.XmlNamespaceDeclarations;
                }

                new XmlSerializer(value.GetType()).Serialize(writer, value, namespaces);
            }
        }

        result.LoadXml(buffer.ToString());

        return result;
    }
}
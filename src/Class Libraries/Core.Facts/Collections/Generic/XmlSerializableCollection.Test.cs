namespace WhenFresh.Utilities.Core.Facts.Collections.Generic
{
    using System.Xml.Serialization;
    using WhenFresh.Utilities.Core.Collections.Generic;

    [XmlRoot("collection")]
    public sealed class TestXmlSerializableCollection : XmlSerializableCollection<TestXmlSerializableCollectionItem>
    {
    }
}
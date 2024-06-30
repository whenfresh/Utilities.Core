namespace WhenFresh.Utilities.Collections.Generic;

using System.Xml.Serialization;

[XmlRoot("collection")]
public sealed class TestXmlSerializableCollection : XmlSerializableCollection<TestXmlSerializableCollectionItem>
{
}
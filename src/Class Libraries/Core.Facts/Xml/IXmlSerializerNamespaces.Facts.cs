namespace WhenFresh.Utilities.Core.Facts.Xml
{
    using System.Xml.Serialization;
    using Moq;
    using WhenFresh.Utilities.Core.Xml;

    public sealed class IXmlSerializerNamespacesFacts
    {
        [Fact]
        public void a_definition()
        {
            Assert.True(new TypeExpectations<IXmlSerializerNamespaces>().IsInterface()
                                                                        .IsNotDecorated()
                                                                        .Result);
        }

        [Fact]
        public void prop_XmlNamespaceDeclarations_get()
        {
            var expected = new XmlSerializerNamespaces();

            var mock = new Mock<IXmlSerializerNamespaces>();
            mock
                .SetupGet(x => x.XmlNamespaceDeclarations)
                .Returns(expected)
                .Verifiable();

            var actual = mock.Object.XmlNamespaceDeclarations;

            Assert.Same(expected, actual);

            mock.VerifyAll();
        }
    }
}
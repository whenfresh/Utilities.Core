namespace WhenFresh.Utilities.Core.Facts
{
    using Moq;
    using WhenFresh.Utilities.Core;

    public sealed class IChangeDateFacts
    {
        [Fact]
        public void a_definition()
        {
            Assert.True(new TypeExpectations<IChangeDate>().IsInterface()
                                                           .Result);
        }

        [Fact]
        public void op_Day_int()
        {
            var expected = Date.Today.LocalTime;

            var mock = new Mock<IChangeDate>();
            mock
                .Setup(x => x.Day(2))
                .Returns(expected)
                .Verifiable();

            var actual = mock.Object.Day(2);

            Assert.Equal(expected, actual);

            mock.VerifyAll();
        }
    }
}
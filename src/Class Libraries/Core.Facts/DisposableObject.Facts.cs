namespace WhenFresh.Utilities.Core.Facts
{
    using System;
    using WhenFresh.Utilities.Core;

    public sealed class DisposableObjectFacts
    {
        [Fact]
        public void a_definition()
        {
            Assert.True(new TypeExpectations<DisposableObject>().DerivesFrom<object>()
                                                                .IsAbstractBaseClass()
                                                                .IsNotDecorated()
                                                                .Implements<IDisposable>()
                                                                .Result);
        }

        [Fact]
        public void ctor()
        {
            using (var obj = new DerivedDisposableObject())
            {
                Assert.IsAssignableFrom<DisposableObject>(obj);
            }
        }
    }
}
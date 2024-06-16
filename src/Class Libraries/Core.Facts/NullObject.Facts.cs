﻿namespace WhenFresh.Utilities.Core.Facts
{
    using WhenFresh.Utilities.Core;

    public sealed class NullObjectFacts
    {
        [Fact]
        public void a_definition()
        {
            Assert.True(new TypeExpectations<NullObject>().DerivesFrom<object>()
                                                          .IsConcreteClass()
                                                          .IsSealed()
                                                          .NoDefaultConstructor()
                                                          .IsNotDecorated()
                                                          .Result);
        }

        [Fact]
        public void prop_Value()
        {
            Assert.IsType<NullObject>(NullObject.Value);
        }
    }
}
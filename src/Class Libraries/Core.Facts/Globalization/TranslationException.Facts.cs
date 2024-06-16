namespace WhenFresh.Utilities.Core.Facts.Globalization
{
    using System;
    using WhenFresh.Utilities.Core.Globalization;

    public sealed class TranslationExceptionFacts
    {
        [Fact]
        public void a_definition()
        {
            Assert.True(new TypeExpectations<TranslationException>().DerivesFrom<Exception>()
                                                                    .IsConcreteClass()
                                                                    .IsSealed()
                                                                    .HasDefaultConstructor()
                                                                    .Serializable()
                                                                    .Result);
        }

        [Fact]
        public void ctor()
        {
            Assert.NotNull(new TranslationException());
        }

        [Fact]
        public void ctor_string()
        {
            Assert.NotNull(new TranslationException("message"));
        }

        [Fact]
        public void ctor_stringEmpty()
        {
            Assert.NotNull(new TranslationException(string.Empty));
        }

        [Fact]
        public void ctor_stringEmpty_ExceptionNull()
        {
            Assert.NotNull(new TranslationException(string.Empty, null));
        }

        [Fact]
        public void ctor_stringNull()
        {
            Assert.NotNull(new TranslationException(null));
        }

        [Fact]
        public void ctor_stringNull_ExceptionNull()
        {
            Assert.NotNull(new TranslationException(null, null));
        }

        [Fact]
        public void ctor_string_Exception()
        {
            Assert.NotNull(new TranslationException("message", new InvalidOperationException()));
        }

        [Fact]
        public void ctor_string_ExceptionNull()
        {
            Assert.NotNull(new TranslationException("message", null));
        }
    }
}
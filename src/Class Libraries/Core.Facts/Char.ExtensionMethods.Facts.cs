﻿namespace WhenFresh.Utilities;

using System.Xml;

public sealed class CharExtensionMethodsFacts
{
    [Fact]
    public void a_definition()
    {
        Assert.True(typeof(CharExtensionMethods).IsStatic());
    }

    [Theory]
    [InlineData("¤₳฿₵¢₡₢₠$₫৳₯€ƒ₣₲₴₭ℳ₥₦₧₱₰£₹₨₪₸₮₩¥៛")]
    public void op_IsCurrencySymbol_char(string values)
    {
        foreach (var value in values ?? string.Empty)
        {
            Assert.True(value.IsCurrencySymbol(), XmlConvert.ToString(value));
        }
    }

    [Theory]
    [InlineData("0123456789")]
    public void op_IsDigit_char(string values)
    {
        foreach (var value in values ?? string.Empty)
        {
            Assert.True(value.IsDigit(), XmlConvert.ToString(value));
        }
    }

    [Theory]
    [InlineData("½⅓¼⅕⅙⅛⅔⅖¾⅗⅜⅘⅚⅝⅞⁄")]
    public void op_IsFractionSymbol_char(string values)
    {
        foreach (var value in values ?? string.Empty)
        {
            Assert.True(value.IsFractionSymbol(), XmlConvert.ToString(value));
        }
    }

    [Theory]
    [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
    [InlineData("abcdefghijklmnopqrstuvwxyz")]
    [InlineData("0123456789")]
    public void op_IsLetterOrDigit_char(string values)
    {
        foreach (var value in values ?? string.Empty)
        {
            Assert.True(value.IsLetterOrDigit(), XmlConvert.ToString(value));
        }
    }

    [Theory]
    [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
    [InlineData("abcdefghijklmnopqrstuvwxyz")]
    public void op_IsLetter_char(string values)
    {
        foreach (var value in values ?? string.Empty)
        {
            Assert.True(value.IsLetter(), XmlConvert.ToString(value));
        }
    }

    [Theory]
    [InlineData("∞%‰‱+−-±∓×÷⁄∣∤=≠<>≪≫≺∝⊗′″‴√#ℵℶ:!~≈≀◅▻⋉⋈∴∵■□∎▮‣⇒→⊃⇔↔¬˜∧∨⊕⊻∀∃≜≝≐≅≡{}∅∈∉⊆⊂⊇⊃∪∩∆∖→↦∘ℕNℤZℙPℚQℝRℂCℍHO∑∏∐Δδ∂∇′•∫∮πσ†T⊤⊥⊧⊢o")]
    public void op_IsMathematicalSymbol_char(string values)
    {
        foreach (var value in values ?? string.Empty)
        {
            Assert.True(value.IsMathematicalSymbol(), XmlConvert.ToString(value));
        }
    }

    [Theory]
    [InlineData("0123456789")]
    [InlineData("½⅓¼⅕⅙⅛⅔⅖¾⅗⅜⅘⅚⅝⅞")]
    public void op_IsNumber_char(string values)
    {
        foreach (var value in values ?? string.Empty)
        {
            Assert.True(value.IsNumber(), XmlConvert.ToString(value));
        }
    }

    [Theory]
    [InlineData("„“”‘’'\"‐‒–—―…!?.:;,[](){}⟨⟩«»/⁄")]
    public void op_IsPunctuation_char(string values)
    {
        foreach (var value in values ?? string.Empty)
        {
            Assert.True(value.IsPunctuation(), XmlConvert.ToString(value));
        }
    }

    [Theory]
    [InlineData(" ")]
    public void op_IsSeparator_char(string values)
    {
        foreach (var value in values ?? string.Empty)
        {
            Assert.True(value.IsSeparator(), XmlConvert.ToString(value));
        }
    }

    [Theory]
    [InlineData("+™$£")]
    public void op_IsSymbol_char(string values)
    {
        foreach (var value in values ?? string.Empty)
        {
            Assert.True(value.IsSymbol(), XmlConvert.ToString(value));
        }
    }

    [Theory]
    [InlineData("&@*\\•^†‡°〃¡¿#№ºª¶§~_¦|©®℗℠™⁂⊤⊥☞∴∵‽؟◊※⁀")]
    public void op_IsTypography_char(string values)
    {
        foreach (var value in values ?? string.Empty)
        {
            Assert.True(value.IsTypography(), XmlConvert.ToString(value));
        }
    }

    [Fact]
    public void op_IsWhiteSpace_char()
    {
        Assert.False('a'.IsWhiteSpace());
    }

    [Theory]
    [InlineData('A', "ÀÂÆ")]
    [InlineData('a', "àâæ")]
    [InlineData('C', "Ç")]
    [InlineData('c', "ç")]
    [InlineData('E', "ÉÈÊË")]
    [InlineData('e', "éèêë")]
    [InlineData('I', "ÎÏ")]
    [InlineData('i', "îï")]
    [InlineData('O', "ÔŒ")]
    [InlineData('o', "ôœ")]
    [InlineData('U', "ÙÛÜ")]
    [InlineData('u', "ùûü")]
    [InlineData('Y', "Ÿ")]
    [InlineData('y', "ÿ")]
    public void op_ToEnglishAlphabet_char(char expected,
                                          string values)
    {
        Assert.Equal(expected, expected.ToEnglishAlphabet());
        foreach (var value in values ?? string.Empty)
        {
            Assert.Equal(expected, value.ToEnglishAlphabet());
        }
    }
}
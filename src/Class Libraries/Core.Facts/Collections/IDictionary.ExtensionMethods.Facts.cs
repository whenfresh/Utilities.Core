namespace WhenFresh.Utilities.Core.Facts.Collections;

using System;
using System.Collections.Generic;
using WhenFresh.Utilities.Core.Collections;

public sealed class IDictionaryExtensionMethodsFacts
{
    [Fact]
    public void a_definition()
    {
        Assert.True(typeof(IDictionaryExtensionMethods).IsStatic());
    }

    [Fact]
    public void op_NotContainsKey_IDictionaryOfTNull_string()
    {
        Assert.Throws<ArgumentNullException>(() => (null as IDictionary<string, object>).NotContainsKey("example"));
    }

    [Fact]
    public void op_NotContainsKey_IDictionaryOfT_string()
    {
        var list = new Dictionary<string, int>
                       {
                           { "example", 123 }
                       };

        Assert.False(list.NotContainsKey("example"));
        Assert.True(list.NotContainsKey("test"));
    }

    [Fact]
    public void op_TryAdd_IDictionaryOfTNull_KeyValuePair()
    {
        Assert.Throws<ArgumentNullException>(() => (null as IDictionary<string, object>).TryAdd(new KeyValuePair<string, object>("example", new object())));
    }

    [Fact]
    public void op_TryAdd_IDictionaryOfT_KeyValuePair_whenFalse()
    {
        var list = new Dictionary<string, int>
                       {
                           { "example", 123 }
                       };

        Assert.False(list.TryAdd(new KeyValuePair<string, int>("example", 456)));
    }

    [Fact]
    public void op_TryAdd_IDictionaryOfT_KeyValuePair_whenTrue()
    {
        var list = new Dictionary<string, string>();

        Assert.True(list.TryAdd(new KeyValuePair<string, string>("example", string.Empty)));
    }
}
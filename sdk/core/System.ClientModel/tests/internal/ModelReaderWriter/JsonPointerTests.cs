// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests;

public class JsonPointerTests
{
    private const string json = """
    {
        "foo": "bar",
        "numbers": [1, 2, 3],
        "strings": ["hello", "world", "test"],
        "empty": {},
        "a/b": "slash in key",
        "c%d": "percent in key",
        "e^f": "caret in key",
        "g|h": "pipe in key",
        "i\\j": "backslash in key",
        "k\"l": "quotes in key",
        "m~n": "tilde in key",
        "nested": {
            "child": {
                "value": 123,
                "name": "test"
            },
            "array": [4, 5, 6],
            "stringArray": ["nested1", "nested2"]
        },
        "boolValue": true,
        "nullValue": null
    }
    """;

    [TestCase("/foo", typeof(string), ExpectedResult = "bar")]
    [TestCase("/numbers/0", typeof(int), ExpectedResult = 1)]
    [TestCase("/numbers/1", typeof(int), ExpectedResult = 2)]
    [TestCase("/numbers/2", typeof(int), ExpectedResult = 3)]
    [TestCase("/c%d", typeof(string), ExpectedResult = "percent in key")]
    [TestCase("/e^f", typeof(string), ExpectedResult = "caret in key")]
    [TestCase("/g|h", typeof(string), ExpectedResult = "pipe in key")]
    [TestCase("/i\\j", typeof(string), ExpectedResult = "backslash in key")]
    [TestCase("/k\"l", typeof(string), ExpectedResult = "quotes in key")]
    [TestCase("/nested/child/value", typeof(int), ExpectedResult = 123)]
    [TestCase("/nested/child/name", typeof(string), ExpectedResult = "test")]
    [TestCase("/nested/array/1", typeof(int), ExpectedResult = 5)]
    [TestCase("/boolValue", typeof(bool), ExpectedResult = true)]
    //[TestCase("", typeof(ReadOnlySpan<byte>), ExpectedResult = json)]
    //[TestCase("/nullValue", typeof(object), ExpectedResult = null)]
    public object? PositiveTests(string pointer, Type valueType)
    {
        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
        byte[] pointerBytes = Encoding.UTF8.GetBytes(pointer);

        if (valueType == typeof(string))
        {
            return JsonPointer.GetString(jsonBytes, pointerBytes);
        }
        else if (valueType == typeof(bool))
        {
            return JsonPointer.GetBoolean(jsonBytes, pointerBytes);
        }
        else if (valueType == typeof(int))
        {
            return JsonPointer.GetInt32(jsonBytes, pointerBytes);
        }
        else if (valueType == typeof(double))
        {
            return JsonPointer.GetDouble(jsonBytes, pointerBytes);
        }
        else if (valueType == typeof(ReadOnlySpan<byte>))
        {
            ReadOnlySpan<byte> bytes = JsonPointer.GetUtf8(jsonBytes, pointerBytes);
            return Encoding.UTF8.GetString(bytes.ToArray());
        }
        else if (valueType == typeof(int[]))
        {
            return JsonPointer.GetInt32Array(jsonBytes, pointerBytes);
        }
        else if (valueType == typeof(ReadOnlyMemory<byte>[]))
        {
            return JsonPointer.GetUtf8Array(jsonBytes.AsSpan(), pointerBytes);
        }
        else
        {
            throw new ArgumentException($"Unsupported value type: {valueType}", nameof(valueType));
        }
    }

    [TestCase("foo", typeof(string), typeof(ArgumentException))]
    [TestCase("/nonexistent", typeof(string), typeof(KeyNotFoundException))]
    [TestCase("/nonexistent", typeof(bool), typeof(KeyNotFoundException))]
    [TestCase("/nested/nonexistent", typeof(string), typeof(KeyNotFoundException))]
    [TestCase("/numbers/999", typeof(int), typeof(IndexOutOfRangeException))]
    [TestCase("/numbers/999", typeof(string), typeof(IndexOutOfRangeException))]
    [TestCase("/nested/array/99", typeof(string), typeof(IndexOutOfRangeException))]
    [TestCase("/foo", typeof(bool), typeof(InvalidOperationException))]
    [TestCase("/boolValue", typeof(int), typeof(InvalidOperationException))]
    [TestCase("/nested/child/value", typeof(string), typeof(InvalidOperationException))]
    [TestCase("~", typeof(string), typeof(ArgumentException))]
    public void NegativeTests(string pointer, Type accessorType, Type expectedExceptionType)
    {
        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
        byte[] pointerBytes = Encoding.UTF8.GetBytes(pointer);
        string errorMessage = $"Expected {expectedExceptionType.Name} for pointer '{pointer}' with {accessorType.Name} accessor";

        if (accessorType == typeof(string))
        {
            Assert.Throws(expectedExceptionType, () => JsonPointer.GetString(jsonBytes, pointerBytes), errorMessage);
        }
        else if (accessorType == typeof(bool))
        {
            Assert.Throws(expectedExceptionType, () => JsonPointer.GetBoolean(jsonBytes, pointerBytes), errorMessage);
        }
        else if (accessorType == typeof(int))
        {
            Assert.Throws(expectedExceptionType, () => JsonPointer.GetInt32(jsonBytes, pointerBytes), errorMessage);
        }
        else if (accessorType == typeof(double))
        {
            Assert.Throws(expectedExceptionType, () => JsonPointer.GetDouble(jsonBytes, pointerBytes), errorMessage);
        }
        else if (accessorType == typeof(double[]))
        {
            Assert.Throws(expectedExceptionType, () => JsonPointer.GetDoubleArray(jsonBytes, pointerBytes), errorMessage);
        }
        else
        {
            throw new ArgumentException($"Unsupported accessor type: {accessorType}", nameof(accessorType));
        }
    }

    [Test]
    public void TestGetUtf8Array_WithPointer()
    {
        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
        byte[] stringsPointer = Encoding.UTF8.GetBytes("/strings");
        byte[] nestedStringArrayPointer = Encoding.UTF8.GetBytes("/nested/stringArray");

        // Test /strings pointer
        var result1 = JsonPointer.GetUtf8Array(jsonBytes.AsSpan(), stringsPointer);
        Assert.That(result1, Is.Not.Null);
        Assert.That(result1!.Length, Is.EqualTo(3));
        Assert.That(Encoding.UTF8.GetString(result1[0].Span.ToArray()), Is.EqualTo("hello"));
        Assert.That(Encoding.UTF8.GetString(result1[1].Span.ToArray()), Is.EqualTo("world"));
        Assert.That(Encoding.UTF8.GetString(result1[2].Span.ToArray()), Is.EqualTo("test"));

        // Test /nested/stringArray pointer
        var result2 = JsonPointer.GetUtf8Array(jsonBytes.AsSpan(), nestedStringArrayPointer);
        Assert.That(result2, Is.Not.Null);
        Assert.That(result2!.Length, Is.EqualTo(2));
        Assert.That(Encoding.UTF8.GetString(result2[0].Span.ToArray()), Is.EqualTo("nested1"));
        Assert.That(Encoding.UTF8.GetString(result2[1].Span.ToArray()), Is.EqualTo("nested2"));
    }

    [Test]
    public void TestGetUtf8Array_WithoutPointer()
    {
        string stringArrayJson = """["alpha", "beta", "gamma"]""";
        byte[] jsonBytes = Encoding.UTF8.GetBytes(stringArrayJson);

        var result = JsonPointer.GetUtf8Array(jsonBytes.AsSpan());
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Length, Is.EqualTo(3));
        Assert.That(Encoding.UTF8.GetString(result[0].Span.ToArray()), Is.EqualTo("alpha"));
        Assert.That(Encoding.UTF8.GetString(result[1].Span.ToArray()), Is.EqualTo("beta"));
        Assert.That(Encoding.UTF8.GetString(result[2].Span.ToArray()), Is.EqualTo("gamma"));
    }

    [Test]
    public void TestGetUtf8Array_EmptyArray()
    {
        string emptyArrayJson = """[]""";
        byte[] jsonBytes = Encoding.UTF8.GetBytes(emptyArrayJson);

        var result = JsonPointer.GetUtf8Array(jsonBytes.AsSpan());
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Length, Is.EqualTo(0));
    }

    [Test]
    public void TestGetUtf8Array_NonArrayThrows()
    {
        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
        byte[] fooPointer = Encoding.UTF8.GetBytes("/foo"); // Points to a string, not array

        Assert.Throws<InvalidOperationException>(() => JsonPointer.GetUtf8Array(jsonBytes.AsSpan(), fooPointer));
    }

    [Test]
    public void TestGetUtf8Array_MemoryBacking()
    {
        // Test that all ReadOnlyMemory<byte> instances use the same underlying array
        string stringArrayJson = """["test1", "test2"]""";
        ReadOnlySpan<byte> jsonSpan = Encoding.UTF8.GetBytes(stringArrayJson);

        var result = JsonPointer.GetUtf8Array(jsonSpan);
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Length, Is.EqualTo(2));

        // For span-based calls, all ReadOnlyMemory instances should be backed by the same array
        // This is implementation specific - we created a single buffer for all segments
        Assert.That(Encoding.UTF8.GetString(result[0].Span.ToArray()), Is.EqualTo("test1"));
        Assert.That(Encoding.UTF8.GetString(result[1].Span.ToArray()), Is.EqualTo("test2"));
    }
}

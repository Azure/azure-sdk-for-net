// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Serialization;

[TestFixture]
public class CanonicalJsonTests
{
    private static JsonElement Parse(string json) => JsonDocument.Parse(json).RootElement;

    [Test]
    public void SortsObjectKeysOrdinally()
    {
        var bytes = CanonicalJson.SerializeToUtf8Bytes(Parse("{\"b\":1,\"a\":2,\"A\":3}"));
        // Ordinal order: uppercase 'A' (0x41) precedes lowercase 'a' (0x61) and 'b' (0x62).
        Assert.That(Encoding.UTF8.GetString(bytes), Is.EqualTo("{\"A\":3,\"a\":2,\"b\":1}"));
    }

    [Test]
    public void FormatsFloatsLikePythonJsonDumps()
    {
        // Golden output produced by CPython: json.dumps(vals, separators=(",", ":")). Float spelling
        // (trailing ".0", exponent form, and fixed-vs-exponential threshold) must match so canonical
        // content hashes of user JSON agree across languages.
        const string input =
            "[1.0,1.5,0.5,100.0,0.0,0.1,1e16,1e15,1e-4,1e-5,1.5e16,123456789012345.6,2.0,-3.25,9999999999999998.0,1e17,1e-7,3.141592653589793]";
        const string expected =
            "[1.0,1.5,0.5,100.0,0.0,0.1,1e+16,1000000000000000.0,0.0001,1e-05,1.5e+16,123456789012345.6,2.0,-3.25,9999999999999998.0,1e+17,1e-07,3.141592653589793]";
        var bytes = CanonicalJson.SerializeToUtf8Bytes(Parse(input));
        Assert.That(Encoding.UTF8.GetString(bytes), Is.EqualTo(expected));
    }

    [Test]
    public void EmitsLargeIntegersVerbatim()
    {
        var bytes = CanonicalJson.SerializeToUtf8Bytes(Parse("[123456789012345678901234567890,-42]"));
        Assert.That(Encoding.UTF8.GetString(bytes), Is.EqualTo("[123456789012345678901234567890,-42]"));
    }

    [Test]
    public void UsesCompactSeparators()
    {
        var bytes = CanonicalJson.SerializeToUtf8Bytes(Parse("{ \"x\" : [ 1 , 2 , 3 ] }"));
        Assert.That(Encoding.UTF8.GetString(bytes), Is.EqualTo("{\"x\":[1,2,3]}"));
    }

    [Test]
    public void SortsKeysInNestedObjects()
    {
        var bytes = CanonicalJson.SerializeToUtf8Bytes(Parse("{\"outer\":{\"z\":1,\"y\":2}}"));
        Assert.That(Encoding.UTF8.GetString(bytes), Is.EqualTo("{\"outer\":{\"y\":2,\"z\":1}}"));
    }

    [Test]
    public void EscapesNonAsciiAsLowercaseUnicode()
    {
        // 'é' (U+00E9) must escape to \u00e9 (lower-case hex), matching Python ensure_ascii=True.
        var bytes = CanonicalJson.SerializeToUtf8Bytes(Parse("{\"k\":\"caf\\u00e9\"}"));
        Assert.That(Encoding.UTF8.GetString(bytes), Is.EqualTo("{\"k\":\"caf\\u00e9\"}"));
    }

    [Test]
    public void EscapesControlCharactersWithShortForms()
    {
        var bytes = CanonicalJson.SerializeToUtf8Bytes(Parse("{\"k\":\"a\\nb\\tc\"}"));
        Assert.That(Encoding.UTF8.GetString(bytes), Is.EqualTo("{\"k\":\"a\\nb\\tc\"}"));
    }

    [Test]
    public void MeasuresByteSizeOfCanonicalForm()
    {
        Assert.That(CanonicalJson.MeasureByteSize(Parse("{\"a\":1}")), Is.EqualTo(7));
    }

    [Test]
    public void ProducesDeterministicBytesAcrossRuns()
    {
        var a = CanonicalJson.SerializeToUtf8Bytes(Parse("{\"b\":1,\"a\":{\"d\":4,\"c\":3}}"));
        var b = CanonicalJson.SerializeToUtf8Bytes(Parse("{\"a\":{\"c\":3,\"d\":4},\"b\":1}"));
        Assert.That(a, Is.EqualTo(b));
    }

    [Test]
    public void ComputeSha256Hex_Returns64LowercaseHexChars()
    {
        var hex = CanonicalJson.ComputeSha256Hex(Parse("{\"a\":1}"));
        Assert.That(hex, Has.Length.EqualTo(64));
        Assert.That(hex, Is.EqualTo(hex.ToLowerInvariant()));
    }
}

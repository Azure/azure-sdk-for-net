// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.ClientModel.Primitives;
using System.Text;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class JsonPathEqualityComparerTests
    {
        [TestCase("$['foo']", "$[\"foo\"]", true)]
        [TestCase("$.a['b.c']", "$.a.b.c", false)]
        [TestCase("$.x.y", "$['x'].y", true)]
        [TestCase("$.x.y", "$[\"x\"].y", true)]
        [TestCase("$.x.y", "$['x']['y']", true)]
        [TestCase("$.x.y", "$.x.y.z", false)]
        [TestCase("$.x.y", "$.x.z", false)]
        [TestCase("$.foo.bar", "$['foo']['bar']", true)]
        [TestCase("$.foo.bar", "$['foo\'']['bar']", false)]
        [TestCase("$.foo.bar", "$['fo\'o']['bar']", false)]
        [TestCase("$.foo.bar", "$[\"foo\"].bar", true)]
        [TestCase("$.foo.bar", "$[\"\"foo\"].bar", false)]
        [TestCase("$.foo.bar", "$[\"f\"oo\"].bar", false)]
        [TestCase("$.foo.bar", "$.foo.bar.baz", false)]
        [TestCase("$.foo.bar", "$.foo.baz", false)]
        [TestCase("$.a.b[0].c", "$['a'].b[0]['c']", true)]
        [TestCase("$.a.b[0].c", "$.a.b[1].c", false)]
        [TestCase("$.a.b[0].c", "$.a.b[0].d", false)]
        [TestCase("$.foo.bar[2].baz", "$['foo']['bar'][2]['baz']", true)]
        [TestCase("$.foo.bar[2].baz", "$.foo.bar[3].baz", false)]
        [TestCase("$.foo.bar[2].baz", "$.foo.bar[2].qux", false)]
        [TestCase("$.a.b[0].c.d[1]['e'].f", "$['a'].b[0]['c'].d[1][\"e\"].f", true)]
        [TestCase("$.a.b[0].c.d[1]['e'].f", "$.a.b[0].c.d[2]['e'].f", false)]
        [TestCase("$.a.b[0].c.d[1]['e'].f", "$.a.b[0].c.d[1]['e'].g", false)]
        [TestCase("$[\"f.oo\"]['bar']", "$['f.oo'].bar", true)]
        [TestCase("$['f.oo']['bar']", "$['f.oo'].bar", true)]
        [TestCase("$['']", "$.", true)]
        [TestCase("$['f.o.o']", "$['f.o.o']", true)]
        [TestCase("$['f.o.o']", "$.f.o.o", false)]
        [TestCase("$['mix\"quote']", "$['mix\"quote']", true)]
        public void Equals_ByteArray(string left, string right, bool expected)
        {
            var a = Encoding.UTF8.GetBytes(left);
            var b = Encoding.UTF8.GetBytes(right);
            Assert.AreEqual(expected, JsonPathComparer.Default.NormalizedEquals(a, b));

            Span<byte> buffer = stackalloc byte[Math.Max(a.Length, b.Length)];
            JsonPathComparer.Default.Normalize(a.AsSpan(), buffer, out int bytesWrittenA);
            var normalizedA = buffer.Slice(0, bytesWrittenA).ToArray();
            JsonPathComparer.Default.Normalize(b.AsSpan(), buffer, out int bytesWrittenB);
            var normalizedB = buffer.Slice(0, bytesWrittenB).ToArray();

            Assert.AreEqual(expected, JsonPathComparer.Default.Equals(normalizedA, normalizedB));
        }

        [Test]
        public void Equals_ByteArray_Same()
        {
            var a = "$.x"u8.ToArray();
            Assert.AreEqual(true, JsonPathComparer.Default.Equals(a, a));
        }

        [Test]
        public void Equals_ByteArray_Null()
        {
            var a = "$.x"u8.ToArray();
            Assert.AreEqual(false, JsonPathComparer.Default.Equals(a, null));
            Assert.AreEqual(false, JsonPathComparer.Default.Equals(null, a));
        }

        [TestCase("$.x.y", "$['x'].y", true)]
        [TestCase("$.x.y", "$[\"x\"].y", true)]
        [TestCase("$.x.y", "$['x']['y']", true)]
        [TestCase("$.x.y", "$.x.y.z", false)]
        [TestCase("$.x.y", "$.x.z", false)]
        [TestCase("$.foo.bar", "$['foo']['bar']", true)]
        [TestCase("$.foo.bar", "$['foo\'']['bar']", false)]
        [TestCase("$.foo.bar", "$['fo\'o']['bar']", false)]
        [TestCase("$.foo.bar", "$[\"foo\"].bar", true)]
        [TestCase("$.foo.bar", "$[\"\"foo\"].bar", false)]
        [TestCase("$.foo.bar", "$[\"f\"oo\"].bar", false)]
        [TestCase("$.foo.bar", "$.foo.bar.baz", false)]
        [TestCase("$.foo.bar", "$.foo.baz", false)]
        [TestCase("$.a.b[0].c", "$['a'].b[0]['c']", true)]
        [TestCase("$.a.b[0].c", "$.a.b[1].c", false)]
        [TestCase("$.a.b[0].c", "$.a.b[0].d", false)]
        [TestCase("$.foo.bar[2].baz", "$['foo']['bar'][2]['baz']", true)]
        [TestCase("$.foo.bar[2].baz", "$.foo.bar[3].baz", false)]
        [TestCase("$.foo.bar[2].baz", "$.foo.bar[2].qux", false)]
        [TestCase("$.a.b[0].c.d[1]['e'].f", "$['a'].b[0]['c'].d[1][\"e\"].f", true)]
        [TestCase("$.a.b[0].c.d[1]['e'].f", "$.a.b[0].c.d[2]['e'].f", false)]
        [TestCase("$.a.b[0].c.d[1]['e'].f", "$.a.b[0].c.d[1]['e'].g", false)]
        public void Equals_SpanToByteArray(string left, string right, bool expected)
        {
            var a = Encoding.UTF8.GetBytes(left);
            var b = Encoding.UTF8.GetBytes(right);
            Assert.AreEqual(expected, JsonPathComparer.Default.NormalizedEquals(a.AsSpan(), b));
        }

        [Test]
        public void Equals_SpanToNullByteArray()
        {
            var a = "$.x"u8.ToArray();
            Assert.AreEqual(false, JsonPathComparer.Default.Equals(a.AsSpan(), null!));
        }

        [TestCase("$['x'].y", "$.x.y")]
        [TestCase("$[\"x\"].y", "$.x.y")]
        [TestCase("$['x']['y']", "$.x.y")]
        [TestCase("$['foo']['bar']", "$.foo.bar")]
        [TestCase("$['foo\'']['bar']", "$.foo'.bar")]
        [TestCase("$['fo\'o']['bar']", "$.fo'o.bar")]
        [TestCase("$[\"foo\"].bar", "$.foo.bar")]
        [TestCase("$[\"\"foo\"].bar", "$.\"foo.bar")]
        [TestCase("$[\"f\"oo\"].bar", "$.f\"oo.bar")]
        [TestCase("$['a'].b[0]['c']", "$.a.b[0].c")]
        [TestCase("$[\"a\"].b[0].c", "$.a.b[0].c")]
        [TestCase("$['foo']['bar'][2]['baz']", "$.foo.bar[2].baz")]
        [TestCase("$['a'].b[0]['c'].d[1][\"e\"].f", "$.a.b[0].c.d[1].e.f")]
        [TestCase("$['a'].b[0][\"c\"].d[1].e.f", "$.a.b[0].c.d[1].e.f")]
        [TestCase("$['f.oo']['bar']", "$['f.oo'].bar")]
        [TestCase("$[\"f.oo\"]['bar']", "$['f.oo'].bar")]
        [TestCase("$['a'][\"b.c\"]['d']", "$.a['b.c'].d")]
        public void Normalize(string input, string expected)
        {
            var a = Encoding.UTF8.GetBytes(input);
            Span<byte> buffer = stackalloc byte[a.Length];
            JsonPathComparer.Default.Normalize(a.AsSpan(), buffer, out int bytesWritten);
            Assert.AreEqual(expected, Encoding.UTF8.GetString(buffer.Slice(0, bytesWritten).ToArray()));
        }

        [TestCase("$.x.y", "$['x'].y")]
        [TestCase("$.x.y", "$[\"x\"].y")]
        [TestCase("$.x.y", "$['x']['y']")]
        [TestCase("$.foo.bar", "$['foo']['bar']")]
        [TestCase("$.foo.bar", "$.foo.bar")]
        [TestCase("$.foo.bar", "$[\"foo\"].bar")]
        [TestCase("$.a.b[0].c", "$['a'].b[0]['c']")]
        [TestCase("$.foo.bar[2].baz", "$['foo']['bar'][2]['baz']")]
        [TestCase("$.a.b[0].c.d[1]['e'].f", "$['a'].b[0]['c'].d[1][\"e\"].f")]
        public void NormalizedHashCode(string left, string right)
        {
            var a = Encoding.UTF8.GetBytes(left);
            var b = Encoding.UTF8.GetBytes(right);
            Assert.AreEqual(JsonPathComparer.Default.GetNormalizedHashCode(a), JsonPathComparer.Default.GetNormalizedHashCode(b));

            Span<byte> buffer = stackalloc byte[Math.Max(a.Length, b.Length)];
            JsonPathComparer.Default.Normalize(a.AsSpan(), buffer, out int bytesWrittenA);
            var normalizedA = buffer.Slice(0, bytesWrittenA).ToArray();
            JsonPathComparer.Default.Normalize(b.AsSpan(), buffer, out int bytesWrittenB);
            var normalizedB = buffer.Slice(0, bytesWrittenB).ToArray();

            Assert.AreEqual(JsonPathComparer.Default.GetHashCode(normalizedA), JsonPathComparer.Default.GetHashCode(normalizedB));
        }
    }
}

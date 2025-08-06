// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.ClientModel.Primitives;
using System.Text;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class JsonPathEqualityComparerTests
    {
        // Equals(byte[], byte[])
        [TestCase("$.x.y", "$['x'].y", true)]
        [TestCase("$.x.y", "$[\"x\"].y", true)]
        [TestCase("$.x.y", "$['x']['y']", true)]
        [TestCase("$.x.y", "$.x.y.z", false)]
        [TestCase("$.x.y", "$.x.z", false)]
        public void Equals_ByteArray(string left, string right, bool expected)
        {
            var a = Encoding.UTF8.GetBytes(left);
            var b = Encoding.UTF8.GetBytes(right);
            Assert.AreEqual(expected, JsonPathEqualityComparer.Equals(a, b));
        }

        // Equals(ReadOnlySpan<byte>, byte[])
        [TestCase("$.foo.bar", "$['foo']['bar']", true)]
        [TestCase("$.foo.bar", "$[\"foo\"].bar", true)]
        [TestCase("$.foo.bar", "$.foo.bar.baz", false)]
        [TestCase("$.foo.bar", "$.foo.baz", false)]
        public void Equals_SpanAndByteArray(string left, string right, bool expected)
        {
            var a = Encoding.UTF8.GetBytes(left);
            var b = Encoding.UTF8.GetBytes(right);
            Assert.AreEqual(expected, JsonPathEqualityComparer.Equals(a.AsSpan(), b));
        }

        // Equals(ReadOnlySpan<byte>, ReadOnlySpan<byte>)
        [TestCase("$.a.b[0].c", "$['a'].b[0]['c']", true)]
        [TestCase("$.a.b[0].c", "$.a.b[1].c", false)]
        [TestCase("$.a.b[0].c", "$.a.b[0].d", false)]
        public void Equals_SpanAndSpan(string left, string right, bool expected)
        {
            var a = Encoding.UTF8.GetBytes(left);
            var b = Encoding.UTF8.GetBytes(right);
            Assert.AreEqual(expected, JsonPathEqualityComparer.Equals(a.AsSpan(), b.AsSpan()));
        }

        // Equals(JsonPathReader, JsonPathReader)
        [TestCase("$.foo.bar[2].baz", "$['foo']['bar'][2]['baz']", true)]
        [TestCase("$.foo.bar[2].baz", "$.foo.bar[3].baz", false)]
        [TestCase("$.foo.bar[2].baz", "$.foo.bar[2].qux", false)]
        public void Equals_JsonPathReader(string left, string right, bool expected)
        {
            var a = new JsonPathReader(left);
            var b = new JsonPathReader(right);
            Assert.AreEqual(expected, JsonPathEqualityComparer.Equals(a, b));
        }

        // Complex multi-layered paths
        [TestCase("$.a.b[0].c.d[1]['e'].f", "$['a'].b[0]['c'].d[1][\"e\"].f", true)]
        [TestCase("$.a.b[0].c.d[1]['e'].f", "$.a.b[0].c.d[2]['e'].f", false)]
        [TestCase("$.a.b[0].c.d[1]['e'].f", "$.a.b[0].c.d[1]['e'].g", false)]
        public void Equals_ComplexMultiLayeredPaths(string left, string right, bool expected)
        {
            var a = Encoding.UTF8.GetBytes(left);
            var b = Encoding.UTF8.GetBytes(right);
            Assert.AreEqual(expected, JsonPathEqualityComparer.Equals(a, b));
        }
    }
}

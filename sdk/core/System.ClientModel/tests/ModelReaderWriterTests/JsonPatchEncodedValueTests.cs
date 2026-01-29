// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class JsonPatchEncodedValueTests
    {
        [Test]
        public void GetNullFromBytes()
        {
            byte[] nullBytes = "null"u8.ToArray();
            JsonPatch.EncodedValue value = new(nullBytes);
            Assert.AreEqual(JsonPatch.ValueKind.Null, value.Kind);
            Assert.IsTrue(nullBytes.AsSpan().SequenceEqual(value.Value.Span));

            value = new(nullBytes.AsSpan());
            Assert.AreEqual(JsonPatch.ValueKind.Null, value.Kind);
            Assert.IsTrue(nullBytes.AsSpan().SequenceEqual(value.Value.Span));
        }

        [Test]
        public void GetBooleanTrueFromBytes()
        {
            byte[] trueBytes = "true"u8.ToArray();
            JsonPatch.EncodedValue trueValue = new(trueBytes);
            Assert.AreEqual(JsonPatch.ValueKind.BooleanTrue, trueValue.Kind);
            Assert.IsTrue(trueBytes.AsSpan().SequenceEqual(trueValue.Value.Span));

            trueValue = new(trueBytes.AsSpan());
            Assert.AreEqual(JsonPatch.ValueKind.BooleanTrue, trueValue.Kind);
            Assert.IsTrue(trueBytes.AsSpan().SequenceEqual(trueValue.Value.Span));
        }

        [Test]
        public void GetBooleanFalseFromBytes()
        {
            byte[] falseBytes = "false"u8.ToArray();
            JsonPatch.EncodedValue falseValue = new(falseBytes);
            Assert.AreEqual(JsonPatch.ValueKind.BooleanFalse, falseValue.Kind);
            Assert.IsTrue(falseBytes.AsSpan().SequenceEqual(falseValue.Value.Span));

            falseValue = new(falseBytes.AsSpan());
            Assert.AreEqual(JsonPatch.ValueKind.BooleanFalse, falseValue.Kind);
            Assert.IsTrue(falseBytes.AsSpan().SequenceEqual(falseValue.Value.Span));
        }
    }
}

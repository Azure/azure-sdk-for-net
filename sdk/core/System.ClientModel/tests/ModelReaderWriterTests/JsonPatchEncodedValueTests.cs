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
            Assert.That(value.Kind, Is.EqualTo(JsonPatch.ValueKind.Null));
            Assert.That(nullBytes.AsSpan().SequenceEqual(value.Value.Span), Is.True);

            value = new(nullBytes.AsSpan());
            Assert.AreEqual(JsonPatch.ValueKind.Null, value.Kind);
            Assert.That(nullBytes.AsSpan().SequenceEqual(value.Value.Span), Is.True);
        }

        [Test]
        public void GetBooleanTrueFromBytes()
        {
            byte[] trueBytes = "true"u8.ToArray();
            JsonPatch.EncodedValue trueValue = new(trueBytes);
            Assert.That(trueValue.Kind, Is.EqualTo(JsonPatch.ValueKind.BooleanTrue));
            Assert.That(trueBytes.AsSpan().SequenceEqual(trueValue.Value.Span), Is.True);

            trueValue = new(trueBytes.AsSpan());
            Assert.AreEqual(JsonPatch.ValueKind.BooleanTrue, trueValue.Kind);
            Assert.That(trueBytes.AsSpan().SequenceEqual(trueValue.Value.Span), Is.True);
        }

        [Test]
        public void GetBooleanFalseFromBytes()
        {
            byte[] falseBytes = "false"u8.ToArray();
            JsonPatch.EncodedValue falseValue = new(falseBytes);
            Assert.That(falseValue.Kind, Is.EqualTo(JsonPatch.ValueKind.BooleanFalse));
            Assert.That(falseBytes.AsSpan().SequenceEqual(falseValue.Value.Span), Is.True);

            falseValue = new(falseBytes.AsSpan());
            Assert.AreEqual(JsonPatch.ValueKind.BooleanFalse, falseValue.Kind);
            Assert.That(falseBytes.AsSpan().SequenceEqual(falseValue.Value.Span), Is.True);
        }
    }
}

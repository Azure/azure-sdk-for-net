// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RehydrationTokenTests
    {
        [Test]
        public void ThrowOnDeserializationWithNullRehydrationToken()
        {
            Assert.Throws<InvalidOperationException>(() => new RehydrationToken().DeserializeRehydrationToken(default, new ModelReaderWriterOptions("J")));
        }

        [Test]
        public void ThrowOnDeserializationWithRehydrationTokenNullRequiredMember()
        {
            // net462 doesn't play well with validating debug asserts
#if !NETFRAMEWORK
            var data = BinaryData.FromString("{\"requestMethod\": null}");
            Assert.That(() => ModelReaderWriter.Read(data, typeof(RehydrationToken)), Throws.Exception);
#endif
        }

        [Test]
        public void RoundTripForRehydrationToken()
        {
            var token = new RehydrationToken(Guid.NewGuid().ToString(), null, "headerSource", "nextRequestUri", "initialUri", RequestMethod.Get, "lastKnownLocation", OperationFinalStateVia.OperationLocation.ToString());
            var data = ModelReaderWriter.Write(token);
            var deserializedToken = ModelReaderWriter.Read(data, typeof(RehydrationToken));
            Assert.AreEqual(token, deserializedToken);
        }

        [Test]
        public void SerializeDefaultValue()
        {
            var data = ModelReaderWriter.Write(default(RehydrationToken));
            Assert.NotNull(data);
        }
    }
}

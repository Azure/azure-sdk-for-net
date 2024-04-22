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
            var data = BinaryData.FromString("{\"requestMethod\": null}");
            Assert.That(() => ModelReaderWriter.Read(data, typeof(RehydrationToken)), Throws.Exception);
        }

        [Test]
        public void RoundTripForRehydrationToken()
        {
            var token = new RehydrationToken(null, null, "headerSource", "nextRequestUri", "initialUri", RequestMethod.Get, "lastKnownLocation", OperationFinalStateVia.OperationLocation.ToString());
            var data = ModelReaderWriter.Write(token);
            var deserializedToken = ModelReaderWriter.Read(data, typeof(RehydrationToken));
            Assert.AreEqual(token, deserializedToken);
        }

        [Test]
        public void VerifyPublicMembers()
        {
            var headerSource = "None";
            var nextRequestUri = "nextRequestUri";
            var initialUri = "initialUri";
            var requestMethod = RequestMethod.Get;
            var lastKnownLocation = "lastKnownLocation";
            var finalStateVia = OperationFinalStateVia.OperationLocation.ToString();
            var token = new RehydrationToken(null, null, headerSource, nextRequestUri, initialUri, requestMethod, lastKnownLocation, finalStateVia);
            Assert.AreEqual(headerSource, token.HeaderSource);
            Assert.AreEqual(nextRequestUri, token.NextRequestUri);
            Assert.AreEqual(initialUri, token.InitialUri);
            Assert.AreEqual(requestMethod, token.RequestMethod);
            Assert.AreEqual(lastKnownLocation, token.LastKnownLocation);
            Assert.AreEqual(finalStateVia, token.FinalStateVia);
            Assert.AreEqual(NextLinkOperationImplementation.NotSet, token.Id);
            Assert.AreEqual(NextLinkOperationImplementation.RehydrationTokenVersion, token.Version);
        }

        [Test]
        public void SerializeDefaultValue()
        {
            var data = ModelReaderWriter.Write(default(RehydrationToken));
            Assert.NotNull(data);
        }
    }
}

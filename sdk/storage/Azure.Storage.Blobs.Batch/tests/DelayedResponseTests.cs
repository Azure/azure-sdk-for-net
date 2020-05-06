// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class DelayedResponseTests
    {
        [Test]
        public void DelayedResponseToStringDoesntThrow()
        {
            DelayedResponse delayedResponse = new DelayedResponse(new HttpMessage(new MockRequest(), new ResponseClassifier()));
            Assert.AreEqual("Status: NotSent, the batch has not been submitted yet", delayedResponse.ToString());
        }

        [Test]
        public void CompletedDelayedResponseToStringCallsBase()
        {
            DelayedResponse delayedResponse = new DelayedResponse(new HttpMessage(new MockRequest(), new ResponseClassifier()));
            delayedResponse.SetLiveResponse(new MockResponse(200, "Yay"), false);
            Assert.AreEqual("Status: 200, ReasonPhrase: Yay", delayedResponse.ToString());
        }
    }
}

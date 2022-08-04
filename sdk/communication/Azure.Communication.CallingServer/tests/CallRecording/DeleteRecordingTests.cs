// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    public class DeleteRecordingTests : CallingServerTestBase
    {
        private const string AmsDeleteUrl = "https://dummyurl.com/v1/objects/documentid";

        [Test]
        public void DeleteRecording_Returns200Ok()
        {
            CallAutomationClient callingServerClient = CreateMockCallingServerClient(200);
            var response = callingServerClient.GetCallRecording().DeleteRecording(new Uri(AmsDeleteUrl));
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [Test]
        public async Task DeleteRecordingAsync_Returns200Ok()
        {
            CallAutomationClient callingServerClient = CreateMockCallingServerClient(200);
            var response = await callingServerClient.GetCallRecording().DeleteRecordingAsync(new Uri(AmsDeleteUrl)).ConfigureAwait(false);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [Test]
        public void DeleteRecording_Returns404NotFound()
        {
            CallAutomationClient callingServerClient = CreateMockCallingServerClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callingServerClient.GetCallRecording().DeleteRecording(new Uri(AmsDeleteUrl)));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void DeleteRecording_Returns401Unauthorized()
        {
            CallAutomationClient callingServerClient = CreateMockCallingServerClient(401);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callingServerClient.GetCallRecording().DeleteRecording(new Uri(AmsDeleteUrl)));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 401);
        }
    }
}

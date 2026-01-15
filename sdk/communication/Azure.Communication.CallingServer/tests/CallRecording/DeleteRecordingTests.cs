// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    public class DeleteRecordingTests : CallAutomationTestBase
    {
        private const string AmsDeleteUrl = "https://dummyurl.com/v1/objects/documentid";

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void DeleteRecording_Returns200Ok()
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            var response = callAutomationClient.GetCallRecording().DeleteRecording(new Uri(AmsDeleteUrl));
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.OK));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task DeleteRecordingAsync_Returns200Ok()
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            var response = await callAutomationClient.GetCallRecording().DeleteRecordingAsync(new Uri(AmsDeleteUrl)).ConfigureAwait(false);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.OK));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void DeleteRecording_Returns404NotFound()
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.GetCallRecording().DeleteRecording(new Uri(AmsDeleteUrl)));
            Assert.NotNull(ex);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void DeleteRecording_Returns401Unauthorized()
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(401);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.GetCallRecording().DeleteRecording(new Uri(AmsDeleteUrl)));
            Assert.NotNull(ex);
            Assert.That(ex?.Status, Is.EqualTo(401));
        }
    }
}

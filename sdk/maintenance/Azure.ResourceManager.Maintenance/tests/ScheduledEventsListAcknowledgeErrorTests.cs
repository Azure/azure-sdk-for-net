// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Maintenance.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Maintenance.Tests
{
    public class ScheduledEventsListAcknowledgeErrorTests
    {
        private const string ResponseContent =
            "{\"error\":{\"code\":\"207\",\"message\":\"Some scheduled events could not be acknowledged.\",\"details\":[" +
            "{\"target\":\"00000000-0000-0000-0000-000000000000\",\"code\":\"Conflict\",\"message\":\"The event cannot be acknowledged.\"}," +
            "{\"target\":\"11111111-1111-1111-1111-111111111111\",\"code\":\"NotFound\",\"message\":\"The event was not found.\"}]}}";

        [Test]
        public void CanDeserializeResponseContent()
        {
            BinaryData content = BinaryData.FromString(ResponseContent);

            ScheduledEventsListAcknowledgeError result = ModelReaderWriter.Read<ScheduledEventsListAcknowledgeError>(content);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Error);
            Assert.AreEqual("207", result.Error.Code);
            Assert.AreEqual("Some scheduled events could not be acknowledged.", result.Error.Message);
            Assert.AreEqual(2, result.Error.Details.Count);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result.Error.Details[0].Target);
            Assert.AreEqual("Conflict", result.Error.Details[0].Code);
            Assert.AreEqual("The event cannot be acknowledged.", result.Error.Details[0].Message);
            Assert.AreEqual("11111111-1111-1111-1111-111111111111", result.Error.Details[1].Target);
            Assert.AreEqual("NotFound", result.Error.Details[1].Code);
            Assert.AreEqual("The event was not found.", result.Error.Details[1].Message);

            BinaryData roundTripContent = ModelReaderWriter.Write(result);
            ScheduledEventsListAcknowledgeError roundTripResult = ModelReaderWriter.Read<ScheduledEventsListAcknowledgeError>(roundTripContent);
            Assert.AreEqual(result.Error.Code, roundTripResult.Error.Code);
            Assert.AreEqual(result.Error.Details[0].Target, roundTripResult.Error.Details[0].Target);
        }

        [Test]
        public void CanDeserializeAcknowledgeListMultiStatusResponse()
        {
            var mockResponse = new MockResponse(207);
            mockResponse.SetContent(ResponseContent);
            var options = new ArmClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };
            var client = new ArmClient(new MockCredential(), "00000000-0000-0000-0000-000000000000", options);
            var scope = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm");
            var scheduledEventIds = new MaintenanceScheduledEventIdList(new[] { "00000000-0000-0000-0000-000000000000" });

            Response<MaintenanceScheduledEventApproveResult> response = client.AcknowledgeList(scope, scheduledEventIds);
            ScheduledEventsListAcknowledgeError result = ModelReaderWriter.Read<ScheduledEventsListAcknowledgeError>(response.GetRawResponse().Content);

            Assert.AreEqual(207, response.GetRawResponse().Status);
            Assert.AreEqual("207", result.Error.Code);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result.Error.Details[0].Target);
        }
    }
}
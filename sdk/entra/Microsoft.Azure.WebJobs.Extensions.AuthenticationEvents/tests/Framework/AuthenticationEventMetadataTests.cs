// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using NUnit.Framework;
using Payload = Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Framework
{
    [TestFixture]
    public class AuthenticationEventMetadataTests
    {
        [Test]
        [TestCaseSource(nameof(TestJsonPayloadScenarios))]
        public void TestRequestPayloadStructureInstance(object testObject, string message, bool success, string exceptionMessage)
        {
            string payload = testObject.ToString();
            if (success == false)
            {
                var ex = Assert.Throws<AuthenticationEventTriggerRequestValidationException>(() => AuthenticationEventMetadataLoader.GetEventMetadata(payload));
                Assert.AreEqual(exceptionMessage, ex.Message);
            }
            else
            {
                Assert.DoesNotThrow(() => AuthenticationEventMetadataLoader.GetEventMetadata(payload));
            }
        }

        [Test]
        [TestCaseSource(nameof(TestAttributeScenarios))]
        public void TestRequestAttributesCreateInstance(object testObject, string message, bool success, string exceptionMessage)
        {
            string payload = testObject.ToString();
            AuthenticationEventMetadata eventMetadata = AuthenticationEventMetadataLoader.GetEventMetadata(payload);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post,"https://localhost.net/");

            if (success == false)
            {
                var ex = Assert.Throws<AuthenticationEventTriggerRequestValidationException>(() => eventMetadata.CreateEventRequestValidate(requestMessage, payload, string.Empty));
                Assert.AreEqual(exceptionMessage, ex.Message);
            }
            else
            {
                Assert.DoesNotThrow(() => eventMetadata.CreateEventRequestValidate(requestMessage, payload, string.Empty));
            }
        }

        private static IEnumerable<object[]> TestJsonPayloadScenarios()
        {
#region Invalid
            yield return new TestCaseStructure()
            {
                Test = Payload.TokenIssuanceStart.RequestWithInvalidCharacter,
                Message = "Testing request payload with invalid character passed and verifies it throws an error",
                ExceptionMessage = "The JSON object contains a trailing comma at the end which is not supported in this mode. Change the reader options. LineNumber: 38 | BytePositionInLine: 6."
            }.ToArray;
#endregion

#region Valid
            yield return new TestCaseStructure()
            {
                Test = Payload.TokenIssuanceStart.ValidRequestPayload,
                Message = "Testing valid full request payload",
                Success = true,
            }.ToArray;
#endregion
        }

        private static IEnumerable<object[]> TestAttributeScenarios()
        {
#region Invalid
            yield return new TestCaseStructure()
            {
                Test = Payload.TokenIssuanceStart.RequestWithoutSourcePayload,
                Message = "Testing request payload without source field passed and verifies it throws an error",
                ExceptionMessage = "TokenIssuanceStartRequest: The Source field is required."
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = Payload.TokenIssuanceStart.RequestWithoutODataTypePayload,
                Message = "Testing request payload without ODataType field passed and verifies it throws an error",
                ExceptionMessage = "TokenIssuanceStartRequest: The ODataType field is required."
            }.ToArray;
#endregion

#region Valid
            yield return new TestCaseStructure()
            {
                Test = Payload.TokenIssuanceStart.ValidRequestPayload,
                Message = "Testing valid full request payload",
                Success = true,
            }.ToArray;
#endregion
        }
    }
}

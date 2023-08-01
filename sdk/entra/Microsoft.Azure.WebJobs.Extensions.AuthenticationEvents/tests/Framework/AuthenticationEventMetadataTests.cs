// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [TestCaseSource(nameof(TestScenarios))]
        public void TestRequestCreateInstance(object testObject, string message, bool success)
        {
            string payload = testObject.ToString();
            AuthenticationEventMetadata eventMetadata = AuthenticationEventMetadataLoader.GetEventMetadata(payload);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:7278/runtime/webhooks/customauthenticationextension?code=opVsbQul8-MsRuM9x6yVoghE2Xda5G-MeV_Ybv1MdEfuAzFuVtpEpg==&functionName=onTokenIssuanceStart");

            if (success == false)
            {
                var ex = Assert.Throws<ValidationException>(() => eventMetadata.CreateEventRequestValidate(requestMessage, payload, string.Empty));
            }
            else
            {
                Assert.DoesNotThrow(() => eventMetadata.CreateEventRequestValidate(requestMessage, payload, string.Empty));
            }
        }

        private static IEnumerable<object[]> TestScenarios()
        {
#region Invalid
            yield return new TestCaseStructure()
            {
                Test = Payload.TokenIssuanceStart.RequestWithoutSourcePayload,
                Message = "Testing request payload without source field passed and verifies it throws an error",
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;
using Payload = Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{
    [TestFixture]
    public class AuthenticationEventBindingTests
    {
        [Test]
        [TestCaseSource(nameof(TestPayloadScenarios))]
        public void TestRequestJsonPayload(object eventPayload, string message, bool success, string exceptionMessage)
        {
            string payload = eventPayload.ToString();
            if (success == false)
            {
                var ex = Assert.Throws<AuthenticationEventTriggerRequestValidationException>(() => AuthenticationEventBinding.GetEventAndValidateSchema(payload));
                Assert.AreEqual(exceptionMessage, ex.Message);
            }
            else
            {
                Assert.DoesNotThrow(() => AuthenticationEventBinding.GetEventAndValidateSchema(payload));
            }
        }

        private static IEnumerable<object[]> TestPayloadScenarios()
        {
#region Invalid
            yield return new TestCaseStructure()
            {
                Test = string.Empty,
                Message = "Testing request without payload throws an error",
                ExceptionMessage = "Invalid Json Payload: JSON is null or empty."
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = Payload.TokenIssuanceStart.RequestWithXmlBody,
                Message = "Testing request with XML payload throws an error",
                ExceptionMessage = "Invalid Json Payload: '<' is an invalid start of a value. LineNumber: 0 | BytePositionInLine: 0."
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

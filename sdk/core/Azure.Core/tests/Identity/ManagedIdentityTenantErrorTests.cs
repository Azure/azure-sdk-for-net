// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Core.Tests.Identity
{
    public class ManagedIdentityTenantErrorTests
    {
        internal const string DenialBody = """{"error":"invalid_request","error_codes":[3921996]}""";

        [TestCase(400, true)]
        [TestCase(401, true)]
        [TestCase(0, false)]
        [TestCase(200, false)]
        [TestCase(403, false)]
        [TestCase(429, false)]
        [TestCase(500, false)]
        public void RequiresTokenEndpointErrorStatus(int status, bool expected)
        {
            Assert.AreEqual(expected, MsalManagedIdentityClient.IsTenantNotAllowedForBoundToken(CreateDenial(status)));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("{")]
        [TestCase("null")]
        [TestCase("[]")]
        [TestCase("42")]
        [TestCase("""{"error_codes":3921996}""")]
        [TestCase("""{"error_codes":null}""")]
        [TestCase("""{"error_codes":[]}""")]
        [TestCase("""{"error_codes":["3921996"]}""")]
        [TestCase("""{"error_codes":[true]}""")]
        [TestCase("""{"error_codes":[392196]}""")]
        [TestCase("""{"error_codes":[3921996,1000604]}""")]
        [TestCase("""{"error_codes":[3921996],"error_codes":[3921996]}""")]
        [TestCase("""{"error":{"error_codes":[3921996]}}""")]
        [TestCase("""{"error_description":"AADSTS3921996: Tenant not allowed."}""")]
        [TestCase("""{"error":"MtlsClientPopTokenNotSupportedByResource"}""")]
        [TestCase("""{"error":"MtlsMsiTenantNotAllowedForBoundToken"}""")]
        public void RejectsUnrecognizedOrAmbiguousBody(string body)
        {
            var exception = new MsalServiceException("invalid_request", "AADSTS3921996: Tenant not allowed.", 400)
            {
                ResponseBody = body
            };

            Assert.IsFalse(MsalManagedIdentityClient.IsTenantNotAllowedForBoundToken(exception));
        }

        [Test]
        public void DoesNotSearchInnerExceptionsOrMessages()
        {
            var exception = new MsalServiceException("managed_identity_request_failed", "AADSTS3921996", CreateDenial());
            Assert.IsFalse(MsalManagedIdentityClient.IsTenantNotAllowedForBoundToken(exception));
        }

        internal static MsalServiceException CreateDenial(int status = 400) =>
            new("invalid_request", "Tenant not allowed.", status) { ResponseBody = DenialBody };
    }
}

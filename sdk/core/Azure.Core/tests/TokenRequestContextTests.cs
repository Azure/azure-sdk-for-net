// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure
{
    public class TokenRequestContextTests
    {
        [Test]
        public void TokenRequestContextCtor()
        {
            var scopes = new string[] { "scope1", "scope2" };
            var parentRequestId = Guid.NewGuid().ToString();
            var claims = "claims";
            var tenantId = Guid.NewGuid().ToString();
            var isCaeEnabled = true;
            var isProofOfPossessionEnabled = true;
            var proofOfPossessionNonce = Guid.NewGuid().ToString();
            var request = new MockRequest
            {
                Method = RequestMethod.Get
            };
            request.Uri.Reset(new Uri("http://example.com"));

            var context = new TokenRequestContext(scopes, parentRequestId, claims, tenantId, isCaeEnabled, isProofOfPossessionEnabled, proofOfPossessionNonce, request.Uri.ToUri(), request.Method.ToString());

            Assert.AreEqual(scopes, context.Scopes);
            Assert.AreEqual(parentRequestId, context.ParentRequestId);
            Assert.AreEqual(claims, context.Claims);
            Assert.AreEqual(tenantId, context.TenantId);
            Assert.AreEqual(isCaeEnabled, context.IsCaeEnabled);
            Assert.AreEqual(isProofOfPossessionEnabled, context.IsProofOfPossessionEnabled);
            Assert.AreEqual(proofOfPossessionNonce, context.ProofOfPossessionNonce);
            Assert.AreEqual(request.Method.ToString(), context.ResourceRequestMethod);
            Assert.AreEqual(request.Uri.ToUri(), context.ResourceRequestUri);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure
{
    public class PopTokenRequestContextTests
    {
        [Test]
        public void PopTokenRequestContextCtor()
        {
            var scopes = new string[] { "scope1", "scope2" };
            var parentRequestId = Guid.NewGuid().ToString();
            var claims = "claims";
            var tenantId = Guid.NewGuid().ToString();
            var isCaeEnabled = true;
            var isProofOfPossessionEnabled = true;
            var proofOfPossessionNonce = Guid.NewGuid().ToString();
            var request = new MockRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("http://example.com"));

            var context = new PopTokenRequestContext(scopes, parentRequestId, claims, tenantId, isCaeEnabled, isProofOfPossessionEnabled, proofOfPossessionNonce, request);

            Assert.AreEqual(scopes, context.Scopes);
            Assert.AreEqual(parentRequestId, context.ParentRequestId);
            Assert.AreEqual(claims, context.Claims);
            Assert.AreEqual(tenantId, context.TenantId);
            Assert.AreEqual(isCaeEnabled, context.IsCaeEnabled);
            Assert.AreEqual(isProofOfPossessionEnabled, context.IsProofOfPossessionEnabled);
            Assert.AreEqual(proofOfPossessionNonce, context.ProofOfPossessionNonce);
            Assert.AreEqual(new HttpMethod(request.Method.ToString()), context.HttpMethod);
            Assert.AreEqual(request.Uri.ToUri(), context.Uri);
        }
    }
}

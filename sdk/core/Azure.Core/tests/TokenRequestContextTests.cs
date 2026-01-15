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

            Assert.That(context.Scopes, Is.EqualTo(scopes));
            Assert.That(context.ParentRequestId, Is.EqualTo(parentRequestId));
            Assert.That(context.Claims, Is.EqualTo(claims));
            Assert.That(context.TenantId, Is.EqualTo(tenantId));
            Assert.That(context.IsCaeEnabled, Is.EqualTo(isCaeEnabled));
            Assert.That(context.IsProofOfPossessionEnabled, Is.EqualTo(isProofOfPossessionEnabled));
            Assert.That(context.ProofOfPossessionNonce, Is.EqualTo(proofOfPossessionNonce));
            Assert.That(context.ResourceRequestMethod, Is.EqualTo(request.Method.ToString()));
            Assert.That(context.ResourceRequestUri, Is.EqualTo(request.Uri.ToUri()));
        }
    }
}

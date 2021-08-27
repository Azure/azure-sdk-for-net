// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class OnBehalfOfCredentialTests : CredentialTestBase
    {
        public OnBehalfOfCredentialTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task UsesTenantIdHint(
            [Values(null, TenantIdHint)] string tenantId,
            [Values(true)] bool allowMultiTenantAuthentication,
            [Values(null, TenantId)] string explicitTenantId)
        {
            TestSetup();
            options = new OnBehalfOfCredentialOptions();
            options.AllowMultiTenantAuthentication = allowMultiTenantAuthentication;
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(explicitTenantId, context, options.AllowMultiTenantAuthentication);
            OnBehalfOfCredential client = InstrumentClient(
                new OnBehalfOfCredential(
                    TenantId,
                    ClientId,
                    "secret",
                    expectedUserAssertion,
                    options as OnBehalfOfCredentialOptions,
                    null,
                    mockConfidentialMsalClient));

            var token = await client.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");
        }
    }
}

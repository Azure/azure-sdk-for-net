// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class OnBehalfOfCredentialTests : ClientTestBase
    {
        private const string Scope = "https://vault.azure.net/.default";
        private const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private const string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        private string expectedToken;
        private string expectedUserAssertion;
        private string expectedTenantId;
        private DateTimeOffset expiresOn;
        private MockMsalConfidentialClient mockMsalClient;
        private TokenCredentialOptions options;
        private AuthenticationResult result;

        public OnBehalfOfCredentialTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task UsesTenantIdHint(
            [Values(true, false)] bool usePemFile,
            [Values(null, TenantIdHint)] string tenantId,
            [Values(true)] bool allowMultiTenantAuthentication)
        {
            TestSetup();
            options.AllowMultiTenantAuthentication = allowMultiTenantAuthentication;
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(TenantId, context, options.AllowMultiTenantAuthentication);
            OnBehalfOfCredential client = InstrumentClient(new OnBehalfOfCredential(TenantId, ClientId, "secret", options, null, mockMsalClient));

            using (_ = new UserAssertionScope(expectedUserAssertion))
            {
                var token = await client.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);
                Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");
            }
        }

        [Test]
        public async Task UserAssertionScopeIsConsistent()
        {
            TestSetup();
            expectedTenantId = TenantId;
            OnBehalfOfCredential client = InstrumentClient(new OnBehalfOfCredential(expectedTenantId, ClientId, "secret", options, null, mockMsalClient));

            var evt = new ManualResetEventSlim(false);
            int count = 100;
            int getTokenCalledCount = 0;
            List<Task> tasks = new(count);
            List<string> expectedUserAssertions = Enumerable.Range(1, count).Select(_ => Guid.NewGuid().ToString()).ToList();
            mockMsalClient.WithOnBehalfOfFactory(
                (scopes, _, userAssertion, _, _) =>
                {
                    Interlocked.Increment(ref getTokenCalledCount);
                    int i = int.Parse(scopes[0]);
                    Assert.AreEqual(expectedUserAssertions[i], userAssertion.Assertion);
                    return new ValueTask<AuthenticationResult>(result);
                });

            for (int i = 0; i < count; i++)
            {
                tasks.Add(
                    Task.Factory.StartNew(
                        index =>
                        {
                            int ii = (int)index;
                            evt.Wait();
                            Task.Yield().GetAwaiter().GetResult();
                            using (_ = new UserAssertionScope(expectedUserAssertions[ii]))
                            {
                                client.GetTokenAsync(new TokenRequestContext(new[] { ii.ToString() }), default).GetAwaiter().GetResult();
                            }
                        },
                        i,
                        CancellationToken.None));
            }
            evt.Set();
            await Task.WhenAll(tasks);
            Assert.AreEqual(count, tasks.Count, "Task count should be correct");
            Assert.AreEqual(count, getTokenCalledCount, "getTokenCalledCount should be correct");
        }

        public void TestSetup()
        {
            options = new TokenCredentialOptions();
            expectedToken = Guid.NewGuid().ToString();
            expectedUserAssertion = Guid.NewGuid().ToString();
            expiresOn = DateTimeOffset.Now.AddHours(1);
            result = new AuthenticationResult(
                expectedToken,
                false,
                null,
                expiresOn,
                expiresOn,
                TenantId,
                new MockAccount("username"),
                null,
                new[] { Scope },
                Guid.NewGuid(),
                null,
                "Bearer");

            mockMsalClient = new MockMsalConfidentialClient().WithOnBehalfOfFactory(
                (_, _, userAssertion, _, _) =>
                {
                    Assert.AreEqual(expectedUserAssertion, userAssertion.Assertion);
                    return new ValueTask<AuthenticationResult>(result);
                });
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
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
                new OnBehalfOfCredential(TenantId, ClientId, "secret", options as OnBehalfOfCredentialOptions, null, mockConfidentialMsalClient));

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
            options = new OnBehalfOfCredentialOptions();
            OnBehalfOfCredential client = InstrumentClient(
                new OnBehalfOfCredential(expectedTenantId, ClientId, "secret", options as OnBehalfOfCredentialOptions, null, mockConfidentialMsalClient));

            var evt = new ManualResetEventSlim(false);
            int count = 100;
            int getTokenCalledCount = 0;
            List<Task> tasks = new(count);
            List<string> expectedUserAssertions = Enumerable.Range(1, count).Select(_ => Guid.NewGuid().ToString()).ToList();
            mockConfidentialMsalClient.WithOnBehalfOfFactory(
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

        public class TestInMemoryTokenCacheOptions : UnsafeTokenCacheOptions
        {
            private readonly ReadOnlyMemory<byte> _bytes = ReadOnlyMemory<byte>.Empty;
            private readonly Func<TokenCacheUpdatedArgs, Task> _updated;

            public TestInMemoryTokenCacheOptions(Func<TokenCacheUpdatedArgs, Task> updated = null)
            {
                _updated = updated;
            }

            protected internal override Task<ReadOnlyMemory<byte>> RefreshCacheAsync() { throw new NotImplementedException(); }

            protected internal override Task<UserAssertionCacheDetails> RefreshCacheAsync(TokenCacheNotificationDetails details)
            {
                return Task.FromResult(new UserAssertionCacheDetails { CacheBytes = _bytes });
            }

            protected internal override Task TokenCacheUpdatedAsync(TokenCacheUpdatedArgs tokenCacheUpdatedArgs)
            {
                return _updated == null ? Task.CompletedTask : _updated(tokenCacheUpdatedArgs);
            }
        }
    }
}

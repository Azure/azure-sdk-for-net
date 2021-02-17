// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Microsoft.Identity.Client;
using Moq;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class TokenCacheTests : ClientTestBase
    {
        public TokenCacheTests(bool isAsync) : base(isAsync)
        { }

        public static Random random = new Random();
        public TokenCache cache;
        public byte[] bytes = new byte[] { 1, 0 };
        public byte[] updatedBytes = new byte[] { 0, 2 };
        public byte[] mergedBytes = new byte[] { 1, 2 };
        public Mock<ITokenCacheSerializer> mockSerializer1;
        public Mock<ITokenCacheSerializer> mockSerializer2;
        public Mock<ITokenCache> mockMSALCache;
        public Func<TokenCacheNotificationArgs, Task> main_OnBeforeCacheAccessAsync = null;
        public Func<TokenCacheNotificationArgs, Task> main_OnAfterCacheAccessAsync = null;
        public TokenCacheCallback merge_OnBeforeCacheAccessAsync = null;
        public TokenCacheCallback merge_OnAfterCacheAccessAsync = null;

        [SetUp]
        public void Setup()
        {
            cache = new TokenCache(bytes);
            mockSerializer1 = new Mock<ITokenCacheSerializer>();
            mockSerializer2 = new Mock<ITokenCacheSerializer>();
            mockMSALCache = new Mock<ITokenCache>();
        }

        [Test]
        public void ConstructorInitializesCache()
        {
            Assert.That(cache.Data, Is.EquivalentTo(bytes));
        }

        [Test]
        public async Task RegisterCacheInitializesEvents()
        {
            await cache.RegisterCache(IsAsync, mockMSALCache.Object, default);

            mockMSALCache.Verify(m => m.SetBeforeAccessAsync(It.IsAny<Func<TokenCacheNotificationArgs, Task>>()), Times.Once);
            mockMSALCache.Verify(m => m.SetAfterAccessAsync(It.IsAny<Func<TokenCacheNotificationArgs, Task>>()), Times.Once);
        }

        [Test]
        public async Task RegisterCacheInitializesEventsOnlyOnce()
        {
            await cache.RegisterCache(IsAsync, mockMSALCache.Object, default);
            await cache.RegisterCache(IsAsync, mockMSALCache.Object, default);

            mockMSALCache.Verify(m => m.SetBeforeAccessAsync(It.IsAny<Func<TokenCacheNotificationArgs, Task>>()), Times.Once);
            mockMSALCache.Verify(m => m.SetAfterAccessAsync(It.IsAny<Func<TokenCacheNotificationArgs, Task>>()), Times.Once);
        }

        [Test]
        public async Task RegisteredEventsAreCalledOnFirstUpdate()
        {
            TokenCacheNotificationArgs mockArgs = GetMockArgs(mockSerializer1, true);
            bool updatedCalled = false;

            mockMSALCache
                .Setup(m => m.SetBeforeAccessAsync(It.IsAny<Func<TokenCacheNotificationArgs, Task>>()))
                .Callback<Func<TokenCacheNotificationArgs, Task>>(beforeAccess => main_OnBeforeCacheAccessAsync = beforeAccess);
            mockMSALCache
                .Setup(m => m.SetAfterAccessAsync(It.IsAny<Func<TokenCacheNotificationArgs, Task>>()))
                .Callback<Func<TokenCacheNotificationArgs, Task>>(afterAccess => main_OnAfterCacheAccessAsync = afterAccess);

            mockSerializer1.Setup(m => m.SerializeMsalV3()).Returns(bytes);

            cache.Updated += (args) =>
            {
                updatedCalled = true;
                return Task.CompletedTask;
            };

            await cache.RegisterCache(IsAsync, mockMSALCache.Object, default);
            await main_OnBeforeCacheAccessAsync.Invoke(mockArgs);
            await main_OnAfterCacheAccessAsync.Invoke(mockArgs);

            mockSerializer1.Verify(m => m.DeserializeMsalV3(cache.Data, true), Times.Once);
            mockSerializer1.Verify(m => m.SerializeMsalV3(), Times.Once);
            Assert.That(updatedCalled);
        }

        [Test]
        public async Task MergeOccursOnSecondUpdate()
        {
            var mockPublicClient = new Mock<IPublicClientApplication>();
            var mergeMSALCache = new Mock<ITokenCache>();
            TokenCacheNotificationArgs mockArgs1 = GetMockArgs(mockSerializer1, true);
            TokenCacheNotificationArgs mockArgs2 = GetMockArgs(mockSerializer2, true);

            mockMSALCache
                .Setup(m => m.SetBeforeAccessAsync(It.IsAny<Func<TokenCacheNotificationArgs, Task>>()))
                .Callback<Func<TokenCacheNotificationArgs, Task>>(beforeAccess => main_OnBeforeCacheAccessAsync = beforeAccess);
            mockMSALCache
                .Setup(m => m.SetAfterAccessAsync(It.IsAny<Func<TokenCacheNotificationArgs, Task>>()))
                .Callback<Func<TokenCacheNotificationArgs, Task>>(afterAccess => main_OnAfterCacheAccessAsync = afterAccess);
            mergeMSALCache
                .Setup(m => m.SetBeforeAccess(It.IsAny<TokenCacheCallback>()))
                .Callback<TokenCacheCallback>(beforeAccess =>
                {
                    merge_OnBeforeCacheAccessAsync = beforeAccess;
                });
            mergeMSALCache
                .Setup(m => m.SetAfterAccess(It.IsAny<TokenCacheCallback>()))
                .Callback<TokenCacheCallback>(afterAccess => merge_OnAfterCacheAccessAsync = afterAccess);
            mockSerializer1
                .SetupSequence(m => m.SerializeMsalV3())
                .Returns(bytes)
                .Returns(mergedBytes);
            mockSerializer2
                .SetupSequence(m => m.SerializeMsalV3())
                .Returns(updatedBytes);
            mockPublicClient
                .SetupGet(m => m.UserTokenCache).Returns(mergeMSALCache.Object);
            mockPublicClient
                .Setup(m => m.GetAccountsAsync())
                .ReturnsAsync(() => new List<IAccount>())
                .Callback(() =>
                {
                    merge_OnBeforeCacheAccessAsync(mockArgs1);
                    var list = merge_OnBeforeCacheAccessAsync.GetInvocationList();
                    if (merge_OnAfterCacheAccessAsync != null)
                        merge_OnAfterCacheAccessAsync(mockArgs1);
                });

            cache = new TokenCache(bytes, new (() => mockPublicClient.Object));

            await cache.RegisterCache(IsAsync, mockMSALCache.Object, default);
            await cache.RegisterCache(IsAsync, mergeMSALCache.Object, default);

            // Read the cache from consumer 1.
            await main_OnBeforeCacheAccessAsync.Invoke(mockArgs1);
            // Read and write the cache from consumer 2.
            await main_OnBeforeCacheAccessAsync.Invoke(mockArgs2);
            // Dealy to ensure that the timestamps are different between last read and last updated.
            await Task.Delay(100);
            await main_OnAfterCacheAccessAsync.Invoke(mockArgs2);
            // Consumer 1 now writes, and must update its cache first.
            await main_OnAfterCacheAccessAsync.Invoke(mockArgs1);

            mockSerializer1.Verify(m => m.DeserializeMsalV3(bytes, true), Times.Exactly(1));
            mockSerializer1.Verify(m => m.SerializeMsalV3(), Times.Exactly(2));
            mockSerializer1.Verify(m => m.DeserializeMsalV3(bytes, false), Times.Exactly(1));
            mockSerializer1.Verify(m => m.DeserializeMsalV3(updatedBytes, false), Times.Exactly(1));
            mockSerializer2.Verify(m => m.DeserializeMsalV3(bytes, true), Times.Exactly(1));
            mockSerializer2.Verify(m => m.SerializeMsalV3(), Times.Exactly(1));

            // validate that we ended up with the merged cache.
            Assert.That(cache.Data, Is.EqualTo(mergedBytes));
        }

        private static TokenCacheNotificationArgs GetMockArgs(Mock<ITokenCacheSerializer> mockSerializer, bool hasStateChanged)
        {
            TokenCacheNotificationArgs mockArgs = (TokenCacheNotificationArgs)FormatterServices.GetUninitializedObject(typeof(TokenCacheNotificationArgs));
            var ctor = typeof(TokenCacheNotificationArgs).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            mockArgs = (TokenCacheNotificationArgs)ctor[0].Invoke(new object[] { mockSerializer.Object, "foo", null, hasStateChanged, true, true, null });
            return mockArgs;
        }
    }
}

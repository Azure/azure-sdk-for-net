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
    public class PersistentTokenCacheTests : ClientTestBase
    {
        public PersistentTokenCacheTests(bool isAsync) : base(isAsync)
        { }

        public static Random random = new Random();
        public PersistentTokenCache cache;
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
            cache = new PersistentTokenCache();
            mockSerializer1 = new Mock<ITokenCacheSerializer>();
            mockSerializer2 = new Mock<ITokenCacheSerializer>();
            mockMSALCache = new Mock<ITokenCache>();
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void DefaultConstructorInitializesAllowUnencryptedStorage(bool allowUnencryptedStorage)
        {
            cache = new PersistentTokenCache(allowUnencryptedStorage);
            Assert.That(cache._allowUnencryptedStorage, Is.EqualTo(allowUnencryptedStorage));
        }

        public static IEnumerable<object[]> PersistentCacheOptions()
        {
            yield return new object[] { new PersistentTokenCacheOptions { AllowUnencryptedStorage = true, Name = "foo" }, true, "foo" };
            yield return new object[] { new PersistentTokenCacheOptions { AllowUnencryptedStorage = false, Name = "bar" }, false, "bar" };
            yield return new object[] { new PersistentTokenCacheOptions { AllowUnencryptedStorage = false }, false, null };
            yield return new object[] { new PersistentTokenCacheOptions { Name = "fizz" }, false, "fizz" };
            yield return new object[] { new PersistentTokenCacheOptions(), false, null };
        }

        [Test]
        [TestCaseSource(nameof(PersistentCacheOptions))]
        public void DefaultConstructorInitializesAllowUnencryptedStorage(PersistentTokenCacheOptions options, bool expectedAllowUnencryptedStorage, string expectedName)
        {
            cache = new PersistentTokenCache(options);
            Assert.That(cache._allowUnencryptedStorage, Is.EqualTo(expectedAllowUnencryptedStorage));
            Assert.That(cache._name, Is.EqualTo(expectedName));
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
        public async Task RegisterCacheUnencryptedInitializesCache()
        {
            cache = new PersistentTokenCache(true);
            await cache.RegisterCache(IsAsync, mockMSALCache.Object, default);
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

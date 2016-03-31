//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.


using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Core;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace KeyVault.Extensions.Tests
{
    public class CachingKeyResolverTests
    {
        private const string KeyId  = "keyID";
        private const string KeyId2 = "keyID2";
        private const string KeyId3 = "keyID3";

        /// <summary>
        /// Test capacity and trimming of <see cref="CachingKeyResolver"/>
        /// </summary>
        [Fact]
        public async Task KeyVault_CapacityLimitOfCachingKeyResolver()
        {
            var mockedResolver = new Mock<IKeyResolver>();
            var ct = default(CancellationToken);

            mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId, ct))
                .Returns(Task.FromResult<IKey>(new RsaKey(KeyId)));
            mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId2, ct))
                .Returns(Task.FromResult<IKey>(new RsaKey(KeyId2)));
            mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId3, ct))
                .Returns(Task.FromResult<IKey>(new RsaKey(KeyId3)));

            using (var resolver = new CachingKeyResolver(2, mockedResolver.Object))
            {
                // Three items are added to the cache and because the size of the cache is 2
                // after the third key is added the least recently used (LRU) key (first key) is evicted
                await resolver.ResolveKeyAsync(KeyId, ct);
                await resolver.ResolveKeyAsync(KeyId2, ct);
                await resolver.ResolveKeyAsync(KeyId3, ct);

                // First Key is evicted; so it is going to be added to the cache again when its key is resolved
                // and second key is evicted to open space for first key as it is the LRU key
                await resolver.ResolveKeyAsync(KeyId2, ct);
                await resolver.ResolveKeyAsync(KeyId3, ct);
                await resolver.ResolveKeyAsync(KeyId, ct);
                await resolver.ResolveKeyAsync(KeyId3, ct);
            }

            mockedResolver.Verify(r => r.ResolveKeyAsync(KeyId2, ct), Times.Once());
            mockedResolver.Verify(r => r.ResolveKeyAsync(KeyId3, ct), Times.Once());
            mockedResolver.Verify(r => r.ResolveKeyAsync(KeyId, ct), Times.Exactly(2));
        }

        /// <summary>
        /// Test resolving a key that throws and gets removed from cache
        /// </summary>
        [Fact]
        public async Task KeyVault_CachingKeyResolverThrows()
        {
            var mockedResolver = new Mock<IKeyResolver>();
            var ct = default(CancellationToken);

            using (var resolver = new CachingKeyResolver(10, mockedResolver.Object))
            {
                // Throws
                mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId, ct))
                    .Throws(new EmptyException());
                try
                {
                    await resolver.ResolveKeyAsync(KeyId, ct);
                }
                catch (EmptyException) { }

                // Throws async
                mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId, ct))
                    .ThrowsAsync(new FalseException("test"));
                try
                {
                    await resolver.ResolveKeyAsync(KeyId, ct);
                }
                catch (FalseException) { }

                // Succeeds and caches
                mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId, ct))
                    .Returns(Task.FromResult<IKey>(new RsaKey(KeyId)));
                await resolver.ResolveKeyAsync(KeyId, ct);
                await resolver.ResolveKeyAsync(KeyId, ct);
                resolver.Dispose();
            }

            mockedResolver.Verify(r => r.ResolveKeyAsync(KeyId, ct), Times.Exactly(3));
        }

        /// <summary>
        /// Test multi-thread safty of <see cref="CachingKeyResolver"/>
        /// </summary>
        [Fact]
        public void KeyVault_CachingKeyResolverGetAndAddThreadSafety()
        {
            const int parallelThreads = 10;
            var mockedResolver = new Mock<IKeyResolver>();
            var ct = default(CancellationToken);

            mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId, ct))
                .Returns(() => Task.FromResult<IKey>(new RsaKey(KeyId)));

            using (var resolver = new CachingKeyResolver(5, mockedResolver.Object))
            {
                var tasks = new List<Task>();
                for (var i = 0; i < parallelThreads; i++)
                {
                    tasks.Add(Task.Run(() => resolver.ResolveKeyAsync(KeyId, ct), ct));
                }
                Task.WaitAll(tasks.ToArray());
            }
        }

        /// <summary>
        /// Test multi-thread safty of size limit <see cref="CachingKeyResolver"/>
        /// </summary>
        [Fact]
        public void KeyVault_CachingKeyResolverCapacityThreadSafety()
        {
            const int parallelThreads = 30;
            var mockedResolver = new Mock<IKeyResolver>();
            var ct = default(CancellationToken);

            mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId, ct))
                .Returns(() => Task.FromResult<IKey>(new RsaKey(KeyId)));
            mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId2, ct))
                .Returns(() => Task.FromResult<IKey>(new RsaKey(KeyId2)));
            mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId3, ct))
                .Returns(() => Task.FromResult<IKey>(new RsaKey(KeyId3)));

            using (var resolver = new CachingKeyResolver(2, mockedResolver.Object))
            {
                var tasks = new List<Task>();
                for (var i = 0; i < parallelThreads; i += 3)
                {
                    tasks.Add(Task.Run(() => resolver.ResolveKeyAsync(KeyId, ct), ct));

                    tasks.Add(Task.Run(() => resolver.ResolveKeyAsync(KeyId, ct), ct));

                    tasks.Add(Task.Run(() => resolver.ResolveKeyAsync(KeyId, ct), ct));
                }
                Task.WaitAll(tasks.ToArray());
            }
        }

        /// <summary>
        /// Test disposing key after cache is disposed in <see cref="CachingKeyResolver"/>
        /// </summary>
        [Fact]
        public async Task KeyVault_CachingKeyResolverKeyIsDisposed()
        {
            var mockedResolver = new Mock<IKeyResolver>();
            var mockedKey = new Mock<IKey>();
            var ct = default(CancellationToken);

            mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId, ct))
                .Returns(Task.FromResult(mockedKey.Object));

            using (var resolver = new CachingKeyResolver(2, mockedResolver.Object))
            {
                await resolver.ResolveKeyAsync(KeyId, ct);
            }

            mockedKey.Verify(k => k.Dispose(), Times.Once);
        }

        /// <summary>
        /// Test disposing a key while it is cached in <see cref="CachingKeyResolver"/>
        /// </summary>
        [Fact]
        public async Task KeyVault_CachingKeyResolverDisposeCachedKey()
        {
            var mockedResolver = new Mock<IKeyResolver>();
            var mockedKey = new Mock<IKey>();
            var ct = default(CancellationToken);

            mockedResolver.Setup(r => r.ResolveKeyAsync(KeyId, ct))
                .Returns(Task.FromResult(mockedKey.Object));

            using (var resolver = new CachingKeyResolver(2, mockedResolver.Object))
            {
                var cachedKey = await resolver.ResolveKeyAsync(KeyId, ct);

                // key doesn't get disposed because dispose of key is disabled
                cachedKey.Dispose();
                mockedKey.Verify(k => k.Dispose(), Times.Never);

                await resolver.ResolveKeyAsync(KeyId, ct);
            }

            // Dispose on key is only called when cache is disposing
            mockedKey.Verify(k => k.Dispose(), Times.Exactly(1));
            mockedResolver.Verify(r => r.ResolveKeyAsync(KeyId, ct), Times.Exactly(1));
        }
    }
}

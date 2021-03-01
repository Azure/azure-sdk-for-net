// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Identity.Client;

using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class TokenCacheSerializerTests
    {
        private const int TestBufferSize = 512;
        private static Random rand = new Random();

        [Test]
        public void AuthenticationRecordConstructor()
        {
            var record = new AuthenticationRecord(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                $"{Guid.NewGuid()}.{Guid.NewGuid()}", Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            IAccount account = (AuthenticationAccount)record;
            Assert.NotNull(account.Username);
            Assert.NotNull(account.Environment);
            Assert.NotNull(account.HomeAccountId.Identifier);
            Assert.NotNull(account.HomeAccountId.ObjectId);
            Assert.NotNull(account.HomeAccountId.TenantId);
        }

        public static IEnumerable<object[]> InvalidCtorArgs()
        {
            yield return new object[] { null, null };
            yield return new object[] { new TokenCache(), null };
            yield return new object[] { null, new MemoryStream() };
        }

        [Test]
        [TestCaseSource(nameof(InvalidCtorArgs))]
        public void SerializeInputChecks(TokenCache cache, Stream stream)
        {
            Assert.Throws<ArgumentNullException>(() => TokenCacheSerializer.Serialize(cache, stream));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await TokenCacheSerializer.SerializeAsync(cache, stream));
        }

        [Test]
        public void DeserializeInputChecks()
        {
            Assert.Throws<ArgumentNullException>(() => TokenCacheSerializer.Deserialize(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await TokenCacheSerializer.DeserializeAsync(null));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task Serialize(bool async)
        {
            byte[] buff = new byte[TestBufferSize];
            rand.NextBytes(buff);
            var expectedStream = new MemoryStream(buff);
            var actualStream = new MemoryStream();

            var cache = new TokenCache(buff);
            if (async)
            {
                await TokenCacheSerializer.SerializeAsync(cache, actualStream);
            }
            else
            {
                TokenCacheSerializer.Serialize(cache, actualStream);
            }

            expectedStream.Position = 0;
            actualStream.Position = 0;

            Assert.That(expectedStream.Length, Is.EqualTo(actualStream.Length));
            Assert.That(expectedStream.ToArray(), Is.EquivalentTo(actualStream.ToArray()));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeSerialize(bool async)
        {
            byte[] buff = new byte[TestBufferSize];
            rand.NextBytes(buff);
            var stream = new MemoryStream(buff);

            var expectedCache = new TokenCache(buff);
            TokenCache actualCache;

            if (async)
            {
                actualCache = await TokenCacheSerializer.DeserializeAsync(stream);
            }
            else
            {
                actualCache = TokenCacheSerializer.Deserialize(stream);
            }

            Assert.That(actualCache.Data, Is.EquivalentTo(buff));
        }
    }
}

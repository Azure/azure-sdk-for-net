// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Identity.Client;

using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AuthenticationRecordTests
    {
        private const int TestBufferSize = 512;

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

        [Test]
        public void SerializeDeserializeInputChecks()
        {
            var record = new AuthenticationRecord(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            Assert.Throws<ArgumentNullException>(() => record.Serialize(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await record.SerializeAsync(null));
            Assert.Throws<ArgumentNullException>(() => AuthenticationRecord.Deserialize(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await AuthenticationRecord.DeserializeAsync(null));
        }

        [Test]
        public async Task SerializeDeserializeAsync()
        {
            var expRecord = new AuthenticationRecord(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), $"{Guid.NewGuid()}.{Guid.NewGuid()}", Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            byte[] buff = new byte[TestBufferSize];

            var stream = new MemoryStream(buff);

            await expRecord.SerializeAsync(stream);
            IAccount expAccount = (AuthenticationAccount)expRecord;

            stream = new MemoryStream(buff, 0, (int)stream.Position);

            var actRecord = await AuthenticationRecord.DeserializeAsync(stream);
            IAccount actAccount = (AuthenticationAccount)actRecord;

            Assert.AreEqual(expRecord.Username, actRecord.Username);
            Assert.AreEqual(expRecord.Authority, actRecord.Authority);
            Assert.AreEqual(expRecord.HomeAccountId, actRecord.HomeAccountId);
            Assert.AreEqual(expRecord.TenantId, actRecord.TenantId);
            Assert.AreEqual(expRecord.ClientId, actRecord.ClientId);
            Assert.AreEqual(expRecord.Version, actRecord.Version);

            Assert.AreEqual(expAccount.Username, actAccount.Username);
            Assert.AreEqual(expAccount.Environment, actAccount.Environment);
            Assert.AreEqual(expAccount.HomeAccountId.Identifier, actAccount.HomeAccountId.Identifier);
            Assert.AreEqual(expAccount.HomeAccountId.ObjectId, actAccount.HomeAccountId.ObjectId);
            Assert.AreEqual(expAccount.HomeAccountId.TenantId, actAccount.HomeAccountId.TenantId);
        }

        [Test]
        public void SerializeDeserialize()
        {
            var expRecord = new AuthenticationRecord(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            byte[] buff = new byte[TestBufferSize];

            var stream = new MemoryStream(buff);

            expRecord.Serialize(stream);

            stream = new MemoryStream(buff, 0, (int)stream.Position);

            var actRecord = AuthenticationRecord.Deserialize(stream);

            Assert.AreEqual(expRecord.Username, actRecord.Username);
            Assert.AreEqual(expRecord.Authority, actRecord.Authority);
            Assert.AreEqual(expRecord.HomeAccountId, actRecord.HomeAccountId);
            Assert.AreEqual(expRecord.TenantId, actRecord.TenantId);
            Assert.AreEqual(expRecord.ClientId, actRecord.ClientId);
            Assert.AreEqual(expRecord.Version, actRecord.Version);
        }
        [Test]
        public void DeserializeThrowsWithNonCurrentVersion()
        {
            var version = "2.0";
            var jsonWithVersion = $"{{\"username\":\"2012c4ff-e82f-40de-ab6e-0afa51a1700d\",\"authority\":\"f5313742-e9ea-49fe-8864-910911375241\",\"homeAccountId\":\"309958ce-97c3-4c0e-8047-ba3931aef15f\",\"tenantId\":\"5d083b4e-4d2e-431c-adb7-fec97397a359\",\"clientId\":\"387f4ada-ea9b-4773-b5c3-ea5f54991738\",\"version\":\"{version}\"}}";

            var buff = Encoding.UTF8.GetBytes(jsonWithVersion);
            var stream = new MemoryStream(buff, 0, buff.Length);

            Assert.Throws<InvalidOperationException>(() => AuthenticationRecord.Deserialize(stream));
        }

        [Test]
        public void DeserializesWithVersion()
        {
            var version = "1.0";
            var jsonWithVersion = $"{{\"username\":\"2012c4ff-e82f-40de-ab6e-0afa51a1700d\",\"authority\":\"f5313742-e9ea-49fe-8864-910911375241\",\"homeAccountId\":\"309958ce-97c3-4c0e-8047-ba3931aef15f\",\"tenantId\":\"5d083b4e-4d2e-431c-adb7-fec97397a359\",\"clientId\":\"387f4ada-ea9b-4773-b5c3-ea5f54991738\",\"version\":\"{version}\"}}";

            var buff = Encoding.UTF8.GetBytes(jsonWithVersion);
            var stream = new MemoryStream(buff, 0, buff.Length);

            var actRecord = AuthenticationRecord.Deserialize(stream);

            Assert.AreEqual(actRecord.Version, version);
        }

        [Test]
        public void DeserializesWithoutVersion()
        {
            var jsonWithoutVersion = "{\"username\":\"2012c4ff-e82f-40de-ab6e-0afa51a1700d\",\"authority\":\"f5313742-e9ea-49fe-8864-910911375241\",\"homeAccountId\":\"309958ce-97c3-4c0e-8047-ba3931aef15f\",\"tenantId\":\"5d083b4e-4d2e-431c-adb7-fec97397a359\",\"clientId\":\"387f4ada-ea9b-4773-b5c3-ea5f54991738\"}";

            var buff = Encoding.UTF8.GetBytes(jsonWithoutVersion);
            var stream = new MemoryStream(buff, 0, buff.Length);

            var actRecord = AuthenticationRecord.Deserialize(stream);

            Assert.AreEqual(actRecord.Version, AuthenticationRecord.CurrentVersion);
        }

        [Test]
        public void SerializeCancellationTokenCancelled()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            cts.Cancel();

            var expRecord = new AuthenticationRecord(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            var stream = new MemoryStream(TestBufferSize);

            Assert.CatchAsync<OperationCanceledException>(async () => await expRecord.SerializeAsync(stream, cts.Token));
        }

        [Test]
        public void DeserializeCancellationTokenCancelled()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            cts.Cancel();

            var stream = new MemoryStream(TestBufferSize);

            Assert.CatchAsync<OperationCanceledException>(async () => await AuthenticationRecord.DeserializeAsync(stream, cts.Token));
        }
    }
}

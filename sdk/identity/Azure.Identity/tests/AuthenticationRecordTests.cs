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
            Assert.That(account.Username, Is.Not.Null);
            Assert.That(account.Environment, Is.Not.Null);
            Assert.That(account.HomeAccountId.Identifier, Is.Not.Null);
            Assert.That(account.HomeAccountId.ObjectId, Is.Not.Null);
            Assert.That(account.HomeAccountId.TenantId, Is.Not.Null);
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

            Assert.That(actRecord.Username, Is.EqualTo(expRecord.Username));
            Assert.That(actRecord.Authority, Is.EqualTo(expRecord.Authority));
            Assert.That(actRecord.HomeAccountId, Is.EqualTo(expRecord.HomeAccountId));
            Assert.That(actRecord.TenantId, Is.EqualTo(expRecord.TenantId));
            Assert.That(actRecord.ClientId, Is.EqualTo(expRecord.ClientId));
            Assert.That(actRecord.Version, Is.EqualTo(expRecord.Version));

            Assert.That(actAccount.Username, Is.EqualTo(expAccount.Username));
            Assert.That(actAccount.Environment, Is.EqualTo(expAccount.Environment));
            Assert.That(actAccount.HomeAccountId.Identifier, Is.EqualTo(expAccount.HomeAccountId.Identifier));
            Assert.That(actAccount.HomeAccountId.ObjectId, Is.EqualTo(expAccount.HomeAccountId.ObjectId));
            Assert.That(actAccount.HomeAccountId.TenantId, Is.EqualTo(expAccount.HomeAccountId.TenantId));
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

            Assert.That(actRecord.Username, Is.EqualTo(expRecord.Username));
            Assert.That(actRecord.Authority, Is.EqualTo(expRecord.Authority));
            Assert.That(actRecord.HomeAccountId, Is.EqualTo(expRecord.HomeAccountId));
            Assert.That(actRecord.TenantId, Is.EqualTo(expRecord.TenantId));
            Assert.That(actRecord.ClientId, Is.EqualTo(expRecord.ClientId));
            Assert.That(actRecord.Version, Is.EqualTo(expRecord.Version));
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

            Assert.That(version, Is.EqualTo(actRecord.Version));
        }

        [Test]
        public void DeserializesWithoutVersion()
        {
            var jsonWithoutVersion = "{\"username\":\"2012c4ff-e82f-40de-ab6e-0afa51a1700d\",\"authority\":\"f5313742-e9ea-49fe-8864-910911375241\",\"homeAccountId\":\"309958ce-97c3-4c0e-8047-ba3931aef15f\",\"tenantId\":\"5d083b4e-4d2e-431c-adb7-fec97397a359\",\"clientId\":\"387f4ada-ea9b-4773-b5c3-ea5f54991738\"}";

            var buff = Encoding.UTF8.GetBytes(jsonWithoutVersion);
            var stream = new MemoryStream(buff, 0, buff.Length);

            var actRecord = AuthenticationRecord.Deserialize(stream);

            Assert.That(actRecord.Version, Is.EqualTo(AuthenticationRecord.CurrentVersion));
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

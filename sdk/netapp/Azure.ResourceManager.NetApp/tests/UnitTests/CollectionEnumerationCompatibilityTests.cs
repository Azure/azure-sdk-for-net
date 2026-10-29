// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class CollectionEnumerationCompatibilityTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public Task ActiveDirectoryConfigEnumerationForwards(bool async) =>
            VerifyEnumeration(new TestActiveDirectoryConfigCollection(), async);

        [TestCase(false)]
        [TestCase(true)]
        public Task ElasticAccountEnumerationForwards(bool async) =>
            VerifyEnumeration(new TestElasticAccountCollection(), async);

        [TestCase(false)]
        [TestCase(true)]
        public Task ElasticCapacityPoolEnumerationForwards(bool async) =>
            VerifyEnumeration(new TestElasticCapacityPoolCollection(), async);

        [TestCase(false)]
        [TestCase(true)]
        public Task ElasticVolumeEnumerationForwards(bool async) =>
            VerifyEnumeration(new TestElasticVolumeCollection(), async);

        [TestCase(false)]
        [TestCase(true)]
        public Task ElasticSnapshotEnumerationForwards(bool async) =>
            VerifyEnumeration(new TestElasticSnapshotCollection(), async);

        [TestCase(false)]
        [TestCase(true)]
        public Task ElasticSnapshotPolicyEnumerationForwards(bool async) =>
            VerifyEnumeration(new TestElasticSnapshotPolicyCollection(), async);

        [TestCase(false)]
        [TestCase(true)]
        public Task ElasticBackupEnumerationForwards(bool async) =>
            VerifyEnumeration(new TestElasticBackupCollection(), async);

        [TestCase(false)]
        [TestCase(true)]
        public Task ElasticBackupPolicyEnumerationForwards(bool async) =>
            VerifyEnumeration(new TestElasticBackupPolicyCollection(), async);

        [TestCase(false)]
        [TestCase(true)]
        public Task ElasticBackupVaultEnumerationForwards(bool async) =>
            VerifyEnumeration(new TestElasticBackupVaultCollection(), async);

        private static async Task VerifyEnumeration<T>(IEnumerable<T> collection, bool async)
        {
            EnumerationProbe probe = ((ITestCollection)collection).Probe;
            if (async)
            {
                using var cancellation = new CancellationTokenSource();
                await using IAsyncEnumerator<T> enumerator =
                    ((IAsyncEnumerable<T>)collection).GetAsyncEnumerator(cancellation.Token);

                Assert.That(await enumerator.MoveNextAsync(), Is.True);
                Assert.That(enumerator.Current, Is.Null);
                Assert.That(await enumerator.MoveNextAsync(), Is.False);
                Assert.That(probe.AsyncCalls, Is.EqualTo(1));
                Assert.That(probe.GetAllAsyncToken, Is.EqualTo(cancellation.Token));
                Assert.That(probe.EnumeratorToken, Is.EqualTo(cancellation.Token));
            }
            else
            {
                using IEnumerator<T> enumerator = collection.GetEnumerator();
                Assert.That(enumerator.MoveNext(), Is.True);
                Assert.That(enumerator.Current, Is.Null);
                Assert.That(enumerator.MoveNext(), Is.False);
                Assert.That(probe.SyncCalls, Is.EqualTo(1));

                IEnumerator nonGeneric = ((IEnumerable)collection).GetEnumerator();
                using ((IDisposable)nonGeneric)
                {
                    Assert.That(nonGeneric.MoveNext(), Is.True);
                    Assert.That(nonGeneric.Current, Is.Null);
                    Assert.That(nonGeneric.MoveNext(), Is.False);
                }
                Assert.That(probe.SyncCalls, Is.EqualTo(2));
            }
        }

        private interface ITestCollection
        {
            EnumerationProbe Probe { get; }
        }

        private class EnumerationProbe
        {
            public int SyncCalls { get; private set; }
            public int AsyncCalls { get; private set; }
            public CancellationToken GetAllAsyncToken { get; private set; }
            public CancellationToken EnumeratorToken { get; set; }

            public Pageable<T> GetAll<T>()
            {
                SyncCalls++;
                return Pageable<T>.FromPages(new[] { CreatePage<T>() });
            }

            public AsyncPageable<T> GetAllAsync<T>(CancellationToken cancellationToken)
            {
                AsyncCalls++;
                GetAllAsyncToken = cancellationToken;
                return new TestAsyncPageable<T>(this);
            }

            private static Page<T> CreatePage<T>() =>
                Page<T>.FromValues(new[] { default(T) }, null, new MockResponse(200));

            private class TestAsyncPageable<T> : AsyncPageable<T>
            {
                private readonly EnumerationProbe _probe;

                public TestAsyncPageable(EnumerationProbe probe)
                {
                    _probe = probe;
                }

                public override IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
                {
                    _probe.EnumeratorToken = cancellationToken;
                    return AsyncPageable<T>.FromPages(new[] { CreatePage<T>() }).GetAsyncEnumerator(cancellationToken);
                }

                public override IAsyncEnumerable<Page<T>> AsPages(string continuationToken = default, int? pageSizeHint = default) =>
                    AsyncPageable<T>.FromPages(new[] { CreatePage<T>() }).AsPages(continuationToken, pageSizeHint);
            }
        }

        private class TestActiveDirectoryConfigCollection : NetAppActiveDirectoryConfigCollection, ITestCollection
        {
            public EnumerationProbe Probe { get; } = new EnumerationProbe();
            public override Pageable<NetAppActiveDirectoryConfigResource> GetAll(CancellationToken cancellationToken = default) =>
                Probe.GetAll<NetAppActiveDirectoryConfigResource>();
            public override AsyncPageable<NetAppActiveDirectoryConfigResource> GetAllAsync(CancellationToken cancellationToken = default) =>
                Probe.GetAllAsync<NetAppActiveDirectoryConfigResource>(cancellationToken);
        }

        private class TestElasticAccountCollection : NetAppElasticAccountCollection, ITestCollection
        {
            public EnumerationProbe Probe { get; } = new EnumerationProbe();
            public override Pageable<NetAppElasticAccountResource> GetAll(CancellationToken cancellationToken = default) =>
                Probe.GetAll<NetAppElasticAccountResource>();
            public override AsyncPageable<NetAppElasticAccountResource> GetAllAsync(CancellationToken cancellationToken = default) =>
                Probe.GetAllAsync<NetAppElasticAccountResource>(cancellationToken);
        }

        private class TestElasticCapacityPoolCollection : NetAppElasticCapacityPoolCollection, ITestCollection
        {
            public EnumerationProbe Probe { get; } = new EnumerationProbe();
            public override Pageable<NetAppElasticCapacityPoolResource> GetAll(CancellationToken cancellationToken = default) =>
                Probe.GetAll<NetAppElasticCapacityPoolResource>();
            public override AsyncPageable<NetAppElasticCapacityPoolResource> GetAllAsync(CancellationToken cancellationToken = default) =>
                Probe.GetAllAsync<NetAppElasticCapacityPoolResource>(cancellationToken);
        }

        private class TestElasticVolumeCollection : NetAppElasticVolumeCollection, ITestCollection
        {
            public EnumerationProbe Probe { get; } = new EnumerationProbe();
            public override Pageable<NetAppElasticVolumeResource> GetAll(CancellationToken cancellationToken = default) =>
                Probe.GetAll<NetAppElasticVolumeResource>();
            public override AsyncPageable<NetAppElasticVolumeResource> GetAllAsync(CancellationToken cancellationToken = default) =>
                Probe.GetAllAsync<NetAppElasticVolumeResource>(cancellationToken);
        }

        private class TestElasticSnapshotCollection : NetAppElasticSnapshotCollection, ITestCollection
        {
            public EnumerationProbe Probe { get; } = new EnumerationProbe();
            public override Pageable<NetAppElasticSnapshotResource> GetAll(CancellationToken cancellationToken = default) =>
                Probe.GetAll<NetAppElasticSnapshotResource>();
            public override AsyncPageable<NetAppElasticSnapshotResource> GetAllAsync(CancellationToken cancellationToken = default) =>
                Probe.GetAllAsync<NetAppElasticSnapshotResource>(cancellationToken);
        }

        private class TestElasticSnapshotPolicyCollection : NetAppElasticSnapshotPolicyCollection, ITestCollection
        {
            public EnumerationProbe Probe { get; } = new EnumerationProbe();
            public override Pageable<NetAppElasticSnapshotPolicyResource> GetAll(CancellationToken cancellationToken = default) =>
                Probe.GetAll<NetAppElasticSnapshotPolicyResource>();
            public override AsyncPageable<NetAppElasticSnapshotPolicyResource> GetAllAsync(CancellationToken cancellationToken = default) =>
                Probe.GetAllAsync<NetAppElasticSnapshotPolicyResource>(cancellationToken);
        }

        private class TestElasticBackupCollection : NetAppElasticBackupCollection, ITestCollection
        {
            public EnumerationProbe Probe { get; } = new EnumerationProbe();
            public override Pageable<NetAppElasticBackupResource> GetAll(CancellationToken cancellationToken = default) =>
                Probe.GetAll<NetAppElasticBackupResource>();
            public override AsyncPageable<NetAppElasticBackupResource> GetAllAsync(CancellationToken cancellationToken = default) =>
                Probe.GetAllAsync<NetAppElasticBackupResource>(cancellationToken);
        }

        private class TestElasticBackupPolicyCollection : NetAppElasticBackupPolicyCollection, ITestCollection
        {
            public EnumerationProbe Probe { get; } = new EnumerationProbe();
            public override Pageable<NetAppElasticBackupPolicyResource> GetAll(CancellationToken cancellationToken = default) =>
                Probe.GetAll<NetAppElasticBackupPolicyResource>();
            public override AsyncPageable<NetAppElasticBackupPolicyResource> GetAllAsync(CancellationToken cancellationToken = default) =>
                Probe.GetAllAsync<NetAppElasticBackupPolicyResource>(cancellationToken);
        }

        private class TestElasticBackupVaultCollection : NetAppElasticBackupVaultCollection, ITestCollection
        {
            public EnumerationProbe Probe { get; } = new EnumerationProbe();
            public override Pageable<NetAppElasticBackupVaultResource> GetAll(CancellationToken cancellationToken = default) =>
                Probe.GetAll<NetAppElasticBackupVaultResource>();
            public override AsyncPageable<NetAppElasticBackupVaultResource> GetAllAsync(CancellationToken cancellationToken = default) =>
                Probe.GetAllAsync<NetAppElasticBackupVaultResource>(cancellationToken);
        }
    }
}

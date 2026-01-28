// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    [ClientTestFixture(FakeClientVersion.V0, FakeClientVersion.V1, FakeClientVersion.V2, FakeClientVersion.V3, FakeClientVersion.V4)]
    [ServiceVersion(Min = FakeClientVersion.V1, Max = FakeClientVersion.V3)]
    public class ClientTestBaseMultiVersionTests : ClientTestBase
    {
        private readonly FakeClientVersion _version;

        public ClientTestBaseMultiVersionTests(bool isAsync, FakeClientVersion version) : base(isAsync)
        {
            _version = version;
        }

        [Test]
        public void HasValidVersion()
        {
            Assert.That(
                _version == FakeClientVersion.V1 ||
                          _version == FakeClientVersion.V2 ||
                           _version == FakeClientVersion.V3,
                Is.True);
        }

        [Test]
        [ServiceVersion(Min = FakeClientVersion.V2)]
        public void MinVersionWorks()
        {
            Assert.That(
                _version == FakeClientVersion.V2 ||
                _version == FakeClientVersion.V3,
                Is.True);
        }

        [Test]
        [ServiceVersion(Max = FakeClientVersion.V2)]
        public void MaxVersionWorks()
        {
            Assert.That(
                _version == FakeClientVersion.V2 ||
                _version == FakeClientVersion.V1,
                Is.True);
        }

        [Test]
        [AsyncOnly]
        public void AsyncOnlyWorks()
        {
            Assert.That(IsAsync, Is.True);
        }

        [Test]
        [SyncOnly]
        public void SyncOnlyWorks()
        {
            Assert.That(IsAsync, Is.False);
        }
    }
}

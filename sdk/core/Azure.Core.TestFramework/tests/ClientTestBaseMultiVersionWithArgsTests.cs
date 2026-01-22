// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    [ClientTestFixture(
        serviceVersions: new object[] { FakeClientVersion.V1, FakeClientVersion.V2, FakeClientVersion.V3 },
         additionalParameters: new object[] { someParam1, someParam2 })]
    public class ClientTestBaseMultiVersionWithArgsTests : ClientTestBase
    {
        private readonly FakeClientVersion _version;
        private readonly string _param;

        public ClientTestBaseMultiVersionWithArgsTests(bool isAsync, FakeClientVersion version, string param) : base(isAsync)
        {
            _version = version;
            _param = param;
        }

        [Test]
        public void HasValidAdditionalParam()
        {
            Assert.That(
                _param == someParam1 ||
                _param == someParam2,
                Is.True);
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

        public enum FakeClientVersion
        {
            V1 = 1,
            V2 = 2,
            V3 = 3
        }

        public const string someParam1 = "someParam1";
        public const string someParam2 = "someParam2";
    }
}

﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [ClientTestFixture(FakeClientVersion.V1, FakeClientVersion.V2, FakeClientVersion.V3)]
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
            Assert.IsTrue(
                _version == FakeClientVersion.V1 ||
                          _version == FakeClientVersion.V2 ||
                           _version == FakeClientVersion.V3);
        }

        [Test]
        [ServiceVersion(Min = FakeClientVersion.V2)]
        public void MinVersionWorks()
        {
            Assert.IsTrue(
                _version == FakeClientVersion.V2 ||
                _version == FakeClientVersion.V3);
        }

        [Test]
        [ServiceVersion(Max = FakeClientVersion.V2)]
        public void MaxVersionWorks()
        {
            Assert.IsTrue(
                _version == FakeClientVersion.V2 ||
                _version == FakeClientVersion.V1);
        }

        [Test]
        [AsyncOnly]
        public void AsyncOnlyWorks()
        {
            Assert.IsTrue(IsAsync);
        }

        [Test]
        [SyncOnly]
        public void SyncOnlyWorks()
        {
            Assert.IsFalse(IsAsync);
        }

        public enum FakeClientVersion
        {
            V1 = 1,
            V2 = 2,
            V3 = 3
        }
    }
}

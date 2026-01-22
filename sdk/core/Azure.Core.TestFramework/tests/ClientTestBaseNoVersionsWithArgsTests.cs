// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    [ClientTestFixture(
            serviceVersions: default,
             additionalParameters: new object[] { someParam1, someParam2 })]
    public class ClientTestBaseNoVersionsWithArgsTests : ClientTestBase
    {
        private readonly string _param;

        public ClientTestBaseNoVersionsWithArgsTests(bool isAsync, string param) : base(isAsync)
        {
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

        public const string someParam1 = "someParam1";
        public const string someParam2 = "someParam2";
    }
}

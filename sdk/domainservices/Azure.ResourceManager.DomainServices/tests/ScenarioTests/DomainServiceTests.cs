// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DomainServices.Tests
{
    public class DomainServiceTests : DomainServicesManagementTestBase
    {
        public DomainServiceTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        [Ignore("api-version 2025-10-01-preview is not deployed to ARM")]
        public async Task List()
        {
            var domainServices = await DefaultSubscription.GetDomainServicesAsync().ToEnumerableAsync();
            Assert.That(domainServices, Is.Not.Null);
        }
    }
}

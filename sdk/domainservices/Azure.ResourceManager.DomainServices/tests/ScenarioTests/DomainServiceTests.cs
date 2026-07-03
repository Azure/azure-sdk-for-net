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

        // Live-only: the onboarded api-version (2025-10-01-preview) is not yet deployed to ARM,
        // so this read-only list cannot be recorded for playback. It can be recorded once the
        // preview api-version (or the stable 2025-10-01) is the generation target.
        [Test]
        [LiveOnly]
        public async Task List()
        {
            // Read-only: list all Domain Services in the subscription. The result may be empty,
            // but the operation should succeed and return a valid collection.
            var domainServices = await DefaultSubscription.GetDomainServicesAsync().ToEnumerableAsync();
            Assert.That(domainServices, Is.Not.Null);
        }
    }
}

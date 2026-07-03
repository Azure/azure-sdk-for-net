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

        // Marked [Ignore] because the onboarded api-version (2025-10-01-preview) is not yet
        // deployed to ARM, so the call fails live and cannot be recorded for playback. Remove
        // the [Ignore] and record once a deployed api-version is the generation target.
        [Test]
        [RecordedTest]
        [Ignore("api-version 2025-10-01-preview is not deployed to ARM; service supports up to stable 2025-10-01.")]
        public async Task List()
        {
            // Read-only: list all Domain Services in the subscription. The result may be empty,
            // but the operation should succeed and return a valid collection.
            var domainServices = await DefaultSubscription.GetDomainServicesAsync().ToEnumerableAsync();
            Assert.That(domainServices, Is.Not.Null);
        }
    }
}

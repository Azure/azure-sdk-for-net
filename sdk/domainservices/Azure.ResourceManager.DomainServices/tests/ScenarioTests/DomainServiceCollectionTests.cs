// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DomainServices.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DomainServices.Tests
{
    // Live-only: provisioning an Azure AD Domain Service takes ~45-60 minutes and requires a
    // pre-existing virtual-network subnet, so this lifecycle test is not run in CI playback.
    [LiveOnly]
    public class DomainServiceCollectionTests : DomainServicesManagementTestBase
    {
        public DomainServiceCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        private DomainServiceData GetDomainServiceData(string domainName, ResourceIdentifier subnetId)
        {
            var data = new DomainServiceData
            {
                Location = DefaultLocation,
                DomainName = domainName,
                Sku = "Standard",
                FilteredSync = FilteredSync.Disabled,
            };
            data.ReplicaSets.Add(new ReplicaSet
            {
                Location = DefaultLocation,
                SubnetId = subnetId,
            });
            return data;
        }

        [Test]
        public async Task CRUD()
        {
            ResourceGroupResource resourceGroup = await CreateResourceGroupAsync();
            ResourceIdentifier subnetId = await CreateSubnetAsync(resourceGroup);
            DomainServiceCollection collection = resourceGroup.GetDomainServices();

            string domainName = $"{Recording.GenerateAssetName("dstest")}.contoso.com";

            // Create
            var createLro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, GetDomainServiceData(domainName, subnetId));
            DomainServiceResource created = createLro.Value;
            Assert.That(created, Is.Not.Null);
            Assert.That(created.Data.Name, Is.EqualTo(domainName));
            Assert.That(created.Data.DomainName, Is.EqualTo(domainName));

            // Read (Exists + Get)
            Assert.That((await collection.ExistsAsync(domainName)).Value, Is.True);
            DomainServiceResource fetched = await created.GetAsync();
            Assert.That(fetched.Data.Id, Is.EqualTo(created.Data.Id));

            // List
            var all = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(all.Any(d => d.Data.Name == domainName), Is.True);

            // Update (add a tag)
            DomainServiceResource updated = await fetched.AddTagAsync("env", "test");
            Assert.That(updated.Data.Tags.ContainsKey("env"), Is.True);
            Assert.That(updated.Data.Tags["env"], Is.EqualTo("test"));

            // Delete
            await updated.DeleteAsync(WaitUntil.Completed);
            Assert.That((await collection.ExistsAsync(domainName)).Value, Is.False);
        }
    }
}

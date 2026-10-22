// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Maintenance.Tests
{
    public class ApiVersionOverrideTests
    {
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task CompatibilityGetUsesResourceApiVersion(bool async, bool hasOverride)
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000001";
            const string overrideVersion = "2099-01-01";
            string id = $"/subscriptions/{subscriptionId}/resourceGroups/group/providers/Microsoft.Compute/virtualMachines/vm/providers/Microsoft.Maintenance/applyUpdates/default";
            var response = new MockResponse(200).SetContent("{\"id\":\"" + id + "\",\"name\":\"default\",\"type\":\"Microsoft.Maintenance/applyUpdates\",\"properties\":{}}");
            var transport = new MockTransport(response);
            var options = new ArmClientOptions { Transport = transport };
            options.SetApiVersion(ResourceGroupResource.ResourceType, "resource-group-version");
            if (hasOverride)
            {
                options.SetApiVersion(MaintenanceApplyUpdateResource.ResourceType, overrideVersion);
            }
            var client = new ArmClient(new MockCredential(), subscriptionId, options);
            var group = client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(subscriptionId, "group"));

            if (async)
            {
                await group.GetMaintenanceApplyUpdateAsync("Microsoft.Compute", "virtualMachines", "vm", "default");
            }
            else
            {
                group.GetMaintenanceApplyUpdate("Microsoft.Compute", "virtualMachines", "vm", "default");
            }

            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            var request = transport.Requests[0];
            Assert.That(request.Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(request.Uri.ToUri().Query, Is.EqualTo("?api-version=" + (hasOverride ? overrideVersion : "2025-10-01-preview")));
        }
    }
}

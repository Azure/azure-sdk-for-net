// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.OperationTemplates;
using Azure.ResourceManager.OperationTemplates.Models;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.OperationTemplates
{
    public class PagingTests : OperationTemplatesTestBase
    {
        [SpectorTest]
        public Task PostActionPaging() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var monitor = GetClient(host, requests).GetMonitorResource(MonitorResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName, "monitor1"));
            var values = new List<MonitoredResource>();
            await foreach (var value in monitor.PostActionPagingAsync(new LogStatusRequest { Filter = "status eq 'active'" }))
            {
                values.Add(value);
            }

            Assert.That(requests.Count, Is.EqualTo(2));
            requests.AssertRequest(0, "POST", $"{ResourceGroupProviderPath}/monitors/monitor1/postActionPaging", """{"filter":"status eq 'active'"}""");
            requests.AssertRequest(1, "GET", $"{ResourceGroupProviderPath}/monitors/monitor1/postActionPaging/nextPage", "");
            Assert.That(values, Has.Count.EqualTo(2));
            Assert.That(values[0].Id, Does.EndWith("/virtualMachines/vm1"));
            Assert.That(values[0].SendingMetrics, Is.True);
            Assert.That(values[1].Id, Does.EndWith("/virtualMachines/vm2"));
            Assert.That(values[1].SendingMetrics, Is.False);
        });

        [SpectorTest]
        public Task MarkAsPageable() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var monitor = GetClient(host, requests).GetMonitorResource(MonitorResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName, "monitor1"));
            var names = new List<string>();
            var displays = new List<string>();
            await foreach (var value in monitor.MarkAsPageableAsync())
            {
                names.Add(value.Name);
                displays.Add(value.CollectionDisplayName);
            }

            Assert.That(requests.Count, Is.EqualTo(1));
            requests.AssertRequest(0, "GET", $"{ResourceGroupProviderPath}/monitors/monitor1/collections", "");
            Assert.That(names, Is.EqualTo(new[] { "collection1", "collection2" }));
            Assert.That(displays, Is.EqualTo(new[] { "Test Collection", "Another Collection" }));
        });
    }
}

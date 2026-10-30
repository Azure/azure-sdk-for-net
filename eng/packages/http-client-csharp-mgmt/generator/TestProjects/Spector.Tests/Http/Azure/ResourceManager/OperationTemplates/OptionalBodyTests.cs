// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.OperationTemplates;
using Azure.ResourceManager.OperationTemplates.Models;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.OperationTemplates
{
    public class OptionalBodyTests : OperationTemplatesTestBase
    {
        [SpectorTest]
        public Task Get() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var widget = GetClient(host, requests).GetWidgetResource(WidgetResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName, "widget1"));
            var response = await widget.GetAsync();

            Assert.That(requests.Count, Is.EqualTo(1));
            requests.AssertRequest(0, "GET", $"{ResourceGroupProviderPath}/widgets/widget1", "");
            Assert.That(response.Value.Data.Properties.Name, Is.EqualTo("widget1"));
            Assert.That(response.Value.Data.Properties.Description, Is.EqualTo("A test widget"));
        });

        [SpectorTest]
        public Task Patch() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var widget = GetClient(host, requests).GetWidgetResource(WidgetResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName, "widget1"));
            var empty = await widget.UpdateAsync(null);
            Assert.That(empty.Value.Data.Properties.Name, Is.EqualTo("widget1"));

            var data = new WidgetData(AzureLocation.EastUS)
            {
                Properties = new WidgetProperties { Name = "updated-widget", Description = "Updated description" }
            };
            var updated = await widget.UpdateAsync(data);
            Assert.That(requests.Count, Is.EqualTo(2));
            requests.AssertRequest(0, "PATCH", $"{ResourceGroupProviderPath}/widgets/widget1", "");
            requests.AssertRequest(1, "PATCH", $"{ResourceGroupProviderPath}/widgets/widget1",
                """{"location":"eastus","properties":{"name":"updated-widget","description":"Updated description"}}""");
            Assert.That(updated.Value.Data.Properties.Name, Is.EqualTo("updated-widget"));
            Assert.That(updated.Value.Data.Properties.Description, Is.EqualTo("Updated description"));
        });

        [SpectorTest]
        public Task Post() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var widget = GetClient(host, requests).GetWidgetResource(WidgetResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName, "widget1"));
            var empty = await widget.PostAsync();
            Assert.That(empty.Value.Result, Is.EqualTo("Action completed successfully"));

            var response = await widget.PostAsync(new ActionRequest { ActionType = "perform", Parameters = "test-parameters" });
            Assert.That(requests.Count, Is.EqualTo(2));
            requests.AssertRequest(0, "POST", $"{ResourceGroupProviderPath}/widgets/widget1/post", "");
            requests.AssertRequest(1, "POST", $"{ResourceGroupProviderPath}/widgets/widget1/post", """{"actionType":"perform","parameters":"test-parameters"}""");
            Assert.That(response.Value.Result, Is.EqualTo("Action completed successfully with parameters"));
        });

        [SpectorTest]
        public Task ProviderPost() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var subscription = GetSubscription(host, requests);
            var empty = await subscription.ProviderPostAsync();
            Assert.That(empty.Value.TotalAllowed, Is.EqualTo(50));
            Assert.That(empty.Value.Status, Is.EqualTo("Changed to default allowance"));

            var response = await subscription.ProviderPostAsync(new ChangeAllowanceRequest { TotalAllowed = 100, Reason = "Increased demand" });
            Assert.That(requests.Count, Is.EqualTo(2));
            requests.AssertRequest(0, "POST", $"{ProviderPath}/providerPost", "");
            requests.AssertRequest(1, "POST", $"{ProviderPath}/providerPost", """{"totalAllowed":100,"reason":"Increased demand"}""");
            Assert.That(response.Value.TotalAllowed, Is.EqualTo(100));
            Assert.That(response.Value.Status, Is.EqualTo("Changed to requested allowance"));
        });
    }
}

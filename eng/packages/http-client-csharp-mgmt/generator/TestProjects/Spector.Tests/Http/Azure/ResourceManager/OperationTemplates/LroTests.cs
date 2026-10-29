// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.OperationTemplates;
using Azure.ResourceManager.OperationTemplates.Models;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.OperationTemplates
{
    public class LroTests : OperationTemplatesTestBase
    {
        [SpectorTest]
        public Task CreateOrReplace() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var data = new Order(AzureLocation.EastUS) { Properties = new OrderProperties("product1", 1) };
            var operation = await GetResourceGroup(host, requests).CreateOrReplaceAsync(WaitUntil.Completed, "order1", data);

            Assert.That(requests.Count, Is.GreaterThanOrEqualTo(3));
            requests.AssertRequest(0, "PUT", $"{ResourceGroupProviderPath}/orders/order1", """{"location":"eastus","properties":{"productId":"product1","amount":1}}""");
            for (int i = 1; i < requests.Count - 1; i++)
            {
                requests.AssertRequest(i, "GET", $"{ProviderPath}/locations/eastus/operations/lro_create_aao", "");
            }
            requests.AssertRequest(requests.Count - 1, "GET", $"{ResourceGroupProviderPath}/orders/order1", "");
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Name, Is.EqualTo("order1"));
            Assert.That(operation.Value.Properties.ProductId, Is.EqualTo("product1"));
            Assert.That(operation.Value.Properties.Amount, Is.EqualTo(1));
            Assert.That(operation.Value.Properties.ProvisioningState, Is.EqualTo("Succeeded"));
        });

        [SpectorTest]
        public Task Export() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var operation = await GetResourceGroup(host, requests).ExportAsync(WaitUntil.Completed, "order1", new ExportRequest("csv"));
            Assert.That(requests.Count, Is.GreaterThanOrEqualTo(2));
            requests.AssertRequest(0, "POST", $"{ResourceGroupProviderPath}/orders/order1/export", """{"format":"csv"}""");
            for (int i = 1; i < requests.Count; i++)
            {
                requests.AssertRequest(i, "GET", $"{ProviderPath}/locations/eastus/operations/lro_post_location", "",
                    $"{ProviderPath}/locations/eastus/operations/lro_post_aao", allowMissingApiVersion: true);
            }
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Content, Is.EqualTo("order1,product1,1"));
        });

        [SpectorTest]
        public Task Delete() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var operation = await OperationTemplatesExtensions.DeleteAsync(GetResourceGroup(host, requests), WaitUntil.Completed, "order1");
            Assert.That(requests.Count, Is.GreaterThanOrEqualTo(2));
            requests.AssertRequest(0, "DELETE", $"{ResourceGroupProviderPath}/orders/order1", "");
            for (int i = 1; i < requests.Count; i++)
            {
                requests.AssertRequest(i, "GET", $"{ProviderPath}/locations/eastus/operationResults/lro_delete_location", "");
            }
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExportArray() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var operation = await GetSubscription(host, requests).ExportArrayAsync(WaitUntil.Completed, new ExportRequest("csv"));
            Assert.That(requests.Count, Is.GreaterThanOrEqualTo(2));
            requests.AssertRequest(0, "POST", $"{ProviderPath}/exportArray", """{"format":"csv"}""");
            for (int i = 1; i < requests.Count; i++)
            {
                requests.AssertRequest(i, "GET", $"{ProviderPath}/locations/eastus/operations/lro_exportarray_location", "",
                    $"{ProviderPath}/locations/eastus/operations/lro_exportarray_aao", allowMissingApiVersion: true);
            }
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Select(value => value.Content), Is.EqualTo(new[] { "order1,product1,1", "order2,product2,2" }));
        });

        [SpectorTest]
        public Task GetLro() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var operation = await GetClient(host, requests).GetCostReportAsync(
                new ResourceIdentifier($"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}"),
                WaitUntil.Completed, "report1");
            Assert.That(requests.Count, Is.GreaterThanOrEqualTo(2));
            for (int i = 0; i < requests.Count; i++)
            {
                requests.AssertRequest(i, "GET", $"{ResourceGroupProviderPath}/costReports/report1", "");
            }
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo("report1"));
            Assert.That(operation.Value.Data.Properties.DownloadUri.ToString(), Is.EqualTo("https://storage.blob.core.windows.net/reports/report1.csv"));
        });
    }
}

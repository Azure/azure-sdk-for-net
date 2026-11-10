// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Sovereign.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sovereign.Tests
{
    public class SovereignSdkRegressionTests
    {
        private const string ViewId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/test/providers/Microsoft.Sovereign/sovereignViews/test";
        private const string ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/test/providers/Microsoft.Network/networkSecurityGroups/test";
        private const string RemediationRequest = "{\"dimensionType\":\"DataResidency\",\"residencyRemediationRequest\":{\"configuration\":{\"targetRegion\":\"uksouth\"},\"resources\":[]}}";

        [TestCase("2026-11-10T12:34:56.1234567Z")]
        [TestCase("2026-11-10T12:34:56.0000001Z")]
        [TestCase("2026-11-10T12:34:56.9999999Z")]
        [TestCase("2026-11-10T12:34:56.1234567+05:30")]
        public async Task TypedTimestampRoundTripPreservesAllSevenDigits(string timestamp)
        {
            var detail = ModelReaderWriter.Read<SovereignViewDimensionDetail>(BinaryData.FromString(
                "{\"dimension\":\"DataResidency\",\"state\":\"NonCompliant\",\"complianceDetails\":[],\"sources\":[],\"evaluatedAt\":\"" + timestamp + "\"}"));
            var content = new SovereignViewComplianceResourceDetailsContent(new ResourceIdentifier(ResourceId), detail.Dimension)
            {
                EvaluatedOn = detail.EvaluatedOn
            };
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(content));
            Assert.That(DateTimeOffset.Parse(document.RootElement.GetProperty("evaluatedAt").GetString()).UtcTicks,
                Is.EqualTo(DateTimeOffset.Parse(timestamp).UtcTicks));
            Assert.That(document.RootElement.GetProperty("evaluatedAt").GetString(), Does.Contain(timestamp.Substring(19, 8)));
            var transport = new MockTransport(new MockResponse(200).SetContent("{}"));
            await CreateResource(transport).ComplianceResourceDetailsAsync(content);
            using var body = new MemoryStream();
            transport.Requests.Single().Content.WriteTo(body, default);
            using JsonDocument wire = JsonDocument.Parse(body.ToArray());
            Assert.That(DateTimeOffset.Parse(wire.RootElement.GetProperty("evaluatedAt").GetString()).UtcTicks,
                Is.EqualTo(DateTimeOffset.Parse(timestamp).UtcTicks));
            Assert.That(wire.RootElement.GetProperty("evaluatedAt").GetString(), Does.Contain(timestamp.Substring(19, 8)));
        }

        [TestCase("{\"remediationId\":\"flat-id\"}", "flat-id")]
        [TestCase("{\"status\":\"Succeeded\",\"properties\":{\"remediationId\":\"nested-id\"}}", "nested-id")]
        [TestCase("{\"status\":\"Succeeded\",\"remediationId\":\"flat-id\",\"properties\":{\"remediationId\":\"nested-id\"}}", "flat-id")]
        [TestCase("{\"status\":\"Running\",\"properties\":{\"remediationId\":\"not-complete\"}}", null)]
        [TestCase("{\"status\":\"Failed\",\"properties\":{\"remediationId\":\"not-success\"},\"error\":{\"code\":\"ProviderError\",\"message\":\"failed\"}}", null)]
        [TestCase("{\"status\":\"Succeeded\",\"properties\":null}", null)]
        [TestCase("{\"status\":\"Succeeded\",\"properties\":{}}", null)]
        [TestCase("{\"status\":\"Succeeded\",\"properties\":{\"remediationId\":null}}", null)]
        [TestCase("{\"properties\":{\"remediationId\":\"not-a-terminal-result\"}}", null)]
        public void RemediationModelSupportsBothResponseShapes(string json, string expectedId)
        {
            var result = ModelReaderWriter.Read<SovereignViewRemediateResult>(BinaryData.FromString(json));
            Assert.That(result.RemediationId, Is.EqualTo(expectedId));
            if (json.Contains("ProviderError"))
            {
                Assert.That(result.Error.Code, Is.EqualTo("ProviderError"));
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task AwaitedRemediationExposesNestedId(bool async)
        {
            var transport = new MockTransport(
                new MockResponse(202).AddHeader("Azure-AsyncOperation", "https://management.azure.com/operations/test").AddHeader("Retry-After", "0"),
                new MockResponse(200).SetContent("{\"status\":\"Succeeded\",\"properties\":{\"remediationId\":\"nested-id\"}}"));
            var resource = CreateResource(transport);
            var request = ModelReaderWriter.Read<SovereignViewRemediateContent>(BinaryData.FromString(RemediationRequest));
            ArmOperation<SovereignViewRemediateResult> operation = async
                ? await resource.RemediateAsync(WaitUntil.Completed, request)
                : resource.Remediate(WaitUntil.Completed, request);
            Assert.That(operation.HasCompleted && operation.HasValue, Is.True);
            Assert.That(operation.Value.RemediationId, Is.EqualTo("nested-id"));
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(transport.Requests.Count(), Is.EqualTo(2));
            Assert.That(transport.Requests.First().Uri.Query, Does.Contain("api-version=2026-10-31-preview"));
        }

        [Test]
        public async Task LocationPollingAlsoExposesNestedId()
        {
            var transport = new MockTransport(
                new MockResponse(202).AddHeader("Location", "https://management.azure.com/operations/test").AddHeader("Retry-After", "0"),
                new MockResponse(200).SetContent("{\"status\":\"Succeeded\",\"properties\":{\"remediationId\":\"location-id\"}}"));
            var request = ModelReaderWriter.Read<SovereignViewRemediateContent>(BinaryData.FromString(RemediationRequest));
            var operation = await CreateResource(transport).RemediateAsync(WaitUntil.Completed, request);
            Assert.That(operation.Value.RemediationId, Is.EqualTo("location-id"));
        }

        [TestCase("Failed")]
        [TestCase("Canceled")]
        public void FailedRemediationStillThrows(string status)
        {
            var transport = new MockTransport(
                new MockResponse(202).AddHeader("Azure-AsyncOperation", "https://management.azure.com/operations/test").AddHeader("Retry-After", "0"),
                new MockResponse(200).SetContent("{\"status\":\"" + status + "\",\"error\":{\"code\":\"ProviderError\",\"message\":\"failed\"}}"));
            var request = ModelReaderWriter.Read<SovereignViewRemediateContent>(BinaryData.FromString(RemediationRequest));
            Assert.ThrowsAsync<RequestFailedException>(async () => await CreateResource(transport).RemediateAsync(WaitUntil.Completed, request));
        }

        [Test]
        public async Task StartedRemediationCanBePolledNormally()
        {
            var transport = new MockTransport(
                new MockResponse(202).AddHeader("Azure-AsyncOperation", "https://management.azure.com/operations/test").AddHeader("Retry-After", "0"),
                new MockResponse(200).SetContent("{\"status\":\"Running\"}"),
                new MockResponse(200).SetContent("{\"status\":\"Succeeded\",\"properties\":{\"remediationId\":\"polled-id\"}}"));
            var request = ModelReaderWriter.Read<SovereignViewRemediateContent>(BinaryData.FromString(RemediationRequest));
            var operation = await CreateResource(transport).RemediateAsync(WaitUntil.Started, request);
            Assert.That(operation.HasCompleted, Is.False);
            await operation.UpdateStatusAsync();
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.GetRehydrationToken(), Is.Not.Null);
            var response = await operation.WaitForCompletionAsync();
            Assert.That(response.Value.RemediationId, Is.EqualTo("polled-id"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ListContinuationPreservesServiceLinkAndFailure(bool subscriptionScope)
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000001";
            string path = subscriptionScope
                ? $"/subscriptions/{subscriptionId}/providers/Microsoft.Sovereign/sovereignViews"
                : $"/subscriptions/{subscriptionId}/resourceGroups/test/providers/Microsoft.Sovereign/sovereignViews";
            string nextLink = "https://management.azure.com" + path +
                "?api-version=2026-10-31-preview&$skiptoken=opaque%2Btoken%2Fvalue%3D";
            var transport = new MockTransport(
                new MockResponse(200).SetContent("{\"value\":[],\"nextLink\":\"" + nextLink + "\"}"),
                new MockResponse(502).SetContent("{\"error\":{\"code\":\"ProviderError\",\"message\":\"Continuation failed\"}}"));
            var options = new ArmClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            var client = new ArmClient(new MockCredential(), subscriptionId, options);
            AsyncPageable<SovereignViewResource> resources = subscriptionScope
                ? client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(subscriptionId)).GetSovereignViewsAsync()
                : client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(subscriptionId, "test")).GetSovereignViews().GetAllAsync();
            await using var pages = resources.AsPages().GetAsyncEnumerator();
            Assert.That(await pages.MoveNextAsync(), Is.True);
            Assert.That(pages.Current.ContinuationToken, Is.EqualTo(nextLink));
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await pages.MoveNextAsync());
            Assert.That(exception.Status, Is.EqualTo(502));
            Assert.That(exception.ErrorCode, Is.EqualTo("ProviderError"));
            Assert.That(transport.Requests.Count(), Is.EqualTo(2));
            Assert.That(transport.Requests.Last().Uri.ToUri().AbsoluteUri, Is.EqualTo(new Uri(nextLink).AbsoluteUri));
        }

        [Test]
        public void CancellationStillPropagates()
        {
            var transport = new MockTransport(
                new MockResponse(202).AddHeader("Azure-AsyncOperation", "https://management.azure.com/operations/test"),
                new MockResponse(200).AddHeader("Retry-After", "30").SetContent("{\"status\":\"Running\"}"));
            var request = ModelReaderWriter.Read<SovereignViewRemediateContent>(BinaryData.FromString(RemediationRequest));
            using var cancellation = new CancellationTokenSource();
            cancellation.CancelAfter(TimeSpan.FromMilliseconds(50));
            Assert.CatchAsync<OperationCanceledException>(async () =>
                await CreateResource(transport).RemediateAsync(WaitUntil.Completed, request, cancellation.Token));
        }

        private static SovereignViewResource CreateResource(MockTransport transport)
        {
            var options = new ArmClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            return new ArmClient(new MockCredential(), "00000000-0000-0000-0000-000000000001", options).GetSovereignViewResource(new ResourceIdentifier(ViewId));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AIInfraOptimization.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AIInfraOptimization.Tests
{
    public class RecommendVmSkuTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private static readonly ModelReaderWriterOptions WireOptions = new ModelReaderWriterOptions("W");
        private const string RecommendationResponse = """
            {
              "options": [
                {
                  "vmSize": "Standard_NC24ads_A100_v4",
                  "recommendationRank": 1,
                  "readiness": { "status": "VerificationRequired", "reason": "Placement was not evaluated." },
                  "topology": {
                    "estimatedNodeCountPerReplica": 1,
                    "estimatedTotalNodeCount": 2,
                    "accelerator": { "model": "A100", "countPerVm": 1, "memoryGiBPerAccelerator": 80 }
                  },
                  "cost": {
                    "currencyCode": "USD",
                    "vmHourly": 3.5,
                    "deploymentHourly": 7,
                    "source": "AzureRetail",
                    "priceAsOf": "2026-06-01T12:00:00Z"
                  },
                  "quota": { "status": "Available", "maxAvailableReplicaCount": 4 },
                  "placement": {
                    "status": "NotEvaluated",
                    "error": { "code": "TimedOut", "message": "Placement evaluation timed out." }
                  },
                  "azureMlRecommended": true,
                  "benchmark": { "level": "Benchmarked", "modelClass": "8b", "scenario": "Server", "submitterCount": 1 }
                }
              ],
              "sizing": {
                "model": { "parameterCount": 8000000000, "weightPrecision": "INT8" },
                "workload": { "maxConcurrentRequestsPerReplica": 2, "contextLength": 4096 },
                "memory": { "modelWeightsGiB": 8, "kvCacheGiBPerRequest": 1, "kvCacheGiBTotal": 2, "modelAndKvCacheGiB": 10 },
                "basis": { "parameterCountSource": "Request", "contextLengthSource": "Request", "modelWeightsCalculation": "EstimatedFromParameterCount" }
              }
            }
            """;

        [TestCase(false)]
        [TestCase(true)]
        public async Task RecommendVmSkuPreservesRequestAndResponseContract(bool isAsync)
        {
            var transport = new MockTransport(request =>
            {
                Assert.That(request.Method, Is.EqualTo(RequestMethod.Post));
                Assert.That(request.Uri.ToUri().AbsoluteUri, Is.EqualTo(
                    $"https://management.azure.com/subscriptions/{SubscriptionId}/providers/Microsoft.AIInfraOptimization/locations/eastus/recommendVmSku?api-version=2026-06-01-preview"));
                Assert.That(request.Headers.TryGetValue("Content-Type", out string contentType), Is.True);
                Assert.That(contentType, Is.EqualTo("application/json"));
                Assert.That(request.Headers.TryGetValue("Accept", out string accept), Is.True);
                Assert.That(accept, Is.EqualTo("application/json"));
                using var stream = new MemoryStream();
                request.Content.WriteTo(stream, CancellationToken.None);
                using JsonDocument document = JsonDocument.Parse(stream.ToArray());
                AssertRequestContent(document.RootElement, "INT8");
                return new MockResponse(200).SetContent(RecommendationResponse);
            });
            SubscriptionResource subscription = CreateSubscription(transport);
            RecommendVmSkuContent content = CreateContent(WeightPrecision.Int8);

            Response<RecommendVmSkuResult> response = isAsync
                ? await subscription.RecommendVmSkuAsync(AzureLocation.EastUS, content)
                : subscription.RecommendVmSku(AzureLocation.EastUS, content);

            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Options, Has.Count.EqualTo(1));
            AIInfraOptimizationRecommendVmSkuOptionConfig option = response.Value.Options[0];
            Assert.That(option.VmSize, Is.EqualTo("Standard_NC24ads_A100_v4"));
            Assert.That(option.Readiness.Status, Is.EqualTo(RecommendVmSkuReadinessStatus.VerificationRequired));
            Assert.That(option.Topology.EstimatedTotalNodeCount, Is.EqualTo(2));
            Assert.That(option.Cost.Source, Is.EqualTo(RecommendVmSkuCostSource.AzureRetail));
            Assert.That(option.Cost.DeploymentHourly, Is.EqualTo(7));
            Assert.That(option.Cost.PriceObservedOn, Is.EqualTo(new DateTimeOffset(2026, 6, 1, 12, 0, 0, TimeSpan.Zero)));
            Assert.That(option.IsAzureMlRecommended, Is.True);
            Assert.That(option.Quota.Status, Is.EqualTo(RecommendVmSkuQuotaStatus.Available));
            Assert.That(option.Placement.Status, Is.EqualTo(RecommendVmSkuPlacementStatus.NotEvaluated));
            Assert.That(option.Placement.Error.Code, Is.EqualTo(RecommendVmSkuStageErrorCode.TimedOut));
            Assert.That(option.Benchmark.Level, Is.EqualTo(RecommendVmSkuBenchmarkLevel.Benchmarked));
            Assert.That(response.Value.Sizing.Model.ParameterCount, Is.EqualTo(8000000000L));
            Assert.That(response.Value.Sizing.Model.WeightPrecision, Is.EqualTo(WeightPrecision.Int8));
            Assert.That(response.Value.Sizing.Workload.ContextLength, Is.EqualTo(4096));
            Assert.That(response.Value.Sizing.Memory.ModelAndKvCacheGiB, Is.EqualTo(10));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void RecommendVmSkuReportsServiceError(bool isAsync)
        {
            var transport = new MockTransport(new MockResponse(400)
                .SetContent("""{"error":{"code":"InvalidRequest","message":"The workload is invalid."}}"""));
            SubscriptionResource subscription = CreateSubscription(transport);
            RecommendVmSkuContent content = CreateContent(WeightPrecision.Int8);

            RequestFailedException exception = isAsync
                ? Assert.ThrowsAsync<RequestFailedException>(async () => await subscription.RecommendVmSkuAsync(AzureLocation.EastUS, content))
                : Assert.Throws<RequestFailedException>(() => subscription.RecommendVmSku(AzureLocation.EastUS, content));

            Assert.That(exception.Status, Is.EqualTo(400));
            Assert.That(exception.ErrorCode, Is.EqualTo("InvalidRequest"));
            Assert.That(exception.Message, Does.Contain("The workload is invalid."));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
        }

        [TestCase("INT8")]
        [TestCase("INT4")]
        public void RenamedRequestMembersPreserveWireNames(string precision)
        {
            RecommendVmSkuContent content = CreateContent(precision == "INT8" ? WeightPrecision.Int8 : WeightPrecision.Int4);
            BinaryData data = ModelReaderWriter.Write(content, WireOptions, AzureResourceManagerAIInfraOptimizationContext.Default);
            using JsonDocument document = JsonDocument.Parse(data);
            AssertRequestContent(document.RootElement, precision);
        }

        [Test]
        public void UnspecifiedSubscriptionFlagsAreOmitted()
        {
            var content = new RecommendVmSkuContent { SubscriptionOptions = new RecommendVmSkuSubscriptionConfig() };
            BinaryData data = ModelReaderWriter.Write(content, WireOptions, AzureResourceManagerAIInfraOptimizationContext.Default);
            using JsonDocument document = JsonDocument.Parse(data);
            JsonElement subscription = document.RootElement.GetProperty("subscriptionOptions");
            Assert.That(subscription.TryGetProperty("includeQuota", out _), Is.False);
            Assert.That(subscription.TryGetProperty("includePlacement", out _), Is.False);
            Assert.That(subscription.TryGetProperty("includePricing", out _), Is.False);
        }

        [TestCase("""{"cost":{}}""")]
        [TestCase("""{"azureMlRecommended":null,"cost":{"priceAsOf":null}}""")]
        public void OptionalResponseMembersRemainNullable(string json)
        {
            var option = ModelReaderWriter.Read<AIInfraOptimizationRecommendVmSkuOptionConfig>(
                BinaryData.FromString(json), WireOptions, AzureResourceManagerAIInfraOptimizationContext.Default);
            Assert.That(option.IsAzureMlRecommended, Is.Null);
            Assert.That(option.Cost.PriceObservedOn, Is.Null);
        }

        [Test]
        public void UnknownPlacementStatusRoundTrips()
        {
            var placement = ModelReaderWriter.Read<RecommendVmSkuPlacement>(
                BinaryData.FromString("""{"status":"FutureStatus"}"""), WireOptions, AzureResourceManagerAIInfraOptimizationContext.Default);
            Assert.That(placement.Status.ToString(), Is.EqualTo("FutureStatus"));
            BinaryData data = ModelReaderWriter.Write(placement, ModelReaderWriterOptions.Json, AzureResourceManagerAIInfraOptimizationContext.Default);
            using JsonDocument document = JsonDocument.Parse(data);
            Assert.That(document.RootElement.GetProperty("status").GetString(), Is.EqualTo("FutureStatus"));
        }

        private static SubscriptionResource CreateSubscription(MockTransport transport)
        {
            var options = new ArmClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);
            return client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));
        }

        private static RecommendVmSkuContent CreateContent(WeightPrecision precision) => new RecommendVmSkuContent
        {
            Model = new RecommendVmSkuModel { ParameterCount = 8000000000L, WeightPrecision = precision },
            Workload = new RecommendVmSkuWorkload { MaxConcurrentRequestsPerReplica = 2 },
            Deployment = new RecommendVmSkuDeployment { ReplicaCount = 2, ProcurementOption = RecommendVmSkuProcurementOption.OnDemand },
            Optimization = new RecommendVmSkuOptimization { RankingPreference = RecommendVmSkuRankingPreference.Cost },
            TargetVmSizes = { "Standard_NC24ads_A100_v4" },
            SubscriptionOptions = new RecommendVmSkuSubscriptionConfig
            {
                ShouldIncludeQuota = true,
                ShouldIncludePlacement = false,
                ShouldIncludePricing = true
            }
        };

        private static void AssertRequestContent(JsonElement content, string precision)
        {
            Assert.That(content.GetProperty("model").GetProperty("weightPrecision").GetString(), Is.EqualTo(precision));
            Assert.That(content.GetProperty("model").GetProperty("parameterCount").GetInt64(), Is.EqualTo(8000000000L));
            Assert.That(content.GetProperty("deployment").GetProperty("procurementOption").GetString(), Is.EqualTo("OnDemand"));
            Assert.That(content.GetProperty("optimization").GetProperty("rankingPreference").GetString(), Is.EqualTo("Cost"));
            Assert.That(content.GetProperty("targetVmSizes")[0].GetString(), Is.EqualTo("Standard_NC24ads_A100_v4"));
            JsonElement subscription = content.GetProperty("subscriptionOptions");
            Assert.That(subscription.GetProperty("includeQuota").GetBoolean(), Is.True);
            Assert.That(subscription.GetProperty("includePlacement").GetBoolean(), Is.False);
            Assert.That(subscription.GetProperty("includePricing").GetBoolean(), Is.True);
            Assert.That(subscription.TryGetProperty("shouldIncludeQuota", out _), Is.False);
            Assert.That(subscription.TryGetProperty("shouldIncludePlacement", out _), Is.False);
            Assert.That(subscription.TryGetProperty("shouldIncludePricing", out _), Is.False);
        }
    }
}

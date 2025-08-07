// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Monitor.Query.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class MetricsQueryClientTests
    {
        [Test]
        public async Task UsesDefaultEndpoint()
        {
            var mockTransport = MockTransport.FromMessageCallback(_ => new MockResponse(200).SetContent("{}"));

            var client = new MetricsQueryClient(new MockCredential(), new MetricsQueryClientOptions()
            {
                Transport = mockTransport
            });

            await client.QueryResourceAsync("rid", new string[]{});
            StringAssert.StartsWith("https://management.azure.com", mockTransport.SingleRequest.Uri.ToString());
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        private static IEnumerable<object[]> GetAudience()
        {
            yield return new object[] { null, "https://management.azure.com//.default" };
            yield return new object[] { MetricsQueryAudience.AzurePublicCloud, "https://management.azure.com//.default" };
            yield return new object[] { MetricsQueryAudience.AzureGovernment, "https://management.usgovcloudapi.net//.default" };
            yield return new object[] { MetricsQueryAudience.AzureChina, "https://management.chinacloudapi.cn//.default" };
        }

        [Test]
        [TestCaseSource(nameof(GetAudience))]
        public async Task UsesDefaultAuthScope(MetricsQueryAudience audience, string expectedScope)
        {
            var mockTransport = MockTransport.FromMessageCallback(_ => new MockResponse(200).SetContent("{}"));

            Mock<MockCredential> mock = new() { CallBase = true };

            string[] scopes = null;
            mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .Callback<TokenRequestContext, CancellationToken>((c, _) => scopes = c.Scopes)
                .CallBase();

            var options = new MetricsQueryClientOptions()
            {
                Transport = mockTransport,
                Audience = audience
            };

            var client = new MetricsQueryClient(mock.Object, options);

            await client.QueryResourceAsync("", new string[] { });
            Assert.AreEqual(new[] { expectedScope }, scopes);
        }

        [Test]
        public void ExposesPublicEndpoint()
        {
            var client = new MetricsQueryClient(new Uri("https://management.azure.gov"), new MockCredential(), new MetricsQueryClientOptions());
            Assert.AreEqual(new Uri("https://management.azure.gov"), client.Endpoint);
        }

        [Test]
        public void CanGetMetricQueryResult()
        {
            var metadata = new Dictionary<string, string> { { "metadatatest1", "metadatatest2" } };
            var metricValue = MonitorQueryModelFactory.MetricValue(new DateTimeOffset(new DateTime(10)));
            var metricValueList = new List<MetricValue>() { metricValue };
            MetricTimeSeriesElement metricTimeSeriesElement = MonitorQueryModelFactory.MetricTimeSeriesElement(metadata, metricValueList);
            Assert.IsNotNull(metricTimeSeriesElement);
            Assert.AreEqual(1, metricTimeSeriesElement.Metadata.Count);
            var firstElement = metricTimeSeriesElement.Metadata.First();
            Assert.AreEqual("metadatatest1", firstElement.Key);
            Assert.AreEqual("metadatatest2", firstElement.Value);
            Assert.AreEqual(1, metricTimeSeriesElement.Values.Count);
            Assert.AreEqual(new DateTimeOffset(new DateTime(10)), metricTimeSeriesElement.Values[0].TimeStamp);
            IEnumerable<MetricTimeSeriesElement> metricTimeSeriesElements = new[] { metricTimeSeriesElement };

            MetricUnit metricUnit = new MetricUnit("test");
            Assert.IsNotNull(metricUnit);
            Assert.AreEqual("test", metricUnit.ToString());

            MetricResult metricResult = MonitorQueryModelFactory.MetricResult("https://management.azure.gov", "type", "name", metricUnit, metricTimeSeriesElements);
            Assert.IsNotNull(metricResult);
            Assert.AreEqual(null, metricResult.Description);
            Assert.AreEqual(null, metricResult.Error.Code);
            Assert.AreEqual(null, metricResult.Error.Message);
            Assert.AreEqual("https://management.azure.gov", metricResult.Id);
            Assert.AreEqual("name", metricResult.Name);
            Assert.AreEqual("type", metricResult.ResourceType);
            Assert.AreEqual(1, metricResult.TimeSeries.Count);
            Assert.AreEqual("test", metricResult.Unit.ToString());
            IEnumerable<MetricResult> metricResults = new[] { metricResult };

            MetricsQueryResult metricsQueryResult = MonitorQueryModelFactory.MetricsQueryResult(null, TimeSpan.FromMinutes(3).ToString(), null, "namespace", "eastus", metricResults.ToList());
            Assert.AreEqual(null, metricsQueryResult.Cost);
            Assert.AreEqual(null, metricsQueryResult.Granularity);
            Assert.AreEqual(1, metricsQueryResult.Metrics.Count);
            Assert.AreEqual(null, metricsQueryResult.Metrics[0].Description);
            Assert.AreEqual(null, metricsQueryResult.Metrics[0].Error.Code);
            Assert.AreEqual(null, metricsQueryResult.Metrics[0].Error.Message);
            Assert.AreEqual("https://management.azure.gov", metricsQueryResult.Metrics[0].Id);
            Assert.AreEqual("name", metricsQueryResult.Metrics[0].Name);
            Assert.AreEqual("type", metricsQueryResult.Metrics[0].ResourceType);
            Assert.AreEqual("namespace", metricsQueryResult.Namespace);
            Assert.AreEqual("eastus", metricsQueryResult.ResourceRegion);
            Assert.IsNotNull(metricsQueryResult);
        }

        [Test]
        public void Constructor_WhenOptionsIsNull_UsesDefaultEndpoint()
        {
            // Arrange
            var credential = new DefaultAzureCredential();

            // Act
            var client = new MetricsQueryClient(credential);

            // Assert
            Assert.AreEqual(MetricsQueryAudience.AzurePublicCloud.ToString(), client.Endpoint.OriginalString);
        }

        [Test]
        public void Constructor_WhenOptionsIsNotNull_UsesOptionsAudience()
        {
            // Arrange
            var credential = new DefaultAzureCredential();
            var options = new MetricsQueryClientOptions
            {
                Audience = "https://custom.audience"
            };

            // Act
            var client = new MetricsQueryClient(credential, options);

            // Assert
            Assert.AreEqual("https://custom.audience", client.Endpoint.OriginalString);
        }
    }
}

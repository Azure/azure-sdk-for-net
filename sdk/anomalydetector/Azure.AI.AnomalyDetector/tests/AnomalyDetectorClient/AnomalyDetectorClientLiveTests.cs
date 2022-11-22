// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.AnomalyDetector.Tests.Infrastructure;
using Azure.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.AI.AnomalyDetector.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="AnomalyDetectorClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class AnomalyDetectorClientLiveTests : AnomalyDetectorLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyDetectorClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public AnomalyDetectorClientLiveTests(bool isAsync) : base(isAsync)
        {
        }
        [Test]
        public async Task GetResultForEntireDetect()
        {
            var client = CreateAnomalyDetectorClient();
            dynamic request = TestData.request;
            request.MaxAnomalyRatio = 0.25F;
            request.Sensitivity = 95;
            Response response = await client.DetectUnivariateEntireSeriesAsync(RequestContent.Create(JsonConvert.SerializeObject(request))).ConfigureAwait(false);
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

            Assert.IsNotNull(result.GetProperty("expectedValues"));
            Assert.IsNotNull(result.GetProperty("expectedValues"));
            Assert.IsNotNull(result.GetProperty("upperMargins"));
            Assert.IsNotNull(result.GetProperty("lowerMargins"));
            Assert.IsNotNull(result.GetProperty("isAnomaly"));
            Assert.IsNotNull(result.GetProperty("isPositiveAnomaly"));
            Assert.IsNotNull(result.GetProperty("isNegativeAnomaly"));
            Assert.IsNotNull(result.GetProperty("severity"));
        }

        [Test]
        public async Task GetResultForLastDetect()
        {
            var client = CreateAnomalyDetectorClient();

            dynamic request = TestData.request;
            request.MaxAnomalyRatio = 0.25F;
            request.Sensitivity = 95;
            Response response = await client.DetectUnivariateLastPointAsync(RequestContent.Create(JsonConvert.SerializeObject(request))).ConfigureAwait(false);
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

            Assert.IsNotNull(result.GetProperty("expectedValue"));
            Assert.IsNotNull(result.GetProperty("isAnomaly"));
            Assert.IsNotNull(result.GetProperty("isNegativeAnomaly"));
            Assert.IsNotNull(result.GetProperty("isPositiveAnomaly"));
            Assert.IsNotNull(result.GetProperty("lowerMargin"));
            Assert.IsNotNull(result.GetProperty("period"));
            Assert.IsNotNull(result.GetProperty("suggestedWindow"));
            Assert.IsNotNull(result.GetProperty("upperMargin"));
            Assert.IsNotNull(result.GetProperty("severity"));
        }

        [Test]
        public async Task GetResultForChangePointDetect()
        {
            var client = CreateAnomalyDetectorClient();

            dynamic request = TestData.changePointRequest;
            request.CustomInterval = 5;
            request.StableTrendWindow = 10;
            request.Threshold = 0.5F;
            request.Period = 0;
            Response response = await client.DetectUnivariateChangePointAsync(RequestContent.Create(JsonConvert.SerializeObject(request))).ConfigureAwait(false);
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
            Assert.IsNotNull(result.GetProperty("period"));
            Assert.IsNotNull(result.GetProperty("isChangePoint"));
            Assert.IsNotNull(result.GetProperty("confidenceScores"));
        }
    }
}

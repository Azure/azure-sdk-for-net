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
            Response response = await client.DetectEntireSeriesAsync(RequestContent.Create(JsonConvert.SerializeObject(request)));
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

            /*
            Assert.AreEqual(TestData.ExpectedEntireDetectResult.GetValue("expectedValues"), JArray.Parse(result.GetProperty("expectedValues").ToString()));
            Assert.AreEqual(TestData.ExpectedEntireDetectResult.GetValue("upperMargins"), JArray.Parse(result.GetProperty("upperMargins").ToString()));
            Assert.AreEqual(TestData.ExpectedEntireDetectResult.GetValue("lowerMargins"), JArray.Parse(result.GetProperty("lowerMargins").ToString()));
            Assert.AreEqual(TestData.ExpectedEntireDetectResult.GetValue("isAnomaly"), JArray.Parse(result.GetProperty("isAnomaly").ToString()));
            Assert.AreEqual(TestData.ExpectedEntireDetectResult.GetValue("isPositiveAnomaly"), JArray.Parse(result.GetProperty("isPositiveAnomaly").ToString()));
            Assert.AreEqual(TestData.ExpectedEntireDetectResult.GetValue("isNegativeAnomaly"), JArray.Parse(result.GetProperty("isNegativeAnomaly").ToString()));
            Assert.AreEqual(TestData.ExpectedEntireDetectResult.GetValue("severity"), JArray.Parse(result.GetProperty("severity").ToString()));
            */
        }

        [Test]
        public async Task GetResultForLastDetect()
        {
            var client = CreateAnomalyDetectorClient();

            dynamic request = TestData.request;
            request.MaxAnomalyRatio = 0.25F;
            request.Sensitivity = 95;
            Response response = await client.DetectLastPointAsync(RequestContent.Create(JsonConvert.SerializeObject(request)));
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

            /*
            Assert.AreEqual(809.5658016931228F, float.Parse(result.GetProperty("expectedValue").ToString()));
            Assert.AreEqual(false, bool.Parse(result.GetProperty("isAnomaly").ToString()));
            Assert.AreEqual(false, bool.Parse(result.GetProperty("isNegativeAnomaly").ToString()));
            Assert.AreEqual(false, bool.Parse(result.GetProperty("isPositiveAnomaly").ToString()));
            Assert.AreEqual(40.47829008465612F, float.Parse(result.GetProperty("lowerMargin").ToString()));
            Assert.AreEqual(12, int.Parse(result.GetProperty("period").ToString()));
            Assert.AreEqual(49, int.Parse(result.GetProperty("suggestedWindow").ToString()));
            Assert.AreEqual(40.47829008465612F, float.Parse(result.GetProperty("upperMargin").ToString()));
            Assert.AreEqual(0.0f, float.Parse(result.GetProperty("severity").ToString()));
            */
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
            Response response = await client.DetectChangePointAsync(RequestContent.Create(JsonConvert.SerializeObject(request)));
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

            /*
            Assert.AreEqual(TestData.ExpectedChangePointResult.GetValue("period"), int.Parse(result.GetProperty("period").ToString()));
            Assert.AreEqual(TestData.ExpectedChangePointResult.GetValue("isChangePoint"), JArray.Parse(result.GetProperty("isChangePoint").ToString()));
            Assert.AreEqual(TestData.ExpectedChangePointResult.GetValue("confidenceScores"), JArray.Parse(result.GetProperty("confidenceScores").ToString()));
            */
        }
    }
}

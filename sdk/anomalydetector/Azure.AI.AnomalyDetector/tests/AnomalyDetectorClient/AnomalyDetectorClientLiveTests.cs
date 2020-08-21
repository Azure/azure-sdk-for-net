// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.AnomalyDetector.Models;
using Azure.AI.AnomalyDetector.Tests.Infrastructure;
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

            var request = TestData.TestPointSeries;
            request.MaxAnomalyRatio = 0.25F;
            request.Sensitivity = 95;
            var result = await client.EntireDetectAsync(request);

            Assert.AreEqual(TestData.ExpectedEntireResult.ExpectedValues, result.Value.ExpectedValues);
            Assert.AreEqual(TestData.ExpectedEntireResult.UpperMargins, result.Value.UpperMargins);
            Assert.AreEqual(TestData.ExpectedEntireResult.LowerMargins, result.Value.LowerMargins);
            Assert.AreEqual(TestData.ExpectedEntireResult.IsAnomaly, result.Value.IsAnomaly);
            Assert.AreEqual(TestData.ExpectedEntireResult.IsPositiveAnomaly, result.Value.IsPositiveAnomaly);
            Assert.AreEqual(TestData.ExpectedEntireResult.IsNegativeAnomaly, result.Value.IsNegativeAnomaly);
        }

        [Test]
        public async Task GetResultForLastDetect()
        {
            var client = CreateAnomalyDetectorClient();

            var request = TestData.TestPointSeries;
            request.MaxAnomalyRatio = 0.25F;
            request.Sensitivity = 95;

            var expectedResult = new LastDetectResponse(
                expectedValue: 809.5658016931228F,
                isAnomaly: false,
                isNegativeAnomaly: false,
                isPositiveAnomaly: false,
                lowerMargin: 40.47829008465612F,
                period: 12,
                suggestedWindow: 49,
                upperMargin: 40.47829008465612F);

            var result = await client.LastDetectAsync(request);
            Assert.AreEqual(expectedResult.ExpectedValue, result.Value.ExpectedValue);
            Assert.AreEqual(expectedResult.IsAnomaly, result.Value.IsAnomaly);
            Assert.AreEqual(expectedResult.IsNegativeAnomaly, result.Value.IsNegativeAnomaly);
            Assert.AreEqual(expectedResult.IsPositiveAnomaly, result.Value.IsPositiveAnomaly);
            Assert.AreEqual(expectedResult.LowerMargin, result.Value.LowerMargin);
            Assert.AreEqual(expectedResult.Period, result.Value.Period);
            Assert.AreEqual(expectedResult.SuggestedWindow, result.Value.SuggestedWindow);
            Assert.AreEqual(expectedResult.UpperMargin, result.Value.UpperMargin);
        }

        [Test]
        public async Task GetResultForChangePointDetect()
        {
            var client = CreateAnomalyDetectorClient();

            var request = TestData.TestChangePointSeries;
            request.CustomInterval = 5;
            request.StableTrendWindow = 10;
            request.Threshold = 0.5F;
            request.Period = 0;
            var result = await client.ChangePointDetectAsync(request);

            Assert.AreEqual(TestData.ExpectedChangePointResult.Period, result.Value.Period);
            Assert.AreEqual(TestData.ExpectedChangePointResult.IsChangePoint, result.Value.IsChangePoint);
            Assert.AreEqual(TestData.ExpectedChangePointResult.ConfidenceScores, result.Value.ConfidenceScores);
        }
    }
}

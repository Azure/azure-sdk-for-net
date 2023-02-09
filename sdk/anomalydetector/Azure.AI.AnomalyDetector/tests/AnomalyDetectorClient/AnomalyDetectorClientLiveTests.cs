// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
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
            var result = await client.DetectUnivariateEntireSeriesAsync(request);

            Assert.IsNotNull(result.Value.ExpectedValues);
            Assert.IsNotNull(result.Value.UpperMargins);
            Assert.IsNotNull(result.Value.LowerMargins);
            Assert.IsNotNull(result.Value.IsAnomaly);
            Assert.IsNotNull(result.Value.IsPositiveAnomaly);
            Assert.IsNotNull(result.Value.IsNegativeAnomaly);
            Assert.IsNotNull(result.Value.Severity);
        }

        [Test]
        public async Task GetResultForLastDetect()
        {
            var client = CreateAnomalyDetectorClient();

            var request = TestData.TestPointSeries;
            request.MaxAnomalyRatio = 0.25F;
            request.Sensitivity = 95;
            var result = await client.DetectUnivariateLastPointAsync(request);

            Assert.IsNotNull(result.Value.ExpectedValue);
            Assert.IsNotNull(result.Value.IsAnomaly);
            Assert.IsNotNull(result.Value.IsNegativeAnomaly);
            Assert.IsNotNull(result.Value.IsPositiveAnomaly);
            Assert.IsNotNull(result.Value.LowerMargin);
            Assert.IsNotNull(result.Value.Period);
            Assert.IsNotNull(result.Value.SuggestedWindow);
            Assert.IsNotNull(result.Value.UpperMargin);
            Assert.IsNotNull(result.Value.Severity);
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
            var result = await client.DetectUnivariateChangePointAsync(request);

            Assert.IsNotNull(result.Value.Period);
            Assert.IsNotNull(result.Value.IsChangePoint);
            Assert.IsNotNull(result.Value.ConfidenceScores);
        }

        [Test]
        public async Task GetResultForMultivariateListModel()
        {
            var client = CreateAnomalyDetectorClient();

            int model_number = 0;
            await foreach (var multivariateModel in client.GetMultivariateModelsAsync())
            {
                model_number++;
            }

            Assert.IsTrue(model_number >= 0);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
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
            var response = await client.GetUnivariateClient().DetectUnivariateEntireSeriesAsync(request.ToRequestContent());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Assert.That(result.GetProperty("expectedValues"), Is.Not.Null);
            Assert.That(result.GetProperty("upperMargins"), Is.Not.Null);
            Assert.That(result.GetProperty("lowerMargins"), Is.Not.Null);
            Assert.That(result.GetProperty("isAnomaly"), Is.Not.Null);
            Assert.That(result.GetProperty("isPositiveAnomaly"), Is.Not.Null);
            Assert.That(result.GetProperty("isNegativeAnomaly"), Is.Not.Null);
            Assert.That(result.GetProperty("severity"), Is.Not.Null);
        }

        [Test]
        public async Task GetResultForLastDetect()
        {
            var client = CreateAnomalyDetectorClient();

            var request = TestData.TestPointSeries;
            request.MaxAnomalyRatio = 0.25F;
            request.Sensitivity = 95;
            var result = await client.GetUnivariateClient().DetectUnivariateLastPointAsync(request);

            Assert.That(result.Value.ExpectedValue, Is.Not.Null);
            Assert.That(result.Value.IsAnomaly, Is.Not.Null);
            Assert.That(result.Value.IsNegativeAnomaly, Is.Not.Null);
            Assert.That(result.Value.IsPositiveAnomaly, Is.Not.Null);
            Assert.That(result.Value.LowerMargin, Is.Not.Null);
            Assert.That(result.Value.Period, Is.Not.Null);
            Assert.That(result.Value.SuggestedWindow, Is.Not.Null);
            Assert.That(result.Value.UpperMargin, Is.Not.Null);
            Assert.That(result.Value.Severity, Is.Not.Null);
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
            var result = await client.GetUnivariateClient().DetectUnivariateChangePointAsync(request);

            Assert.That(result.Value.Period, Is.Not.Null);
            Assert.That(result.Value.IsChangePoint, Is.Not.Null);
            Assert.That(result.Value.ConfidenceScores, Is.Not.Null);
        }

        [Test]
        public async Task GetResultForMultivariateListModel()
        {
            var client = CreateAnomalyDetectorClient();

            int model_number = 0;
            await foreach (var multivariateModel in client.GetMultivariateClient().GetMultivariateModelsAsync())
            {
                model_number++;
            }

            Assert.That(model_number >= 0, Is.True);
        }
    }
}

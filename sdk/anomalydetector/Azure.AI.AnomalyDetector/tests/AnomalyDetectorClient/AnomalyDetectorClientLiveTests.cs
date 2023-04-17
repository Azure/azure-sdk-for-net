// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.AnomalyDetector.Tests.Infrastructure;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Newtonsoft.Json;

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
        private string modelId;
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

        [Test]
        public async Task TrainMultivariateModel()
        {
            var client = CreateAnomalyDetectorClient();

            string dataSource = TestEnvironment.DataSource;
            TimeSpan offset = new TimeSpan(0);
            DateTimeOffset startTime = new DateTimeOffset(2021, 1, 2, 0, 0, 0, offset);
            DateTimeOffset endTime = new DateTimeOffset(2021, 1, 2, 5, 0, 0, offset);
            ModelInfo modelInfo = new ModelInfo(dataSource, startTime, endTime);
            modelInfo.DataSchema = DataSchema.OneTable;
            modelInfo.SlidingWindow = 100;
            modelInfo.AlignPolicy = new AlignPolicy();
            modelInfo.AlignPolicy.AlignMode = new AlignMode("Outer");
            modelInfo.AlignPolicy.FillNAMethod = new FillNAMethod("Linear");
            modelInfo.AlignPolicy.PaddingValue = 0;
            AnomalyDetectionModel response = await client.TrainMultivariateModelAsync(modelInfo);
            string modelId = response.ModelId;
            ModelStatus? status = response.ModelInfo.Status;
            Assert.IsNotNull(status);
            while (status != ModelStatus.Failed && status != ModelStatus.Ready)
            {
                System.Threading.Thread.Sleep(10000);
                response = await client.GetMultivariateModelValueAsync(modelId);
                status = response.ModelInfo.Status;
            }
            Assert.AreEqual(ModelStatus.Ready, status);
            this.modelId = modelId;
        }

        [Test]
        public async Task MultivariateBatchDetection()
        {
            var client = CreateAnomalyDetectorClient();
            string dataSource = TestEnvironment.DataSource;
            TimeSpan offset = new TimeSpan(0);
            DateTimeOffset startTime = new DateTimeOffset(2021, 1, 2, 0, 0, 0, offset);
            DateTimeOffset endTime = new DateTimeOffset(2021, 1, 2, 5, 0, 0, offset);
            MultivariateBatchDetectionOptions request = new MultivariateBatchDetectionOptions(dataSource, 10, startTime, endTime);
            MultivariateDetectionResult response = await client.DetectMultivariateBatchAnomalyAsync(this.modelId, request);
            String resultId = response.ResultId;
            MultivariateBatchDetectionStatus status = response.Summary.Status;
            Assert.IsNotNull(status);
            while (status != MultivariateBatchDetectionStatus.Ready && status != MultivariateBatchDetectionStatus.Failed)
            {
                System.Threading.Thread.Sleep(10000);
                response = await client.GetMultivariateBatchDetectionResultValueAsync(resultId);
                status = response.Summary.Status;
            }
        }

        [Test]
        public async Task MultivariateLastDetection()
        {
            var client = CreateAnomalyDetectorClient();
            List<VariableValues> variables = new List<VariableValues>();
            using (StreamReader r = new StreamReader("./samples/data/multivariate_sample_data.json"))
            {
                string json = r.ReadToEnd();
                JsonElement lastDetectVariables = JsonDocument.Parse(json).RootElement.GetProperty("variables");
                foreach (var index in Enumerable.Range(0, lastDetectVariables.GetArrayLength()))
                {
                    IEnumerable<string> timestamps = JsonConvert.DeserializeObject<IEnumerable<String>>(lastDetectVariables[index].GetProperty("timestamps").ToString());
                    IEnumerable<float> values = JsonConvert.DeserializeObject<IEnumerable<float>>(lastDetectVariables[index].GetProperty("values").ToString());
                    variables.Add(new VariableValues(lastDetectVariables[index].GetProperty("variable").ToString(), timestamps, values));
                }
            }
            MultivariateLastDetectionOptions request = new MultivariateLastDetectionOptions(variables);
            MultivariateLastDetectionResult response = await client.DetectMultivariateLastAnomalyAsync(this.modelId, request);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Results);
        }

        [Test]
        public async Task DeleteMultivariateModel()
        {
            var client = CreateAnomalyDetectorClient();
            await client.DeleteMultivariateModelAsync(this.modelId);
        }
    }
}

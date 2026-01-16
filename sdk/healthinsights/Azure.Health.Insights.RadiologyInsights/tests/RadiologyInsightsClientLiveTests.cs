// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using Azure.Core;
using System.Net;
using Azure.Core.TestFramework;
using Azure.Health.Insights.RadiologyInsights.Tests.Infrastructure;
using Azure.Health.Insights.RadiologyInsights;
using System.Text.Json;
using System;

namespace Azure.Health.Insights.RadiologyInsights.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="RadiologyInsightsClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class RadiologyInsightsClientLiveTests : HealthInsightsLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadiologyInsightsClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public RadiologyInsightsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetResultsFromCreateJob()
        {
            var client = CreateRadiologyInsightsClient();

            var request = GetRequestContent("RadiologyInsightsClientTest.request.json");
            var jobId = "job1714464002036";
            var operation = await client.InferRadiologyInsightsAsync(WaitUntil.Completed, jobId, request);

            Assert.That(operation, Is.Not.Null);
            Response response = operation.GetRawResponse();
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Status == (int)HttpStatusCode.OK, Is.True);
            RadiologyInsightsInferenceResult results = FetchResults(response);
            Assert.That(results.PatientResults, Is.Not.Empty);
            var patient = results.PatientResults[0];
            Assert.That(patient.Inferences, Is.Not.Empty);
        }

        private RequestContent GetRequestContent(string resourceName)
        {
            Assembly assembly = Assembly.GetAssembly(this.GetType());
            Stream content = assembly.GetManifestResourceStream($"Azure.Health.Insights.RadiologyInsights.Tests.TestData.{resourceName}");
            using StreamReader reader = new StreamReader(content);
            string data = reader.ReadToEnd();
            return RequestContent.Create(data);
        }

        private RadiologyInsightsInferenceResult FetchResults(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return RadiologyInsightsInferenceResult.DeserializeRadiologyInsightsInferenceResult(document.RootElement.GetProperty("result"));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using Azure.Core;
using System.Net;
using Azure.Core.TestFramework;
using Azure.Health.Insights.ClinicalMatching.Tests.Infrastructure;
using Azure.Health.Insights.ClinicalMatching;
using System.Text.Json;

namespace Azure.Health.Insights.ClinicalMatching.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="ClinicalMatchingClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class ClinicalMatchingClientLiveTests : HealthInsightsLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClinicalMatchingClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ClinicalMatchingClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetResultsFromCreateJob()
        {
            var client = CreateClinicalMatchingClient();

            var request = GetRequestContent("ClinicalMatchingClientTest.request.json");
            var operation = await client.MatchTrialsAsync(WaitUntil.Completed, request);

            Assert.IsNotNull(operation);
            Response response = operation.GetRawResponse();
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status == (int)HttpStatusCode.OK);
            TrialMatcherResults results = FetchResults(response);
            Assert.IsNotEmpty(results.Patients);
            var patient = results.Patients[0];
            Assert.IsNotEmpty(patient.Inferences);
        }

        private RequestContent GetRequestContent(string resourceName)
        {
            Assembly assembly = Assembly.GetAssembly(this.GetType());
            Stream content = assembly.GetManifestResourceStream($"Azure.Health.Insights.ClinicalMatching.Tests.TestData.{resourceName}");
            using StreamReader reader = new StreamReader(content);
            string data = reader.ReadToEnd();
            return RequestContent.Create(data);
        }

        private TrialMatcherResults FetchResults(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return TrialMatcherResults.DeserializeTrialMatcherResults(document.RootElement.GetProperty("results"));
        }
    }
}

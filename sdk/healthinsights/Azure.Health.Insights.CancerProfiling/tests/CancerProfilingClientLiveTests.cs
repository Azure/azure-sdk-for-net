// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using Azure.Core;
using System.Net;
using Azure.Core.TestFramework;
using Azure.Health.Insights.CancerProfiling.Tests.Infrastructure;
using Azure.Health.Insights.CancerProfiling;
using System;

namespace Azure.Health.Insights.CancerProfiling.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="CancerProfilingClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class CancerProfilingClientLiveTests : HealthInsightsLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancerProfilingClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public CancerProfilingClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetResultsFromCreateJob()
        {
            var client = CreateCancerProfilingClient();

            var request = GetRequestContent("CancerProfilingClientTest.request.json");
            try
            {
                var operation = await client.InferCancerProfileAsync(WaitUntil.Completed, request);
                Assert.IsNotNull(operation);
                Response response = operation.GetRawResponse();
                Assert.IsNotNull(response);
                Assert.IsTrue(response.Status == (int)HttpStatusCode.OK);
                OncoPhenotypeResult oncoResponse = OncoPhenotypeResult.FromResponse(response);
                Assert.IsNotEmpty(oncoResponse.Results.Patients);
                var patient = oncoResponse.Results.Patients[0];
                Assert.IsNotEmpty(patient.Inferences);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private RequestContent GetRequestContent(string resourceName)
        {
            Assembly assembly = Assembly.GetAssembly(this.GetType());
            Stream content = assembly.GetManifestResourceStream($"Azure.Health.Insights.CancerProfiling.Tests.TestData.{resourceName}");
            using StreamReader reader = new StreamReader(content);
            string data = reader.ReadToEnd();
            return RequestContent.Create(data);
        }
    }
}

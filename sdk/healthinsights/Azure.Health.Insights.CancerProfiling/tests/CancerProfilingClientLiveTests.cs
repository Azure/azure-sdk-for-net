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
using System.Collections.Generic;
using Microsoft.Extensions.Azure;
using System.Text.Json;

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
                OncoPhenotypeResults results = FetchResults(response);
                Assert.IsNotEmpty(results.Patients);
                var patient = results.Patients[0];
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

        private OncoPhenotypeResults FetchResults(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return OncoPhenotypeResults.DeserializeOncoPhenotypeResults(document.RootElement.GetProperty("results"));
        }

        // TODO: Use model class to compose request
        private OncoPhenotypeData GetRequestData()
        {
            var requestData = new OncoPhenotypeData(new List<PatientRecord> {
                new PatientRecord("patient1"){
                    Data = {
                        new PatientDocument(DocumentType.Note, "document1", new DocumentContent(DocumentContentSourceType.Inline, "Laterality: Left \n Tumor type present: Invasive duct carcinoma; duct carcinoma in situ \n Tumor site: Upper inner quadrant \n Invasive carcinoma \n Histologic type: Ductal \n Size of invasive component: 0.9 cm \n Histologic Grade - Nottingham combined histologic score: 1 out of 3 \n In situ carcinoma (DCIS) \n Histologic type of DCIS: Cribriform and solid \n Necrosis in DCIS: Yes \n DCIS component of invasive carcinoma: Extensive \n"))
                        {
                            Language = "en",
                            CreatedDateTime = DateTimeOffset.Parse("2022-01-01T00:00:00"),
                        }
                    }
                }
            })
            {
                Configuration = new OncoPhenotypeModelConfiguration()
                {
                    CheckForCancerCase = true,
                    IncludeEvidence = true
                }
            };

            return requestData;
        }
    }
}

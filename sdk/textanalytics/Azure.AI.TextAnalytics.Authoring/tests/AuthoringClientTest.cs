// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Authoring.Tests
{
    public class AuthoringClientTest : RecordedTestBase<AuthoringClientTestEnvironment>
    {
        public AuthoringClientTest(bool isAsync) : base(isAsync)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        public TextAuthoringClient GetClient()
        {
            string Endpoint = Environment.GetEnvironmentVariable("AZURE_TEXT_AUTHORING_ENDPOINT");
            string ApiKey = Environment.GetEnvironmentVariable("AZURE_TEXT_AUTHORING_KEY");
            return new TextAuthoringClient(new Uri(Endpoint), new AzureKeyCredential(ApiKey));
        }

        [RecordedTest]
        public void CreateProjectTest()
        {
            TextAuthoringClient client = GetClient();
            var data = new
            {
                projectKind = "CustomSingleLabelClassification",
                storageInputContainerName = "ct-data-assets",
                projectName = "Project_Name",
                multilingual = true,
                description = "A Test for .NET SDK",
                language = "en",
            };

            Response response = client.CreateProject("Project_Name", RequestContent.Create(data));
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

            // Reaching here means no exception was thrown so test passes
            Assert.IsTrue(true);
        }

        [RecordedTest]
        public void DeleteProjectTest()
        {
            TextAuthoringClient client = GetClient();

            var operation = client.DeleteProject(WaitUntil.Completed, "Project_Name");

            BinaryData response = operation.WaitForCompletion();
            JsonElement result = JsonDocument.Parse(response.ToStream()).RootElement;
            Assert.AreEqual(result.GetProperty("status").ToString(), "succeeded");
        }

        [RecordedTest]
        public void ExportProjectTest()
        {
            TextAuthoringClient client = GetClient();

            var operation = client.ExportProject(WaitUntil.Completed, "Project_Name", "Utf16CodeUnit");
            BinaryData response = operation.WaitForCompletion();
            JsonElement result = JsonDocument.Parse(response.ToStream()).RootElement;

            Assert.AreEqual(result.GetProperty("status").ToString(), "succeeded");
        }

        [RecordedTest]
        public void ImportProjectTest()
        {
            TextAuthoringClient client = GetClient();
            string projectJson = File.ReadAllText("../../../../../sdk/textanalytics/Azure.AI.TextAnalytics.Authoring/tests/Samples/sample_project.json");
            var data = JsonDocument.Parse(projectJson).RootElement;
            string arr = data.ToString();
            var content = RequestContent.Create(data);

            var operation = client.ImportProject(WaitUntil.Completed, "LoanAgreements", content);

            BinaryData response = operation.WaitForCompletion();
            JsonElement result = JsonDocument.Parse(response.ToStream()).RootElement;

            Assert.AreEqual(result.GetProperty("status").ToString(), "succeeded");
        }

        [RecordedTest]
        public void TrainProjectTest()
        {
            TextAuthoringClient client = GetClient();
            var training_parameters = new {
                modelLabel = "model1",
                trainingConfigVersion = "latest",
                evaluationOptions = new {
                    kind = "percentage",
                    testingSplitPercentage = 20,
                    trainingSplitPercentage = 80
                }
            };

            var operation = client.Train(WaitUntil.Completed, "Emails", RequestContent.Create(training_parameters));
            BinaryData response = operation.WaitForCompletion();
            JsonElement result = JsonDocument.Parse(response.ToStream()).RootElement;
            Assert.AreEqual(result.GetProperty("status").ToString(), "succeeded");
        }

        [RecordedTest]
        public void DeployProjectTest()
        {
            TextAuthoringClient client = GetClient();

            var deployment = new
            {
                trainedModelLabel = "v1"
            };

            var operation = client.DeployProject(WaitUntil.Completed, "Emails", deployment.trainedModelLabel, RequestContent.Create(deployment));
            BinaryData response = operation.WaitForCompletion();
            JsonElement result = JsonDocument.Parse(response.ToStream()).RootElement;
            Assert.AreEqual(result.GetProperty("deploymentName").ToString(), deployment.trainedModelLabel);
        }
    }
}

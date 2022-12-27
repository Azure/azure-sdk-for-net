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

        public TextAuthoringClient GetClient()
        {
            string Endpoint = TestEnvironment.Endpoint;
            string ApiKey = TestEnvironment.ApiKey;
            return new TextAuthoringClient(new Uri(Endpoint), new AzureKeyCredential(ApiKey));
        }

        [RecordedTest]
        public void CreateProjectTest()
        {
            TextAuthoringClient client = GetClient();
            var data = new
            {
                projectKind = "CustomSingleLabelClassification",
                storageInputContainerName = TestEnvironment.ContainerName,
                projectName = TestEnvironment.ProjectName,
                multilingual = true,
                description = "A Test for .NET SDK",
                language = "en",
            };

            Response response = client.CreateProject(TestEnvironment.ProjectName, RequestContent.Create(data));
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

            Assert.IsTrue(response.Status == 200 || response.Status == 201);
        }

        [RecordedTest]
        public void DeleteProjectTest()
        {
            TextAuthoringClient client = GetClient();

            var operation = client.DeleteProject(WaitUntil.Completed, TestEnvironment.ProjectName);

            BinaryData response = operation.WaitForCompletion();
            JsonElement result = JsonDocument.Parse(response.ToStream()).RootElement;
            Assert.AreEqual(result.GetProperty("status").ToString(), "succeeded");
        }

        [RecordedTest]
        public void ExportProjectTest()
        {
            TextAuthoringClient client = GetClient();

            var operation = client.ExportProject(WaitUntil.Completed, TestEnvironment.ProjectName, "Utf16CodeUnit");
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

            var operation = client.ImportProject(WaitUntil.Completed, TestEnvironment.ProjectName, content);

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

            var operation = client.Train(WaitUntil.Completed, TestEnvironment.ProjectName, RequestContent.Create(training_parameters));
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

            var operation = client.DeployProject(WaitUntil.Completed, TestEnvironment.ProjectName, deployment.trainedModelLabel, RequestContent.Create(deployment));
            BinaryData response = operation.WaitForCompletion();
            JsonElement result = JsonDocument.Parse(response.ToStream()).RootElement;
            Assert.AreEqual(result.GetProperty("deploymentName").ToString(), deployment.trainedModelLabel);
        }
    }
}

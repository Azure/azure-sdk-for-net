// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Authoring.Tests.Samples
{
    public partial class AuthoringSamples : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        public void DeployProject()
        {
            // Create a text analytics client.
            string Endpoint = TestEnvironment.Endpoint;
            string ApiKey = TestEnvironment.ApiKey;
            TextAuthoringClient client = new TextAuthoringClient(new Uri(Endpoint), new AzureKeyCredential(ApiKey));

            #region Snippet:Deploy a project
            var deployment = new
            {
                trainedModelLabel = "model1"
            };

            var operation = client.DeployProject(WaitUntil.Completed, TestEnvironment.ProjectName, deployment.trainedModelLabel, RequestContent.Create(deployment));
            BinaryData response = operation.WaitForCompletion();
            JsonElement result = JsonDocument.Parse(response.ToStream()).RootElement;

            Console.WriteLine(result.GetProperty("deploymentName").ToString());
            Console.WriteLine(result.GetProperty("modelId").ToString());
            Console.WriteLine(result.GetProperty("lastTrainedDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastDeployedDateTime").ToString());
            Console.WriteLine(result.GetProperty("deploymentExpirationDate").ToString());
            Console.WriteLine(result.GetProperty("modelTrainingConfigVersion").ToString());

            #endregion
        }
    }
}

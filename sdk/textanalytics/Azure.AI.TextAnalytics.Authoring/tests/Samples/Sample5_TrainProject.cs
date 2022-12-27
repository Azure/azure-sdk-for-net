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
        public void TrainProject()
        {
            // Create a text analytics client.
            string Endpoint = TestEnvironment.Endpoint;
            string ApiKey = TestEnvironment.ApiKey;
            TextAuthoringClient client = new TextAuthoringClient(new Uri(Endpoint), new AzureKeyCredential(ApiKey));

            #region Snippet:Train a project
            var training_parameters = new
            {
                modelLabel = "model1",
                trainingConfigVersion = "latest",
                evaluationOptions = new
                {
                    kind = "percentage",
                    testingSplitPercentage = 20,
                    trainingSplitPercentage = 80
                }
            };

            var operation = client.Train(WaitUntil.Completed, TestEnvironment.ProjectName, RequestContent.Create(training_parameters));
            BinaryData response = operation.WaitForCompletion();
            JsonElement result = JsonDocument.Parse(response.ToStream()).RootElement;

            if (result.GetProperty("status").ToString().Equals("succeeded"))
                Console.WriteLine("Project training succeeded!");
            else
                Console.WriteLine("Project training failed, check \"result\" error message for more information");

            #endregion
        }
    }
}

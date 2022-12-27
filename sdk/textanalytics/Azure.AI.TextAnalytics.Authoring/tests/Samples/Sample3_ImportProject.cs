// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
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
        public void ImportProject()
        {
            // Create a text analytics client.
            string Endpoint = TestEnvironment.Endpoint;
            string ApiKey = TestEnvironment.ApiKey;
            TextAuthoringClient client = new TextAuthoringClient(new Uri(Endpoint), new AzureKeyCredential(ApiKey));

            #region Snippet:Import a project
            string projectJson = File.ReadAllText("../../../../../sdk/textanalytics/Azure.AI.TextAnalytics.Authoring/tests/Samples/sample_project.json");
            var data = JsonDocument.Parse(projectJson).RootElement;
            string arr = data.ToString();
            var content = RequestContent.Create(data);

            var operation = client.ImportProject(WaitUntil.Completed, TestEnvironment.ProjectName, content);

            BinaryData response = operation.WaitForCompletion();
            JsonElement result = JsonDocument.Parse(response.ToStream()).RootElement;

            if (result.GetProperty("status").ToString().Equals("succeeded"))
                Console.WriteLine("Project importing succeeded!");
            else
                Console.WriteLine("Project importing failed, check \"result\" error message for more information");

            #endregion
        }
    }
}

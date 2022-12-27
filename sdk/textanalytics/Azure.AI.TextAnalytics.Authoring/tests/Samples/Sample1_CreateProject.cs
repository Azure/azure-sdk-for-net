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
    public partial class AuthoringSamples: SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        public void CreateProject()
        {
            // Create a text analytics client.
            string Endpoint = TestEnvironment.Endpoint;
            string ApiKey = TestEnvironment.ApiKey;
            TextAuthoringClient client = new TextAuthoringClient(new Uri(Endpoint), new AzureKeyCredential(ApiKey));

            #region Snippet:Create a project
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

            Console.WriteLine(result.GetProperty("jobId").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
            Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            #endregion
        }
    }
}

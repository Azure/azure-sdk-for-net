// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Readme : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public void Authenticate()
    {
        #region Snippet:AI_Projects_OverviewCreateClient
#if SNIPPET
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
#endif
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        #endregion
    }

    [Test]
    public void Troubleshooting()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

        #region Snippet:AI_Projects_Readme_Troubleshooting
        try
        {
            projectClient.Datasets.GetDataset("non-existent-dataset-name", "non-existent-dataset-version");
        }
        catch (ClientResultException ex) when (ex.Status == 404)
        {
            Console.WriteLine($"Exception status code: {ex.Status}");
            Console.WriteLine($"Exception message: {ex.Message}");
        }
        #endregion
    }
}

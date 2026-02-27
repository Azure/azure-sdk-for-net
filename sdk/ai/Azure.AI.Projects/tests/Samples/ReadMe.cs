// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples;

public partial class Readme : SamplesBase
{
    [Test]
    public void Authenticate()
    {
        #region Snippet:AI_Projects_OverviewCreateClient
#if SNIPPET
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
        var endpoint = TestEnvironment.PROJECT_ENDPOINT;
#endif
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        #endregion
    }

    [Test]
    public void Troubleshooting()
    {
        var endpoint = TestEnvironment.PROJECT_ENDPOINT;
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

    public Readme(bool isAsync) : base(isAsync) { }
}

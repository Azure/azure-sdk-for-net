// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel.Primitives;
using System.IO;
using Azure.AI.Projects.OpenAI;
using Azure.AI.Projects.Tests.Utils;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests;

/// <summary>
/// Base class for fine-tuning tests containing common functionality.
/// </summary>
public abstract class FineTuningTestsBase : ProjectsClientTestBase
{
    protected FineTuningTestsBase(bool isAsync) : base(isAsync)
    {
    }

    protected string GetDataDirectory()
    {
        var testDirectory = Path.GetDirectoryName(typeof(FineTuningTestsBase).Assembly.Location);
        while (testDirectory != null && !Directory.Exists(Path.Combine(testDirectory, "sdk")))
        {
            testDirectory = Path.GetDirectoryName(testDirectory);
        }
        return Path.Combine(testDirectory!, "sdk", "ai", "Azure.AI.Projects", "tests", "FineTuning", "data");
    }

    /// <summary>
    /// Gets OpenAIFileClient and FineTuningClient with recording support and HTTP logging enabled.
    /// </summary>
    /// <returns>A tuple containing OpenAIFileClient and FineTuningClient.</returns>
    protected (OpenAIFileClient FileClient, FineTuningClient FineTuningClient) GetClients()
    {
        AIProjectClient projectClient = GetTestClient();

        ProjectOpenAIClient oaiClient = projectClient.OpenAI;

        return (oaiClient.GetOpenAIFileClient(), oaiClient.GetFineTuningClient());
    }

    protected void ValidateFineTuningJob(FineTuningJob job, string expectedJobId = null, string expectedStatus = null)
    {
        Assert.IsNotNull(job);
        Assert.IsNotNull(job.JobId);
        Assert.IsNotNull(job.Status);

        if (expectedJobId != null)
        {
            Assert.AreEqual(expectedJobId, job.JobId);
        }

        if (expectedStatus != null)
        {
            Assert.AreEqual(expectedStatus, job.Status.ToString().ToLowerInvariant());
        }
    }
}

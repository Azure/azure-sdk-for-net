// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_PublishedAgent : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task PublishedAgentAync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_ReadEndpoint_PublishedAgent
#if SNIPPET
        var publishedEndpoint = System.Environment.GetEnvironmentVariable("PUBLISHED_ENDPOINT");
#else
        var publishedEndpoint = TestEnvironment.PUBLISHED_ENDPOINT;
#endif
        Uri endpoint = new(publishedEndpoint);
        #endregion
        #region Snippet:Sample_CreateResponse_ReadEndpoint_Async
        ProjectResponsesClient responseClient = new(
            projectEndpoint: endpoint,
            tokenProvider: new DefaultAzureCredential()
        );
        ResponseResult response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");
        Console.WriteLine(response.GetOutputText());
        #endregion
    }

    [Test]
    [SyncOnly]
    public void PublishedAgent()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var publishedEndpoint = System.Environment.GetEnvironmentVariable("PUBLISHED_ENDPOINT");
#else
        var publishedEndpoint = TestEnvironment.PUBLISHED_ENDPOINT;
#endif
        Uri endpoint = new(publishedEndpoint);
        #region Snippet:Sample_CreateResponse_ReadEndpoint_Sync
        ProjectResponsesClient responseClient = new(
            projectEndpoint: endpoint,
            tokenProvider: new DefaultAzureCredential()
        );
        ResponseResult response = responseClient.CreateResponse("What is the size of France in square miles?");
        Console.WriteLine(response.GetOutputText());
        #endregion
    }

    public Sample_PublishedAgent(bool isAsync) : base(isAsync)
    { }
}

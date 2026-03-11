// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;

[Category("Smoke")]
public class ProjectOpenAIClientSmokeTest : ProjectsOpenAITestBase
{
    private static readonly string AGENT_NAME = "MyAgentOAI";
    public ProjectOpenAIClientSmokeTest(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task TestUserAgentHeaders()
    {
        List<string> userAgentsFetched = null;
        PipelinePolicy fetchUserAgentAndFailPolicy = new TestPipelinePolicy(
            processMessageAction: (PipelineMessage message) =>
            {
                if (message.Request.Headers.TryGetValues("User-Agent", out IEnumerable<string> headers))
                {
                    userAgentsFetched = [..headers];
                }
                else
                {
                    userAgentsFetched = null;
                }
                throw new NotImplementedException("This exception is expected as this policy is meant to short-circuit the pipeline after validating the User-Agent header.");
            });

        T WithExtraPolicy<T>(T options) where T : ClientPipelineOptions
        {
            options.RetryPolicy = new ClientRetryPolicy(maxRetries: 0);
            options.AddPolicy(
                fetchUserAgentAndFailPolicy,
                PipelinePosition.BeforeTransport);
            return options;
        }

        void VerifyCall(Task callTask, string expectedUserAgentPattern)
        {
            Assert.ThrowsAsync<NotImplementedException>(async () => await callTask);
            Assert.That(userAgentsFetched, Has.Count.EqualTo(1));
            Console.WriteLine($"{Regex.IsMatch(userAgentsFetched[0], expectedUserAgentPattern)} - {userAgentsFetched[0]}");
        }

        AIProjectClient projectClientWithoutApp = new(
            endpoint: new Uri(TestEnvironment.PROJECT_ENDPOINT),
            tokenProvider: new MockCredential(),
            options: WithExtraPolicy(new AIProjectClientOptions()));

        AIProjectClient projectClientWithApp = new(
            endpoint: new Uri(TestEnvironment.PROJECT_ENDPOINT),
            tokenProvider: new MockCredential(),
            options: WithExtraPolicy(new AIProjectClientOptions()
            {
                UserAgentApplicationId = "MyApplication",
            }));

        ProjectOpenAIClient openAIClientWithoutApp = new(
            projectEndpoint: new Uri(TestEnvironment.PROJECT_ENDPOINT),
            tokenProvider: new MockCredential(),
            options: WithExtraPolicy(new ProjectResponsesClientOptions()));

        ProjectOpenAIClient openAIClientWithApp = new(
            projectEndpoint: new Uri(TestEnvironment.PROJECT_ENDPOINT),
            tokenProvider: new MockCredential(),
            options: WithExtraPolicy(new ProjectResponsesClientOptions()
            {
                UserAgentApplicationId = "MyOtherApplication",
            }));

        async Task DoCreateAgentAsync(AgentsClient agentsClient)
        {
            await agentsClient.CreateAgentVersionAsync(
                agentName: "foobar",
                options: new AgentVersionCreationOptions(
                    definition: new PromptAgentDefinition("mock-model")));
        }

        ProjectResponsesClient responsesClientWithoutApp = new(
            projectEndpoint: new(TestEnvironment.PROJECT_ENDPOINT),
            tokenProvider: new MockCredential(),
            options: WithExtraPolicy(new ProjectResponsesClientOptions()));

        async Task DoResponseAsync(ResponsesClient responsesClient)
        {
            CreateResponseOptions options = new()
            {
                InputItems = { ResponseItem.CreateUserMessageItem("hello, model") }
            };
            await responsesClient.CreateResponseAsync(options);
        }

        VerifyCall(DoCreateAgentAsync(projectClientWithoutApp.Agents), "Azure.AI.Projects.*");
        VerifyCall(DoCreateAgentAsync(projectClientWithApp.Agents), "MyApplication Azure.AI.Projects.*");
        VerifyCall(DoResponseAsync(projectClientWithoutApp.OpenAI.Responses), "Azure.AI.Projects.*");
        VerifyCall(DoResponseAsync(projectClientWithApp.OpenAI.Responses), "MyApplication Azure.AI.Projects.*");
        VerifyCall(DoResponseAsync(openAIClientWithoutApp.Responses), "AIProjectClient OpenAI.*");
        VerifyCall(DoResponseAsync(openAIClientWithApp.Responses), "MyOtherApplication-AIProjectClient OpenAI.*");
        VerifyCall(DoResponseAsync(responsesClientWithoutApp), "AIProjectClient.*");
    }

    [RecordedTest]
    public async Task TestFileUpload()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        string filePath = "sample_file_for_upload.txt";
        System.IO.File.WriteAllText(
            path: filePath,
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        OpenAIFileClient fileClient = projectClient.OpenAI.GetOpenAIFileClient();
        OpenAIFile uploadedFile = await fileClient.UploadFileAsync(filePath: filePath, purpose: FileUploadPurpose.Assistants);
        FileDeletionResult deletion = await fileClient.DeleteFileAsync(fileId: uploadedFile.Id);
        Assert.That(deletion.Deleted, Is.True);
    }

    [TearDown]
    public override void Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        Uri connectionString = new(TestEnvironment.PROJECT_ENDPOINT);
        AIProjectClient projectClient = new(connectionString, TestEnvironment.Credential);
        // Remove Agents.
        foreach (AgentVersion ag in projectClient.Agents.GetAgentVersions(agentName: AGENT_NAME))
        {
            projectClient.Agents.DeleteAgentVersion(agentName: ag.Name, agentVersion: ag.Version);
        }
    }
}

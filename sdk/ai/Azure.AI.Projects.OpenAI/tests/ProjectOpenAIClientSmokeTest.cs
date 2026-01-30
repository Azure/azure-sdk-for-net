// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.OpenAI.Tests;

[Category("Smoke")]
public class ProjectOpenAIClientSmokeTest : ProjectsOpenAITestBase
{
    private static readonly string AGENT_NAME = "MyAgentOAI";
    public ProjectOpenAIClientSmokeTest(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    [TestCase("", "^AIProjectClient OpenAI/.+ [(][^)]+[)]$")]
    [TestCase(null, "^AIProjectClient OpenAI/.+ [(][^)]+[)]$")]
    [TestCase("MyClient", "^MyClient-AIProjectClient OpenAI/.+ [(][^)]+[)]$")]
    public async Task TestUserAgentHeaders(string customUserAgent, string expectedRegex)
    {
        AIProjectClient proojectClient = GetTestProjectClient();
        PromptAgentDefinition def = new(model: TestEnvironment.MODELDEPLOYMENTNAME)
        {
            Instructions = "You are helpful assistant",
        };
        AgentVersion agentVersion = await proojectClient.Agents.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(def)
        );
        PipelineMessageClassifier pipelineMessageClassifier200 = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
        ProjectOpenAIClientOptions options = CreateTestOpenAIClientOptions<ProjectOpenAIClientOptions>();
        options.UserAgentApplicationId = customUserAgent;
        ClientPipeline pipeline = ProjectOpenAIClient.CreatePipeline(new BearerTokenPolicy(new AzureCliCredential(), "https://ai.azure.com/.default"), options);
        ClientUriBuilder uri = new();
        uri.Reset(new System.Uri(TestEnvironment.PROJECT_ENDPOINT));
        uri.AppendPath("/openai/responses", false);
        PipelineMessage msg = pipeline.CreateMessage(uri.ToUri(), "POST", pipelineMessageClassifier200);
        PipelineRequest request = msg.Request;
        request.Headers.Set("Accept", "application/json, text/event-stream");
        request.Headers.Set("Content-Type", "application/json");
        BinaryData contentData = BinaryData.FromObjectAsJson(new
        {
            input = new[]
            {
                new
                {
                    type = "message",
                    role = "user",
                    content = new[]
                    {
                        new
                        {
                            type = "input_text",
                            text = "Please greet me and tell me what would be good to wear outside today."
                        }
                    }
                }
            },
            agent = new
            {
                type = "agent_reference",
                name = agentVersion.Name,
                version = agentVersion.Version
            }
        });
        using BinaryContent content = BinaryContent.Create(contentData);
        request.Content = content;
        PipelineResponse response = await pipeline.ProcessMessageAsync(msg, options: new());
        if (msg.Request.Headers.TryGetValues("User-Agent", out IEnumerable<string> headers))
        {
            List<string> userAgent = [..headers];
            Assert.That(userAgent.Count, Is.EqualTo(1), $"Unexpectedly found {userAgent.Count} User-Agent headers.");
            Assert.That(Regex.IsMatch(userAgent[0], expectedRegex), Is.True, $"The header {userAgent[0]} does not match the pattern {expectedRegex}");
        }
        else
        {
            Assert.Fail("No User-Agent headers were found.");
        }
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

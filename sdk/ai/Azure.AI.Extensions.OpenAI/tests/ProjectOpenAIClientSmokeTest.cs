// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
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
    private static readonly string FOUNDRY_AGENT_NAME = "MyAgentOAI";
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
                    userAgentsFetched = [.. headers];
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
            endpoint: new Uri(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT),
            tokenProvider: new MockCredential(),
            options: WithExtraPolicy(new AIProjectClientOptions()));

        AIProjectClient projectClientWithApp = new(
            endpoint: new Uri(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT),
            tokenProvider: new MockCredential(),
            options: WithExtraPolicy(new AIProjectClientOptions()
            {
                UserAgentApplicationId = "MyApplication",
            }));

        ProjectOpenAIClient openAIClientWithoutApp = new(
            projectEndpoint: new Uri(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT),
            tokenProvider: new MockCredential(),
            options: WithExtraPolicy(new ProjectResponsesClientOptions()));

        ProjectOpenAIClient openAIClientWithApp = new(
            projectEndpoint: new Uri(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT),
            tokenProvider: new MockCredential(),
            options: WithExtraPolicy(new ProjectResponsesClientOptions()
            {
                UserAgentApplicationId = "MyOtherApplication",
            }));

        async Task DoCreateAgentAsync(AgentAdministrationClient agentsClient)
        {
            await agentsClient.CreateAgentVersionAsync(
                agentName: "foobar",
                options: new ProjectsAgentVersionCreationOptions(
                    definition: new DeclarativeAgentDefinition("mock-model")));
        }

        ProjectResponsesClient responsesClientWithoutApp = new(
            projectEndpoint: new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT),
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

        VerifyCall(DoCreateAgentAsync(projectClientWithoutApp.AgentAdministrationClient), "Azure.AI.Projects.*");
        VerifyCall(DoCreateAgentAsync(projectClientWithApp.AgentAdministrationClient), "MyApplication Azure.AI.Projects.*");
        VerifyCall(DoResponseAsync(projectClientWithoutApp.ProjectOpenAIClient.GetProjectResponsesClient()), "Azure.AI.Projects.*");
        VerifyCall(DoResponseAsync(projectClientWithApp.ProjectOpenAIClient.GetProjectResponsesClient()), "MyApplication Azure.AI.Projects.*");
        VerifyCall(DoResponseAsync(openAIClientWithoutApp.GetProjectResponsesClient()), "AIProjectClient OpenAI.*");
        VerifyCall(DoResponseAsync(openAIClientWithApp.GetProjectResponsesClient()), "MyOtherApplication-AIProjectClient OpenAI.*");
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
        OpenAIFileClient fileClient = projectClient.ProjectOpenAIClient.GetOpenAIFileClient();
        OpenAIFile uploadedFile = await fileClient.UploadFileAsync(filePath: filePath, purpose: FileUploadPurpose.Assistants);
        FileDeletionResult deletion = await fileClient.DeleteFileAsync(fileId: uploadedFile.Id);
        Assert.That(deletion.Deleted, Is.True);
    }

    [RecordedTest]
    [TestCase(true, true)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(false, false)]
    public async Task TestEncryptedPayload(bool useProjects, bool storedOutputEnabled)
    {
        ProjectResponsesClient oaiClient;
        if (useProjects)
        {
            AIProjectClient projectClient = GetTestProjectClient();
            oaiClient = projectClient.GetProjectOpenAIClient().GetProjectResponsesClientForModel(TestEnvironment.FOUNDRY_MODEL_NAME);
        }
        else
        {
            oaiClient = GetTestProjectOpenAIClient().GetProjectResponsesClientForModel(TestEnvironment.FOUNDRY_MODEL_NAME);
        }
        CreateResponseOptions options = new()
        {
            ReasoningOptions = new()
            {
                ReasoningEffortLevel = ResponseReasoningEffortLevel.High,
                ReasoningSummaryVerbosity = ResponseReasoningSummaryVerbosity.Detailed
            },
            InputItems = {
                ResponseItem.CreateSystemMessageItem("You are helpful assistant who knows that Plagiarus praepotens likes cookies with raisins."),
                ResponseItem.CreateUserMessageItem("Hello, tell me about Plagiarus praepotens.")},
            StoredOutputEnabled = storedOutputEnabled,
            IncludedProperties = { IncludedResponseProperty.ReasoningEncryptedContent }
        };
        ResponseResult result = await oaiClient.CreateResponseAsync(options);
        Assert.That(result.Error, Is.Null, $"Error code: {result.Error?.Code}, {result.Error?.Message}");
        Assert.That(result.OutputItems, Has.Count.GreaterThan(0));
        Assert.That(result.OutputItems.Any(x => x is ReasoningResponseItem), Is.True);
        options.InputItems.Clear();
        foreach (ResponseItem item in result.OutputItems)
        {
            options.InputItems.Add(item);
        }
        options.InputItems.Add(ResponseItem.CreateUserMessageItem("Could you please explain more?"));
        result = await oaiClient.CreateResponseAsync(options);
        Assert.That(result.Error, Is.Null, $"Error code: {result.Error?.Code}, {result.Error?.Message}");
        Assert.That(result.OutputItems.Any(x => x is ReasoningResponseItem), Is.True);
        Assert.That(result.OutputItems, Has.Count.GreaterThan(0));
    }

    [RecordedTest]
    [TestCase(true)]
    [TestCase(false)]
    public async Task TestCompaction(bool useProjects)
    {
        ProjectResponsesClient oaiClient;
        if (useProjects)
        {
            AIProjectClient projectClient = GetTestProjectClient();
            oaiClient = projectClient.GetProjectOpenAIClient().GetProjectResponsesClientForModel(TestEnvironment.FOUNDRY_MODEL_NAME);
        }
        else
        {
            oaiClient = GetTestProjectOpenAIClient().GetProjectResponsesClientForModel(TestEnvironment.FOUNDRY_MODEL_NAME);
        }
        BinaryData options = BinaryData.FromObjectAsJson(
        new
        {
            model = TestEnvironment.FOUNDRY_MODEL_NAME,
            input = new[]
            {
                new {
                    role = "system",
                    content = "You are helpful assistant who knows that Plagiarus praepotens likes cookies with raisins."
                },
                new {
                    role = "user",
                    content = "Hello, tell me about Plagiarus praepotens."
                }
            }
        });
        ClientResult result;
        using BinaryContent optionsContent = BinaryContent.Create(options);
        {
            result = await oaiClient.CompactResponseAsync(optionsContent, "application/json");
        }
        List<object> items = ParseAndValidateCompactedResponse(result);
        items.Add(new
        {
            role = "user",
            content = "Could you please explain more?"
        });
        options = BinaryData.FromObjectAsJson(
        new
        {
            model = TestEnvironment.FOUNDRY_MODEL_NAME,
            input = items.ToArray()
        });
        using BinaryContent newOptionsContent = BinaryContent.Create(options);
        {
            result = await oaiClient.CompactResponseAsync(newOptionsContent, "application/json");
        }

        ParseAndValidateCompactedResponse(result);
    }

    private static List<object> ParseAndValidateCompactedResponse(ClientResult compactionResponse)
    {
        List<object> items = [];
        Utf8JsonReader reader = new(compactionResponse.GetRawResponse().Content.ToMemory().ToArray());
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        HashSet<string> expectedTypes = ["compaction", "message"];
        foreach (JsonProperty prop in document.RootElement.EnumerateObject())
        {
            if (prop.NameEquals("output"u8) && prop.Value.ValueKind == JsonValueKind.Array && prop.Value is JsonElement countsElement)
            {
                foreach (JsonElement itemNode in countsElement.EnumerateArray())
                {
                    // Define the item type
                    string itemType = default;
                    foreach (JsonProperty node in itemNode.EnumerateObject())
                    {
                        if (node.NameEquals("type"u8) && node.Value.ValueKind == JsonValueKind.String)
                        {
                            itemType = node.Value.GetString();
                            expectedTypes.Remove(itemType);
                            break;
                        }
                    }
                    Assert.That(itemType, Is.Not.Null.And.Not.Empty);
                    items.Add(itemNode.GetObject());
                }
            }
        }
        // Check that we have met all the expected types.
        Assert.That(expectedTypes, Is.Empty);
        Assert.That(items, Has.Count.GreaterThanOrEqualTo(3));
        return items;
    }

    [RecordedTest]
    [TestCase(true, true)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(false, false)]
    public async Task TestGetResponse(bool useProjects, bool storeResponse)
    {
        ProjectResponsesClient oaiClient;
        if (useProjects)
        {
            AIProjectClient projectClient = GetTestProjectClient();
            oaiClient = projectClient.GetProjectOpenAIClient().GetProjectResponsesClientForModel(TestEnvironment.FOUNDRY_MODEL_NAME);
        }
        else
        {
            oaiClient = GetTestProjectOpenAIClient().GetProjectResponsesClientForModel(TestEnvironment.FOUNDRY_MODEL_NAME);
        }
        CreateResponseOptions options = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem("Hello, tell me a joke.") },
            StoredOutputEnabled = storeResponse
        };
        ResponseResult result = await oaiClient.CreateResponseAsync(options);
        Assert.That(result.Error, Is.Null, $"Error code: {result.Error?.Code}, {result.Error?.Message}");
        Assert.That(result.OutputItems, Has.Count.GreaterThan(0));
        if (storeResponse)
        {
            result = await oaiClient.GetResponseAsync(result.Id);
            Assert.That(result.Error, Is.Null, $"Error code: {result.Error?.Code}, {result.Error?.Message}");
            Assert.That(result.OutputItems, Has.Count.GreaterThan(0));
        }
        else
        {
            try
            {
                await oaiClient.GetResponseAsync(result.Id);
                Assert.Fail("Expected GetResponseAsync to fail when StoredOutputEnabled=false.");
            }
            catch (ClientResultException e)
            {
                Assert.That(e.Status, Is.EqualTo(404));
            }
        }
    }

    [TearDown]
    public override void Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        Uri connectionString = new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT);
        AIProjectClient projectClient = new(connectionString, GetTestAuthenticationProvider());
        // Remove Agents.
        foreach (ProjectsAgentVersion ag in projectClient.AgentAdministrationClient.GetAgentVersions(agentName: FOUNDRY_AGENT_NAME))
        {
            projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: ag.Name, agentVersion: ag.Version);
        }
    }
}

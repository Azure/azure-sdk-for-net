// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel.Primitives;
using Azure.AI.Projects;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Agents.Tests;

[Category("Smoke")]
public class AgentsSmokeTests : AgentsTestBase
{
    public AgentsSmokeTests(bool isAsync) : base(isAsync, RecordedTestMode.Live)
    {
        // TestDiagnostics = false;
    }

    [Test]
    [LiveOnly]
    public void CanGetClients()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        AgentsClient agentsClient = projectClient.GetAgentsClient();
        OpenAIClient openAIClient = agentsClient.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient("test-model");
    }

    [Test]
    public void TestResponseItemExtension()
    {
        string rawStructuredInputsItem = """
            {
              "type": "structured_inputs",
              "inputs": {
                "hello": "world"
              }
            }
            """;

        ResponseItem item = ModelReaderWriter.Read<ResponseItem>(BinaryData.FromString(rawStructuredInputsItem));
        Assert.That(item, Is.Not.Null);

        AgentResponseItem agentResponseItem = item.AsAgentResponseItem();
        Assert.That(agentResponseItem, Is.Not.Null);

        ResponseItem revertedResponseItem = agentResponseItem;
        Assert.That(revertedResponseItem, Is.Not.Null);
    }

    [Test]
    public void TestUseAnAgentTool()
    {
        ResponseCreationOptions responseOptions = new()
        {
            Tools =
            {
                ResponseTool.CreateWebSearchTool(),
                AgentTool.CreateA2ATool(new Uri("https://test-uri.microsoft.com")),
            }
        };

        Assert.That(responseOptions.Tools, Has.Count.EqualTo(2));

        Assert.That(
            ModelReaderWriter.Write(responseOptions).ToString(),
            Does.Contain("base_url"));

        OpenAIResponse mockResponse = ModelReaderWriter.Read<OpenAIResponse>(BinaryData.FromString("""
            {
              "id": "resp_09e840ce9e2f16c60068c4c1ce2cc481a3ad9e41ec88e4cbe5",
              "object": "response",
              "created_at": 1757725134,
              "status": "completed",
              "background": false,
              "error": null,
              "incomplete_details": null,
              "instructions": null,
              "max_output_tokens": null,
              "max_tool_calls": null,
              "model": "gpt-4o-mini-2024-07-18",
              "output": [
                {
                  "id": "msg_09e840ce9e2f16c60068c4c1cf253c81a397d15e2efdbcd7dd",
                  "type": "message",
                  "status": "completed",
                  "content": [
                    {
                      "type": "output_text",
                      "annotations": [],
                      "logprobs": [],
                      "text": "Hello! How can I assist you today?"
                    }
                  ],
                  "role": "assistant"
                }
              ],
              "parallel_tool_calls": true,
              "previous_response_id": null,
              "prompt_cache_key": null,
              "reasoning": {
                "effort": null,
                "summary": null
              },
              "safety_identifier": null,
              "service_tier": "default",
              "store": true,
              "temperature": 1.0,
              "text": {
                "format": {
                  "type": "text"
                },
                "verbosity": "medium"
              },
              "tool_choice": "auto",
              "tools": [
                {
                  "type": "web_search_preview",
                  "search_context_size": "medium",
                  "user_location": {
                    "type": "approximate",
                    "city": null,
                    "country": "US",
                    "region": null,
                    "timezone": null
                  }
                },
                {
                  "type": "a2a_preview",
                  "base_url": "https://test-uri.microsoft.com"
                }
              ],
              "top_logprobs": 0,
              "top_p": 1.0,
              "truncation": "disabled",
              "usage": {
                "input_tokens": 305,
                "input_tokens_details": {
                  "cached_tokens": 0
                },
                "output_tokens": 11,
                "output_tokens_details": {
                  "reasoning_tokens": 0
                },
                "total_tokens": 316
              },
              "user": null,
              "metadata": {}
            }
            """));

        Assert.That(mockResponse.Tools, Has.Count.EqualTo(2));

        A2ATool a2aToolFromResponse = mockResponse.Tools[1].AsAgentTool() as A2ATool;
        Assert.That(a2aToolFromResponse?.BaseUrl.AbsoluteUri, Does.Contain("microsoft.com"));
    }

    [Test]
    public void TestPromptAgentSerialization()
    {
        PromptAgentDefinition agent = new(model: "test-model");
        Assert.That(ModelReaderWriter.Write(agent).ToString(), Does.Contain("kind"));

        agent = new("test-model")
        {
            Tools = { ResponseTool.CreateWebSearchTool() },
        };
        Assert.That(ModelReaderWriter.Write(agent).ToString(), Does.Contain("web_search"));

        agent = new("test-model")
        {
            ReasoningOptions = new()
            {
                ReasoningEffortLevel = ResponseReasoningEffortLevel.Low,
                ReasoningSummaryVerbosity = ResponseReasoningSummaryVerbosity.Concise,
            }
        };
        Assert.That(ModelReaderWriter.Write(agent).ToString(), Does.Contain(@"""reasoning"":{"));
        Assert.That(ModelReaderWriter.Write(agent).ToString(), Does.Contain("concise"));
    }

    [Test]
    public void TestUseAnAgentReference()
    {
        ResponseCreationOptions responseOptions = new()
        {
            Instructions = "You talk like a pirate."
        };

        responseOptions.SetAgentReference(new AgentReference("my-test-agent"));
        responseOptions.SetConversationReference("conv_abcd1234");

        Assert.That(ModelReaderWriter.Write(responseOptions).ToString(), Does.Contain("my-test-agent"));
        Assert.That(ModelReaderWriter.Write(responseOptions).ToString(), Does.Contain("conv_abcd1234"));
    }

    [Test]
    public void ItemDeserializationTest()
    {
        const string rawItem = """
            {
              "role": "user",
              "content": "hello, world"
            }
            """;
        BinaryData itemBytes = BinaryData.FromString(rawItem);

        AgentResponseItem asAgentItem = ModelReaderWriter.Read<AgentResponseItem>(itemBytes);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using OpenAI.Responses;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests;

public class AgentsTestBase : RecordedTestBase<AgentsTestEnvironment>
{
    protected const string AGENT_NAME = "cs-e2e-tests-client";
    protected const string AGENT_NAME2 = "cs-e2e-tests-client2";

    public AgentsTestBase(bool isAsync, RecordedTestMode? testMode = null) : base(isAsync, testMode)
    {
        // Please note that in System.ClientModel, the recording mode is taken from CLIENTMODEL_TEST_MODE
        // environment variable as opposed to AZURE_TEST_MODE in Azure.Core.
        // Allowed values are: Playback, Live, Record.
        ProjectsTestSanitizers.ApplySanitizers(this);
    }

    private AuthenticationTokenProvider GetTestTokenProvider()
    {
        // For local testing if you are using non default account
        // add USE_CLI_CREDENTIAL into the .runsettings and set it to true,
        // also provide the PATH variable.
        // This path should allow launching az command.
        if (Mode != RecordedTestMode.Playback && bool.TryParse(Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL"), out bool cliValue) && cliValue)
        {
            return new AzureCliCredential();
        }
        return TestEnvironment.Credential;
    }
    internal static PipelinePolicy GetDumpPolicy()
    {
        return new TestPipelinePolicy((message) =>
        {
            if (message.Request is not null && message.Response is null)
            {
                Console.WriteLine($"{message?.Request?.Method} URI: {message?.Request?.Uri}");
                Console.WriteLine($"--- New request ---");
                IEnumerable<string> headerPairs = message?.Request?.Headers?.Select(header => $"\n   {header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
                string headers = string.Join("", headerPairs);
                Console.WriteLine($"Request headers:{headers}");
                if (message.Request?.Content != null)
                {
                    string contentType = "Unknown Content Type";
                    if (message.Request.Headers?.TryGetValue("Content-Type", out contentType) == true
                        && contentType == "application/json")
                    {
                        using MemoryStream stream = new();
                        message.Request.Content.WriteTo(stream, default);
                        stream.Position = 0;
                        using StreamReader reader = new(stream);
                        string requestDump = reader.ReadToEnd();
                        stream.Position = 0;
                        requestDump = Regex.Replace(requestDump, @"""data"":[\\w\\r\\n]*""[^""]*""", @"""data"":""...""");
                        // Make sure JSON string is properly formatted.
                        JsonSerializerOptions jsonOptions = new()
                        {
                            WriteIndented = true,
                        };
                        JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(requestDump);
                        Console.WriteLine("--- Begin request content ---");
                        Console.WriteLine(JsonSerializer.Serialize(jsonElement, jsonOptions));
                        Console.WriteLine("--- End request content ---");
                    }
                    else
                    {
                        string length = message.Request.Content.TryComputeLength(out long numberLength)
                            ? $"{numberLength} bytes"
                            : "unknown length";
                        Console.WriteLine($"<< Non-JSON content: {contentType} >> {length}");
                    }
                }
            }
            if (message.Response != null)
            {
                IEnumerable<string> headerPairs = message?.Response?.Headers?.Select(header => $"\n   {header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
                string headers = string.Join("", headerPairs);
                Console.WriteLine($"Response headers: {headers}");
                if (message.BufferResponse)
                {
                    message.Response.BufferContent();
                    Console.WriteLine("--- Begin response content ---");
                    Console.WriteLine(message.Response.Content?.ToString());
                    Console.WriteLine("--- End of response content ---");
                }
                else
                {
                    Console.WriteLine("--- Response (unbuffered, content not rendered) ---");
                }
            }
        });
    }

    protected AgentAdministrationClient GetTestClient()
    {
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(GetDumpPolicy(), PipelinePosition.BeforeTransport);
        options.AddPolicy(
            new TestPipelinePolicy(message =>
            {
                if (Mode == RecordedTestMode.Playback)
                {
                    // TODO: ...why!?
                    message.Request.Headers.Set("Authorization", "Sanitized");
                }
                else
                {
                    message.NetworkTimeout = TimeSpan.FromMinutes(5);
                }
            }),
            PipelinePosition.PerCall);
        return CreateProxyFromClient(new AgentAdministrationClient(new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT), GetTestTokenProvider(), InstrumentClientOptions(options)));
    }

    protected async Task<ResponseResult> WaitForRun(ResponsesClient responses, ResponseResult response, int waitTime = 500)
    {
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            if (Mode != RecordedTestMode.Playback)
                await Task.Delay(TimeSpan.FromMilliseconds(waitTime));
            response = await responses.GetResponseAsync(responseId: response.Id);
        }
        return response;
    }

    public static void AssertListEqual(string[] expected, List<string> observed)
    {
        // Assert.AreEqual(expected.Length, observed.Count, $"The length of arrays are different. Expected: {expected}, Observed: {observed.ToArray()}");
        HashSet<string> expectedHash = [.. expected];
        HashSet<string> observedHash = [.. observed];
        if (!expectedHash.SetEquals(observedHash))
        {
            Assert.Fail($"The members of arrays differ. Expected: {ToPritableString(expected)}, Observed: {ToPritableString(observed)}");
        }
    }

    private static string ToPritableString(IEnumerable<string> data)
    {
        StringBuilder sb = new();
        foreach (string val in data)
        {
            sb.Append(val);
            sb.Append(',');
            sb.Append(' ');
        }
        if (sb.Length > 2)
        {
            sb.Remove(sb.Length - 2, 2);
        }
        return sb.ToString();
    }

    protected static string GetModelType<T>(IJsonModel<T> model)
    {
        using MemoryStream memoryStream = new();
        using var writer = new Utf8JsonWriter(memoryStream, new JsonWriterOptions());
        model.Write(writer, ModelReaderWriterOptions.Json);
        writer.Flush();
        memoryStream.Position = 0;
        using JsonDocument document = JsonDocument.Parse(memoryStream);
        foreach (JsonProperty prop in document.RootElement.EnumerateObject())
        {
            if (prop.NameEquals("type"u8))
            {
                return prop.Value.ToString();
            }
        }
        return default;
    }

    #region Cleanup
    [TearDown]
    public async virtual Task Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        AgentAdministrationClientOptions options = new();
        AgentAdministrationClient agentsClient = new(new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT), TestEnvironment.Credential, options);

        // Remove Agents.
        foreach (AgentVersion ag in agentsClient.GetAgentVersions(agentName: AGENT_NAME))
        {
            agentsClient.DeleteAgentVersion(agentName: ag.Name, agentVersion: ag.Version);
        }
        foreach (AgentVersion ag in agentsClient.GetAgentVersions(agentName: AGENT_NAME2))
        {
            agentsClient.DeleteAgentVersion(agentName: ag.Name, agentVersion: ag.Version);
        }
    }
    #endregion
}

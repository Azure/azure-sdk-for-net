// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Azure.AI.Projects;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests;

[LiveParallelizable(ParallelScope.All)]
public class ProjectsOpenAITestBase : RecordedTestBase<ProjectsOpenAITestEnvironment>
{
    protected AIProjectClientOptions CreateTestProjectClientOptions(bool instrument = true)
        => GetConfiguredOptions(new AIProjectClientOptions(), instrument);

    protected ProjectOpenAIClientOptions CreateTestProjectOpenAIClientOptions(Uri endpoint = null, string apiVersion = null, bool instrument = true)
        => GetConfiguredOptions(
            new ProjectOpenAIClientOptions()
            {
                Endpoint = endpoint,
                ApiVersion = apiVersion,
            },
            instrument);

    private T GetConfiguredOptions<T>(T options, bool instrument)
        where T : ClientPipelineOptions
    {
        options.AddPolicy(GetDumpPolicy(), PipelinePosition.BeforeTransport);
        options.AddPolicy(
            new TestPipelinePolicy(message =>
            {
                if (Mode == RecordedTestMode.Playback)
                {
                    // TODO: ...why!?
                    message.Request.Headers.Set("Authorization", "Sanitized");
                }
            }),
            PipelinePosition.PerCall);

        return instrument ? InstrumentClientOptions(options) : options;
    }

    private readonly List<string> _conversationIDs = [];
    private ProjectOpenAIConversationClient _conversations = null;

    private static RecordedTestMode? GetRecordedTestMode() => Environment.GetEnvironmentVariable("AZURE_TEST_MODE") switch
    {
        "Playback" => RecordedTestMode.Playback,
        "Live" => RecordedTestMode.Live,
        "Record" => RecordedTestMode.Record,
        _ => null
    };

    public ProjectsOpenAITestBase(bool isAsync) : this(isAsync: isAsync, testMode: GetRecordedTestMode()) { }

    public ProjectsOpenAITestBase(bool isAsync, RecordedTestMode? testMode = null) : base(isAsync, testMode)
    {
    }

    protected AIProjectClient GetTestProjectClient()
    {
        AIProjectClientOptions options = CreateTestProjectClientOptions();
        AIProjectClient baseClient = new(new Uri(TestEnvironment.PROJECT_ENDPOINT), GetTestAuthenticationProvider(), options);
        return CreateProxyFromClient(baseClient);
    }

    protected ProjectOpenAIClient GetTestClient()
    {
        ProjectOpenAIClientOptions clientOptions = CreateTestProjectOpenAIClientOptions(endpoint: new Uri($"{TestEnvironment.PROJECT_ENDPOINT}/openai"), apiVersion: "2025-11-15-preview");
        return CreateProxyFromClient(new ProjectOpenAIClient(GetTestAuthenticationPolicy(), clientOptions));
    }

    protected ProjectOpenAIResponseClient GetTestResponseClient(Uri constructorEndpoint = null, ProjectOpenAIClientOptions options = null)
    {
        options ??= CreateTestProjectOpenAIClientOptions(endpoint: null, apiVersion: "2025-11-15-preview");
        ProjectOpenAIResponseClient baseClient = constructorEndpoint is null
            ? new ProjectOpenAIResponseClient(GetTestAuthenticationProvider(), options)
            : new ProjectOpenAIResponseClient(constructorEndpoint, GetTestAuthenticationProvider(), options);
        return CreateProxyFromClient(baseClient);
    }

    private AuthenticationTokenProvider GetTestAuthenticationProvider()
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

    private AuthenticationPolicy GetTestAuthenticationPolicy() => new BearerTokenPolicy(GetTestAuthenticationProvider(), "https://ai.azure.com/.default");

    protected async Task<OpenAIResponse> WaitForRun(OpenAIResponseClient responses, OpenAIResponse response, int waitTime=500)
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
        HashSet<string> expectedHash = [..expected];
        HashSet<string> observedHash = [..observed];
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

    protected void IgnoreSampleMayBe()
    {
        if (Mode != RecordedTestMode.Live)
        {
            Assert.Ignore("Samples represented as tests only for validation of compilation.");
        }
    }

    #region ToolHelper

    protected static string GetCityNicknameForTest(string location) => location switch
    {
        "Seattle, WA" => "The Emerald City",
        _ => throw new NotImplementedException(),
    };

    #endregion
    #region Cleanup
    [TearDown]
    public virtual void Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        ProjectOpenAIClient openAIClient = GetTestClient();
        // Remove conversations.
        if (_conversations is not null)
        {
            foreach (string id in _conversationIDs)
            {
                try
                {
                    openAIClient.Conversations.DeleteConversation(conversationId: id);
                }
                catch (RequestFailedException ex)
                {
                    // Throw only if it is the error other then "Not found."
                    if (ex.Status != 404)
                        throw;
                }
            }
        }
        //// Remove Vector stores
        //OpenAIClient oaiClient = client.GetOpenAIClient();
        //VectorStoreClient oaiVctStoreClient = oaiClient.GetVectorStoreClient();
        //foreach (VectorStore vct in oaiVctStoreClient.GetVectorStores().Where(x => (x.Name ?? "").Equals(VECTOR_STORE)))
        //{
        //    oaiVctStoreClient.DeleteVectorStore(vectorStoreId: vct.Id);
        //}
    }
    #endregion
    #region Debug Method
    internal static PipelinePolicy GetDumpPolicy()
    {
        return new TestPipelinePolicy((message) =>
        {
            if (message.Request is not null && message.Response is null)
            {
                Console.WriteLine($"--- New request ---");
                IEnumerable<string> headerPairs = message?.Request?.Headers?.Select(header => $"{header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
                string headers = string.Join(",", headerPairs);
                Console.WriteLine($"Headers: {headers}");
                Console.WriteLine($"{message?.Request?.Method} URI: {message?.Request?.Uri}");
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
                        Console.WriteLine(requestDump);
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
                IEnumerable<string> headerPairs = message?.Response?.Headers?.Select(header => $"{header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
                string headers = string.Join(",", headerPairs);
                Console.WriteLine($"Response headers: {headers}");
                if (message.BufferResponse)
                {
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
    #endregion
}

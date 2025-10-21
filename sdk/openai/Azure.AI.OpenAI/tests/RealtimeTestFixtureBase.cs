using Azure.AI.OpenAI.Tests.Utils.Config;
using OpenAI.Realtime;
using OpenAI.TestFramework;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace Azure.AI.OpenAI.Tests;

#nullable disable
#pragma warning disable OPENAI002

[Parallelizable(ParallelScope.All)]
[Category("Conversation")]
[Category("Live")]
public class RealtimeTestFixtureBase
{
    internal TestConfig TestConfig { get; } = new(() => RecordedTestMode.Live);
    internal IConfiguration DefaultConfiguration { get; }

    public CancellationTokenSource CancellationTokenSource { get; }
    public CancellationToken CancellationToken => CancellationTokenSource?.Token ?? default;
    public RequestOptions CancellationOptions => new() { CancellationToken = CancellationToken };

    public RealtimeTestFixtureBase(bool isAsync)
    {
        CancellationTokenSource = new();
        if (!Debugger.IsAttached)
        {
            CancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(25));
        }
        DefaultConfiguration = TestConfig.GetConfig("rt_eus2");
        if (DefaultConfiguration is null || DefaultConfiguration.Endpoint is null)
        {
            Assert.Inconclusive();
        }
    }

    public TestClientOptions GetTestClientOptions(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        return version is null ? new TestClientOptions() : new TestClientOptions(version.Value);
    }

    public RealtimeClient GetTestClient(TestClientOptions clientOptions = null) => GetTestClient(DefaultConfiguration, clientOptions);
    public string GetTestDeployment() => DefaultConfiguration.Deployment;
    public RealtimeClient GetTestClient(string configurationName, TestClientOptions clientOptions = null) => GetTestClient(TestConfig.GetConfig(configurationName), clientOptions);
    public RealtimeClient GetTestClient(IConfiguration testConfig, TestClientOptions clientOptions = null)
    {
        clientOptions ??= new();

        Uri endpoint = testConfig.Endpoint;
        ApiKeyCredential key = new(testConfig.Key);
        string deployment = testConfig.Deployment;

        Console.WriteLine($"--- Connecting to endpoint: {endpoint.AbsoluteUri}");

        AzureOpenAIClient topLevelClient = new(endpoint, key, clientOptions);
        RealtimeClient client = topLevelClient.GetRealtimeClient();

        client.OnSendingCommand += (_, data) => PrintMessageData(data, "> ");
        client.OnReceivingCommand += (_, data) => PrintMessageData(data, "  < ");
        return client;
    }

    public static void PrintMessageData(BinaryData data, string prefix = "")
    {
#if NET6_0_OR_GREATER
        JsonNode jsonNode = JsonNode.Parse(data.ToString());

        foreach ((string labelKey, string labelValue, string dataKey) in new (string, string, string)[]
        {
            ("type", "input_audio_buffer.append", "audio"),
            ("type", "audio", "data"),
            ("event", "add_user_audio", "data"),
            ("type", "response.audio.delta", "delta")
        })
        {
            if (jsonNode[labelKey]?.GetValue<string>() == labelValue)
            {
                string rawBase64Data = jsonNode[dataKey]?.GetValue<string>();
                if (rawBase64Data is not null)
                {
                    byte[] base64Data = rawBase64Data == null ? [] : Convert.FromBase64String(rawBase64Data);
                    jsonNode[dataKey] = $"<{base64Data.Length} bytes>";
                }
            }
        }

        string rawMessage = jsonNode.ToJsonString(new JsonSerializerOptions());
        Console.WriteLine($"{prefix}{rawMessage}");
#endif
    }
}

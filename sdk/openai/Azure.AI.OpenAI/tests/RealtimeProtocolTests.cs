using Azure.AI.OpenAI.Tests.Utils.Config;
using OpenAI.Realtime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.Tests;

#if !AZURE_OPENAI_GA

#nullable disable
#pragma warning disable OPENAI002

[TestFixture(true)]
[TestFixture(false)]
public class RealtimeProtocolTests : RealtimeTestFixtureBase
{
    public RealtimeProtocolTests(bool isAsync) : base(isAsync)
    { }

#if NET6_0_OR_GREATER
    [Test]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(null)]
    public async Task ProtocolCanConfigureSession(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        RealtimeClient client = GetTestClient(GetTestClientOptions(version));
        using RealtimeSession session = await client.StartConversationSessionAsync(GetTestDeployment(), new RealtimeSessionOptions(), CancellationToken);

        BinaryData configureSessionCommand = BinaryData.FromString("""
            {
              "type": "session.update",
              "session": {
                "turn_detection": { "type": "none" }
              }
            }
            """);
        await session.SendCommandAsync(configureSessionCommand, CancellationOptions);

        List<JsonNode> receivedCommands = [];

        await foreach (RealtimeUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            BinaryData rawContentBytes = update.GetRawContent();
            JsonNode jsonNode = JsonNode.Parse(rawContentBytes);
            string updateType = jsonNode["type"]?.GetValue<string>();
            Assert.That(updateType, Is.Not.Null.And.Not.Empty);

            receivedCommands.Add(jsonNode);

            if (updateType == "error")
            {
                Assert.Fail($"Error encountered: {rawContentBytes.ToString()}");
            }
            else if (updateType == "session.created")
            {
                BinaryData createResponseCommand = BinaryData.FromString("""
                    {
                      "type": "response.create"
                    }
                    """);
                await session.SendCommandAsync(createResponseCommand, CancellationOptions);
            }
            else if (updateType == "response.done")
            {
                break;
            }
        }

        List<JsonNode> NodesOfType(string type) => receivedCommands.Where(command => command["type"].GetValue<string>() == type).ToList();

        Assert.That(NodesOfType("session.created"), Has.Count.EqualTo(1));
        Assert.That(NodesOfType("response.created"), Has.Count.EqualTo(1));
        Assert.That(NodesOfType("response.output_item.added"), Has.Count.EqualTo(1));
        Assert.That(NodesOfType("conversation.item.created"), Has.Count.EqualTo(1));
        Assert.That(NodesOfType("response.content_part.added"), Has.Count.EqualTo(1));
        Assert.That(NodesOfType("response.audio_transcript.delta"), Has.Count.GreaterThan(0));
        Assert.That(NodesOfType("response.audio.delta"), Has.Count.GreaterThan(0));
        Assert.That(NodesOfType("response.audio_transcript.done"), Has.Count.EqualTo(1));
        Assert.That(NodesOfType("response.content_part.done"), Has.Count.EqualTo(1));
        Assert.That(NodesOfType("response.output_item.done"), Has.Count.EqualTo(1));
    }
#endif
}

#endif

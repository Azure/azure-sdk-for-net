// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001, SCME0006

namespace Azure.AI.Projects.Agents.Tests;

public class TelephonyAddressSerializationTests
{
    [Test]
    public void DerivedAddressWritesInheritedValueOnce(
        [Values("phone_number", "teams", "sip")] string type,
        [Values("J", "W")] string format,
        [Values(false, true)] bool polymorphic)
    {
        TelephonyAddress address = CreateAddress(type);
        string value = GetValue(type, updated: true);
        address.Value = value;

        BinaryData data = WriteAddress(address, type, new(format), polymorphic);
        using JsonDocument document = JsonDocument.Parse(data);
        AssertUniqueProperties(document.RootElement);
        Assert.Multiple(() =>
        {
            Assert.That(document.RootElement.GetProperty("type").GetString(), Is.EqualTo(type));
            Assert.That(document.RootElement.GetProperty("value").GetString(), Is.EqualTo(value));
            Assert.That(document.RootElement.EnumerateObject().Count(), Is.EqualTo(2));
            Assert.That(JsonNode.Parse(data.ToString()).AsObject().Count, Is.EqualTo(2));
        });
        TelephonyAddress roundTrip = ModelReaderWriter.Read<TelephonyAddress>(
            data, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        Assert.That(roundTrip.GetType(), Is.EqualTo(address.GetType()));
        Assert.That(roundTrip.Value, Is.EqualTo(value));
    }

    [Test]
    public void DerivedAddressPreservesFormatAndExtensionData(
        [Values("phone_number", "teams", "sip")] string type,
        [Values("J", "W")] string format,
        [Values(false, true)] bool polymorphic)
    {
        BinaryData input = BinaryData.FromString(
            $"{{\"type\":\"{type}\",\"value\":\"{GetValue(type)}\",\"future\":{{\"nested\":42}}}}");
        TelephonyAddress address = ModelReaderWriter.Read<TelephonyAddress>(
            input, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        BinaryData data = WriteAddress(address, type, new(format), polymorphic);
        using JsonDocument document = JsonDocument.Parse(data);
        AssertUniqueProperties(document.RootElement);
        Assert.That(document.RootElement.GetProperty("value").GetString(), Is.EqualTo(GetValue(type)));
        Assert.That(document.RootElement.TryGetProperty("future", out JsonElement future), Is.EqualTo(format == "J"));
        if (format == "J")
        {
            Assert.That(future.GetProperty("nested").GetInt32(), Is.EqualTo(42));
        }
    }

    [TestCase("J")]
    [TestCase("W")]
    public void UnknownAddressRetainsBaseValueSerialization(string format)
    {
        TelephonyAddress address = ModelReaderWriter.Read<TelephonyAddress>(
            BinaryData.FromString("""{"type":"future_address","value":"future-value","future":42}"""),
            ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        BinaryData data = ModelReaderWriter.Write(address, new(format), AzureAIProjectsAgentsContext.Default);
        using JsonDocument document = JsonDocument.Parse(data);
        AssertUniqueProperties(document.RootElement);
        Assert.That(document.RootElement.GetProperty("type").GetString(), Is.EqualTo("future_address"));
        Assert.That(document.RootElement.GetProperty("value").GetString(), Is.EqualTo("future-value"));
        Assert.That(document.RootElement.TryGetProperty("future", out _), Is.EqualTo(format == "J"));
    }

    [Test]
    public async Task TypedRequestsWriteUniqueNestedAddressProperties(
        [Values("job", "campaign", "transfer")] string operation,
        [Values(false, true)] bool isAsync)
    {
        string requestBody = null;
        MockPipelineTransport transport = new(message =>
        {
            using MemoryStream stream = new();
            message.Request.Content.WriteTo(stream, CancellationToken.None);
            requestBody = BinaryData.FromBytes(stream.ToArray()).ToString();
            return new MockPipelineResponse(operation == "job" ? 202 : 200)
                .WithHeader("Operation-Id", "operation")
                .WithContent("{}");
        })
        { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient administration = new(
            new Uri("https://example.test/api/projects/project"),
            new FakeTokenProvider(), new() { Transport = transport });
        PhoneNumber source = new("+15555550100");
        PhoneNumber destination = new("+15555550101");
        if (operation == "job")
        {
            TelephonyCallJobCreate job = new(destination, "connection", source);
            BetaVoiceAgentsTelephony client = administration.GetBetaVoiceAgentTelephony();
            if (isAsync)
            {
                await client.CreateTelephonyCallJobAsync("agent", "request", job, CancellationToken.None);
            }
            else
            {
                client.CreateTelephonyCallJob("agent", "request", job, CancellationToken.None);
            }
        }
        else if (operation == "campaign")
        {
            TelephonyCampaign campaign = new("connection", source)
            {
                Recipients = { new TelephonyRecipient(destination) }
            };
            TelephonyCampaigns client = administration.GetBetaVoiceAgentTelephonyCampaigns();
            if (isAsync)
            {
                await client.CreateAsync(false, "agent", "campaign", campaign, "operation", "*");
            }
            else
            {
                client.Create(false, "agent", "campaign", campaign, "operation", "*");
            }
        }
        else
        {
            TelephonyTransferTarget[] targets = [new("support", "Support", destination)];
            BetaVoiceAgentsTelephony client = administration.GetBetaVoiceAgentTelephony();
            if (isAsync)
            {
                await client.ReplaceTelephonyTransferTargetsAsync("agent", "*", targets, CancellationToken.None);
            }
            else
            {
                client.ReplaceTelephonyTransferTargets("agent", "*", targets, CancellationToken.None);
            }
        }

        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        Assert.That(requestBody, Is.Not.Null.And.Not.Empty);
        using JsonDocument document = JsonDocument.Parse(requestBody);
        AssertUniqueProperties(document.RootElement);
        Assert.That(JsonNode.Parse(requestBody).AsObject().Count, Is.GreaterThan(0));
        if (operation == "job")
        {
            Assert.That(document.RootElement.GetProperty("source").GetProperty("value").GetString(), Is.EqualTo(source.Value));
            Assert.That(document.RootElement.GetProperty("destination").GetProperty("value").GetString(), Is.EqualTo(destination.Value));
        }
        if (operation == "campaign")
        {
            Assert.That(document.RootElement.GetProperty("source").GetProperty("value").GetString(), Is.EqualTo(source.Value));
            Assert.That(document.RootElement.GetProperty("recipients")[0].GetProperty("destination").GetProperty("value").GetString(),
                Is.EqualTo(destination.Value));
            foreach (string responseField in new[] { "name", "status", "created_at", "updated_at", "etag", "operation_id", "progress" })
            {
                Assert.That(document.RootElement.TryGetProperty(responseField, out _), Is.False, responseField);
            }
        }
        if (operation == "transfer")
        {
            Assert.That(document.RootElement.GetProperty("transfer_targets")[0].GetProperty("destination").GetProperty("value").GetString(),
                Is.EqualTo(destination.Value));
        }
    }

    private static TelephonyAddress CreateAddress(string type)
        => type switch
        {
            "phone_number" => new PhoneNumber(GetValue(type)),
            "teams" => new TeamsAddress(GetValue(type)),
            "sip" => new SipAddress(GetValue(type)),
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };

    private static string GetValue(string type, bool updated = false)
        => type switch
        {
            "phone_number" => updated ? "+15555550101" : "+15555550100",
            "teams" => updated ? "22222222-2222-2222-2222-222222222222" : "11111111-1111-1111-1111-111111111111",
            "sip" => updated ? "sips:updated@example.test" : "sip:original@example.test",
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };

    private static BinaryData WriteAddress(TelephonyAddress address, string type, ModelReaderWriterOptions options, bool polymorphic)
        => polymorphic ? ModelReaderWriter.Write(address, options, AzureAIProjectsAgentsContext.Default)
            : type switch
            {
                "phone_number" => ModelReaderWriter.Write((PhoneNumber)address, options, AzureAIProjectsAgentsContext.Default),
                "teams" => ModelReaderWriter.Write((TeamsAddress)address, options, AzureAIProjectsAgentsContext.Default),
                "sip" => ModelReaderWriter.Write((SipAddress)address, options, AzureAIProjectsAgentsContext.Default),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };

    private static void AssertUniqueProperties(JsonElement element, string path = "$")
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            JsonProperty[] properties = element.EnumerateObject().ToArray();
            Assert.That(properties.Select(property => property.Name), Is.Unique, path);
            foreach (JsonProperty property in properties)
            {
                AssertUniqueProperties(property.Value, path + "." + property.Name);
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            int index = 0;
            foreach (JsonElement item in element.EnumerateArray())
            {
                AssertUniqueProperties(item, path + "[" + index++ + "]");
            }
        }
    }

    private sealed class FakeTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);
        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
            => new("fake-token", "Bearer", DateTimeOffset.UtcNow.AddHours(1), null);
        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
            => new(GetToken(options, cancellationToken));
    }
}

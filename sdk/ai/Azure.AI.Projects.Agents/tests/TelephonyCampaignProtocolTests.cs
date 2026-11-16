// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001, SCME0006

namespace Azure.AI.Projects.Agents.Tests;

public class TelephonyCampaignProtocolTests
{
    private const string Endpoint = "https://example.services.ai.azure.com/api/projects/project";
    private const string AgentName = "agent /?#";
    private const string CampaignName = "campaign /?#";
    private const string OperationId = "operation /?#";
    private const string CampaignJson = """
        {"name":"campaign /?#","connection_name":"connection","source":{"type":"phone_number","value":"+15555550100"},
         "status":"running","operation_id":"operation /?#","etag":"etag","created_at":1700000000,"updated_at":1700000000}
        """;
    private const string OperationJson = """
        {"id":"operation /?#","status":"succeeded","kind":"validation","created_at":1700000000}
        """;

    private static readonly (string Name, string Method, string Path, int Status)[] s_cases =
    {
        ("CreateNew", "PUT", "/api/projects/project/agents/agent%20%2F%3F%23/telephony_campaigns/campaign%20%2F%3F%23", 201),
        ("CreateReplacement", "PUT", "/api/projects/project/agents/agent%20%2F%3F%23/telephony_campaigns/campaign%20%2F%3F%23", 201),
        ("Get", "GET", "/api/projects/project/agents/agent%20%2F%3F%23/telephony_campaigns/campaign%20%2F%3F%23", 200),
        ("Cancel", "POST", "/api/projects/project/agents/agent%20%2F%3F%23/telephony_campaigns/campaign%20%2F%3F%23:cancel", 202),
        ("Delete", "DELETE", "/api/projects/project/agents/agent%20%2F%3F%23/telephony_campaigns/campaign%20%2F%3F%23", 204),
        ("GetOperation", "GET", "/api/projects/project/agents/agent%20%2F%3F%23/telephony_campaigns/campaign%20%2F%3F%23/operations/operation%20%2F%3F%23", 200),
    };

    private static IEnumerable<TestCaseData> RequestCases()
    {
        foreach (var test in s_cases)
        {
            foreach (bool isAsync in new[] { false, true })
            {
                foreach (bool protocol in new[] { false, true })
                {
                    yield return new TestCaseData(isAsync, protocol, test.Name, test.Method, test.Path, test.Status)
                        .SetName($"Campaign_{test.Name}_{(protocol ? "Protocol" : "Typed")}_{(isAsync ? "Async" : "Sync")}");
                }
            }
        }
    }

    [TestCaseSource(nameof(RequestCases))]
    public async Task RequestsPreserveTheWireContract(
        bool isAsync, bool protocol, string operation, string method, string expectedPath, int status)
    {
        string response = operation == "Delete" ? "" : operation == "GetOperation" ? OperationJson : CampaignJson;
        MockPipelineResponse pipelineResponse = new MockPipelineResponse(status).WithContent(response);
        if (operation.StartsWith("Create", StringComparison.Ordinal) || operation == "Cancel")
        {
            pipelineResponse
                .WithHeader("Operation-Id", OperationId)
                .WithHeader("Operation-Location", Endpoint + "/agents/agent%20%2F%3F%23/telephony_campaigns/campaign%20%2F%3F%23/operations/operation%20%2F%3F%23?api-version=v1")
                .WithHeader("Retry-After", "0");
        }
        var (client, transport) = CreateClient(isAsync, pipelineResponse);
        RequestOptions options = new();
        options.SetHeader("x-campaign-test", "retained");

        ClientResult result = await InvokeAsync(client, isAsync, protocol, operation, options);
        MockPipelineRequest request = transport.Requests.Single();
        Assert.Multiple(() =>
        {
            Assert.That(request.Method, Is.EqualTo(method));
            Assert.That(request.Uri.AbsolutePath, Is.EqualTo(expectedPath));
            Assert.That(Query(request.Uri, "api-version"), Is.EqualTo("v1"));
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(status));
            Assert.That(request.Headers.TryGetValue("Foundry-Features", out string features), Is.True);
            Assert.That(features, Does.Contain("VoiceAgents=V1Preview"));
            if (protocol)
            {
                Assert.That(request.Headers.TryGetValue("x-campaign-test", out string custom), Is.True);
                Assert.That(custom, Is.EqualTo("retained"));
            }
        });

        if (operation == "Get")
        {
            Assert.That(Query(request.Uri, "operation_id"), Is.EqualTo(OperationId));
        }
        else
        {
            Assert.That(Query(request.Uri, "operation_id"), Is.Null);
        }
        if (operation.StartsWith("Create", StringComparison.Ordinal) || operation is "Cancel" or "Delete")
        {
            Assert.That(request.Headers.TryGetValue("Operation-Id", out string operationId), Is.True);
            Assert.That(operationId, Is.EqualTo(OperationId));
        }
        if (operation is "CreateReplacement" or "Cancel" or "Delete")
        {
            Assert.That(request.Headers.TryGetValue("If-Match", out string ifMatch), Is.True);
            Assert.That(ifMatch, Is.EqualTo("\"etag\""));
        }
        else if (operation == "CreateNew")
        {
            Assert.That(request.Headers.TryGetValue("If-Match", out _), Is.False);
        }
        if (!protocol && operation == "GetOperation")
        {
            Assert.That(((ClientResult<TelephonyCampaignOperation>)result).Value.Id, Is.EqualTo(OperationId));
        }
        else if (!protocol && operation == "Get")
        {
            Assert.That(((ClientResult<TelephonyCampaign>)result).Value.Name, Is.EqualTo(CampaignName));
        }
    }

    [Test]
    public async Task CreateBodiesRespectTypedLifecycleAndPreserveProtocolContent(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool protocol)
    {
        MockPipelineResponse response = new MockPipelineResponse(201)
            .WithHeader("Operation-Id", OperationId)
            .WithHeader("Operation-Location", Endpoint + "/monitor?api-version=v1")
            .WithContent(CampaignJson);
        var (client, transport) = CreateClient(isAsync, response);
        byte[] requestBody = null;
        transport.OnSendingRequest = message =>
        {
            using MemoryStream stream = new();
            message.Request.Content.WriteTo(stream, CancellationToken.None);
            requestBody = stream.ToArray();
        };
        RequestOptions options = new();

        await InvokeAsync(client, isAsync, protocol, "Create", options);
        Assert.That(requestBody, Is.Not.Null);
        using JsonDocument body = JsonDocument.Parse(requestBody);
        Assert.Multiple(() =>
        {
            Assert.That(body.RootElement.GetProperty("connection_name").GetString(), Is.EqualTo(protocol ? "raw-connection" : "connection"));
            Assert.That(body.RootElement.GetProperty("source").GetProperty("value").GetString(), Is.EqualTo("+15555550100"));
            Assert.That(body.RootElement.GetProperty("recipients")[0].GetProperty("destination").GetProperty("type").GetString(), Is.EqualTo("phone_number"));
            Assert.That(body.RootElement.GetProperty("recipients")[0].GetProperty("structured_inputs").GetProperty("customer").GetProperty("id").GetInt32(), Is.EqualTo(7));
            Assert.That(body.RootElement.TryGetProperty("name", out _), Is.False);
            Assert.That(body.RootElement.TryGetProperty("status", out _), Is.False);
            Assert.That(body.RootElement.TryGetProperty("etag", out _), Is.False);
            Assert.That(body.RootElement.TryGetProperty("raw_marker", out JsonElement marker), Is.EqualTo(protocol));
            if (protocol)
            {
                Assert.That(marker.GetString(), Is.EqualTo("preserved"));
            }
        });
    }

    [Test]
    public async Task ProtocolNoThrowRetainsConflictBodies(
        [Values(false, true)] bool isAsync,
        [Values("Create", "Cancel", "Delete")] string operation,
        [Values(409, 412)] int status,
        [Values(false, true)] bool noThrow)
    {
        string error = $$"""{"code":"campaign_conflict","status":{{status}}}""";
        var (client, transport) = CreateClient(isAsync, new MockPipelineResponse(status).WithContent(error));
        RequestOptions options = new() { ErrorOptions = noThrow ? ClientErrorBehaviors.NoThrow : ClientErrorBehaviors.Default };

        if (noThrow)
        {
            ClientResult result = await InvokeAsync(client, isAsync, true, operation, options);
            Assert.Multiple(() =>
            {
                Assert.That(result.GetRawResponse().Status, Is.EqualTo(status));
                Assert.That(result.GetRawResponse().Content.ToString(), Is.EqualTo(error));
            });
        }
        else
        {
            ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
                async () => await InvokeAsync(client, isAsync, true, operation, options));
            Assert.That(exception.Status, Is.EqualTo(status));
        }
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    [Test]
    public void RequiredArgumentsFailBeforeTransport(
        [Values(false, true)] bool isAsync,
        [Values("Create", "Get", "Cancel", "Delete", "GetOperation")] string operation,
        [Values(null, "")] string invalid)
    {
        var (client, transport) = CreateClient(isAsync, new MockPipelineResponse(200));
        RequestOptions options = new();
        ArgumentException exception = Assert.CatchAsync<ArgumentException>(async () =>
        {
            if (operation == "Create")
            {
                using BinaryContent content = BinaryContent.Create(BinaryData.FromString("{}"));
                if (isAsync)
                {
                    await client.CreateAsync(false, invalid, CampaignName, content, OperationId, "\"etag\"", options);
                }
                else
                {
                    client.Create(false, invalid, CampaignName, content, OperationId, "\"etag\"", options);
                }
            }
            else if (operation == "Get")
            {
                if (isAsync)
                {
                    await client.GetAsync(invalid, CampaignName, OperationId, options);
                }
                else
                {
                    client.Get(invalid, CampaignName, OperationId, options);
                }
            }
            else if (operation == "Cancel")
            {
                if (isAsync)
                {
                    await client.CancelAsync(false, AgentName, CampaignName, invalid, OperationId, options);
                }
                else
                {
                    client.Cancel(false, AgentName, CampaignName, invalid, OperationId, options);
                }
            }
            else if (operation == "Delete")
            {
                if (isAsync)
                {
                    await client.DeleteAsync(false, AgentName, CampaignName, invalid, OperationId, options);
                }
                else
                {
                    client.Delete(false, AgentName, CampaignName, invalid, OperationId, options);
                }
            }
            else
            {
                if (isAsync)
                {
                    await client.GetOperationAsync(AgentName, CampaignName, invalid, options);
                }
                else
                {
                    client.GetOperation(AgentName, CampaignName, invalid, options);
                }
            }
        });
        Assert.That(exception, Is.TypeOf(invalid == null ? typeof(ArgumentNullException) : typeof(ArgumentException)));
        Assert.That(exception.ParamName, Is.EqualTo(operation switch
        {
            "Create" or "Get" => "agentName",
            "Cancel" or "Delete" => "ifMatch",
            _ => "operationId"
        }));
        Assert.That(transport.Requests, Is.Empty);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task CallerCancellationReachesThePipeline(bool isAsync)
    {
        var (client, transport) = CreateClient(isAsync, new MockPipelineResponse(200).WithContent(CampaignJson));
        transport.OnSendingRequest = message => message.CancellationToken.ThrowIfCancellationRequested();
        using CancellationTokenSource cancellation = new();
        cancellation.Cancel();

        if (isAsync)
        {
            Assert.CatchAsync<OperationCanceledException>(async () =>
                await client.GetAsync(AgentName, CampaignName, OperationId, cancellation.Token));
        }
        else
        {
            Assert.Catch<OperationCanceledException>(() =>
                client.Get(AgentName, CampaignName, OperationId, cancellation.Token));
        }
        Assert.That(transport.Requests, Is.Empty);
    }

    private static async Task<ClientResult> InvokeAsync(
        TelephonyCampaigns client, bool isAsync, bool protocol, string operation, RequestOptions options)
    {
        if (operation.StartsWith("Create", StringComparison.Ordinal))
        {
            string ifMatch = operation == "CreateNew" ? null : "\"etag\"";
            if (protocol)
            {
                using BinaryContent content = BinaryContent.Create(BinaryData.FromString(
                    """
                    {"connection_name":"raw-connection","source":{"type":"phone_number","value":"+15555550100"},"raw_marker":"preserved",
                     "recipients":[{"destination":{"type":"phone_number","value":"+15555550101"},"structured_inputs":{"customer":{"id":7}}}]}
                    """));
                OperationResult operationResult = isAsync
                    ? await client.CreateAsync(false, AgentName, CampaignName, content, OperationId, ifMatch, options)
                    : client.Create(false, AgentName, CampaignName, content, OperationId, ifMatch, options);
                return ClientResult.FromResponse(operationResult.GetRawResponse());
            }
            TelephonyCampaign campaign = new("connection", new PhoneNumber("+15555550100"));
            TelephonyRecipient recipient = new(new PhoneNumber("+15555550101"));
            recipient.StructuredInputs["customer"] = BinaryData.FromString("""{"id":7}""");
            campaign.Recipients.Add(recipient);
            OperationResult typedOperation = isAsync
                ? await client.CreateAsync(false, AgentName, CampaignName, campaign, OperationId, ifMatch, options.CancellationToken)
                : client.Create(false, AgentName, CampaignName, campaign, OperationId, ifMatch, options.CancellationToken);
            return ClientResult.FromResponse(typedOperation.GetRawResponse());
        }
        if (operation == "Get")
        {
            return protocol
                ? isAsync ? await client.GetAsync(AgentName, CampaignName, OperationId, options) : client.Get(AgentName, CampaignName, OperationId, options)
                : isAsync ? await client.GetAsync(AgentName, CampaignName, OperationId, options.CancellationToken) : client.Get(AgentName, CampaignName, OperationId, options.CancellationToken);
        }
        if (operation == "Cancel")
        {
            OperationResult operationResult = isAsync
                ? protocol
                    ? await client.CancelAsync(false, AgentName, CampaignName, "\"etag\"", OperationId, options)
                    : await client.CancelAsync(false, AgentName, CampaignName, "\"etag\"", OperationId, options.CancellationToken)
                : protocol
                    ? client.Cancel(false, AgentName, CampaignName, "\"etag\"", OperationId, options)
                    : client.Cancel(false, AgentName, CampaignName, "\"etag\"", OperationId, options.CancellationToken);
            return ClientResult.FromResponse(operationResult.GetRawResponse());
        }
        if (operation == "Delete")
        {
            OperationResult operationResult = isAsync
                ? protocol
                    ? await client.DeleteAsync(false, AgentName, CampaignName, "\"etag\"", OperationId, options)
                    : await client.DeleteAsync(false, AgentName, CampaignName, "\"etag\"", OperationId, options.CancellationToken)
                : protocol
                    ? client.Delete(false, AgentName, CampaignName, "\"etag\"", OperationId, options)
                    : client.Delete(false, AgentName, CampaignName, "\"etag\"", OperationId, options.CancellationToken);
            return ClientResult.FromResponse(operationResult.GetRawResponse());
        }
        return protocol
            ? isAsync ? await client.GetOperationAsync(AgentName, CampaignName, OperationId, options) : client.GetOperation(AgentName, CampaignName, OperationId, options)
            : isAsync ? await client.GetOperationAsync(AgentName, CampaignName, OperationId, options.CancellationToken) : client.GetOperation(AgentName, CampaignName, OperationId, options.CancellationToken);
    }

    private static string Query(Uri uri, string name)
        => uri.Query.TrimStart('?').Split('&').Select(value => value.Split(new[] { '=' }, 2))
            .Where(value => value.Length == 2 && Uri.UnescapeDataString(value[0]) == name)
            .Select(value => Uri.UnescapeDataString(value[1])).SingleOrDefault();

    private static (TelephonyCampaigns Client, MockPipelineTransport Transport) CreateClient(
        bool isAsync, params MockPipelineResponse[] responses)
    {
        int index = 0;
        MockPipelineTransport transport = new(_ =>
        {
            Assert.That(index, Is.LessThan(responses.Length), "Unexpected campaign request.");
            return responses[index++];
        })
        { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient administration = new(
            new Uri(Endpoint), new FakeTokenProvider(), new AgentAdministrationClientOptions { Transport = transport });
        return (administration.GetBetaVoiceAgentTelephonyCampaigns(), transport);
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

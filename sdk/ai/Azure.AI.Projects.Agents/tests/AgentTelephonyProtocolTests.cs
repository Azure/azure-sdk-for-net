// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001
namespace Azure.AI.Projects.Agents.Tests;

/// <summary>
/// Mocked tests for the <see cref="BetaVoiceAgentsTelephony"/> REST surface, including typed
/// facades, synchronous and asynchronous pipelines, request contracts, and response handling.
/// </summary>
/// <remarks>
/// The Telephony REST routes are deployed on the test Foundry resource, and most of the recorded
/// tests in <see cref="AgentTelephonyTests"/> that exercise this same surface are enabled; the few
/// that remain <c>[Ignore]</c>d there are skipped for narrower, test-environment-specific reasons
/// (needing a real Twilio/Teams-provider connection, or contention on a shared resource) documented
/// on each. These protocol tests still give unconditional, always-running coverage of request
/// construction independent of that live test environment (mirroring azure-ai-projects' (Python)
/// tests/foundry_features_header/test_agent_telephony_protocol.py, which exists for the same
/// reason).
/// </remarks>
public class AgentTelephonyProtocolTests
{
    private const string FakeEndpoint = "https://fake-account.services.ai.azure.com/api/projects/fake-project";
    private const string BindingJson = """
        {"id":"fake-binding","provider":"twilio","connection_name":"connection","phone_number":"+15555550100",
         "label":"support","incoming_call_url":"https://example.com/incoming"}
        """;
    private const string BindingCreateJson = """
        {"provider":"twilio","connection_name":"connection","phone_number":"+15555550100","label":"support"}
        """;
    private const string PatchJson = """{"label":"updated"}""";
    private const string CallJson = """
        {"id":"fake-call","provider":"twilio","status":"success","phase":"completed","started_at":1700000000,
         "timing":{},"events":[],"events_truncated":false}
        """;
    private const string TargetsJson = """
        {"transfer_targets":[{"name":"support","description":"Customer support",
         "destination":{"type":"phone_number","value":"+15555550100"}}]}
        """;
    private const string CallJobCreateJson = """
        {"destination":{"type":"phone_number","value":"+15555550101"},"connection_name":"connection",
         "source":{"type":"phone_number","value":"+15555550100"}}
        """;
    private const string CallJobJson = """
        {"id":"fake-call-job","agent_name":"fake-agent","destination":{"type":"phone_number","value":"+15555550101"},
         "connection_name":"connection","source":{"type":"phone_number","value":"+15555550100"},"status":"queued",
         "retry_policy":{"type":"fixed_interval","max_attempts":1,"interval":0},"attempt_count":0,
         "revision":1,"created_at":1700000000,"updated_at":1700000000}
        """;

    private static (BetaVoiceAgentsTelephony Client, MockPipelineTransport Transport, AgentAdministrationClient Administration) CreateClient(
        bool isAsync = true, int status = 200, string response = "{}")
        => CreateClient(isAsync, new MockPipelineResponse(status).WithContent(response));

    private static (BetaVoiceAgentsTelephony Client, MockPipelineTransport Transport, AgentAdministrationClient Administration) CreateClient(
        bool isAsync, params MockPipelineResponse[] responses)
    {
        int index = 0;
        MockPipelineTransport transport = new(_ =>
        {
            Assert.That(index, Is.LessThan(responses.Length), "Unexpected telephony request.");
            return responses[index++];
        })
        { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClientOptions options = new() { Transport = transport };
        AgentAdministrationClient agentsClient = new(new Uri(FakeEndpoint), new FakeTokenProvider(), options);
        return (agentsClient.GetBetaVoiceAgentTelephony(), transport, agentsClient);
    }

    private static readonly (string Name, string Method, string Path, string IfMatch, string ContentType, int Status, string Response)[] s_cases =
    {
        ("CreateTelephonyBinding", "POST", "/agents/fake-agent/telephony/bindings", null, "application/json", 201, BindingJson),
        ("GetTelephonyBinding", "GET", "/agents/fake-agent/telephony/bindings/fake-binding", null, null, 200, BindingJson),
        ("UpdateTelephonyBinding", "PATCH", "/agents/fake-agent/telephony/bindings/fake-binding", "\"binding-etag\"", "application/merge-patch+json", 200, BindingJson),
        ("DeleteTelephonyBinding", "DELETE", "/agents/fake-agent/telephony/bindings/fake-binding", "\"binding-etag\"", null, 204, ""),
        ("GetTelephonyCall", "GET", "/agents/fake-agent/telephony/calls/fake-call", null, null, 200, CallJson),
        ("TransferTelephonyCall", "POST", "/agents/fake-agent/telephony/calls/fake-call:transfer", null, "application/json", 200, CallJson),
        ("EndTelephonyCall", "POST", "/agents/fake-agent/telephony/calls/fake-call:end", null, null, 200, CallJson),
        ("GetTelephonyTransferTargets", "GET", "/agents/fake-agent/telephony/transfer_targets", null, null, 200, TargetsJson),
        ("ReplaceTelephonyTransferTargets", "PUT", "/agents/fake-agent/telephony/transfer_targets", "\"targets-etag\"", "application/json", 200, TargetsJson),
        ("CreateTelephonyCallJob", "POST", "/agents/fake-agent/telephony_call_jobs", null, "application/json", 202, CallJobJson),
        ("GetTelephonyCallJob", "GET", "/agents/fake-agent/telephony_call_jobs/fake-call-job", null, null, 200, CallJobJson),
        ("CancelTelephonyCallJob", "POST", "/agents/fake-agent/telephony_call_jobs/fake-call-job:cancel", "\"job-etag\"", null, 202, CallJobJson.Replace("\"queued\"", "\"cancelled\"")),
    };

    private static IEnumerable<TestCaseData> Cases()
    {
        foreach (var test in s_cases)
        {
            foreach (bool isAsync in new[] { false, true })
            {
                foreach (bool protocol in new[] { false, true })
                {
                    if (!protocol && test.Name == "UpdateTelephonyBinding")
                    {
                        continue; // Binding PATCH is exposed only as a protocol method.
                    }
                    yield return new TestCaseData(isAsync, protocol, test.Name, test.Method, test.Path, test.IfMatch, test.ContentType, test.Status, test.Response)
                        .SetName($"TelephonyRequest_{test.Name}_{(protocol ? "Protocol" : "Typed")}_{(isAsync ? "Async" : "Sync")}");
                }
            }
        }
    }

    [TestCase("/agents/agent/telephony/call_jobs?api-version=v1", "/agents/agent/telephony_call_jobs?api-version=v1")]
    [TestCase("/agents/agent/telephony/call_jobs/job:cancel?api-version=v1", "/agents/agent/telephony_call_jobs/job:cancel?api-version=v1")]
    [TestCase("/agents/agent/telephony_call_jobs/job?api-version=v1", "/agents/agent/telephony_call_jobs/job?api-version=v1")]
    [TestCase("/agents/agent/telephony/call_jobs_extra", "/agents/agent/telephony/call_jobs_extra")]
    [TestCase("/files/telephony/call_jobs/job", "/files/telephony/call_jobs/job")]
    public void LegacyCallJobRecordingRoutesPreserveOtherPaths(string path, string expectedPath)
    {
        string normalized = Regex.Replace(path,
            ProjectsTestSanitizers.LegacyTelephonyCallJobPathPattern,
            ProjectsTestSanitizers.LegacyTelephonyCallJobPathReplacement);
        Assert.That(normalized, Is.EqualTo(expectedPath));
    }

    private static IEnumerable<TestCaseData> TypedReadArgumentCases()
    {
        foreach (bool isAsync in new[] { false, true })
        {
            foreach (string value in new string[] { null, "" })
            {
                foreach (string operation in new[] { "binding", "call", "call_job", "targets" })
                {
                    yield return new TestCaseData(isAsync, operation, "agentName", value);
                    string parameter = operation switch
                    {
                        "binding" => "bindingId",
                        "call" => "callId",
                        "call_job" => "callJobId",
                        _ => null
                    };
                    if (parameter != null)
                    {
                        yield return new TestCaseData(isAsync, operation, parameter, value);
                    }
                }
            }
        }
    }

    [TestCaseSource(nameof(TypedReadArgumentCases))]
    public void TypedReadValidatesPublicArgumentsBeforeSending(bool isAsync, string operation, string parameter, string value)
    {
        var (client, transport, _) = CreateClient();
        string agentName = parameter == "agentName" ? value : "agent";
        string id = parameter == "agentName" ? "resource" : value;
        Task Invoke() => operation switch
        {
            "binding" => isAsync ? client.GetTelephonyBindingAsync(agentName, id, CancellationToken.None) : Task.FromResult(client.GetTelephonyBinding(agentName, id, CancellationToken.None)),
            "call" => isAsync ? client.GetTelephonyCallAsync(agentName, id, CancellationToken.None) : Task.FromResult(client.GetTelephonyCall(agentName, id, CancellationToken.None)),
            "call_job" => isAsync ? client.GetTelephonyCallJobAsync(agentName, id, CancellationToken.None) : Task.FromResult(client.GetTelephonyCallJob(agentName, id, CancellationToken.None)),
            "targets" => isAsync ? client.GetTelephonyTransferTargetsAsync(agentName, CancellationToken.None) : Task.FromResult(client.GetTelephonyTransferTargets(agentName, CancellationToken.None)),
            _ => throw new ArgumentOutOfRangeException(nameof(operation))
        };
        ArgumentException exception = Assert.CatchAsync<ArgumentException>(async () => await Invoke());
        Assert.Multiple(() =>
        {
            Assert.That(exception, Is.TypeOf(value == null ? typeof(ArgumentNullException) : typeof(ArgumentException)));
            Assert.That(exception.ParamName, Is.EqualTo(parameter));
            Assert.That(transport.Requests, Is.Empty);
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public void GenerateAgentValidatesBodyBeforeSerialization(bool isAsync)
    {
        var (_, transport, administration) = CreateClient();
        ArgumentNullException exception = isAsync
            ? Assert.ThrowsAsync<ArgumentNullException>(async () => await administration.GenerateAgentAsync((GenerateVoiceAgentRequest)null))
            : Assert.Throws<ArgumentNullException>(() => administration.GenerateAgent((GenerateVoiceAgentRequest)null));
        Assert.Multiple(() =>
        {
            Assert.That(exception.ParamName, Is.EqualTo("body"));
            Assert.That(transport.Requests, Is.Empty);
        });
    }

    [TestCaseSource(nameof(Cases))]
    public async Task TelephonyMethodBuildsExpectedRequest(
        bool isAsync,
        bool protocol,
        string operation,
        string expectedMethod,
        string expectedPathSuffix,
        string expectedIfMatch,
        string expectedContentType,
        int expectedStatus,
        string expectedResponse)
    {
        var (client, transport, _) = CreateClient(isAsync, expectedStatus, expectedResponse);
        byte[] requestBody = null;
        transport.OnSendingRequest = message =>
        {
            if (message.Request.Content != null)
            {
                using MemoryStream stream = new();
                message.Request.Content.WriteTo(stream, CancellationToken.None);
                requestBody = stream.ToArray();
            }
        };
        RequestOptions options = new();
        options.SetHeader("x-telephony-test", "retained");
        ClientResult result = protocol
            ? await InvokeProtocolAsync(client, operation, isAsync, options)
            : await InvokeTypedAsync(client, operation, isAsync, CancellationToken.None);

        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        MockPipelineRequest request = transport.Requests[0];
        Assert.Multiple(() =>
        {
            Assert.That(request.Method, Is.EqualTo(expectedMethod));
            Assert.That(request.Uri.AbsolutePath, Does.EndWith(expectedPathSuffix));
            Assert.That(request.Uri.Query, Is.EqualTo("?api-version=v1"));
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(expectedStatus));
            Assert.That(result.GetRawResponse().Content.ToString(), Is.EqualTo(expectedResponse));
            Assert.That(request.Headers.TryGetValue("Foundry-Features", out string foundryFeatures), Is.True);
            Assert.That(foundryFeatures, Does.Contain("VoiceAgents=V1Preview"));

            if (protocol)
            {
                Assert.That(request.Headers.TryGetValue("x-telephony-test", out string header), Is.True);
                Assert.That(header, Is.EqualTo("retained"));
            }
            if (expectedIfMatch is not null)
            {
                Assert.That(request.Headers.TryGetValue("If-Match", out string ifMatch), Is.True, "Expected an If-Match header for this conditional-request operation.");
                Assert.That(ifMatch, Is.EqualTo(expectedIfMatch));
            }

            if (expectedContentType is not null)
            {
                Assert.That(request.Headers.TryGetValue("Content-Type", out string contentType), Is.True);
                Assert.That(contentType, Is.EqualTo(expectedContentType));
            }
        });
        if (operation == "CreateTelephonyCallJob")
        {
            Assert.That(request.Headers.TryGetValue("Idempotency-Key", out string key), Is.True);
            Assert.That(key, Is.EqualTo("fake-idempotency-key"));
        }
        if (operation == "CreateTelephonyBinding")
        {
            Assert.That(request.Headers.TryGetValue("Repeatability-Request-ID", out string requestId), Is.True);
            Assert.That(Guid.TryParse(requestId, out _), Is.True);
            Assert.That(request.Headers.TryGetValue("Repeatability-First-Sent", out string firstSent), Is.True);
            Assert.That(DateTimeOffset.TryParse(firstSent, out _), Is.True);
        }
        if (expectedContentType != null)
        {
            Assert.That(requestBody, Is.Not.Null);
            using JsonDocument body = JsonDocument.Parse(requestBody);
            switch (operation)
            {
                case "CreateTelephonyBinding":
                    Assert.That(body.RootElement.GetProperty("provider").GetString(), Is.EqualTo("twilio"));
                    Assert.That(body.RootElement.GetProperty("phone_number").GetString(), Is.EqualTo("+15555550100"));
                    Assert.That(body.RootElement.TryGetProperty("incoming_call_url", out _), Is.False);
                    break;
                case "UpdateTelephonyBinding":
                    Assert.That(body.RootElement.GetProperty("label").GetString(), Is.EqualTo("updated"));
                    break;
                case "TransferTelephonyCall":
                    Assert.That(body.RootElement.GetProperty("target").GetString(), Is.EqualTo("support"));
                    break;
                case "ReplaceTelephonyTransferTargets":
                    Assert.That(body.RootElement.GetProperty("transfer_targets")[0].GetProperty("destination").GetProperty("type").GetString(), Is.EqualTo("phone_number"));
                    break;
                case "CreateTelephonyCallJob":
                    Assert.That(body.RootElement.GetProperty("connection_name").GetString(), Is.EqualTo("connection"));
                    Assert.That(body.RootElement.GetProperty("destination").GetProperty("value").GetString(), Is.EqualTo("+15555550101"));
                    Assert.That(body.RootElement.GetProperty("source").GetProperty("value").GetString(), Is.EqualTo("+15555550100"));
                    break;
            }
        }
        if (!protocol)
        {
            AssertTypedResponse(result);
        }
    }

    [Test]
    public async Task BindingPatchReportsConcurrencyErrors(
        [Values(false, true)] bool isAsync,
        [Values(409, 412)] int status,
        [Values(false, true)] bool noThrow)
    {
        const string error = """{"error":{"code":"PreconditionFailed","message":"The binding changed."}}""";
        var (client, transport, _) = CreateClient(isAsync, status, error);
        RequestOptions options = new() { ErrorOptions = noThrow ? ClientErrorBehaviors.NoThrow : ClientErrorBehaviors.Default };
        if (noThrow)
        {
            ClientResult result = await InvokeProtocolAsync(client, "UpdateTelephonyBinding", isAsync, options);
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(status));
            Assert.That(result.GetRawResponse().Content.ToString(), Is.EqualTo(error));
        }
        else
        {
            ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(async () =>
                await InvokeProtocolAsync(client, "UpdateTelephonyBinding", isAsync, options));
            Assert.That(exception.Status, Is.EqualTo(status));
            Assert.That(exception.Message, Does.Contain("The binding changed."));
        }
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task ListsPreserveFiltersAndStopOnTheNonemptyTerminalPage(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool calls)
    {
        string first = (calls ? CallJson : BindingJson).Replace(calls ? "fake-call" : "fake-binding", "first");
        string last = (calls ? CallJson : BindingJson).Replace(calls ? "fake-call" : "fake-binding", "last");
        var (client, transport, _) = CreateClient(isAsync,
            new MockPipelineResponse(200).WithContent($$"""{"data":[{{first}}],"first_id":"first","last_id":"first","has_more":true}"""),
            new MockPipelineResponse(200).WithContent($$"""{"data":[{{last}}],"first_id":"last","last_id":"last","has_more":false}"""));
        DateTimeOffset startedAfter = DateTimeOffset.FromUnixTimeSeconds(1700000000);
        DateTimeOffset startedBefore = DateTimeOffset.FromUnixTimeSeconds(1700000100);
        List<string> ids = [];
        if (calls)
        {
            if (isAsync)
            {
                await foreach (TelephonyCallSummary call in client.GetTelephonyCallsAsync(
                    "fake-agent", TelephonyProvider.Twilio, TelephonyCallStatus.Success, startedAfter, startedBefore, 7, AgentListOrder.Ascending, "initial"))
                {
                    ids.Add(call.Id);
                }
            }
            else
            {
                ids.AddRange(client.GetTelephonyCalls(
                    "fake-agent", TelephonyProvider.Twilio, TelephonyCallStatus.Success, startedAfter, startedBefore, 7, AgentListOrder.Ascending, "initial").Select(call => call.Id));
            }
        }
        else if (isAsync)
        {
            await foreach (TelephonyBindingListItem binding in client.GetTelephonyBindingsAsync(
                "fake-agent", TelephonyProvider.Twilio, 7, AgentListOrder.Ascending, "initial"))
            {
                Assert.That(binding, Is.TypeOf<TwilioTelephonyBindingListItem>());
                ids.Add(binding.Id);
            }
        }
        else
        {
            foreach (TelephonyBindingListItem binding in client.GetTelephonyBindings(
                "fake-agent", TelephonyProvider.Twilio, 7, AgentListOrder.Ascending, "initial"))
            {
                Assert.That(binding, Is.TypeOf<TwilioTelephonyBindingListItem>());
                ids.Add(binding.Id);
            }
        }

        Assert.That(ids, Is.EqualTo(new[] { "first", "last" }));
        Assert.That(transport.Requests, Has.Count.EqualTo(2));
        for (int i = 0; i < transport.Requests.Count; i++)
        {
            MockPipelineRequest request = transport.Requests[i];
            Assert.Multiple(() =>
            {
                Assert.That(request.Uri.AbsolutePath, Does.EndWith(calls ? "/telephony/calls" : "/telephony/bindings"));
                Assert.That(Query(request.Uri, "provider"), Is.EqualTo("twilio"));
                Assert.That(Query(request.Uri, "limit"), Is.EqualTo("7"));
                Assert.That(Query(request.Uri, "order"), Is.EqualTo("asc"));
                Assert.That(Query(request.Uri, "after"), Is.EqualTo(i == 0 ? "initial" : "first"));
                Assert.That(Query(request.Uri, "before"), Is.Null);
                Assert.That(request.Headers.TryGetValue("Foundry-Features", out string features), Is.True);
                Assert.That(features, Does.Contain("VoiceAgents=V1Preview"));
                if (calls)
                {
                    Assert.That(Query(request.Uri, "status"), Is.EqualTo("success"));
                    Assert.That(Query(request.Uri, "started_after"), Is.EqualTo("1700000000"));
                    Assert.That(Query(request.Uri, "started_before"), Is.EqualTo("1700000100"));
                }
            });
        }
    }

    [Test]
    public async Task CallHistoryContinuesBackwardWithTheFirstCursor([Values(false, true)] bool isAsync)
    {
        var (client, transport, _) = CreateClient(isAsync,
            new MockPipelineResponse(200).WithContent($$"""{"data":[{{CallJson}}],"first_id":"backward-first","last_id":"forward-last","has_more":true}"""),
            new MockPipelineResponse(200).WithContent("""{"data":[],"last_id":"terminal","has_more":false}"""));
        if (isAsync)
        {
            await foreach (TelephonyCallSummary _ in client.GetTelephonyCallsAsync(
                "fake-agent", (TelephonyProvider?)null, before: "initial"))
            {
            }
        }
        else
        {
            _ = client.GetTelephonyCalls("fake-agent", (TelephonyProvider?)null, before: "initial").ToList();
        }
        Assert.That(transport.Requests, Has.Count.EqualTo(2));
        Assert.That(Query(transport.Requests[0].Uri, "before"), Is.EqualTo("initial"));
        Assert.That(Query(transport.Requests[1].Uri, "before"), Is.EqualTo("backward-first"));
        Assert.That(Query(transport.Requests[1].Uri, "after"), Is.Null);
    }

    [Test]
    public void CancellationReachesTypedAndProtocolRequests(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool protocol)
    {
        var (client, transport, _) = CreateClient(isAsync, 200, BindingJson);
        transport.OnSendingRequest = message => message.CancellationToken.ThrowIfCancellationRequested();
        using CancellationTokenSource cancellation = new();
        cancellation.Cancel();
        RequestOptions options = new() { CancellationToken = cancellation.Token };
        Assert.CatchAsync<OperationCanceledException>(async () =>
        {
            if (protocol)
            {
                await InvokeProtocolAsync(client, "UpdateTelephonyBinding", isAsync, options);
            }
            else
            {
                await InvokeTypedAsync(client, "GetTelephonyBinding", isAsync, cancellation.Token);
            }
        });
        Assert.That(transport.Requests, Is.Empty);
    }

    private static async Task<ClientResult> InvokeProtocolAsync(BetaVoiceAgentsTelephony client, string operation, bool isAsync, RequestOptions options)
    {
        string json = operation switch
        {
            "CreateTelephonyBinding" => BindingCreateJson,
            "UpdateTelephonyBinding" => PatchJson,
            "TransferTelephonyCall" => """{"target":"support"}""",
            "ReplaceTelephonyTransferTargets" => TargetsJson,
            "CreateTelephonyCallJob" => CallJobCreateJson,
            _ => "{}"
        };
        using BinaryContent content = BinaryContent.Create(BinaryData.FromString(json));
        return isAsync
            ? await (operation switch
            {
                "CreateTelephonyBinding" => client.CreateTelephonyBindingAsync("fake-agent", content, null, options),
                "GetTelephonyBinding" => client.GetTelephonyBindingAsync("fake-agent", "fake-binding", null, options),
                "UpdateTelephonyBinding" => client.UpdateTelephonyBindingAsync("fake-agent", "fake-binding", "\"binding-etag\"", content, options),
                "DeleteTelephonyBinding" => client.DeleteTelephonyBindingAsync("fake-agent", "fake-binding", "\"binding-etag\"", null, options),
                "GetTelephonyCall" => client.GetTelephonyCallAsync("fake-agent", "fake-call", null, options),
                "TransferTelephonyCall" => client.TransferTelephonyCallAsync("fake-agent", "fake-call", content, null, options),
                "EndTelephonyCall" => client.EndTelephonyCallAsync("fake-agent", "fake-call", null, options),
                "GetTelephonyTransferTargets" => client.GetTelephonyTransferTargetsAsync("fake-agent", null, options),
                "ReplaceTelephonyTransferTargets" => client.ReplaceTelephonyTransferTargetsAsync("fake-agent", "\"targets-etag\"", content, null, options),
                "CreateTelephonyCallJob" => client.CreateTelephonyCallJobAsync("fake-agent", "fake-idempotency-key", content, null, options),
                "GetTelephonyCallJob" => client.GetTelephonyCallJobAsync("fake-agent", "fake-call-job", null, options),
                "CancelTelephonyCallJob" => client.CancelTelephonyCallJobAsync("fake-agent", "fake-call-job", "\"job-etag\"", null, options),
                _ => throw new ArgumentOutOfRangeException(nameof(operation))
            })
            : operation switch
            {
                "CreateTelephonyBinding" => client.CreateTelephonyBinding("fake-agent", content, null, options),
                "GetTelephonyBinding" => client.GetTelephonyBinding("fake-agent", "fake-binding", null, options),
                "UpdateTelephonyBinding" => client.UpdateTelephonyBinding("fake-agent", "fake-binding", "\"binding-etag\"", content, options),
                "DeleteTelephonyBinding" => client.DeleteTelephonyBinding("fake-agent", "fake-binding", "\"binding-etag\"", null, options),
                "GetTelephonyCall" => client.GetTelephonyCall("fake-agent", "fake-call", null, options),
                "TransferTelephonyCall" => client.TransferTelephonyCall("fake-agent", "fake-call", content, null, options),
                "EndTelephonyCall" => client.EndTelephonyCall("fake-agent", "fake-call", null, options),
                "GetTelephonyTransferTargets" => client.GetTelephonyTransferTargets("fake-agent", null, options),
                "ReplaceTelephonyTransferTargets" => client.ReplaceTelephonyTransferTargets("fake-agent", "\"targets-etag\"", content, null, options),
                "CreateTelephonyCallJob" => client.CreateTelephonyCallJob("fake-agent", "fake-idempotency-key", content, null, options),
                "GetTelephonyCallJob" => client.GetTelephonyCallJob("fake-agent", "fake-call-job", null, options),
                "CancelTelephonyCallJob" => client.CancelTelephonyCallJob("fake-agent", "fake-call-job", "\"job-etag\"", null, options),
                _ => throw new ArgumentOutOfRangeException(nameof(operation))
            };
    }

    private static async Task<ClientResult> InvokeTypedAsync(BetaVoiceAgentsTelephony client, string operation, bool isAsync, CancellationToken cancellationToken)
    {
        TwilioTelephonyBinding binding = new("connection", "+15555550100") { Label = "support" };
        TelephonyCallJobCreate callJob = new(new PhoneNumber("+15555550101"), "connection", new PhoneNumber("+15555550100"));
        TelephonyTransferTarget[] targets = [new("support", "Customer support", new PhoneNumber("+15555550100"))];
        return operation switch
        {
            "CreateTelephonyBinding" => isAsync ? await client.CreateTelephonyBindingAsync("fake-agent", binding, cancellationToken) : client.CreateTelephonyBinding("fake-agent", binding, cancellationToken),
            "GetTelephonyBinding" => isAsync ? await client.GetTelephonyBindingAsync("fake-agent", "fake-binding", cancellationToken) : client.GetTelephonyBinding("fake-agent", "fake-binding", cancellationToken),
            "DeleteTelephonyBinding" => isAsync ? await client.DeleteTelephonyBindingAsync("fake-agent", "fake-binding", "\"binding-etag\"", cancellationToken) : client.DeleteTelephonyBinding("fake-agent", "fake-binding", "\"binding-etag\"", cancellationToken),
            "GetTelephonyCall" => isAsync ? await client.GetTelephonyCallAsync("fake-agent", "fake-call", cancellationToken) : client.GetTelephonyCall("fake-agent", "fake-call", cancellationToken),
            "TransferTelephonyCall" => isAsync ? await client.TransferTelephonyCallAsync("fake-agent", "fake-call", "support", cancellationToken) : client.TransferTelephonyCall("fake-agent", "fake-call", "support", cancellationToken),
            "EndTelephonyCall" => isAsync ? await client.EndTelephonyCallAsync("fake-agent", "fake-call", cancellationToken) : client.EndTelephonyCall("fake-agent", "fake-call", cancellationToken),
            "GetTelephonyTransferTargets" => isAsync ? await client.GetTelephonyTransferTargetsAsync("fake-agent", cancellationToken) : client.GetTelephonyTransferTargets("fake-agent", cancellationToken),
            "ReplaceTelephonyTransferTargets" => isAsync ? await client.ReplaceTelephonyTransferTargetsAsync("fake-agent", "\"targets-etag\"", targets, cancellationToken) : client.ReplaceTelephonyTransferTargets("fake-agent", "\"targets-etag\"", targets, cancellationToken),
            "CreateTelephonyCallJob" => isAsync ? await client.CreateTelephonyCallJobAsync("fake-agent", "fake-idempotency-key", callJob, cancellationToken) : client.CreateTelephonyCallJob("fake-agent", "fake-idempotency-key", callJob, cancellationToken),
            "GetTelephonyCallJob" => isAsync ? await client.GetTelephonyCallJobAsync("fake-agent", "fake-call-job", cancellationToken) : client.GetTelephonyCallJob("fake-agent", "fake-call-job", cancellationToken),
            "CancelTelephonyCallJob" => isAsync ? await client.CancelTelephonyCallJobAsync("fake-agent", "fake-call-job", "\"job-etag\"", cancellationToken) : client.CancelTelephonyCallJob("fake-agent", "fake-call-job", "\"job-etag\"", cancellationToken),
            _ => throw new ArgumentOutOfRangeException(nameof(operation))
        };
    }

    private static void AssertTypedResponse(ClientResult result)
    {
        switch (result)
        {
            case ClientResult<TelephonyBinding> binding:
                Assert.That(binding.Value, Is.TypeOf<TwilioTelephonyBinding>());
                Assert.That(binding.Value.Id, Is.EqualTo("fake-binding"));
                Assert.That(binding.Value.IncomingCallUrl.AbsoluteUri, Is.EqualTo("https://example.com/incoming"));
                break;
            case ClientResult<TelephonyCallRecord> call:
                Assert.That(call.Value.Id, Is.EqualTo("fake-call"));
                Assert.That(call.Value.Status, Is.EqualTo(TelephonyCallStatus.Success));
                break;
            case ClientResult<TelephonyTransferTargets> targets:
                Assert.That(targets.Value.TransferTargets, Has.Count.EqualTo(1));
                Assert.That(targets.Value.TransferTargets[0].Name, Is.EqualTo("support"));
                Assert.That(targets.Value.TransferTargets[0].Destination, Is.TypeOf<PhoneNumber>());
                break;
            case ClientResult<TelephonyCallJob> callJob:
                Assert.That(callJob.Value.Id, Is.EqualTo("fake-call-job"));
                Assert.That(callJob.Value.Revision, Is.EqualTo(1));
                Assert.That(callJob.Value.Destination, Is.TypeOf<PhoneNumber>());
                Assert.That(callJob.Value.Source.Value, Is.EqualTo("+15555550100"));
                break;
            default:
                Assert.That(result.GetRawResponse().Status, Is.EqualTo(204));
                break;
        }
    }

    private static string Query(Uri uri, string name)
        => uri.Query.TrimStart('?').Split('&').Select(value => value.Split(new[] { '=' }, 2))
            .Where(value => value.Length == 2 && Uri.UnescapeDataString(value[0]) == name)
            .Select(value => Uri.UnescapeDataString(value[1])).SingleOrDefault();

    private sealed class FakeTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
            => new(properties);

        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
            => new("fake-token", "Bearer", DateTimeOffset.UtcNow.AddHours(1), null);

        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
            => new(GetToken(options, cancellationToken));
    }
}

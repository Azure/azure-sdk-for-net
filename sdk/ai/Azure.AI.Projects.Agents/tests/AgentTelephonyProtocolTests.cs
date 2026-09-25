// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents._Beta.VoiceAgents;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001
namespace Azure.AI.Projects.Agents.Tests;

/// <summary>
/// Mocked protocol-level tests for the <see cref="BetaVoiceAgentsTelephony"/> REST surface: verify
/// each method builds the expected HTTP method and URL path, using a
/// <see cref="MockPipelineTransport"/> that captures the outgoing request and returns a canned
/// response -- no live or recorded service dependency.
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

    private static BinaryContent FakeJsonContent => BinaryContent.Create(BinaryData.FromString("{}"));

    private static (BetaVoiceAgentsTelephony Client, MockPipelineTransport Transport) CreateClient()
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200).WithContent("{}")) { ExpectSyncPipeline = false };
        AgentAdministrationClientOptions options = new() { Transport = transport };
        AgentAdministrationClient agentsClient = new(new Uri(FakeEndpoint), new FakeTokenProvider(), options);
        return (agentsClient.GetBetaVoiceAgentTelephony(), transport);
    }

    private static readonly (string Name, Func<BetaVoiceAgentsTelephony, Task<ClientResult>> Invoke, string ExpectedMethod, string ExpectedPathSuffix, string ExpectedIfMatch, string ExpectedContentType)[] s_cases = new (string, Func<BetaVoiceAgentsTelephony, Task<ClientResult>>, string, string, string, string)[]
    {
        ("CreateTelephonyBinding", c => c.CreateTelephonyBindingAsync("fake-agent", FakeJsonContent, foundryFeatures: null, options: new RequestOptions()), "POST", "/agents/fake-agent/telephony/bindings", null, null),
        ("GetTelephonyBinding", c => c.GetTelephonyBindingAsync("fake-agent", "fake-binding", null, new RequestOptions()), "GET", "/agents/fake-agent/telephony/bindings/fake-binding", null, null),
        ("UpdateTelephonyBinding", c => c.UpdateTelephonyBindingAsync("fake-agent", "fake-binding", "*", FakeJsonContent, foundryFeatures: null, options: new RequestOptions()), "PATCH", "/agents/fake-agent/telephony/bindings/fake-binding", "*", "application/merge-patch+json"),
        ("DeleteTelephonyBinding", c => c.DeleteTelephonyBindingAsync("fake-agent", "fake-binding", "*", null, new RequestOptions()), "DELETE", "/agents/fake-agent/telephony/bindings/fake-binding", "*", null),
        ("GetTelephonyCall", c => c.GetTelephonyCallAsync("fake-agent", "fake-call", null, new RequestOptions()), "GET", "/agents/fake-agent/telephony/calls/fake-call", null, null),
        ("TransferTelephonyCall", c => c.TransferTelephonyCallAsync("fake-agent", "fake-call", FakeJsonContent, foundryFeatures: null, options: new RequestOptions()), "POST", "/agents/fake-agent/telephony/calls/fake-call:transfer", null, null),
        ("EndTelephonyCall", c => c.EndTelephonyCallAsync("fake-agent", "fake-call", null, new RequestOptions()), "POST", "/agents/fake-agent/telephony/calls/fake-call:end", null, null),
        ("GetTelephonyTransferTargets", c => c.GetTelephonyTransferTargetsAsync("fake-agent", null, new RequestOptions()), "GET", "/agents/fake-agent/telephony/transfer_targets", null, null),
        ("ReplaceTelephonyTransferTargets", c => c.ReplaceTelephonyTransferTargetsAsync("fake-agent", "*", FakeJsonContent, foundryFeatures: null, options: new RequestOptions()), "PUT", "/agents/fake-agent/telephony/transfer_targets", "*", null),
        ("CreateTelephonyCallJob", c => c.CreateTelephonyCallJobAsync("fake-agent", "fake-idempotency-key", FakeJsonContent, foundryFeatures: null, options: new RequestOptions()), "POST", "/agents/fake-agent/telephony/call_jobs", null, null),
        ("GetTelephonyCallJob", c => c.GetTelephonyCallJobAsync("fake-agent", "fake-call-job", null, new RequestOptions()), "GET", "/agents/fake-agent/telephony/call_jobs/fake-call-job", null, null),
        ("CancelTelephonyCallJob", c => c.CancelTelephonyCallJobAsync("fake-agent", "fake-call-job", "*", null, new RequestOptions()), "POST", "/agents/fake-agent/telephony/call_jobs/fake-call-job:cancel", "*", null),
    };

    private static IEnumerable<TestCaseData> Cases()
    {
        foreach ((string name, Func<BetaVoiceAgentsTelephony, Task<ClientResult>> invoke, string expectedMethod, string expectedPathSuffix, string expectedIfMatch, string expectedContentType) in s_cases)
        {
            yield return new TestCaseData(invoke, expectedMethod, expectedPathSuffix, expectedIfMatch, expectedContentType).SetName($"TelephonyRequestProtocol_{name}");
        }
    }

    [TestCaseSource(nameof(Cases))]
    public async Task TelephonyMethodBuildsExpectedRequest(
        Func<BetaVoiceAgentsTelephony, Task<ClientResult>> invoke,
        string expectedMethod,
        string expectedPathSuffix,
        string expectedIfMatch,
        string expectedContentType)
    {
        (BetaVoiceAgentsTelephony client, MockPipelineTransport transport) = CreateClient();

        try
        {
            await invoke(client);
        }
        catch (ClientResultException)
        {
            // Only the request the mock transport captured (asserted below) matters for this test;
            // the canned 200 response doesn't match every operation's expected success status code
            // (some require 201/202/204), and the response body is never a real, valid payload.
        }

        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        MockPipelineRequest request = transport.Requests[0];
        Assert.Multiple(() =>
        {
            Assert.That(request.Method, Is.EqualTo(expectedMethod));
            Assert.That(request.Uri.AbsolutePath, Does.EndWith(expectedPathSuffix));
            Assert.That(request.Headers.TryGetValue("Foundry-Features", out string foundryFeatures), Is.True);
            Assert.That(foundryFeatures, Does.Contain("VoiceAgents=V1Preview"));

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
    }

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

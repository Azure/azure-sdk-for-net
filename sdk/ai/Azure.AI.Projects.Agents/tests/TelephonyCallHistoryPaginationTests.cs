// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests;

public class TelephonyCallHistoryPaginationTests
{
    [Test]
    public async Task HistoryHonorsDirectionFiltersAndTerminalPages(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool backward)
    {
        string[] responses =
        [
            """{"data":[{"id":"call-1","provider":"twilio","status":"success","phase":"completed","started_at":1700000000}],"first_id":"first/+?=","last_id":"last/+?=","has_more":true}""",
            """{"data":[{"id":"call-2","provider":"twilio","status":"success","phase":"completed","started_at":1700000001}],"first_id":"terminal-first","last_id":"terminal-last","has_more":false}"""
        ];
        int index = 0;
        MockPipelineTransport transport = new(_ =>
        {
            Assert.That(index, Is.LessThan(responses.Length), "A terminal page must not trigger another request.");
            return new MockPipelineResponse(200).WithContent(responses[index++]);
        })
        { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient administration = new(
            new Uri("https://example.services.ai.azure.com/api/projects/project"),
            new FakeTokenProvider(), new() { Transport = transport });
        BetaVoiceAgentsTelephony client = administration.GetBetaVoiceAgentTelephony();
        List<string> ids = [];
        if (isAsync)
        {
            await foreach (TelephonyCallSummary call in client.GetTelephonyCallsAsync(
                "agent", TelephonyProvider.Twilio, TelephonyCallStatus.Success,
                DateTimeOffset.FromUnixTimeSeconds(1700000000), DateTimeOffset.FromUnixTimeSeconds(1700000100),
                7, AgentListOrder.Ascending, backward ? null : "initial", backward ? "initial" : null))
            {
                ids.Add(call.Id);
            }
        }
        else
        {
            ids.AddRange(client.GetTelephonyCalls(
                "agent", TelephonyProvider.Twilio, TelephonyCallStatus.Success,
                DateTimeOffset.FromUnixTimeSeconds(1700000000), DateTimeOffset.FromUnixTimeSeconds(1700000100),
                7, AgentListOrder.Ascending, backward ? null : "initial", backward ? "initial" : null).Select(call => call.Id));
        }
        Assert.That(ids, Is.EqualTo(new[] { "call-1", "call-2" }));
        Assert.That(transport.Requests, Has.Count.EqualTo(2));
        for (int page = 0; page < transport.Requests.Count; page++)
        {
            MockPipelineRequest request = transport.Requests[page];
            Dictionary<string, string> query = request.Uri.Query.TrimStart('?').Split('&')
                .Select(pair => pair.Split(new[] { '=' }, 2))
                .ToDictionary(pair => Uri.UnescapeDataString(pair[0]), pair => Uri.UnescapeDataString(pair[1]));
            Assert.Multiple(() =>
            {
                Assert.That(request.Uri.AbsolutePath, Does.EndWith("/agents/agent/telephony/calls"));
                Assert.That(query["provider"], Is.EqualTo("twilio"));
                Assert.That(query["status"], Is.EqualTo("success"));
                Assert.That(query["limit"], Is.EqualTo("7"));
                Assert.That(query["order"], Is.EqualTo("asc"));
                Assert.That(query["started_after"], Is.EqualTo("1700000000"));
                Assert.That(query["started_before"], Is.EqualTo("1700000100"));
                Assert.That(query, Does.Not.ContainKey(backward ? "after" : "before"));
                Assert.That(query[backward ? "before" : "after"],
                    Is.EqualTo(page == 0 ? "initial" : backward ? "first/+?=" : "last/+?="));
            });
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

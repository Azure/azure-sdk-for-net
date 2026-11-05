// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests;

public class TelephonyCampaignPaginationTests
{
    private static readonly Uri Endpoint = new("https://example.services.ai.azure.com/api/projects/project");
    private const string InitialCursor = "initial/opaque+token=";
    private const string FirstCursor = "first/opaque+token=";
    private const string LastCursor = "last/opaque+token=";

    [Test]
    public void AdministrationAccessorCachesClientSharesPipelineAndIsExperimental()
    {
        MockPipelineTransport transport = new();
        AgentAdministrationClient administration = CreateAdministrationClient(transport);
        TelephonyCampaigns[] clients = new TelephonyCampaigns[32];
        Parallel.For(0, clients.Length, i => clients[i] = administration.GetBetaVoiceAgentTelephonyCampaigns());
        MethodInfo accessor = typeof(AgentAdministrationClient).GetMethod(nameof(AgentAdministrationClient.GetBetaVoiceAgentTelephonyCampaigns));

        Assert.Multiple(() =>
        {
            Assert.That(clients.All(client => ReferenceEquals(client, clients[0])), Is.True);
            Assert.That(clients[0].Pipeline, Is.SameAs(administration.Pipeline));
            Assert.That(accessor.IsPublic, Is.True);
            Assert.That(accessor.GetCustomAttribute<ExperimentalAttribute>()?.DiagnosticId, Is.EqualTo("AAIP001"));
            Assert.That(typeof(TelephonyCampaigns).IsPublic, Is.True);
            Assert.That(typeof(TelephonyCampaigns).GetCustomAttribute<ExperimentalAttribute>()?.DiagnosticId, Is.EqualTo("AAIP001"));
            Assert.That(transport.Requests, Is.Empty, "Obtaining a cached subclient must not send a request.");
        });
    }

    [Test]
    public async Task PagingPreservesDirectionFiltersOptionsAndRawPages(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool protocol,
        [Values(false, true)] bool errors,
        [Values(false, true)] bool backward,
        [Values(false, true)] bool hasMore)
    {
        string[] responses = hasMore
            ? [Page(errors, 1, true), Page(errors, 2, false)]
            : [Page(errors, 1, false)];
        (TelephonyCampaigns client, MockPipelineTransport transport) = CreateClient(isAsync, responses);
        using CancellationTokenSource cancellation = new();
        RequestOptions options = new() { CancellationToken = cancellation.Token };
        options.SetHeader("x-pagination-test", "retained");
        transport.OnSendingRequest = message => Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
        List<ClientResult> pages = [];
        ContinuationToken firstToken;
        ContinuationToken lastToken;

        if (isAsync)
        {
            AsyncCollectionResult collection = CreateAsyncCollection(client, protocol, errors, backward, options);
            await foreach (ClientResult page in collection.GetRawPagesAsync())
            {
                pages.Add(page);
            }
            firstToken = collection.GetContinuationToken(pages[0]);
            lastToken = collection.GetContinuationToken(pages[pages.Count - 1]);
        }
        else
        {
            CollectionResult collection = CreateCollection(client, protocol, errors, backward, options);
            pages.AddRange(collection.GetRawPages());
            firstToken = collection.GetContinuationToken(pages[0]);
            lastToken = collection.GetContinuationToken(pages[pages.Count - 1]);
        }

        Assert.Multiple(() =>
        {
            Assert.That(pages, Has.Count.EqualTo(responses.Length));
            Assert.That(transport.Requests, Has.Count.EqualTo(responses.Length));
            Assert.That(firstToken?.ToBytes().ToString(), Is.EqualTo(hasMore ? backward ? FirstCursor : LastCursor : null));
            Assert.That(lastToken, Is.Null, "has_more=false terminates paging even when both boundary IDs are retained.");
        });
        for (int i = 0; i < pages.Count; i++)
        {
            MockPipelineRequest request = transport.Requests[i];
            Dictionary<string, string> query = request.Uri.Query.TrimStart('?').Split('&')
                .Select(component => component.Split(new[] { '=' }, 2))
                .ToDictionary(parts => Uri.UnescapeDataString(parts[0]), parts => Uri.UnescapeDataString(parts[1]));
            PipelineResponse response = pages[i].GetRawResponse();
            Assert.Multiple(() =>
            {
                Assert.That(request.Method, Is.EqualTo("GET"));
                Assert.That(request.Uri.GetLeftPart(UriPartial.Authority), Is.EqualTo(Endpoint.GetLeftPart(UriPartial.Authority)));
                Assert.That(request.Uri.AbsolutePath, Is.EqualTo(Endpoint.AbsolutePath + "/agents/agent/telephony_campaigns" + (errors ? "/campaign/validation_errors" : "")));
                Assert.That(query["limit"], Is.EqualTo("7"));
                Assert.That(query["order"], Is.EqualTo("asc"));
                Assert.That(query["api-version"], Is.EqualTo("v1"));
                Assert.That(query, Does.Not.ContainKey(backward ? "after" : "before"));
                Assert.That(query[backward ? "before" : "after"], Is.EqualTo(i == 0 ? InitialCursor : backward ? FirstCursor : LastCursor));
                if (!errors)
                {
                    Assert.That(query["status"], Is.EqualTo("running"));
                }
                if (protocol)
                {
                    Assert.That(request.Headers.TryGetValue("x-pagination-test", out string header), Is.True);
                    Assert.That(header, Is.EqualTo("retained"));
                }
                Assert.That(response.Status, Is.EqualTo(200));
                Assert.That(response.Content.ToString(), Is.EqualTo(responses[i]));
                Assert.That(response.Headers.TryGetValue("x-pagination-page", out string pageHeader), Is.True);
                Assert.That(pageHeader, Is.EqualTo(i.ToString(CultureInfo.InvariantCulture)));
            });
        }
    }

    [Test]
    public async Task PagingPropagatesCallerCancellation(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool protocol,
        [Values(false, true)] bool errors)
    {
        (TelephonyCampaigns client, MockPipelineTransport transport) = CreateClient(isAsync, Page(errors, 1, false));
        using CancellationTokenSource cancellation = new();
        RequestOptions options = new() { CancellationToken = cancellation.Token };
        bool cancellationObserved = false;
        transport.OnSendingRequest = message =>
        {
            cancellation.Cancel();
            cancellationObserved = message.CancellationToken.IsCancellationRequested;
            message.CancellationToken.ThrowIfCancellationRequested();
        };
        if (isAsync)
        {
            AsyncCollectionResult collection = CreateAsyncCollection(client, protocol, errors, false, options);
            await using IAsyncEnumerator<ClientResult> enumerator = collection.GetRawPagesAsync().GetAsyncEnumerator();
            Assert.CatchAsync<OperationCanceledException>(async () => { await enumerator.MoveNextAsync(); });
        }
        else
        {
            CollectionResult collection = CreateCollection(client, protocol, errors, false, options);
            using IEnumerator<ClientResult> enumerator = collection.GetRawPages().GetEnumerator();
            Assert.Catch<OperationCanceledException>(() => enumerator.MoveNext());
        }
        Assert.That(cancellationObserved, Is.True, "The pipeline's linked token must reflect cancellation by the caller.");
    }

    [Test]
    public async Task NonterminalPageRequiresTheCursorForItsDirection(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool protocol,
        [Values(false, true)] bool errors,
        [Values(false, true)] bool backward,
        [Values(null, "")] string missingCursor)
    {
        (TelephonyCampaigns client, MockPipelineTransport transport) = CreateClient(isAsync,
            Page(errors, 1, true, backward ? missingCursor : FirstCursor, backward ? LastCursor : missingCursor));
        RequestOptions options = new();
        JsonException tokenException;
        JsonException enumerationException;
        if (isAsync)
        {
            AsyncCollectionResult collection = CreateAsyncCollection(client, protocol, errors, backward, options);
            await using IAsyncEnumerator<ClientResult> enumerator = collection.GetRawPagesAsync().GetAsyncEnumerator();
            Assert.That(await enumerator.MoveNextAsync(), Is.True, "The raw response must remain accessible.");
            tokenException = Assert.Throws<JsonException>(() => collection.GetContinuationToken(enumerator.Current));
            enumerationException = Assert.ThrowsAsync<JsonException>(async () => { await enumerator.MoveNextAsync(); });
        }
        else
        {
            CollectionResult collection = CreateCollection(client, protocol, errors, backward, options);
            using IEnumerator<ClientResult> enumerator = collection.GetRawPages().GetEnumerator();
            Assert.That(enumerator.MoveNext(), Is.True, "The raw response must remain accessible.");
            tokenException = Assert.Throws<JsonException>(() => collection.GetContinuationToken(enumerator.Current));
            enumerationException = Assert.Throws<JsonException>(() => enumerator.MoveNext());
        }
        Assert.Multiple(() =>
        {
            Assert.That(tokenException.Message, Does.Contain(backward ? "first_id" : "last_id"));
            Assert.That(enumerationException.Message, Is.EqualTo(tokenException.Message));
            Assert.That(transport.Requests, Has.Count.EqualTo(1), "An invalid page must fail before another request.");
        });
    }

    [Test]
    public async Task TypedEnumerationReturnsBothPagesAndStops(
        [Values(false, true)] bool isAsync,
        [Values(false, true)] bool errors,
        [Values(false, true)] bool backward)
    {
        (TelephonyCampaigns client, MockPipelineTransport transport) = CreateClient(isAsync,
            Page(errors, 1, true), Page(errors, 2, false));
        string after = backward ? null : InitialCursor;
        string before = backward ? InitialCursor : null;
        List<string> values = [];
        if (errors)
        {
            if (isAsync)
            {
                await foreach (TelephonyCampaignValidationError error in client.GetValidationErrorsAsync("agent", "campaign", after: after, before: before))
                {
                    values.Add(error.RowNumber.ToString(CultureInfo.InvariantCulture));
                }
            }
            else
            {
                values.AddRange(client.GetValidationErrors("agent", "campaign", after: after, before: before)
                    .Select(error => error.RowNumber.ToString(CultureInfo.InvariantCulture)));
            }
        }
        else if (isAsync)
        {
            await foreach (TelephonyCampaign campaign in client.GetAllAsync("agent", after: after, before: before))
            {
                values.Add(campaign.Name);
            }
        }
        else
        {
            values.AddRange(client.GetAll("agent", after: after, before: before).Select(campaign => campaign.Name));
        }
        Assert.Multiple(() =>
        {
            Assert.That(values, Is.EqualTo(errors ? new[] { "1", "2" } : new[] { "campaign_1", "campaign_2" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
        });
    }

    private static CollectionResult CreateCollection(TelephonyCampaigns client, bool protocol, bool errors, bool backward, RequestOptions options)
    {
        string after = backward ? null : InitialCursor;
        string before = backward ? InitialCursor : null;
        return errors
            ? protocol
                ? client.GetValidationErrors("agent", "campaign", 7, after, before, "asc", options)
                : client.GetValidationErrors("agent", "campaign", 7, after, before, AgentListOrder.Ascending, options.CancellationToken)
            : protocol
                ? client.GetAll("agent", 7, "asc", after, before, "running", options)
                : client.GetAll("agent", 7, AgentListOrder.Ascending, after, before, TelephonyCampaignStatus.Running, options.CancellationToken);
    }

    private static AsyncCollectionResult CreateAsyncCollection(TelephonyCampaigns client, bool protocol, bool errors, bool backward, RequestOptions options)
    {
        string after = backward ? null : InitialCursor;
        string before = backward ? InitialCursor : null;
        return errors
            ? protocol
                ? client.GetValidationErrorsAsync("agent", "campaign", 7, after, before, "asc", options)
                : client.GetValidationErrorsAsync("agent", "campaign", 7, after, before, AgentListOrder.Ascending, options.CancellationToken)
            : protocol
                ? client.GetAllAsync("agent", 7, "asc", after, before, "running", options)
                : client.GetAllAsync("agent", 7, AgentListOrder.Ascending, after, before, TelephonyCampaignStatus.Running, options.CancellationToken);
    }

    private static string Page(bool errors, int number, bool hasMore, string firstId = FirstCursor, string lastId = LastCursor)
    {
        string data = errors
            ? $$$"""{"row_number":{{{number}}},"error":{"code":"InvalidRecipient","message":"Recipient failed validation."}}"""
            : $$"""
                {
                  "name":"campaign_{{number}}",
                  "connection_name":"connection",
                  "source":{"type":"phone_number","value":"+15555550100"},
                  "status":"running",
                  "created_at":1700000000,
                  "updated_at":1700000000,
                  "etag":"campaign-etag"
                }
                """;
        string first = firstId == null ? "" : $"\"first_id\":{JsonSerializer.Serialize(firstId)},";
        string last = lastId == null ? "" : $"\"last_id\":{JsonSerializer.Serialize(lastId)},";
        return $$"""{"data":[{{data}}],{{first}}{{last}}"has_more":{{hasMore.ToString().ToLowerInvariant()}}}""";
    }

    private static (TelephonyCampaigns Client, MockPipelineTransport Transport) CreateClient(bool isAsync, params string[] responses)
    {
        int index = 0;
        MockPipelineTransport transport = new(_ =>
        {
            int responseIndex = Interlocked.Increment(ref index) - 1;
            Assert.That(responseIndex, Is.LessThan(responses.Length), "The client requested an unexpected extra page.");
            return new MockPipelineResponse(200)
                .WithHeader("x-pagination-page", responseIndex.ToString(CultureInfo.InvariantCulture))
                .WithContent(responses[responseIndex]);
        })
        {
            ExpectSyncPipeline = !isAsync
        };
        AgentAdministrationClient administration = CreateAdministrationClient(transport);
        return (administration.GetBetaVoiceAgentTelephonyCampaigns(), transport);
    }

    private static AgentAdministrationClient CreateAdministrationClient(MockPipelineTransport transport)
        => new(Endpoint, new FakeTokenProvider(),
            new AgentAdministrationClientOptions(AgentAdministrationClientOptions.ServiceVersion.V1) { Transport = transport });

    private sealed class FakeTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);
        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
            => new("fake-token", "Bearer", DateTimeOffset.UtcNow.AddHours(1), null);
        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
            => new(GetToken(options, cancellationToken));
    }
}

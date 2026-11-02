// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests;

public class VoiceTelephonyContractCompatibilityTests
{
    private const string Endpoint = "https://fake-account.services.ai.azure.com/api/projects/fake-project";
    private const string AgentName = "fake-agent";
    private const string ConnectionName = "fake-connection";
    private const string ResourceAccountId = "00000000-0000-0000-0000-000000000001";
    private const string DestinationNumber = "+15555550101";
    private const string SourceNumber = "+15555550102";
    private const string BindingPage = """
        {"object":"list","data":[{"id":"binding_1","provider":"twilio",
        "connection_name":"fake-connection","phone_number":"+15555550101",
        "incoming_call_url":"https://fake.example/incoming","etag":"etag_1"}],
        "first_id":"binding_1","last_id":"binding_1","has_more":true}
        """;
    private const string LastBindingPage = """
        {"object":"list","data":[{"id":"binding_2","provider":"twilio",
        "connection_name":"fake-connection","phone_number":"+15555550101",
        "incoming_call_url":"https://fake.example/incoming","etag":"etag_2"}],
        "first_id":"binding_2","last_id":"binding_2","has_more":false}
        """;

    [TestCase("twilio", false)]
    [TestCase("twilio", true)]
    [TestCase("teams_phone_extensibility", false)]
    [TestCase("teams_phone_extensibility", true)]
    [TestCase("sip", false)]
    [TestCase("sip", true)]
    public async Task CreateBindingUsesConsolidatedProviderModel(string provider, bool isAsync)
    {
        TelephonyBinding binding = provider switch
        {
            "twilio" => new TwilioTelephonyBinding(ConnectionName, DestinationNumber),
            "teams_phone_extensibility" => new TeamsPhoneExtensibilityTelephonyBinding(ConnectionName, ResourceAccountId),
            "sip" => new SipTelephonyBinding(ConnectionName) { PhoneNumber = "support" },
            _ => throw new ArgumentOutOfRangeException(nameof(provider))
        };
        binding.Label = "test binding";
        Dictionary<string, object> expected = new()
        {
            ["provider"] = provider,
            ["connection_name"] = ConnectionName,
            ["label"] = binding.Label
        };
        if (binding is TwilioTelephonyBinding)
        {
            expected["phone_number"] = DestinationNumber;
        }
        else if (binding is TeamsPhoneExtensibilityTelephonyBinding)
        {
            expected["resource_account_object_id"] = ResourceAccountId;
        }
        else if (binding is SipTelephonyBinding sip)
        {
            sip.AllowedCallingNumbers.Add(SourceNumber);
            expected["phone_number"] = "support";
            expected["allowed_calling_numbers"] = new[] { SourceNumber };
        }
        Dictionary<string, object> response = new(expected)
        {
            ["id"] = "binding_1",
            ["incoming_call_url"] = provider == "sip" ? "sips:agent@fake.example" : "https://fake.example/incoming"
        };
        (BetaVoiceAgentsTelephony client, MockPipelineTransport transport) = CreateClient(
            isAsync, _ => new MockPipelineResponse(201).WithContent(BinaryData.FromObjectAsJson(response).ToString()));

        ClientResult<TelephonyBinding> result = isAsync
            ? await client.CreateTelephonyBindingAsync(AgentName, binding, CancellationToken.None)
            : client.CreateTelephonyBinding(AgentName, binding, CancellationToken.None);

        Assert.That(result.Value.Id, Is.EqualTo("binding_1"));
        Assert.That(result.Value, Is.TypeOf(binding.GetType()));
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        MockPipelineRequest request = transport.Requests[0];
        AssertCreateRequest(request, "/telephony/bindings");
        using JsonDocument actualBody = ReadRequestBody(request);
        using JsonDocument expectedBody = JsonDocument.Parse(BinaryData.FromObjectAsJson(expected));
        Assert.Multiple(() =>
        {
            Assert.That(actualBody.RootElement.EnumerateObject().Select(p => p.Name),
                Is.EquivalentTo(expected.Keys));
            foreach (JsonProperty property in expectedBody.RootElement.EnumerateObject())
            {
                Assert.That(JsonNode.DeepEquals(
                    JsonNode.Parse(actualBody.RootElement.GetProperty(property.Name).GetRawText()),
                    JsonNode.Parse(property.Value.GetRawText())), Is.True, property.Name);
            }
        });
    }

    [TestCase("phone_number", false)]
    [TestCase("phone_number", true)]
    [TestCase("teams", false)]
    [TestCase("teams", true)]
    public async Task CreateCallJobUsesTypedSourceAndDestination(string sourceType, bool isAsync)
    {
        TelephonyAddress source = sourceType == "teams"
            ? new TeamsAddress(ResourceAccountId)
            : new PhoneNumber(SourceNumber);
        TelephonyCallJob job = new(new PhoneNumber(DestinationNumber), ConnectionName, source)
        {
            Purpose = "test call"
        };
        job.StructuredInputs["profile"] = BinaryData.FromString("""{"customer":"test"}""");
        job.StructuredInputs["tags"] = BinaryData.FromString("""["first","second"]""");
        job.StructuredInputs["optional"] = null;
        string response = BinaryData.FromObjectAsJson(new
        {
            id = "job_1",
            agent_name = AgentName,
            destination = new { type = "phone_number", value = DestinationNumber },
            connection_name = ConnectionName,
            source = new { type = sourceType, value = source.Value },
            status = "queued",
            attempt_count = 0,
            revision = 1,
            created_at = 1700000000,
            updated_at = 1700000000
        }).ToString();
        (BetaVoiceAgentsTelephony client, MockPipelineTransport transport) = CreateClient(
            isAsync, _ => new MockPipelineResponse(202).WithContent(response));

        ClientResult<TelephonyCallJob> result = isAsync
            ? await client.CreateTelephonyCallJobAsync(AgentName, "fake-idempotency-key", job, CancellationToken.None)
            : client.CreateTelephonyCallJob(AgentName, "fake-idempotency-key", job, CancellationToken.None);

        Assert.That(result.Value.Id, Is.EqualTo("job_1"));
        Assert.That(result.Value.Source, Is.TypeOf(source.GetType()));
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        MockPipelineRequest request = transport.Requests[0];
        AssertCreateRequest(request, "/telephony/call_jobs");
        using JsonDocument body = ReadRequestBody(request);
        JsonElement root = body.RootElement;
        Assert.Multiple(() =>
        {
            Assert.That(request.Headers.TryGetValue("Idempotency-Key", out string idempotencyKey), Is.True);
            Assert.That(idempotencyKey, Is.EqualTo("fake-idempotency-key"));
            Assert.That(root.EnumerateObject().Select(p => p.Name),
                Is.EquivalentTo(new[] { "destination", "connection_name", "source", "purpose", "structured_inputs" }));
            Assert.That(root.GetProperty("connection_name").GetString(), Is.EqualTo(ConnectionName));
            Assert.That(root.GetProperty("destination").GetProperty("type").GetString(), Is.EqualTo("phone_number"));
            Assert.That(root.GetProperty("destination").GetProperty("value").GetString(), Is.EqualTo(DestinationNumber));
            Assert.That(root.GetProperty("source").GetProperty("type").GetString(), Is.EqualTo(sourceType));
            Assert.That(root.GetProperty("source").GetProperty("value").GetString(), Is.EqualTo(source.Value));
            Assert.That(root.GetProperty("purpose").GetString(), Is.EqualTo("test call"));
            JsonElement inputs = root.GetProperty("structured_inputs");
            Assert.That(inputs.GetProperty("profile").GetProperty("customer").GetString(), Is.EqualTo("test"));
            Assert.That(inputs.GetProperty("tags").EnumerateArray().Select(v => v.GetString()),
                Is.EqualTo(new[] { "first", "second" }));
            Assert.That(inputs.GetProperty("optional").ValueKind, Is.EqualTo(JsonValueKind.Null));
        });
    }

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public async Task BindingListPreservesSupportedFiltersAndHonorsHasMore(bool isAsync, bool filterProvider)
    {
        int requestCount = 0;
        (BetaVoiceAgentsTelephony client, MockPipelineTransport transport) = CreateClient(isAsync, _ =>
            (++requestCount) switch
            {
                1 => new MockPipelineResponse(200).WithContent(BindingPage),
                2 => new MockPipelineResponse(200).WithContent(LastBindingPage),
                _ => throw new InvalidOperationException("The terminal page must not trigger another request.")
            });
        TelephonyProvider? provider = filterProvider ? TelephonyProvider.Twilio : (TelephonyProvider?)null;
        AgentListOrder order = new("asc");
        List<TelephonyBindingListItem> bindings = new();
        if (isAsync)
        {
            await foreach (TelephonyBindingListItem binding in client.GetTelephonyBindingsAsync(
                AgentName, provider, 2, order, "cursor/initial", "cursor+end", CancellationToken.None))
            {
                bindings.Add(binding);
            }
        }
        else
        {
            bindings.AddRange(client.GetTelephonyBindings(
                AgentName, provider, 2, order, "cursor/initial", "cursor+end", CancellationToken.None));
        }

        Assert.That(bindings.Select(b => b.Id), Is.EqualTo(new[] { "binding_1", "binding_2" }));
        Assert.That(bindings.Select(b => b.Etag), Is.EqualTo(new[] { "etag_1", "etag_2" }));
        Assert.That(transport.Requests, Has.Count.EqualTo(2));
        for (int index = 0; index < transport.Requests.Count; index++)
        {
            MockPipelineRequest request = transport.Requests[index];
            Dictionary<string, string> query = request.Uri.Query.TrimStart('?').Split('&')
                .Select(part => part.Split(new[] { '=' }, 2))
                .ToDictionary(parts => Uri.UnescapeDataString(parts[0]), parts => Uri.UnescapeDataString(parts[1]));
            List<string> expectedKeys = new() { "limit", "order", "after", "before", "api-version" };
            if (filterProvider)
            {
                expectedKeys.Add("provider");
            }
            Assert.Multiple(() =>
            {
                Assert.That(request.Method, Is.EqualTo("GET"));
                Assert.That(request.Uri.AbsolutePath, Does.EndWith($"/agents/{AgentName}/telephony/bindings"));
                Assert.That(query.Keys, Is.EquivalentTo(expectedKeys));
                Assert.That(query["limit"], Is.EqualTo("2"));
                Assert.That(query["order"], Is.EqualTo("asc"));
                Assert.That(query["after"], Is.EqualTo(index == 0 ? "cursor/initial" : "binding_1"));
                Assert.That(query["before"], Is.EqualTo("cursor+end"));
                if (filterProvider)
                {
                    Assert.That(query["provider"], Is.EqualTo("twilio"));
                }
            });
        }
    }

    [TestCase("binding", false)]
    [TestCase("binding", true)]
    [TestCase("call_job", false)]
    [TestCase("call_job", true)]
    [TestCase("list", false)]
    [TestCase("list", true)]
    public void ServiceErrorsAreNotConvertedToSuccessfulResults(string operation, bool isAsync)
    {
        (BetaVoiceAgentsTelephony client, MockPipelineTransport transport) = CreateClient(
            isAsync, _ => new MockPipelineResponse(400).WithContent(
                """{"error":{"code":"invalid_request","message":"The request is invalid.","type":"invalid_request_error"}}"""));

        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(async () =>
        {
            if (operation == "binding")
            {
                TelephonyBinding binding = new TwilioTelephonyBinding(ConnectionName, DestinationNumber);
                if (isAsync)
                {
                    await client.CreateTelephonyBindingAsync(AgentName, binding, CancellationToken.None);
                }
                else
                {
                    client.CreateTelephonyBinding(AgentName, binding, CancellationToken.None);
                }
            }
            else if (operation == "call_job")
            {
                TelephonyCallJob job = new(new PhoneNumber(DestinationNumber), ConnectionName, new PhoneNumber(SourceNumber));
                if (isAsync)
                {
                    await client.CreateTelephonyCallJobAsync(AgentName, "fake-idempotency-key", job, CancellationToken.None);
                }
                else
                {
                    client.CreateTelephonyCallJob(AgentName, "fake-idempotency-key", job, CancellationToken.None);
                }
            }
            else if (isAsync)
            {
                await foreach (TelephonyBindingListItem _ in client.GetTelephonyBindingsAsync(
                    AgentName, (TelephonyProvider?)null, cancellationToken: CancellationToken.None))
                {
                }
            }
            else
            {
                client.GetTelephonyBindings(AgentName, (TelephonyProvider?)null, cancellationToken: CancellationToken.None).ToList();
            }
        });

        Assert.That(exception.Status, Is.EqualTo(400));
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    [Test]
    public void PublicWrappersMatchCurrentModelsAndBindingFilters()
    {
        foreach (string suffix in new[] { "", "Async" })
        {
            AssertWrapper("CreateTelephonyBinding" + suffix,
                new[] { typeof(string), typeof(TelephonyBinding), typeof(CancellationToken) },
                new[] { "agentName", "binding", "cancellationToken" });
            AssertWrapper("CreateTelephonyCallJob" + suffix,
                new[] { typeof(string), typeof(string), typeof(TelephonyCallJob), typeof(CancellationToken) },
                new[] { "agentName", "idempotencyKey", "job", "cancellationToken" });
            AssertWrapper("GetTelephonyBindings" + suffix,
                new[] { typeof(string), typeof(TelephonyProvider?), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken) },
                new[] { "agentName", "provider", "limit", "order", "after", "before", "cancellationToken" });
        }
    }

    private static void AssertWrapper(string name, Type[] parameterTypes, string[] parameterNames)
    {
        MethodInfo[] methods = typeof(BetaVoiceAgentsTelephony)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(method => method.Name == name).ToArray();
        Assert.That(methods, Has.Length.EqualTo(1), name);
        ParameterInfo[] parameters = methods[0].GetParameters();
        Assert.That(parameters.Select(parameter => parameter.ParameterType), Is.EqualTo(parameterTypes), name);
        Assert.That(parameters.Select(parameter => parameter.Name), Is.EqualTo(parameterNames), name);
    }

    private static void AssertCreateRequest(MockPipelineRequest request, string pathSuffix)
    {
        Assert.That(request.Method, Is.EqualTo("POST"));
        Assert.That(request.Uri.AbsolutePath, Does.EndWith($"/agents/{AgentName}{pathSuffix}"));
        Assert.That(request.Headers.TryGetValue("Content-Type", out string contentType), Is.True);
        Assert.That(contentType, Is.EqualTo("application/json"));
    }

    private static JsonDocument ReadRequestBody(MockPipelineRequest request)
    {
        using MemoryStream stream = new();
        request.Content.WriteTo(stream, CancellationToken.None);
        return JsonDocument.Parse(stream.ToArray());
    }

    private static (BetaVoiceAgentsTelephony Client, MockPipelineTransport Transport) CreateClient(
        bool isAsync, Func<MockPipelineMessage, MockPipelineResponse> responseFactory)
    {
        MockPipelineTransport transport = new(responseFactory) { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClientOptions options = new() { Transport = transport };
        AgentAdministrationClient client = new(new Uri(Endpoint), new FakeTokenProvider(), options);
        return (client.GetBetaVoiceAgentTelephony(), transport);
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

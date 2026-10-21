// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentSafety.Tests
{
    public class PreviewOperationsTests
    {
        private static readonly Uri Endpoint = new("https://example.cognitiveservices.azure.com");
        private static readonly AzureKeyCredential Credential = new("fake-key");

        [TestCase(false)]
        [TestCase(true)]
        public async Task UnifiedModerateSerializesRequestAndDeserializesResult(bool isAsync)
        {
            using JsonDocument example = LoadModerationExample("UnifiedModerate_PostToolCall.json");
            JsonElement parameters = example.RootElement.GetProperty("parameters");
            JsonElement expectedBody = parameters.GetProperty("body");
            JsonElement expectedResult = example.RootElement.GetProperty("responses").GetProperty("200").GetProperty("body");
            var transport = new MockTransport(JsonResponse(200, expectedResult.GetRawText()));
            var client = new ContentSafetyClient(Endpoint, Credential, CreateOptions(transport, ContentSafetyClientOptions.ServiceVersion.V2026_10_15_Preview));
            var arguments = new AgentJsonObject();
            arguments.AdditionalProperties.Add("amount", BinaryData.FromObjectAsJson(100));
            arguments.AdditionalProperties.Add("currency", BinaryData.FromObjectAsJson("USD"));
            arguments.AdditionalProperties.Add("note", BinaryData.FromObjectAsJson("invoice"));
            var resultValue = BinaryData.FromString(expectedBody.GetProperty("target").GetRawText());
            var options = new AgentPostToolCallContext(
                expectedBody.GetProperty("timestamp").GetDateTimeOffset(),
                5,
                new AgentDefinition("support-agent", "agent-framework"),
                new AgentSession("example-session"),
                resultValue,
                new AgentToolCall("call-1", "payments.send", arguments),
                new AgentToolResult(resultValue, false)
                {
                    DurationMs = 25
                });

            Response<AgentEvaluationResult> response = isAsync
                ? await client.UnifiedModerateAsync(
                    options,
                    targetResourceId: parameters.GetProperty("targetResourceId").GetString(),
                    selectedPolicyId: parameters.GetProperty("selectedPolicyId").GetString(),
                    selectedPolicyRevision: parameters.GetProperty("selectedPolicyRevision").GetString(),
                    selectedPolicySemanticDigest: parameters.GetProperty("selectedPolicySemanticDigest").GetString())
                : client.UnifiedModerate(
                    options,
                    targetResourceId: parameters.GetProperty("targetResourceId").GetString(),
                    selectedPolicyId: parameters.GetProperty("selectedPolicyId").GetString(),
                    selectedPolicyRevision: parameters.GetProperty("selectedPolicyRevision").GetString(),
                    selectedPolicySemanticDigest: parameters.GetProperty("selectedPolicySemanticDigest").GetString());

            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Verdict, Is.TypeOf<AgentAllowVerdict>());
                Assert.That(response.Value.Verdict.Reason, Is.EqualTo("within_policy"));
                Assert.That(response.Value.Verdict.Warnings[0].Reason, Is.EqualTo("sensitive_financial_data"));
                Assert.That(response.Value.Receipt, Is.TypeOf<AgentFoundryProjectReceipt>());
                Assert.That(response.Value.Receipt.EvaluatedInterventionPoint, Is.EqualTo(AgentInterceptionPoint.PostToolCall));
                Assert.That(response.Value.Receipt.EvaluatedPolicyLayers[0].PolicyRevision, Is.EqualTo(parameters.GetProperty("selectedPolicyRevision").GetString()));
            });

            MockRequest request = transport.SingleRequest;
            AssertRequest(request, RequestMethod.Post, "/contentsafety/content:unifiedModerate", "2026-10-15-preview");
            AssertModerationSelectors(request, parameters);
            JsonElement body = RequestBody(request);
            Assert.Multiple(() =>
            {
                Assert.That(body.GetProperty("spec").GetString(), Is.EqualTo("agent-hooks/0.1"));
                Assert.That(body.GetProperty("interception_point").GetString(), Is.EqualTo("post_tool_call"));
                Assert.That(body.GetProperty("tool_call").GetProperty("args").GetProperty("amount").GetInt32(), Is.EqualTo(100));
                Assert.That(body.GetProperty("tool_result").GetProperty("is_error").GetBoolean(), Is.False);
                Assert.That(body.GetProperty("tool_result").GetProperty("duration_ms").GetDouble(), Is.EqualTo(25));
                Assert.That(JsonNode.DeepEquals(
                    JsonNode.Parse(body.GetProperty("target").GetRawText()),
                    JsonNode.Parse(body.GetProperty("tool_result").GetProperty("value").GetRawText())), Is.True);
                Assert.That(body.TryGetProperty("selectedPolicyId", out _), Is.False);
            });
        }

        public static IEnumerable<TestCaseData> ModerationExamples()
        {
            foreach (string file in Directory.EnumerateFiles(
                Path.Combine(TestContext.CurrentContext.TestDirectory, "AgentHooksExamples"), "UnifiedModerate*.json").OrderBy(file => Path.GetFileName(file), StringComparer.Ordinal))
            {
                yield return new TestCaseData(Path.GetFileName(file), false);
                yield return new TestCaseData(Path.GetFileName(file), true);
            }
        }

        [TestCaseSource(nameof(ModerationExamples))]
        public async Task UnifiedModeratePreservesAuthoritativeExamples(string fileName, bool isAsync)
        {
            using JsonDocument example = LoadModerationExample(fileName);
            JsonElement parameters = example.RootElement.GetProperty("parameters");
            JsonElement expectedBody = parameters.GetProperty("body");
            JsonElement expectedResult = example.RootElement.GetProperty("responses").GetProperty("200").GetProperty("body");
            JsonElement expectedReceipt = expectedResult.GetProperty("receipt");
            var transport = new MockTransport(JsonResponse(200, expectedResult.GetRawText()));
            var client = new ContentSafetyClient(Endpoint, Credential, CreateOptions(transport, ContentSafetyClientOptions.ServiceVersion.V2026_10_15_Preview));
            using RequestContent content = RequestContent.Create(BinaryData.FromString(expectedBody.GetRawText()));

            Response response = isAsync
                ? await client.UnifiedModerateAsync(
                    content, GetSelector(parameters, "targetResourceId"), GetSelector(parameters, "policyId"),
                    GetSelector(parameters, "selectedPolicyId"), GetSelector(parameters, "selectedPolicyRevision"),
                    GetSelector(parameters, "selectedPolicySemanticDigest"))
                : client.UnifiedModerate(
                    content, GetSelector(parameters, "targetResourceId"), GetSelector(parameters, "policyId"),
                    GetSelector(parameters, "selectedPolicyId"), GetSelector(parameters, "selectedPolicyRevision"),
                    GetSelector(parameters, "selectedPolicySemanticDigest"));

            var result = (AgentEvaluationResult)response;
            MockRequest request = transport.SingleRequest;
            AssertRequest(request, RequestMethod.Post, "/contentsafety/content:unifiedModerate", "2026-10-15-preview");
            AssertModerationSelectors(request, parameters);
            Assert.Multiple(() =>
            {
                Assert.That(RequestBody(request).GetRawText(), Is.EqualTo(expectedBody.GetRawText()));
                Assert.That(result.Receipt.ReceiptVersion, Is.EqualTo("2026-10-15-preview"));
                Assert.That(result.Receipt.RequestBinding.Digest, Is.EqualTo(expectedReceipt.GetProperty("requestBinding").GetProperty("digest").GetString()));
                Assert.That(result.Receipt.EvaluationId, Is.EqualTo(expectedReceipt.GetProperty("evaluationId").GetString()));
                Assert.That(result.Receipt.AuthenticatedProducerResourceId, Is.EqualTo(expectedReceipt.GetProperty("authenticatedProducerResourceId").GetString()));
                Assert.That(result.Receipt.EvaluatedPolicyLayers, Has.Count.EqualTo(expectedReceipt.GetProperty("evaluatedPolicyLayers").GetArrayLength()));
            });

            int index = 0;
            foreach (JsonElement layer in expectedReceipt.GetProperty("evaluatedPolicyLayers").EnumerateArray())
            {
                AgentEvaluatedPolicyLayer actual = result.Receipt.EvaluatedPolicyLayers[index++];
                Assert.Multiple(() =>
                {
                    Assert.That(actual.PolicyResourceId, Is.EqualTo(layer.GetProperty("policyResourceId").GetString()));
                    Assert.That(actual.PolicyRevision, Is.EqualTo(layer.GetProperty("policyRevision").GetString()));
                    Assert.That(actual.PolicySemanticDigest, Is.EqualTo(layer.GetProperty("policySemanticDigest").GetString()));
                    Assert.That(actual.ActivatedArtifactDigest, Is.EqualTo(layer.GetProperty("activatedArtifactDigest").GetString()));
                });
            }

            JsonElement expectedVerdict = expectedResult.GetProperty("verdict");
            switch (expectedVerdict.GetProperty("decision").GetString())
            {
                case "allow":
                    Assert.That(result.Verdict, Is.TypeOf<AgentAllowVerdict>());
                    break;
                case "deny":
                    Assert.That(result.Verdict, Is.TypeOf<AgentDenyVerdict>());
                    if (expectedVerdict.TryGetProperty("approval", out JsonElement approval))
                    {
                        Assert.That(((AgentDenyVerdict)result.Verdict).Approval, Is.Not.Null);
                        Assert.That(((AgentDenyVerdict)result.Verdict).Approval.AdditionalProperties.Keys, Is.EquivalentTo(approval.EnumerateObject().Select(property => property.Name)));
                    }
                    break;
                case "transform":
                    Assert.That(result.Verdict, Is.TypeOf<AgentTransformVerdict>());
                    var transform = ((AgentTransformVerdict)result.Verdict).Transform;
                    JsonElement expectedTransform = expectedVerdict.GetProperty("transform");
                    Assert.That(transform.Path, Is.EqualTo(expectedTransform.GetProperty("path").GetString()));
                    JsonNode expectedValue = expectedTransform.TryGetProperty("value", out JsonElement value)
                        ? JsonNode.Parse(value.GetRawText())
                        : null;
                    Assert.That(JsonNode.DeepEquals(
                        transform.Value == null ? null : JsonNode.Parse(transform.Value.ToString()), expectedValue), Is.True);
                    break;
                default:
                    Assert.Fail("Unsupported decision in authoritative example.");
                    break;
            }

            if (expectedReceipt.GetProperty("profile").GetString() == "foundryProject")
            {
                Assert.That(result.Receipt, Is.TypeOf<AgentFoundryProjectReceipt>());
                Assert.That(((AgentFoundryProjectReceipt)result.Receipt).TargetIncarnation, Is.EqualTo(expectedReceipt.GetProperty("targetIncarnation").GetString()));
            }
            else
            {
                Assert.That(result.Receipt, Is.TypeOf<AgentNamedPolicyReceipt>());
            }

            if (expectedReceipt.TryGetProperty("harmResults", out JsonElement harms))
            {
                foreach (JsonProperty harm in harms.EnumerateObject())
                {
                    Assert.That(result.Receipt.HarmResults[harm.Name].Blocked, Is.EqualTo(harm.Value.GetProperty("blocked").GetBoolean()));
                    Assert.That(result.Receipt.HarmResults[harm.Name].Detected, Is.EqualTo(harm.Value.GetProperty("detected").GetBoolean()));
                }
            }

            AssertModerationContextPreservesNativeJson(expectedBody);
        }

        private static void AssertModerationContextPreservesNativeJson(JsonElement expected)
        {
            AgentContext model = ModelReaderWriter.Read<AgentContext>(BinaryData.FromString(expected.GetRawText()));
            using RequestContent content = model;
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            using JsonDocument serialized = JsonDocument.Parse(stream.ToArray());
            JsonElement actual = serialized.RootElement;
            JsonNode expectedJson = JsonNode.Parse(expected.GetRawText());
            JsonNode actualJson = JsonNode.Parse(actual.GetRawText());
            actualJson["timestamp"] = expectedJson["timestamp"].DeepClone();
            if (expectedJson["session"]?["started_at"] != null)
            {
                actualJson["session"]["started_at"] = expectedJson["session"]["started_at"].DeepClone();
            }
            Assert.Multiple(() =>
            {
                Assert.That(actual.GetProperty("interception_point").GetString(), Is.EqualTo(expected.GetProperty("interception_point").GetString()));
                Assert.That(actual.GetProperty("timestamp").GetDateTimeOffset(), Is.EqualTo(expected.GetProperty("timestamp").GetDateTimeOffset()));
                Assert.That(actual.GetProperty("sequence").GetInt64(), Is.EqualTo(expected.GetProperty("sequence").GetInt64()));
                Assert.That(JsonNode.DeepEquals(
                    JsonNode.Parse(actual.GetProperty("target").GetRawText()),
                    JsonNode.Parse(expected.GetProperty("target").GetRawText())), Is.True);
                Assert.That(JsonNode.DeepEquals(actualJson, expectedJson), Is.True, "Every point payload and extension must survive a typed model round trip.");
            });
        }

        [TestCase(false)]
        [TestCase(true)]
        public void UnifiedModeratePreservesOpaqueSelectedPolicyRevision(bool isAsync)
        {
            using JsonDocument example = LoadModerationExample("UnifiedModerate.json");
            JsonNode parameters = JsonNode.Parse(example.RootElement.GetProperty("parameters").GetRawText());
            parameters["selectedPolicyRevision"] = "\"opaque/etag+with?reserved&characters=%#\"";
            using JsonDocument admitted = JsonDocument.Parse(parameters.ToJsonString());
            JsonElement selectors = admitted.RootElement;
            const string error = """{"error":{"code":"SelectedPolicyRevisionMismatch","message":"The exact revision is no longer available."}}""";
            var transport = new MockTransport(JsonResponse(409, error));
            var client = new ContentSafetyClient(Endpoint, Credential, CreateOptions(transport, ContentSafetyClientOptions.ServiceVersion.V2026_10_15_Preview));
            using RequestContent content = RequestContent.Create(BinaryData.FromString(selectors.GetProperty("body").GetRawText()));
            if (isAsync)
            {
                Assert.ThrowsAsync<RequestFailedException>(async () => await client.UnifiedModerateAsync(
                    content, GetSelector(selectors, "targetResourceId"), GetSelector(selectors, "policyId"),
                    GetSelector(selectors, "selectedPolicyId"), GetSelector(selectors, "selectedPolicyRevision"),
                    GetSelector(selectors, "selectedPolicySemanticDigest")));
            }
            else
            {
                Assert.Throws<RequestFailedException>(() => client.UnifiedModerate(
                    content, GetSelector(selectors, "targetResourceId"), GetSelector(selectors, "policyId"),
                    GetSelector(selectors, "selectedPolicyId"), GetSelector(selectors, "selectedPolicyRevision"),
                    GetSelector(selectors, "selectedPolicySemanticDigest")));
            }
            AssertModerationSelectors(transport.SingleRequest, selectors);
        }

        public static IEnumerable<TestCaseData> ModerationErrors()
        {
            using JsonDocument example = LoadModerationExample("UnifiedModerate.json");
            foreach (JsonProperty response in example.RootElement.GetProperty("responses").EnumerateObject())
            {
                if (response.Name != "200")
                {
                    yield return new TestCaseData(int.Parse(response.Name, System.Globalization.CultureInfo.InvariantCulture), false);
                    yield return new TestCaseData(int.Parse(response.Name, System.Globalization.CultureInfo.InvariantCulture), true);
                }
            }
        }

        [TestCaseSource(nameof(ModerationErrors))]
        public void UnifiedModeratePreservesErrorDiagnostics(int status, bool isAsync)
        {
            using JsonDocument example = LoadModerationExample("UnifiedModerate.json");
            JsonElement parameters = example.RootElement.GetProperty("parameters");
            JsonElement error = example.RootElement.GetProperty("responses").GetProperty(status.ToString(System.Globalization.CultureInfo.InvariantCulture)).GetProperty("body");
            var transport = new MockTransport(JsonResponse(status, error.GetRawText()));
            ContentSafetyClientOptions options = CreateOptions(transport, ContentSafetyClientOptions.ServiceVersion.V2026_10_15_Preview);
            options.Retry.MaxRetries = 0;
            var client = new ContentSafetyClient(Endpoint, Credential, options);
            using RequestContent content = RequestContent.Create(BinaryData.FromString(parameters.GetProperty("body").GetRawText()));
            RequestFailedException exception = isAsync
                ? Assert.ThrowsAsync<RequestFailedException>(async () => await client.UnifiedModerateAsync(
                    content, GetSelector(parameters, "targetResourceId"), GetSelector(parameters, "policyId"),
                    GetSelector(parameters, "selectedPolicyId"), GetSelector(parameters, "selectedPolicyRevision"),
                    GetSelector(parameters, "selectedPolicySemanticDigest")))
                : Assert.Throws<RequestFailedException>(() => client.UnifiedModerate(
                    content, GetSelector(parameters, "targetResourceId"), GetSelector(parameters, "policyId"),
                    GetSelector(parameters, "selectedPolicyId"), GetSelector(parameters, "selectedPolicyRevision"),
                    GetSelector(parameters, "selectedPolicySemanticDigest")));

            Assert.Multiple(() =>
            {
                Assert.That(exception.Status, Is.EqualTo(status));
                Assert.That(exception.ErrorCode, Is.EqualTo(error.GetProperty("error").GetProperty("code").GetString()));
                Assert.That(exception.Message, Does.Contain(error.GetProperty("error").GetProperty("message").GetString()));
                Assert.That(exception.GetRawResponse().Content.ToString(), Is.EqualTo(error.GetRawText()));
                Assert.That(transport.Requests, Has.Count.EqualTo(1));
            });
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ContentProvenancePollsToCompletion(bool isAsync)
        {
            const string operationUrl = "https://example.cognitiveservices.azure.com/contentsafety/provenance/operations/operation-1?api-version=2026-09-01-preview";
            MockResponse initialResponse = JsonResponse(202, "{}")
                .AddHeader("Operation-Location", operationUrl)
                .AddHeader("Retry-After", "0");
            MockResponse completedResponse = JsonResponse(200, """
                {
                  "id": "operation-1",
                  "status": "Succeeded",
                  "kind": "Detect",
                  "result": {
                    "outcome": "ProvenanceDetected",
                    "results": [
                      {
                        "type": "C2PA",
                        "provider": "Microsoft",
                        "modelName": "model-1",
                        "timestamp": "2026-09-15T12:00:00Z"
                      }
                    ]
                  }
                }
                """);
            var transport = new MockTransport(initialResponse, completedResponse);
            var client = new ContentProvenanceClient(Endpoint, Credential, CreateOptions(transport));
            var options = new DetectProvenanceOptions(
                new ProvenanceContent(new Uri("https://example.blob.core.windows.net/media/image.png")));

            Operation<DetectProvenanceResult> operation = isAsync
                ? await client.DetectAsync(WaitUntil.Completed, options)
                : client.Detect(WaitUntil.Completed, options);

            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(operation.HasValue, Is.True);
                Assert.That(operation.Value.Outcome, Is.EqualTo(DetectOutcome.ProvenanceDetected));
                Assert.That(operation.Value.Results, Has.Count.EqualTo(1));
                Assert.That(operation.Value.Results[0].Type, Is.EqualTo(DetectedProvenanceType.C2PA));
                Assert.That(operation.Value.Results[0].Provider, Is.EqualTo("Microsoft"));
            });

            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            AssertRequest(transport.Requests[0], RequestMethod.Post, "/contentsafety/provenance:detect");
            AssertRequest(transport.Requests[1], RequestMethod.Get, "/contentsafety/provenance/operations/operation-1");
            Assert.That(
                RequestBody(transport.Requests[0]).GetProperty("content").GetProperty("uri").GetString(),
                Is.EqualTo("https://example.blob.core.windows.net/media/image.png"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ContentProvenanceGetsOperationStatus(bool isAsync)
        {
            var transport = new MockTransport(JsonResponse(200, """
                {
                  "id": "operation-1",
                  "status": "Succeeded",
                  "kind": "Detect",
                  "createdAt": "2026-09-15T11:59:00Z",
                  "lastUpdatedAt": "2026-09-15T12:00:00Z",
                  "result": {
                    "outcome": "NoProvenanceDetected",
                    "results": []
                  }
                }
                """));
            var client = new ContentProvenanceClient(Endpoint, Credential, CreateOptions(transport));

            Response<ProvenanceDetectOperation> response = isAsync
                ? await client.GetOperationStatusAsync("operation-1")
                : client.GetOperationStatus("operation-1");

            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Id, Is.EqualTo("operation-1"));
                Assert.That(response.Value.Status, Is.EqualTo(OperationState.Succeeded));
                Assert.That(response.Value.Kind, Is.EqualTo(ProvenanceOperationKind.Detect));
                Assert.That(response.Value.Result.Outcome, Is.EqualTo(DetectOutcome.NoProvenanceDetected));
                Assert.That(response.Value.CreatedOn, Is.EqualTo(DateTimeOffset.Parse("2026-09-15T11:59:00Z")));
            });
            AssertRequest(
                transport.SingleRequest,
                RequestMethod.Get,
                "/contentsafety/provenance/operations/operation-1");
        }

        private static ContentSafetyClientOptions CreateOptions(
            MockTransport transport,
            ContentSafetyClientOptions.ServiceVersion version = ContentSafetyClientOptions.ServiceVersion.V2026_09_01_Preview)
        {
            return new ContentSafetyClientOptions(version)
            {
                Transport = transport
            };
        }

        private static MockResponse JsonResponse(int status, string content)
        {
            return new MockResponse(status).WithJson(content);
        }

        private static void AssertRequest(MockRequest request, RequestMethod method, string path, string apiVersion = "2026-09-01-preview")
        {
            Uri uri = request.Uri.ToUri();
            Assert.Multiple(() =>
            {
                Assert.That(request.Method, Is.EqualTo(method));
                Assert.That(uri.AbsolutePath, Is.EqualTo(path));
                Assert.That(uri.Query, Does.Contain("api-version=" + apiVersion));
            });
        }

        private static JsonDocument LoadModerationExample(string fileName)
        {
            // Copied unchanged from the specification commit pinned in tsp-location.yaml.
            return JsonDocument.Parse(File.ReadAllText(Path.Combine(
                TestContext.CurrentContext.TestDirectory, "AgentHooksExamples", fileName)));
        }

        private static string GetSelector(JsonElement parameters, string name)
        {
            return parameters.TryGetProperty(name, out JsonElement value) ? value.GetString() : null;
        }

        private static void AssertModerationSelectors(MockRequest request, JsonElement parameters)
        {
            string query = request.Uri.ToUri().Query;
            foreach (string name in new[] { "targetResourceId", "policyId", "selectedPolicyId", "selectedPolicyRevision", "selectedPolicySemanticDigest" })
            {
                string expected = GetSelector(parameters, name);
                string[] actual = query.TrimStart('?').Split('&')
                    .Select(pair => pair.Split(new[] { '=' }, 2))
                    .Where(pair => Uri.UnescapeDataString(pair[0]) == name)
                    .Select(pair => pair.Length == 2 ? Uri.UnescapeDataString(pair[1]) : string.Empty)
                    .ToArray();
                Assert.That(actual, Is.EqualTo(expected == null ? Array.Empty<string>() : new[] { expected }), name);
            }
        }

        private static JsonElement RequestBody(MockRequest request)
        {
            using var stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);
            using JsonDocument document = JsonDocument.Parse(Encoding.UTF8.GetString(stream.ToArray()));
            return document.RootElement.Clone();
        }
    }
}

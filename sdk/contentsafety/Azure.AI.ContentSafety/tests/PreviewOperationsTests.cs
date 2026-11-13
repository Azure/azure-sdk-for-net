// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
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
            var transport = new MockTransport(JsonResponse(200, """
                {
                  "verdict": "blocked",
                  "reason": "policy_violation",
                  "acsVerdict": {
                    "decision": "deny",
                    "warnings": ["Review the submitted content."],
                    "harmResults": {
                      "Violence": {
                        "blocked": true,
                        "detected": true,
                        "severity": "high"
                      }
                    }
                  }
                }
                """));
            var client = new ContentSafetyClient(Endpoint, Credential, CreateOptions(transport));
            var options = new UnifiedModerateConfig(UnifiedModerateSource.PostToolCall, "{\"temperature\":72}")
            {
                PolicyId = "policy-1",
                ToolName = "get_weather",
                ToolCallId = "call-1",
                ToolArguments = "{\"city\":\"Seattle\"}",
                ToolResultIsError = false,
                ToolDurationMs = 25
            };

            Response<UnifiedModerateResult> response = isAsync
                ? await client.UnifiedModerateAsync(options)
                : client.UnifiedModerate(options);

            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Verdict, Is.EqualTo(UnifiedModerateVerdict.Blocked));
                Assert.That(response.Value.Reason, Is.EqualTo("policy_violation"));
                Assert.That(response.Value.AcsVerdict.Decision, Is.EqualTo(AcsDecision.Deny));
                Assert.That(response.Value.AcsVerdict.HarmResults["Violence"].Severity, Is.EqualTo("high"));
            });

            MockRequest request = transport.SingleRequest;
            AssertRequest(request, RequestMethod.Post, "/contentsafety/content:unifiedModerate");
            JsonElement body = RequestBody(request);
            Assert.Multiple(() =>
            {
                Assert.That(body.GetProperty("policyId").GetString(), Is.EqualTo("policy-1"));
                Assert.That(body.GetProperty("source").GetString(), Is.EqualTo("post_tool_call"));
                Assert.That(body.GetProperty("toolResultIsError").GetBoolean(), Is.False);
                Assert.That(body.GetProperty("toolDurationMs").GetDouble(), Is.EqualTo(25));
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

        private static ContentSafetyClientOptions CreateOptions(MockTransport transport)
        {
            return new ContentSafetyClientOptions(ContentSafetyClientOptions.ServiceVersion.V2026_09_01_Preview)
            {
                Transport = transport
            };
        }

        private static MockResponse JsonResponse(int status, string content)
        {
            return new MockResponse(status).WithJson(content);
        }

        private static void AssertRequest(MockRequest request, RequestMethod method, string path)
        {
            Uri uri = request.Uri.ToUri();
            Assert.Multiple(() =>
            {
                Assert.That(request.Method, Is.EqualTo(method));
                Assert.That(uri.AbsolutePath, Is.EqualTo(path));
                Assert.That(uri.Query, Does.Contain("api-version=2026-09-01-preview"));
            });
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

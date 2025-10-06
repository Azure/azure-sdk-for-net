// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Microsoft.Extensions.AI;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests
{
    public class PersistentAgentsChatClientUserAgentHeaderTests
    {
        private const string AgentEndpoint = "https://fake-host";
        private const string AgentId = "agent-id";
        private const string RunId = "run-id";
        private const string ThreadId = "thread-id";

        [Test]
        public async Task TestUserAgentHeaderAddedToAllRequestToCreateRunRegardlessIfThreadExists([Values(null, ThreadId)] string threadId)
        {
            List<string> requestPaths = [];

            var mockTransport = new MockTransport((request) =>
            {
                AssertContainsMEAIHeader(request.Headers);
                requestPaths.Add($"{request.Method}:{request.Uri.Path}");
                return GetResponse(request);
            });

            PersistentAgentsChatClient chatClient = GetChatClient(mockTransport, threadId);

            await chatClient.GetResponseAsync(new ChatMessage(ChatRole.User, "Hello"));

            Assert.AreEqual(3, requestPaths.Count);
            Assert.AreEqual("GET:/assistants/agent-id", requestPaths[0]);       // client.Administration.GetAgentAsync(...)
            if (threadId is null)
            {
                Assert.AreEqual("POST:/threads", requestPaths[1]);              // client.Threads.CreateThreadAsync(...)
            }
            else
            {
                Assert.AreEqual("GET:/threads/thread-id/runs", requestPaths[1]);// client.Runs.GetRunsAsync(...)
            }
            Assert.AreEqual("POST:/threads/thread-id/runs", requestPaths[2]);   // client.Runs.CreateRunStreamingAsync(...)
        }

        [Test]
        public async Task TestUserAgentHeaderAddedToAllRequestToCreateRunWhenActiveRunExists()
        {
            var emptyRunList = false; // Simulate an active run exists

            List<string> requestPaths = [];

            var mockTransport = new MockTransport((request) =>
            {
                AssertContainsMEAIHeader(request.Headers);
                requestPaths.Add($"{request.Method}:{request.Uri.Path}");
                return GetResponse(request, emptyRunList);
            });

            PersistentAgentsChatClient chatClient = GetChatClient(mockTransport);

            await chatClient.GetResponseAsync(new ChatMessage(ChatRole.User, "Hello"));

            Assert.AreEqual(4, requestPaths.Count);
            Assert.AreEqual("GET:/assistants/agent-id", requestPaths[0]);                  // client.Administration.GetAgentAsync(...)
            Assert.AreEqual("GET:/threads/thread-id/runs", requestPaths[1]);               // client.Runs.GetRunsAsync(...)
            Assert.AreEqual("POST:/threads/thread-id/runs/run-id/cancel", requestPaths[2]);// client.Runs.CancelRunAsync(...)
            Assert.AreEqual("POST:/threads/thread-id/runs", requestPaths[3]);              // client.Runs.CreateRunStreamingAsync(...)
        }

        [Test]
        public async Task TestUserAgentHeaderAddedToAllRequestToSubmitToolOutput()
        {
            var emptyRunList = false; // Simulate an active run exists
            var chatMessages = new ChatMessage(ChatRole.Tool, [new FunctionResultContent($"""["{RunId}","call_id"]""", "call_result")]); // Provide tool output to submit to active run

            List<string> requestPaths = [];

            var mockTransport = new MockTransport((request) =>
            {
                AssertContainsMEAIHeader(request.Headers);
                requestPaths.Add($"{request.Method}:{request.Uri.Path}");
                return GetResponse(request, emptyRunList);
            });

            PersistentAgentsChatClient chatClient = GetChatClient(mockTransport);

            await chatClient.GetResponseAsync([chatMessages]);

            Assert.AreEqual(3, requestPaths.Count);
            Assert.AreEqual("GET:/assistants/agent-id", requestPaths[0]);                       // client.Administration.GetAgentAsync(...)
            Assert.AreEqual("GET:/threads/thread-id/runs", requestPaths[1]);                    // client.Runs.GetRunsAsync(...)
            Assert.AreEqual("POST:/threads//runs/run-id/submit_tool_outputs", requestPaths[2]); // client.Runs.GetRunsAsync(...)
        }

        #region Helpers
        private PersistentAgentsChatClient GetChatClient(HttpPipelineTransport transport, string threadId = ThreadId)
        {
            PersistentAgentsClient agentsClient = new(AgentEndpoint, new MockCredential(), options: new PersistentAgentsAdministrationClientOptions()
            {
                Transport = transport
            });

            return new PersistentAgentsChatClient(agentsClient, AgentId, threadId);
        }

        private static void AssertContainsMEAIHeader(RequestHeaders headers)
        {
            Assert.IsTrue(headers.TryGetValue("User-Agent", out string userAgent));

            string[] parts = userAgent.Split(["MEAI"], StringSplitOptions.None);

            Assert.AreEqual(2, parts.Length, "Expected 'MEAI/' to appear exactly once in the User-Agent header but it appears multiple times.");

            Assert.IsTrue(Regex.IsMatch(userAgent, @"MEAI/(\d+\.\d+\.\d+.*)"), "Expected 'MEAI/' to be followed by a version number in the User-Agent header.");
        }

        private static MockResponse GetResponse(MockRequest request, bool? emptyRunList = true)
        {
            // Sent by client.Administration.GetAgentAsync(...) method
            if (request.Method == RequestMethod.Get && request.Uri.Path == $"/assistants/{AgentId}")
            {
                return CreateOKMockResponse($$"""
                {
                    "id": "{{AgentId}}"
                }
                """);
            }
            // Sent by by client.Runs.GetRunsAsync(...) method
            else if (request.Method == RequestMethod.Get && request.Uri.Path == $"/threads/{ThreadId}/runs")
            {
                return CreateOKMockResponse($$"""
                {
                    "data": {{(emptyRunList is true
                        ? "[]"
                        : $$"""[{"id": "{{RunId}}"}]""")}}
                }
                """);
            }
            // Sent by client.Runs.CreateRunStreamingAsync(...) method
            else if (request.Method == RequestMethod.Post && request.Uri.Path == $"/threads/{ThreadId}/runs")
            {
                return CreateOKMockResponse("{}");
            }
            // Sent by client.Threads.CreateThreadAsync(...) method
            else if (request.Method == RequestMethod.Post && request.Uri.Path == $"/threads")
            {
                return CreateOKMockResponse($$"""
                {
                    "id": "{{ThreadId}}"
                }
                """);
            }
            // Sent by client.Runs.CancelRunAsync(...) method
            else if (request.Method == RequestMethod.Post && request.Uri.Path == $"/threads/{ThreadId}/runs/{RunId}/cancel")
            {
                return new MockResponse(200);
            }
            // Sent by client.Runs.SubmitToolOutputsToStreamAsync(...) method
            else if (request.Method == RequestMethod.Post && request.Uri.Path == $"/threads//runs/{RunId}/submit_tool_outputs")
            {
                return CreateOKMockResponse($$"""
                    {
                        "data":[{
                            "id": "{{RunId}}"
                        }]
                    }
                    """);
            }

            throw new InvalidOperationException("Unexpected request");
        }

        private static MockResponse CreateOKMockResponse(string content)
        {
            var response = new MockResponse(200);
            response.SetContent(content);
            return response;
        }
        #endregion
    }
}
